using LATINMEX.Datos.CORE;
using LATINMEX.MODELVIEW;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LATINMEX.MODULOS
{
    public partial class frm_usuarios : System.Web.UI.Page
    {
        CLS_USUARIOS cls_usuarios = new CLS_USUARIOS();
        CLS_MENUS cls_menus = new CLS_MENUS();
        CLS_PERMISOS cls_permisos= new CLS_PERMISOS();
        CLS_CORE cls_core = new CLS_CORE();
        int idUsuario=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!EsNuevo()) idUsuario = Convert.ToInt32(Request.QueryString["idusuario"]);
            if (!IsPostBack)
            {
                CargarControles();
                ListaRoles();
                ListaAuditorias();
            }
        }
        private void CargarControles()
        {
            if (EsNuevo())
            { 
                btn_registrar.Text = "Registrar";
                btn_crearNuevo.Visible = false;
                ck_forzarCambio.Visible = false;
            }
            else
            {
                UsuariosView usuario = cls_usuarios.SP_69_GET_USUARIO(idUsuario);

                lb_nombre.Text = usuario.Nombres;
                txt_nombres.Text = usuario.Nombres;
                txt_apellidos.Text = usuario.Apellidos;
                txt_email.Text = usuario.Email;
                lst_estados.SelectedValue = usuario.IdEstado.ToString();
                lb_fechaCreacion.Text = usuario.FechaHoraCreacion.ToLongDateString();
                lb_fechaActulizacion.Text = usuario.FechaHoraActualizacion.ToLongDateString();

                if (usuario.Foto!=null)
                {
                    img_usuarios.Src = usuario.FotoBase64;
                }

                btn_registrar.Text = "Guardar Cambios";
                btn_crearNuevo.Visible = true;
                ck_forzarCambio.Visible = true;
                ck_forzarCambio.Checked = usuario.ForzarContraseña;
            }
        }
      
        private Result ValidarUsuario()
        {
            var res = new Result();
            res.IsSuccess = true;

            if (string.IsNullOrEmpty(txt_nombres.Text))
            {
                res.IsSuccess = false;
            }

            if (string.IsNullOrEmpty(txt_apellidos.Text))
            {
                res.IsSuccess = false;
            }

            if (string.IsNullOrEmpty(txt_email.Text))
            {
                res.IsSuccess = false;
            }

            if (!string.IsNullOrEmpty(txt_apellidos.Text) && !email_bien_escrito(txt_email.Text))
            {
                res.IsSuccess = false;
            }

            if (lst_estados.SelectedValue == "0")
            {
                res.IsSuccess = false;
            }
            return res;
        }
       
        private void ListaRoles()
        {
           
            var data = cls_usuarios.SP_66_CONSULTAR_ROLES_USUARIOS(idUsuario);
            if (data != null && data.Rows.Count > 0)
            {
                //List<RolesView> lista = data.AsEnumerable().Select(x => new RolesView
                //{
                //    IdRol = x.Field<int>("ID_ROL"),
                //    Rol = x.Field<string>("ROL"),
                //    IdUser= x.Field<int?>("ID_USUARIO"),

                //}).ToList();

                //if (!EsRolSuper())// Quito los roles super
                //{
                //    lista = lista.Where(x => !x.Rol.Contains(ROLES.Super.ToString().ToUpper())).ToList();
                //}

                gvRp_Roles.DataSource = data;
                gvRp_Roles.DataBind();
            }
        }

        private void ListaAuditorias()
        {
            var data = cls_usuarios.SP_71_CONSULTAR_AUDITORIA(idUsuario);
            if (data != null && data.Rows.Count > 0)
            {
                List<AuditoriasView> lista = data.AsEnumerable().Select(x => new AuditoriasView
                {
                    FechaHoraRegistro = x.Field<DateTime>("FECHA_HORA_REGISTRO"),
                    Descripcion = x.Field<string>("DESCRIPCION"),
                }).Take(30).ToList();

                Rp_AuditoriasUsuario.DataSource = lista;
                Rp_AuditoriasUsuario.DataBind();
                
            }
        }

        private bool EsNuevo()
        {
            if (Request.QueryString["idusuario"]==null)
                return true;
            else
                return false;
        }

        protected void btn_registrar_Click(object sender, EventArgs e)
        {
            Result res = ValidarUsuario();
            int idUser = Convert.ToInt32(Session["userID"]);
            if (!res.IsSuccess)
            {
                return;
            }

            if (EsNuevo())
            {
                CrearUsuario(idUser);
            }
            else
            {
                ActualizarUsuario(idUser);
            }
        }

        public void CrearUsuario(int idUsuariCreacion)
        {
            int permiso= ValidarPermiso(PERMISOS_USUARIOS.CrearUsuario);
            if (permiso < 0)
            {
                Message_warning.Visible = true;
                Message_warning.Text = "No tiene permiso para realizar este proceso";
                return;
            }

            string roles = "";
            foreach (GridViewRow row in gvRp_Roles.Rows)
            {
                CheckBox cks = (CheckBox)row.FindControl("ckh_rol");
                if (cks.Checked) roles += cks.TabIndex.ToString() + ",";
            }

            if (!string.IsNullOrEmpty(roles))
                roles = roles.Substring(0, roles.Length - 1);

            string clave = CLS_CORE.GenerarCodigo(7);
            string encritClave = CLS_CORE.Encrypt(clave);

            DataTable result = cls_usuarios.SP_63_CREAR_USUARIO(txt_email.Text, encritClave,
                                                         txt_nombres.Text, txt_apellidos.Text, txt_email.Text
                                                       , Convert.ToInt32(lst_estados.SelectedValue), idUsuariCreacion, roles);

            if (result != null && result.Rows.Count > 0)
            {
                int iduser = Convert.ToInt32(result.Rows[0].ItemArray[0]);
                //Notifico la creacion del usuario
                CLS_NOTIFY.Email_CreacionDeUsuario(txt_email.Text, clave, txt_email.Text);
                Response.Redirect($"frm_usuarios.aspx?idusuario={iduser}");
            }
            else
            {
                Message_danger.Visible = true;
                Message_danger.Text = "Error al registrar el usuario,Puede que este email ya se encuentre registrado";
            }
        }

        public int ValidarPermiso(PERMISOS_USUARIOS permisos)
        {
            int idUsuario = Convert.ToInt32(Session["userID"]);
            //permiso de creacion de usuario
            int permiso = cls_permisos.FS_06_CHECK_PERMISO_USUARIO((int)permisos, idUsuario);
            return permiso;
        }

        public void ActualizarUsuario(int idUsuarioAtualizacion)
        {
            int permiso= ValidarPermiso(PERMISOS_USUARIOS.ActualizarUsuario);
            if (permiso < 0)
            {
                Message_warning.Visible = true;
                Message_warning.Text = "No tiene permiso para realizar este proceso";
                return;
            }

            string roles = "";
            foreach (GridViewRow row in gvRp_Roles.Rows)
            {
                CheckBox cks = (CheckBox)row.FindControl("ckh_rol");
                if (cks.Checked) roles += cks.TabIndex.ToString() + ",";
            }

            if (!string.IsNullOrEmpty(roles))
                roles = roles.Substring(0, roles.Length - 1);


            int result = cls_usuarios.SP_64_ACTUALIZAR_USUARIO(idUsuario, 
                                                         txt_nombres.Text, txt_apellidos.Text, txt_email.Text
                                                         ,Convert.ToInt32(lst_estados.SelectedValue),idUsuarioAtualizacion,roles);

            if (result > 0)
            {
                Message_Succes.Visible = true;
                Message_Succes.Text = "Usuario actualizado correctamente";
            }
            else
            {
                Message_danger.Visible = true;
                Message_danger.Text = "Error al actualizar el usuario, puede que el email ya se encuentre registrado";
            }

        }

        private bool email_bien_escrito(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        protected void ck_forzarCambio_CheckedChanged(object sender, EventArgs e)
        {
            ValidarPermiso(PERMISOS_USUARIOS.ActualizarUsuario);
            var control = sender as CheckBox;
            if (!EsNuevo())
            {
                int res = cls_usuarios.SP_72_FORZAR_CAMBIO_CONTRASEÑA(idUsuario, ck_forzarCambio.Checked);
                if (res > 0)
                {
                    Message_Succes.Visible = true;
                    if (ck_forzarCambio.Checked)
                    {
                        Message_Succes.Text = $"El usuario se vera forzado a realizar cambio de contraseña, este fue notificado al correo {txt_email.Text}";
                        UsuariosView usuario = cls_usuarios.SP_69_GET_USUARIO(idUsuario);
                        //Notico al usuario
                        CLS_NOTIFY.Email_ForzarCambioContraseña(usuario.Email);
                    }

                    else
                        Message_Succes.Text = $"Usuario actualizado correctamente";
                }
                else
                {
                    Message_danger.Visible = true;
                    Message_danger.Text = "No se pudo realizar el cambio de contraseña";
                    ck_forzarCambio.Checked = !ck_forzarCambio.Checked;
                }

            }
           
        }

        public bool EsRolSuper()
        {
            return Session["roles"] == null ? false : Session["roles"].ToString().Contains(ROLES.Super.ToString().ToUpper());
        }
    }
}