using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using LATINMEX.Datos.CORE;
using LATINMEX.Datos.MASTER;
using LATINMEX.Datos.PRODUCTOS;
using LATINMEX.MODELVIEW;
using LATINMEX.MODULOS.VENTAS;

namespace LATINMEX
{
    public partial class SiteMaster : MasterPage
    {
        CLS_MENUS cls_menu = new CLS_MENUS();


        public ASPxComboBox cmbpro_cliente
        {
            get { return this.cmb_clientes; }
        }

        public LinkButton btn_buscar
        {
            get { return this.btn_serch; }
        }

        public List<MenuView> listaMenu { get; set; }

        public List<MenuView> ListaMenu
        {
            get
            {
                return listaMenu;
            }
            set
            {
                listaMenu = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Validar_Tiempo();
                Datos_Usuario();
                Lista_Empresa();
                DateTime FechaNacimiento = DateTime.Now;
                txt_FecPagoGasto.Text = FechaNacimiento.ToString("yyyy-MM-dd");
                txt_fechRegistroGasto.Text = FechaNacimiento.ToString("yyyy-MM-dd");
                CargarListaMenus();
            }

            bool forzar = Session["forzar_contraseña"] != null ? Convert.ToBoolean(Session["forzar_contraseña"]) : false;
            if (forzar)
            {
                Response.Redirect("frm_forzarContrasena");
            }
        }

        public void RefrescarListaDeMenu(bool recargar)
        {
            CargarListaMenus(recargar);
            UpdatePanel1.Update();
        }

        private void Datos_Usuario()
        {
            Datos.LOGIN.DBA_LOGIN dba = new Datos.LOGIN.DBA_LOGIN();
            DataSet dataUsuario = new DataSet();
            dataUsuario = dba.SP_04_GET_DATOS_USUARIO(Session["usuario"].ToString());

            if (dataUsuario != null && dataUsuario.Tables.Count > 0)
            {
                //Session["userID"] = dataUsuario.Tables[0].Rows[0]["ID_USUARIO"].ToString();
                lbl_Nombre1.Text = $"{dataUsuario.Tables[0].Rows[0]["NOMBRES"].ToString()}";
                lbl_Nombre2.Text = dataUsuario.Tables[0].Rows[0]["NOMBRES"].ToString();
            }
        }

