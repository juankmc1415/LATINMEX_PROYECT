using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LATINMEX.Datos.CORE;
using LATINMEX.Datos.MASTER;
using LATINMEX.Datos.PRODUCTOS;

namespace LATINMEX
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbl_FechaIngreso.Text = $"In: {Convert.ToString(DateTime.Now)}";
                Datos_Usuario();
                Lista_Empresa();
                DateTime FechaNacimiento = DateTime.Now;
                txt_FecPagoGasto.Text = FechaNacimiento.ToString("yyyy-MM-dd");

                txt_fechRegistroGasto.Text = FechaNacimiento.ToString("yyyy-MM-dd");

            }
            
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
            DataTable dataCompa = cls_Prod.SP_15_GET_COMPANIAS();
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

                    //CLS_AUDITORIA audi = new CLS_AUDITORIA();
                    //string IP = Request.UserHostAddress;
                    //string nombreCliente = $"{txt_Nombre.Text} {txt_PrimerApellido.Text} {txt_SegunApellido.Text}";
                    //audi.SP_02_INSERTAR_AUDITORIA("CREAR NOTA", $"El usuario {Session["nombre_usuario"]} creo una nota al cliente {nombreCliente}", "VENTAS", IP, Convert.ToInt32(Session["userID"].ToString()));

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
    }
}