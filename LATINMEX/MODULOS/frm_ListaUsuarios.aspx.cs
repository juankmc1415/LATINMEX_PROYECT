using LATINMEX.Datos.CORE;
using LATINMEX.MODELVIEW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace LATINMEX.MODULOS
{
    public partial class frm_ListaUsuarios : System.Web.UI.Page
    {
        CLS_PERMISOS cls_permisos = new CLS_PERMISOS();
        CLS_USUARIOS cls_usuarios = new CLS_USUARIOS();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarListaUsuarios();
            }
        }

        private void CargarListaUsuarios(int pageNumber = 1)
        {
            List<UsuariosView> listaUsuarios = cls_usuarios.SP_62_CONSULTAR_USUARIOS();
            if (!EsRolSuper() )// Quito los roles super
            {
                listaUsuarios = listaUsuarios.Where(x =>x.Roles==null?true: !x.Roles.Contains(ROLES.Super.ToString().ToUpper())).ToList();
            }

            if (Request.QueryString["page"] != null)
            {
                pageNumber = Convert.ToInt32(Request.QueryString["page"]);
            }

            int pageSize = 10;
            if (listaUsuarios.Count() > 0)
            {
                var listPaging = listaUsuarios.Skip((pageNumber - 1) * pageSize).Take(pageSize);
                var countPages = (listaUsuarios.Count() / pageSize) + 1;

                CargarPaginacion(countPages, pageNumber);

                Rp_ColumnaUsuario.DataSource = listPaging;
                Rp_ColumnaUsuario.DataBind();
            }
        }

        private void CargarPaginacion(int countPages, int pageNumber)
        {
            List<object> listPaging = new List<object>();

            for (int i = 0; i < countPages; i++)
            {
                var datos = new { Id = i + 1, CssClass = "page-item" }; listPaging.Add(datos);

            }
            Rp_Pajinacion.DataSource = listPaging;
            Rp_Pajinacion.DataBind();

        }

        protected void Rp_ColumnaUsuario_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName=="Estado")
            {
                int permiso = ValidarPermiso(PERMISOS_USUARIOS.ActualizarUsuario);
                if (permiso < 0)
                {
                    Message_warning.Visible = true;
                    Message_warning.Text = "No tiene permiso para realizar este proceso";
                    return;
                }


                string[] data = e.CommandArgument.ToString().Split(',');

                int idestado = 0;
                if (Convert.ToInt32(data[0]) == 1)
                {
                    idestado = 2;
                }
                else
                {
                    idestado = 1;
                }

                int res = cls_usuarios.SP_73_CAMBIAR_ESTADO_USUARIO(Convert.ToInt32(data[1]), idestado);

                if (res > 0)
                {
                    Message_Succes.Visible = true;
                    Message_Succes.Text = $"Usuario actualizado correctamente";

                    CargarListaUsuarios();
                }
                else
                {
                    Message_danger.Visible = true;
                    Message_danger.Text = "No se pudo actualizar el usuario";
                }
            }

            if (e.CommandName == "Contrasena")
            {

                int permiso = ValidarPermiso(PERMISOS_USUARIOS.ActualizarUsuario);
                if (permiso < 0)
                {
                    Message_warning.Visible = true;
                    Message_warning.Text = "No tiene permiso para realizar este proceso";
                    return;
                }

                string[] data = e.CommandArgument.ToString().Split(',');
                CLS_NOTIFY.Email_RecuperarContraseña(data[0], CLS_CORE.Decrypt(data[1]), data[2]);
            }
        }

        public bool EsRolSuper()
        {
           return Session["roles"]==null?false: Session["roles"].ToString().Contains(ROLES.Super.ToString().ToUpper()); 
        }
        
        public int ValidarPermiso(PERMISOS_USUARIOS idPermiso)
        {
            int idUsuario = Convert.ToInt32(Session["userID"]);
            //permiso de creacion de usuario
            int permiso = cls_permisos.FS_06_CHECK_PERMISO_USUARIO((int)(idPermiso), idUsuario);
            return permiso;
        }

    }
}