using LATINMEX.Datos.CLIENTES;
using LATINMEX.Datos.CORE;
using LATINMEX.Datos.PRODUCTOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LATINMEX.MODULOS.LLAMADAS
{
    public partial class frm_llamadas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string idCliente = Page.Request.QueryString["CLIENT_ID"].ToString();
                    NotasCliente(idCliente);
                    TiposProductos(1);
                }
                catch (Exception)
                {
                    //OcultarControles("NUEVO");
                }
            }
        }

        private void TiposProductos(int tipo)
        {

            CLS_PRODUCTOS cls_Prod = new CLS_PRODUCTOS();
            DataTable data = cls_Prod.SP_12_GET_TIPOS_PRODUCTO(tipo);

            if (data != null && data.Rows.Count > 0)
            {
                DataRow item = data.NewRow();
                item["ID_TIPO_PRODUCTO"] = "0";
                item["ID_PRODUCTO"] = "1";
                item["TIPO_PRODUCTO"] = "Selecionar";

                data.Rows.Add(item);
                bl_CatProduc.DataSource = data;
                bl_CatProduc.DataBind();

                bl_CatProduc.SelectedValue = "0";

            }

            DataTable dataCompa = cls_Prod.SP_15_GET_COMPANIAS();
            if (dataCompa != null && dataCompa.Rows.Count > 0)
            {
                bl_CompaniaSe.DataSource = dataCompa;
                bl_CompaniaSe.DataBind();
            }
        }

        protected void btn_NuevaNota_Click(object sender, EventArgs e)
        {
            txt_nota.Value = "";
            mpe_NuevaNota.Show();
            //OcultarControles("O_MENSAGE");
        }

        protected void btn_cerrar_Click(object sender, EventArgs e)
        {
            txt_nota.Value = "";
            mpe_NuevaNota.Hide();
            //OcultarControles("O_MENSAGE");
        }

        protected void btn_crearNota_Click(object sender, EventArgs e)
        {

            //string tes = test.Text;
            if (string.IsNullOrEmpty(txt_nota.Value) || string.IsNullOrWhiteSpace(txt_nota.Value))
            {
                txt_nota.Focus();

                Message_danger.Text = "la descripción de la nota es un campo obligatorio.";
                Message_danger.Visible = true;
                mpe_NuevaNota.Show();
                return;
            }

            string idCliente = "";
            try
            {
                idCliente = Page.Request.QueryString["CLIENT_ID"].ToString();
            }
            catch (Exception)
            {
            }

            CLS_NOTAS cls_Cli = new CLS_NOTAS();
            int resul = cls_Cli.SP_08_NUEVA_NOTA(txt_nota.Value, Convert.ToInt32(Session["userID"].ToString()), "VISIBLE", "LLAMADAS", Convert.ToInt32(idCliente));

            if (resul > 0)
            {
                txt_nota.Value = "";

                CLS_AUDITORIA audi = new CLS_AUDITORIA();
                string IP = Request.UserHostAddress;
                string nombreCliente = "JUAN MARTINEZ";// $"{txt_PrimerNombre.Text} {txt_SegundoNombre.Text} {txt_Apellidos.Text}";
                audi.SP_02_INSERTAR_AUDITORIA("CREAR NOTA", $"El usuario {Session["nombre_usuario"]} creo una nota al cliente {nombreCliente}", "LLAMADAS", IP, Convert.ToInt32(Session["userID"].ToString()));

                NotasCliente(idCliente);
                Message_Succes.Text = "Nota creada correctamente";
                Message_Succes.Visible = true;
            }
            else
            {
                Message_danger.Text = "Error al crear nota, por favor revise los datos";
                Message_danger.Visible = true;
            }

        }


        private void NotasCliente(string idCLiente)
        {
            CLS_NOTAS cls_Cli = new CLS_NOTAS();
            DataTable notas = cls_Cli.SP_10_GET_LISTA_NOTAS(idCLiente);

            if (notas != null && notas.Rows.Count > 0)
            {
                gv_Notas.DataSource = notas;
                gv_Notas.DataBind();
            }
            else
            {
                notas.Rows.Add(notas.NewRow());
                gv_Notas.DataSource = notas;
                gv_Notas.DataBind();
                gv_Notas.Rows[0].Cells.Clear();
                gv_Notas.Rows[0].Cells.Add(new TableCell());
                gv_Notas.Rows[0].Cells[0].ColumnSpan = notas.Columns.Count;
                gv_Notas.Rows[0].Cells[0].Text = "El usuario no tiene notas";
                gv_Notas.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }
    }
}