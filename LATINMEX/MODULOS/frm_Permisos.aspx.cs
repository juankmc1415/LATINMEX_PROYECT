using LATINMEX.Datos.CORE;
using LATINMEX.MODELVIEW;
using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LATINMEX.MODULOS
{
    public partial class frm_Permisos : System.Web.UI.Page, ICallbackEventHandler
    {
        CLS_PERMISOS cls_permisos = new CLS_PERMISOS();
        CLS_MENUS cls_menus = new CLS_MENUS();
        string respuesta = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Message_warning.Visible = false;
            Message_danger.Visible = false;
            Message_info.Visible = false;
            Message_Succes.Visible = false;

            ValidarRolSuper();

            if (!IsPostBack)
            {
                CargarControles(); 
            }

            // get reference of call back method named JSCallback 
            string cbref = Page.ClientScript.GetCallbackEventReference(this,
                            "arg", "JSCallback", "context");

            // Generate JS method trigger callback 
            string cbScr = string.Format("function UseCallBack(arg," +
                                         " context) {{ {0}; }} ", cbref);
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(),
                              "UseCallBack", cbScr, true);

        }

       public void RaiseCallbackEvent(string eventArgument)
        {
            if (!string.IsNullOrEmpty(eventArgument))
            {
                string[] arrayActulizarIdPermiso = eventArgument.Split(',');
                int idPermiso = Convert.ToInt32(arrayActulizarIdPermiso[1]);
                bool seAsignara = Convert.ToBoolean(arrayActulizarIdPermiso[0]);
                int idrol = Convert.ToInt32(lst_Roles.SelectedValue);
                int res = -1;
                if (seAsignara)
                {
                    res = cls_permisos.SP_57_ASIGNAR_ROLES_PERMISOS(idPermiso, idrol);
                }
                else
                {
                    res = cls_permisos.SP_59_DESASIGNAR_ROLES_PERMISOS(idPermiso, idrol);
                }

                if (res > 0)
                {
                    respuesta = "Correcto";
                }

            }
        }

        public string GetCallbackResult()
        {
            return respuesta;
        }

        protected void btn_AceptarPermisosDMV_Click(object sender, EventArgs e)
        {
        }


        protected void btn_registra_Click(object sender, EventArgs e)
        {
            var result = ValidarPermiso();
            if (!result.IsSuccess)
            {
                return;
            }

            int idTipoPermiso = Convert.ToInt32(lst_tiposPermisos.SelectedValue);
            int res= cls_permisos.SP_55_INSERTAR_PERMISOS(txt_nombre.Text, txt_descripcion.Text, idTipoPermiso);

            if (res > 0)
            {
                TraerOrdenPemiso();
                ConsultarPermisos();
                Message_Succes.Text = "Permiso agregado corectamente";
                Message_Succes.Visible = true;
                //Refrescar el grid y drowdoun
            }
            else
            {
                Message_danger.Text = "Error al crear el permiso";
                Message_danger.Visible = true;
              
            }
        }

        protected void lst_Roles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConsultarPermisos();
        }

        protected void btn_tipoPermiso_Click(object sender, EventArgs e)
        {
            txt_nombreTipo.Text = "";
            mpe_TipoPemisoDMV.Show();
        }

        public Result ValidarPermiso()
        {
            Result res = new Result();
            res.IsSuccess = true;
            if (string.IsNullOrEmpty(txt_nombre.Text))
            {
                res.IsSuccess = false;
            }

            if (string.IsNullOrEmpty(txt_descripcion.Text))
            {
                res.IsSuccess = false;
            }

            if (lst_tiposPermisos.SelectedValue=="0")
            {
                res.IsSuccess = false;
            }

            return res;
        }

        public Result ValidarPermisoMoldal()
        {
            Result res = new Result();
            res.IsSuccess = true;
            if (string.IsNullOrEmpty(txt_nombreModa.Text))
            {
                res.IsSuccess = false;
            }

            if (string.IsNullOrEmpty(txt_descripcionModa.Text))
            {
                res.IsSuccess = false;
            }

            if (Lst_tiposPermisoModal.SelectedValue == "0")
            {
                res.IsSuccess = false;
            }

            return res;
        }

        public Result ValidarTipoPermiso()
        {
            Result res = new Result();
            res.IsSuccess = true;
            if (string.IsNullOrEmpty(txt_nombreTipo.Text))
            {
                res.IsSuccess = false;
            }
            return res;
        }

        public void ListaRoles()
        {
            DataTable data = cls_menus.SP_47_LISTA_ROLES();
            if (data != null && data.Rows.Count > 0)
            {
                lst_Roles.DataSource = data;
                lst_Roles.DataBind();
            }
        }

        public void CargarControles() {
            TraerOrdenPemiso();
            ConsultarTiposPermisos();
            ListaRoles();
            ConsultarPermisos();
            
        }

        public void TraerOrdenPemiso()
        {
            int orden = cls_permisos.FS_05_GET_ORDER_PERMISO();

            if (orden > 0)
            {
                lb_orden.Text = orden.ToString();
            }
        }

        public void ValidarRolSuper()
        {
            if (Session["roles"] == null ? false : Session["roles"].ToString().Contains(ROLES.Super.ToString().ToUpper()) == false)
            {
                Response.Redirect("Default.aspx");
            }
        }

        public void LlenarDatosPermiso(int IdPermiso)
        {
            DataTable data = cls_permisos.SP_62_GET_PERMISO(IdPermiso);

            if (data != null && data.Rows.Count > 0)
            {
                var datos = data.Rows[0];
                lb_ordenModa.Text = datos.Field<int>("ORDEN").ToString();
                txt_nombreModa.Text = datos.Field<string>("PERMISO");
                txt_descripcionModa.Text = datos.Field<string>("DESCRIPCION");
                Lst_tiposPermisoModal.SelectedValue = datos.Field<int>("ID_TIPO_PERMISO").ToString();
                lb_permisoMd.Text = datos.Field<int>("ID_PERMISO").ToString();
            }

        }

        public void ConsultarTiposPermisos()
        {
            DataTable dataTipo = cls_permisos.SP_51_CONSULTAR_TIPOS_PERMISOS();

            if (dataTipo != null && dataTipo.Rows.Count > 0)
            {

                var lista = dataTipo.AsEnumerable().Select(x => new TipoPermisoView
                {
                    Tipo = x.Field<string>("TIPO"),
                    IdTipoPermiso = x.Field<int>("ID_TIPO_PERMISO"),
                }).ToList();

                lista.Add(new TipoPermisoView { IdTipoPermiso = 0, Tipo = "Seleccione" });

                Rp_ColumnasTipoPermisos.DataSource = dataTipo;
                Rp_ColumnasTipoPermisos.DataBind();

                lst_tiposPermisos.DataSource = lista;
                lst_tiposPermisos.DataBind();


                Lst_tiposPermisoModal.DataSource = lista;
                Lst_tiposPermisoModal.DataBind();

                lst_tiposPermisos.SelectedValue = "0";

            }
        }

        public void ConsultarPermisos()
        {
            int idrol = Convert.ToInt32(lst_Roles.SelectedValue);
            DataTable dataPermiso = cls_permisos.SP_61_CONSULTAR_PERMISOS(idrol);

            if (dataPermiso != null && dataPermiso.Rows.Count > 0)
            {
                var listaPermisos = dataPermiso.AsEnumerable().Select(x => new PermisosView
                {
                    Permiso = x.Field<string>("PERMISO"),
                    Descripcion = x.Field<string>("DESCRIPCION"),
                    IdPermiso = x.Field<int?>("ID_PERMISO"),
                    Orden = x.Field<int?>("ORDEN"),
                    Tipo = x.Field<string>("TIPO"),
                    IdRol = x.Field<int?>("ID_ROL")
                }).ToList();

                //Relaciono las tablas
                var listaAgrupada = listaPermisos.GroupBy(b=>b.Tipo).Select(x => new
                {
                    Tipo  = x.Key,
                    data = listaPermisos.Where(p => p.IdPermiso.HasValue && p.Tipo == x.Key).ToList(),
                    Count = listaPermisos.Where(p => p.IdPermiso.HasValue && p.Tipo == x.Key).Count()
                }).ToList();

                Rp_ColumnaPermiso.DataSource = listaAgrupada;
                Rp_ColumnaPermiso.DataBind();
            }

        }

        protected void Rp_ColumnasTipoPermisos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void btn_agregarTipoPermiso_Click(object sender, EventArgs e)
        {
            var result = ValidarTipoPermiso();
            if (!result.IsSuccess)
            {
                return;
            }

            string tipo = txt_nombreTipo.Text.ToUpper();
            int res = cls_permisos.SP_52_INSERTAR_TIPOS_PERMISOS(tipo);
            if (res > 0)
            {
                //Refrescar el grid y drowdoun
                ConsultarTiposPermisos();
            }
            else
            {
                Message_warning.Text = "Error al crear el tipo puede que este se encuentre repetido";
                Message_warning.Visible = true;
                mpe_TipoPemisoDMV.Hide();
            }

        }

        protected void btn_eliminarTipoPermiso_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;

            int id = btn.TabIndex;
            int res = cls_permisos.SP_54_ELIMINAR_TIPO_PERMISO(id);
            if (res > 0)
            {
                //Refrescar el grid y drowdoun
                ConsultarTiposPermisos();
            }
            else
            {
                Message_warning.Text = "Error al eliminar el tipo, puede que ya este relacionado a un permiso";
                Message_warning.Visible = true;
                mpe_TipoPemisoDMV.Hide();
            }

        }

        protected void Rp_ColumnaPermiso_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
        protected void gvRp_permiso_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                LlenarDatosPermiso(id);
                mpe_PermisosDMV.Show();
            }
        }

        protected void btn_eliminarPermiso_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;

            int id = btn.TabIndex;
            int res = cls_permisos.SP_60_ELIMINAR_PERMISOS(id);
            if (res > 0)
            {
                //Refrescar el grid y drowdoun
                ConsultarPermisos();
                Message_Succes.Text = $"Permiso eliminado correctacmente";
                Message_Succes.Visible = true;
            }
            else
            {
                Message_warning.Text = "Error al eliminar el permiso";
                Message_warning.Visible = true;
                mpe_TipoPemisoDMV.Hide();
            }

        }

        protected void btn_GuardarPermisoM_Click(object sender, EventArgs e)
        {
            int id =Convert.ToInt32(lb_permisoMd.Text);

            var result = ValidarPermisoMoldal();
            if (!result.IsSuccess)
            {
                return;
            }

            int idTipoPermiso = Convert.ToInt32(Lst_tiposPermisoModal.SelectedValue);
            int res = cls_permisos.SP_56_ACTUALIZAR_PERMISOS(id, txt_nombreModa.Text, txt_descripcionModa.Text, idTipoPermiso);

            if (res > 0)
            {
                TraerOrdenPemiso();
                ConsultarPermisos();
                Message_Succes.Text = "Permiso actualizado corectamente";
                Message_Succes.Visible = true;
                //Refrescar el grid y drowdoun
            }
            else
            {
                Message_danger.Text = "Error al actualizar el permisos";
                Message_danger.Visible = true;

            }
        }

        public bool EsRolSuper()
        {
            return Session["roles"] == null ? false : Session["roles"].ToString().Contains(ROLES.Super.ToString().ToUpper());
        }

    }
}