        private void Lista_Empresa()
        {
            CLS_PRODUCTOS cls_Prod = new CLS_PRODUCTOS();
            DataTable dataCompa = cls_Prod.SP_15_GET_COMPANIAS(0);
            if (dataCompa != null && dataCompa.Rows.Count > 0)
            {
                dataCompa.Rows.RemoveAt(0);

                gv_ListaEmpresas.DataSource = dataCompa;
                gv_ListaEmpresas.DataBind();
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
        }
        protected void btn_cerrarGasto_Click(object sender, EventArgs e)
        {
            mpe_NuevoGastos.Hide();
        }

        protected void btn_crearGasto_Click(object sender, EventArgs e)
        {
            CLS_MASTER master = new CLS_MASTER();
            try
            {
                int resul = master.SP_20_INSERTAR_GASTO(
                bl_TipoProducto.SelectedValue,
                bl_CatProduc.SelectedValue,
                Convert.ToDecimal(txt_valor.Text),
                txt_descripcion.Value,
                null,
                Convert.ToDateTime(txt_FecPagoGasto.Text),
                Convert.ToDateTime(txt_fechRegistroGasto.Text),
                txt_observacion.Value,
                Convert.ToInt32(Session["userID"].ToString()));

                if (resul > 0)
                {

                    CLS_AUDITORIA audi = new CLS_AUDITORIA();
                    string IP = Request.UserHostAddress;

                    audi.SP_02_INSERTAR_AUDITORIA("CREAR NOTA", $"El usuario {Session["nombre_usuario"]} creo un nuevo gasto", "MASTER", IP, Convert.ToInt32(Session["userID"].ToString()));

                    //NotasCliente(idCliente);

                    //Message_Succes.Text = "Nota creada correctamente";
                    //Message_Succes.Visible = true;
                }
                else
                {
                    //Message_danger.Text = "Error al crear nota, por favor revise los datos";
                    //Message_danger.Visible = true;
                }
            }
            catch (Exception)
            {

            }

        }
        protected void btn_Iniciar_Click(object sender, EventArgs e)
        {

            CLS_MASTER master = new CLS_MASTER();
            int resul = master.SP_25_INICIAR_TIEMPO(Convert.ToInt32(Session["userID"].ToString()));

            if (resul > 0)
            {
                CLS_AUDITORIA audi = new CLS_AUDITORIA();
                string IP = Request.UserHostAddress;
                audi.SP_02_INSERTAR_AUDITORIA("INICIAR TIEMPO", $"El usuario {Session["nombre_usuario"]} inicio su tiempo de acceso en la plataforma", "MASTER", IP, Convert.ToInt32(Session["userID"].ToString()));
            }
            else
            {

                //Message_danger.Text = "Error al crear nota, por favor revise los datos";
                //Message_danger.Visible = true;
            }
            Validar_Tiempo();
        }
        protected void btn_finalizar_Click(object sender, EventArgs e)
        {
            CLS_MASTER master = new CLS_MASTER();
            int resul = master.SP_26_FINALIZAR_TIEMPO(Convert.ToInt32(Session["userID"].ToString()));

            if (resul > 0)
            {
                CLS_AUDITORIA audi = new CLS_AUDITORIA();
                string IP = Request.UserHostAddress;
                audi.SP_02_INSERTAR_AUDITORIA("FINALIZAR TIEMPO", $"El usuario {Session["nombre_usuario"]} finalizi su tiempo de acceso en la plataforma", "MASTER", IP, Convert.ToInt32(Session["userID"].ToString()));
            }
            else
            {

                //Message_danger.Text = "Error al crear nota, por favor revise los datos";
                //Message_danger.Visible = true;
            }
            Validar_Tiempo();
        }
        private void Validar_Tiempo()
        {

            int idUser = 1;//Convert.ToInt32(Session["userID"].ToString());
            CLS_MASTER master = new CLS_MASTER();
            int result = master.FS_01_GUI_CHECK_TIEMPO(idUser);

            if (result != -1)
            {
                //btn_Iniciar.Visible = false;
                //btn_finalizar.Visible = true;

                DataTable dataTiempo = new DataTable();
                dataTiempo = master.SP_27_GET_TIEMPO(idUser);

                if (dataTiempo != null && dataTiempo.Rows.Count > 0)
                {
                    string fecha = $"{dataTiempo.Rows[0]["FECHA_HORA_INICIO"].ToString()}";
                    //lbl_FechaIngreso.Text = $"In: {fecha}";
                    //lbl_FechaIngreso.CssClass = "badge badge-success col-12";
                }
            }
            else
            {
                btn_Iniciar.Visible = true;
                btn_finalizar.Visible = false;
                lbl_FechaIngreso.Text = $"In: {Convert.ToString(DateTime.Now)}";
                lbl_FechaIngreso.CssClass = "badge badge-danger col-12";
            }
        }
        private void CargarListaMenus(bool recargasLista = false)
        {
            int idUsuario = Convert.ToInt32(Session["userID"]);

            DataTable dataMenu = cls_menu.SP_50_CONSULTAR_MENUS_USUARIO(idUsuario);

            if (dataMenu != null && dataMenu.Rows.Count > 0)
            {
                var listaMenus = dataMenu.AsEnumerable().Select(x => new MenuView
                {
                    Texto = x.Field<string>("TEXTO"),
                    IdMenu = x.Field<int>("ID_MENU"),
                    Descripcion = x.Field<string>("DESCRIPCION"),
                    Icono = x.Field<string>("ICONO"),
                    Url = x.Field<string>("URL"),
                    IdMenuParent = x.Field<int?>("ID_MENU_PARENT"),
                    Orden = x.Field<int>("ORDEN")
                }).ToList();

                Session["menus"] = listaMenus;
                //Relaciono las tablas
                var listaAgrupada = listaMenus.Where(m => m.IdMenuParent == (int)HERENCIA.Padre || !m.IdMenuParent.HasValue).Select(x => new
                {
                    Text = x.Texto,
                    IdMenu = x.IdMenu,
                    Icono = x.Icono,
                    Url = x.Url,
                    x.Descripcion,
                    data = listaMenus.Where(p => p.IdMenuParent.HasValue && p.IdMenuParent == x.IdMenu).ToList(),
                    Count = listaMenus.Where(p => p.IdMenuParent.HasValue && p.IdMenuParent == x.IdMenu).Count()
                }).ToList();

                rp_listaMenus.DataSource = listaAgrupada;
                rp_listaMenus.DataBind();

            }
        }

        //protected void cmb_clientes_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cmb_clientes.Value != null && Session["clientes"] == null)
        //    {
        //        List<ClientesView> clientes = new List<ClientesView>
        //        { new ClientesView {IdCliente =Convert.ToInt32(cmb_clientes.Value), Cliente =cmb_clientes.Text.ToString() } };

        //        Session["clientes"] = clientes;
        //        Response.Redirect($"frm_Ventas?CLIENT_ID={cmb_clientes.Value.ToString()}");
        //    }

        //    if (cmb_clientes.Value != null && Session["clientes"] != null)
        //    {
        //        ClientesView cliente = new ClientesView { IdCliente = Convert.ToInt32(cmb_clientes.Value), Cliente = cmb_clientes.Text.ToString() };
        //        var lista = (List<ClientesView>)Session["clientes"];

        //        lista.Add(cliente);
        //        Session["clientes"] = lista;
        //        frm_Ventas frm = new frm_Ventas();
        //        frm.ConsularLista();
        //    }
        //}

        protected void btn_serch_Click(object sender, EventArgs e)
        {
            string url = Request.RawUrl;
            if (cmb_clientes.Value != null)
            {
                if (url.ToLower().Contains("frm_ventas") == false)
                {
                    ASPxComboBox cmb = cmb_clientes;

                    if (cmb.Value != null && Session["clientes"] == null)
                    {
                        List<ClientesView> clientes = new List<ClientesView>();
                        ClientesView cliente = new ClientesView { IdCliente = Convert.ToInt32(cmb.Value), Cliente = cmb.Text.ToString() };
                        clientes.Add(cliente);

                        Session["clientes"] = clientes;
                    }

                    if (cmb.Value != null && Session["clientes"] != null)
                    {
                        ClientesView cliente = new ClientesView { IdCliente = Convert.ToInt32(cmb.Value), Cliente = cmb.Text.ToString() };
                        var lista = (List<ClientesView>)Session["clientes"];


                        lista.Add(cliente);
                        Session["clientes"] = lista;
                    }

                    Response.Redirect($"frm_ventas.aspx?CLIENT_ID={cmb_clientes.Value.ToString()}");
                }
            }
        }

    }
}



