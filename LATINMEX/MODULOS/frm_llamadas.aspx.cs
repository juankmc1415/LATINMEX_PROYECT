using LATINMEX.Datos.CLIENTES;
using LATINMEX.Datos.CORE;
using LATINMEX.Datos.LLAMADAS;
using LATINMEX.Datos.PRODUCTOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

                    btn_NuevaNota.Visible = false;

                    string idCliente = Page.Request.QueryString["CLIENT_ID"].ToString();
                    //NotasCliente(idCliente);
                    TiposProductos(1);

                    ListaProductos();
                    btn_MostrarInfo_Click(null, null);
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

            DataTable dataCompa = cls_Prod.SP_15_GET_COMPANIAS(0);
            if (dataCompa != null && dataCompa.Rows.Count > 0)
            {
                bl_CompaniaSe.DataSource = dataCompa;
                bl_CompaniaSe.DataBind();
            }
        }

        protected void btn_NuevaNota_Click(object sender, EventArgs e)
        {
            txt_nota.Value = "";
            div_llamada.Visible = false;
            mpe_NuevaNota.Show();
            //OcultarControles("O_MENSAGE");
        }

        protected void btn_cerrar_Click(object sender, EventArgs e)
        {
            txt_nota.Value = "";
            mpe_NuevaNota.Hide();
            btn_MostrarInfo_Click(null, null);
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
                idCliente = Id_Cliente.Value;
            }
            catch (Exception)
            {
            }

            string resllamada = "";
            if (cbx_llamada.Checked)
            {
                resllamada = "SI_CONTESTO";
            }
            else
            {
                resllamada = "NO_CONTESTO";
            }

            //hf_tipoProducto.Value = "CUOTA";
            //hf_Producto.Value = varName2;

            CLS_NOTAS cls_Cli = new CLS_NOTAS();
            int resul = cls_Cli.SP_31_NUEVA_NOTA_LLAMADA(txt_nota.Value, Convert.ToInt32(1), "VISIBLE", "LLAMADAS", Convert.ToInt32(idCliente), hf_Producto.Value, hf_tipoProducto.Value, resllamada);

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

            btn_MostrarInfo_Click(null, null);
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

        protected void gv_Llamadas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AgregarNota")
            {
                GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                string cliente = Convert.ToString(((Label)gvRow.FindControl("lbl_Cliente")).Text.ToString());
                Id_Cliente.Value = cliente;
                btn_NuevaNota.Visible = true;
                NotasCliente(cliente);

            }

            if (e.CommandName == "VerProducto")
            {
                GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                string varName1 = Convert.ToString(((Label)gvRow.FindControl("lbl_Produc")).Text.ToString());
                string varName2 = Convert.ToString(((Label)gvRow.FindControl("lbl_producto_a")).Text.ToString());
                string tipo = Convert.ToString(((Label)gvRow.FindControl("lbl_tipo")).Text.ToString());

                

                if (tipo == "PRODUCTO")
                {
                    hf_tipoProducto.Value = "PRODUCTO";
                    hf_Producto.Value = varName1;
                    DetallesProducto(varName1);
                    LimpiarControles("VER_PRODUCTO");

                }
                else
                {
                    hf_tipoProducto.Value = "CUOTA";
                    hf_Producto.Value = varName2;
                    DetallesCuota(varName2);
                    mpe_Cuotas.Show();
                }

                //btn_ActualizarProduto.Visible = true;
                //btn_aceptar.Visible = false;
                
               
            }

            if (e.CommandName == "llamada")
            {
                GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                
                string varName1 = Convert.ToString(((Label)gvRow.FindControl("lbl_Produc")).Text.ToString());
                string varName2 = Convert.ToString(((Label)gvRow.FindControl("lbl_producto_a")).Text.ToString());
                string tipo = Convert.ToString(((Label)gvRow.FindControl("lbl_tipo")).Text.ToString());
                string cliente = Convert.ToString(((Label)gvRow.FindControl("lbl_Cliente")).Text.ToString());
                Id_Cliente.Value = cliente;


                if (tipo == "PRODUCTO")
                {
                    hf_tipoProducto.Value = "PRODUCTO";
                    hf_Producto.Value = varName1;
                }
                else
                {
                    hf_tipoProducto.Value = "CUOTA";
                    hf_Producto.Value = varName2;
                }
                txt_nota.Value = "";
                div_llamada.Visible = true;
                mpe_NuevaNota.Show();
            }

          

            btn_MostrarInfo_Click(null, null);
        }

        protected void txt_Adicional_TextChanged(object sender, EventArgs e)
        {
            decimal total = 0;

            if (bl_TipoProducto.SelectedItem.Text == "SEGURO")
            {
                total = Convert.ToDecimal(txt_pagoEfectivo.Text)
                + Convert.ToDecimal(txt_tarjetaCedito.Text)
                - Convert.ToDecimal(txt_recargo.Text)
                - Convert.ToDecimal(txt_Costo.Text);

                //if (total > 0)
                //{
                txt_SerAdicional.Text = Convert.ToString(total);
                //}
                //else
                //{
                //    txt_SerAdicional.Text = Convert.ToString(0);
                //}
            }
            else
            {
                total = Convert.ToDecimal(txt_pagoEfectivo.Text)
               + Convert.ToDecimal(txt_tarjetaCedito.Text)
               - Convert.ToDecimal(txt_recargo.Text)
               - Convert.ToDecimal(txt_ValorServicio.Text);

                if (total > 0)
                {
                    txt_valorTotal.Text = Convert.ToString(total);
                }
                else
                {
                    txt_valorTotal.Text = Convert.ToString(0);
                }
            }

            mpe_Produc.Show();
        }

        protected void txt_tarjetaCedito_TextChanged(object sender, EventArgs e)
        {
            //OcultarControles("O_MENSAGE");

            if (!string.IsNullOrEmpty(txt_tarjetaCedito.Text) && !string.IsNullOrWhiteSpace(txt_tarjetaCedito.Text))
            {
                if (Convert.ToInt32(txt_tarjetaCedito.Text) > 0)
                {
                    txt_recargo.Enabled = true;
                }
                else
                {
                    txt_recargo.Enabled = false;
                }
            }

            decimal total = 0;

            if (bl_TipoProducto.SelectedItem.Text == "SEGURO")
            {
                total = Convert.ToDecimal(txt_pagoEfectivo.Text)
                 + Convert.ToDecimal(txt_tarjetaCedito.Text)
                 - Convert.ToDecimal(txt_recargo.Text)
                 - Convert.ToDecimal(txt_Costo.Text);

                //if (total > 0)
                //{
                txt_SerAdicional.Text = Convert.ToString(total);
                //}
                //else
                //{
                //    txt_SerAdicional.Text = Convert.ToString(0);
                //}
            }
            else
            {
                total = Convert.ToDecimal(txt_pagoEfectivo.Text)
               + Convert.ToDecimal(txt_tarjetaCedito.Text)
               - Convert.ToDecimal(txt_recargo.Text);

                if (total > 0)
                {
                    txt_valorTotal.Text = Convert.ToString(total);
                }
                else
                {
                    txt_valorTotal.Text = Convert.ToString(0);
                }
            }

            mpe_Produc.Show();
        }

        protected void btn_cerrPro_Click(object sender, EventArgs e)
        {
            mpe_Produc.Hide();
            btn_MostrarInfo_Click(null, null);
        }

        protected void btn_cerrarCuota_Click(object sender, EventArgs e)
        {
            mpe_Cuotas.Hide();
            btn_MostrarInfo_Click(null, null);
        }

        protected void btn_MostrarInfo_Click(object sender, EventArgs e)
        {
            CLS_LLAMADAS cl_llamadas = new CLS_LLAMADAS();

            DataTable notas = cl_llamadas.SP_28_GET_LISTA_PRODUCTO_LLAMADAS(null, null, null, null);
            if (notas != null && notas.Rows.Count > 0)
            {
                gv_Llamadas.DataSource = notas;
                gv_Llamadas.DataBind();
            }
        }

        protected void btn_AceptarCuotas_Click(object sender, EventArgs e)
        {
            //string tes = test.Text;
            if (string.IsNullOrEmpty(txt_ValorPagarTarjeta.Text) || string.IsNullOrWhiteSpace(txt_ValorPagarTarjeta.Text))
            {
                if (string.IsNullOrEmpty(txt_ValorPagarEfectivo.Text) || string.IsNullOrWhiteSpace(txt_ValorPagarEfectivo.Text))
                {
                    txt_ValorPagarTarjeta.Focus();
                    Message_danger.Text = "El valor de la cuota es un campo obligatorio.";
                    Message_danger.Visible = true;
                    mpe_Cuotas.Show();
                    return;
                }
            }

            decimal total = Convert.ToDecimal(txt_ValorPagarTarjeta.Text) + Convert.ToDecimal(txt_ValorPagarEfectivo.Text);

            if (total < 1)
            {
                Message_danger.Text = "El valor pagado no puede ser menor a 0";
                Message_danger.Visible = true;
                mpe_Cuotas.Show();
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


            string idProducto = hf_ID_PRODUCTO_CUOTA.Value;
            string idCuota = hf_IDCUOTA.Value;
            string estado = "PAGADO";
            decimal valorCuota = Convert.ToDecimal(txt_valorCuota.Text);
            decimal valorTarjeta = Convert.ToDecimal(txt_ValorPagarTarjeta.Text);
            decimal valorEfectivo = Convert.ToDecimal(txt_ValorPagarEfectivo.Text);
            decimal valorRecargo = Convert.ToDecimal(txt_ValorPagarRecargo.Text);
            string observacion = txt_ObservacionCuota.Value;
            int idUser = Convert.ToInt32(Session["userID"].ToString());

            decimal totalV = valorTarjeta + valorEfectivo - valorRecargo;

            CLS_PRODUCTOS cls_produ = new CLS_PRODUCTOS();
            string idArchivo = "";
            if (file_Cuotas.HasFile == true)
            {
                if (file_Cuotas.PostedFile.ContentLength > 100000)
                {
                    Message_warning.Text = "El tamaño no puede ser mayo a 10 MB";
                    Message_warning.Visible = true;
                    mpe_Produc.Show();

                    return;
                }
                idArchivo = GuardarArchivos(file_Cuotas);
            }

            int p_inf = 0;
            if (cbx_PagoInferior.Checked)
            {
                p_inf = 1;
            }
            else
            {
                p_inf = 0;
            }


            if (totalV > valorCuota)
            {
                p_inf = 1;
            }


            int resul = cls_produ.SP_23_ACTUALIZAR_CUOTAS(idProducto, idCuota, estado, valorCuota, valorTarjeta, valorEfectivo, valorRecargo, observacion, idUser, p_inf, 0,"False",0);

            if (resul > 0)
            {
                txt_nota.Value = "";

                if (!string.IsNullOrEmpty(idArchivo) && !string.IsNullOrWhiteSpace(idArchivo))
                {
                    cls_produ.SP_30_GUARDAR_FORMULARIO_ARCHIVOS(idArchivo, idCliente, idCuota, "CUOTAS");
                }

                CLS_AUDITORIA audi = new CLS_AUDITORIA();
                string IP = Request.UserHostAddress;
                string nombreCliente = "JUAN CAMILO"; //$"{txt_PrimerNombre.Text} {txt_SegundoNombre.Text} {txt_Apellidos.Text}";
                audi.SP_02_INSERTAR_AUDITORIA("ACTUALIZAR CUOTA", $"El usuario {Session["nombre_usuario"]} actualizo el valor de una cuota {nombreCliente}", "VENTAS", IP, Convert.ToInt32(Session["userID"].ToString()));

                //ProductosCliente(idCliente);

                Message_Succes.Text = "Cuota actulizada correctamente correctamente";
                Message_Succes.Visible = true;
            }
            else
            {
                Message_danger.Text = "Error al actulizar cuota, por favor revise los datos";
                Message_danger.Visible = true;
                mpe_Cuotas.Show();
            }

            btn_MostrarInfo_Click(null, null);

        }

        protected void gv_Llamadas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string estado = DataBinder.Eval(e.Row.DataItem, "ESTADO_LLAMADA").ToString();
                int cantidad_dias = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CANTIDAD_DIAS").ToString());


                if (estado == "NUEVO")
                {
                    e.Row.BackColor = System.Drawing.Color.FromName("#ffffff");
                }

                if (estado == "NO_CONTESTO")
                {
                    e.Row.BackColor = System.Drawing.Color.FromName("#e8f999");
                }

                if (estado == "SI_CONTESTO")
                {
                    e.Row.BackColor = System.Drawing.Color.FromName("#abfdc1");
                }

                if (cantidad_dias < 0)
                {
                    e.Row.BackColor = System.Drawing.Color.FromName("#ee95a7");
                }
            }
        }

        private void ListaProductos()
        {
            CLS_PRODUCTOS cls_Prod = new CLS_PRODUCTOS();

            DataTable data = cls_Prod.SP_11_GET_PRODUCTOS();
            if (data != null && data.Rows.Count > 0)
            {
                int tipo = Convert.ToInt32(data.Rows[0]["ID_PRODUCTO"].ToString());

                bl_TipoProducto.DataSource = data;
                bl_TipoProducto.DataBind();

                TiposProductos(tipo);

                if (data.Rows[0]["PRODUCTO"].ToString() == "SEGURO")
                {
                    div_estad.Visible = true;
                    EstadosProductos(tipo);
                }
                else
                {
                    div_estad.Visible = false;
                }
            }

            DataTable dataCompa = cls_Prod.SP_15_GET_COMPANIAS(0);
            if (dataCompa != null && dataCompa.Rows.Count > 0)
            {
                bl_CompaniaSe.DataSource = dataCompa;
                bl_CompaniaSe.DataBind();

                DropDownList1.DataSource = dataCompa;
                DropDownList1.DataBind();
                txt_CodInterno.Text = dataCompa.Rows[0]["CODIGO_INTERNO"].ToString();
            }
        }

        private void EstadosProductos(int tipo)
        {

            CLS_PRODUCTOS cls_Prod = new CLS_PRODUCTOS();
            DataTable data = cls_Prod.SP_13_GET_ESTADOS_PRODUCTO(tipo);

            if (data != null && data.Rows.Count > 0)
            {
                BL_EstadosProdu.DataSource = data;
                BL_EstadosProdu.DataBind();
            }
        }

        private void DetallesProducto(string idProducto)
        {
            CLS_PRODUCTOS cls_Cli = new CLS_PRODUCTOS();
            DataTable dt_product = cls_Cli.SP_18_GET_DATOS_PRODUCTO(idProducto);

            if (dt_product != null && dt_product.Rows.Count > 0)
            {
                bl_TipoProducto.SelectedValue = dt_product.Rows[0]["TIPO_PRODUCTO"].ToString();
                TiposProductos(Convert.ToInt32(bl_TipoProducto.SelectedValue));
                bl_CatProduc.SelectedValue = dt_product.Rows[0]["ID_CATEGORIA_TIPO_PRODUCTO"].ToString();

                if (bl_TipoProducto.SelectedItem.Text == "SEGURO")
                {
                    BL_EstadosProdu.SelectedValue = dt_product.Rows[0]["ESTADO_PRODUCTO"].ToString();

                }

                txt_numPoliza.Text = dt_product.Rows[0]["NUMERO_POLIZA"].ToString();

                DateTime FechInicio = Convert.ToDateTime(dt_product.Rows[0]["FECHA_INICIO"]);
                txt_FechInicio.Text = FechInicio.ToString("yyyy-MM-dd");

                DateTime fechCaduci = Convert.ToDateTime(dt_product.Rows[0]["FECHA_CADUCIDAD"]);
                txt_fechCaduci.Text = fechCaduci.ToString("yyyy-MM-dd");

                bl_CompaniaSe.SelectedValue = dt_product.Rows[0]["ID_COMPANIA_SEGUROS"].ToString();
                txt_CodInterno.Text = dt_product.Rows[0]["CODIGO_INTERNO"].ToString();

                txt_valor.Text = dt_product.Rows[0]["VALOR_PRODUCTO"].ToString();
                txt_Costo.Text = dt_product.Rows[0]["COSTO"].ToString();
                txt_SerAdicional.Text = dt_product.Rows[0]["SERVICIO_ADICIONAL"].ToString();
                txt_CashOut.Text = dt_product.Rows[0]["CASH_OUT"].ToString();
                txt_tarjetaCedito.Text = dt_product.Rows[0]["TARJETA_CREDITO"].ToString();
                txt_pagoEfectivo.Text = dt_product.Rows[0]["PAGO_EFECTIVO"].ToString();
                txt_recargo.Text = dt_product.Rows[0]["RECARGO"].ToString();
                txt_Intsallmentfee.Text = dt_product.Rows[0]["INTSALLMENTFEE"].ToString();

                if (dt_product.Rows[0]["TIPO_PAGO"].ToString() == "Cuotas")
                {
                    bl_Tipopago.SelectedValue = "2";
                }
                else if (dt_product.Rows[0]["TIPO_PAGO"].ToString() == "Completa")
                {
                    bl_Tipopago.SelectedValue = "3";
                }
                else
                {
                    bl_Tipopago.SelectedValue = "1";
                }

                if (!string.IsNullOrEmpty(dt_product.Rows[0]["NUMERO_CUOTAS"].ToString()) || !string.IsNullOrWhiteSpace(dt_product.Rows[0]["NUMERO_CUOTAS"].ToString()))
                {
                    bl_Numcuotas.SelectedValue = dt_product.Rows[0]["NUMERO_CUOTAS"].ToString();
                }
                else
                {
                    bl_Numcuotas.SelectedValue = "0";
                }

                if (!string.IsNullOrEmpty(dt_product.Rows[0]["FECHA_PROXIMO_PAGO"].ToString()) || !string.IsNullOrWhiteSpace(dt_product.Rows[0]["FECHA_PROXIMO_PAGO"].ToString()))
                {
                    DateTime proximoPago = Convert.ToDateTime(dt_product.Rows[0]["FECHA_PROXIMO_PAGO"].ToString());
                    txt_proximoPago.Text = fechCaduci.ToString("yyyy-MM-dd");
                }
                else
                {
                    txt_proximoPago.Text = "";
                }

                txtx_NombreEmpresa.Text = dt_product.Rows[0]["NOMBRE_EMPRESA"].ToString();

                if (dt_product.Rows[0]["PROSPECTO"].ToString() == "False")
                {
                    cb_prospecto.Checked = false;
                }
                else
                {
                    cb_prospecto.Checked = true;
                }


                if (!string.IsNullOrEmpty(dt_product.Rows[0]["FECHA_RETIRO"].ToString()) || !string.IsNullOrWhiteSpace(dt_product.Rows[0]["FECHA_RETIRO"].ToString()))
                {
                    DateTime FechaRetiro = Convert.ToDateTime(dt_product.Rows[0]["FECHA_RETIRO"]);
                    txt_fechaRetiro.Text = FechaRetiro.ToString("yyyy-MM-dd");
                }

                txt_reserva.Text = dt_product.Rows[0]["RESERVA"].ToString();
                txt_ValorTramite.Text = dt_product.Rows[0]["VALOR_TRAMITE"].ToString();
                txt_ValorTerceros.Text = dt_product.Rows[0]["COSTO_TERCEROS"].ToString();
                txt_ValorServicio.Text = dt_product.Rows[0]["VALOR_SERVICIO"].ToString();
                txt_valorTotal.Text = dt_product.Rows[0]["VALOR_TOTAL"].ToString();
                txt_Impuesto.Text = dt_product.Rows[0]["EXCEDENTE_IMPUESTO"].ToString();
                txt_Exc_tramite.Text = dt_product.Rows[0]["EXCEDENTE_TRAMITE"].ToString();
                txt_totalCobrar.Text = dt_product.Rows[0]["TOTAL_COBRAR"].ToString();

                txt_observacion.Value = dt_product.Rows[0]["OBSERVACION"].ToString();

            }

            mpe_Produc.Show();
            LimpiarControles("VER_PRODUCTO");
            //OcultarControles("O_MENSAGE");
        }

        private void DetallesCuota(string idCuota)
        {
            CLS_PRODUCTOS cls_Cli = new CLS_PRODUCTOS();
            DataTable dt_Cuotas = cls_Cli.SP_22_GET_DETALLES_CUOTA(idCuota);

            if (dt_Cuotas != null && dt_Cuotas.Rows.Count > 0)
            {
                hf_IDCUOTA.Value = dt_Cuotas.Rows[0]["ID_PRODUCTO_ASOCIADO"].ToString();
                hf_ID_PRODUCTO_CUOTA.Value = dt_Cuotas.Rows[0]["ID_PRODUCTO"].ToString();
                txt_Cuotas_producto.Text = dt_Cuotas.Rows[0]["PRODUCTO"].ToString();
                txt_Cuotas_Categoria.Text = dt_Cuotas.Rows[0]["CATEGORIA"].ToString();
                txt_Cuotas_EstadoSeguro.Text = dt_Cuotas.Rows[0]["ESTADO_SEGURO"].ToString();
                txt_Cuota.Text = dt_Cuotas.Rows[0]["SECUENCIA"].ToString();

                DateTime proximoPago = Convert.ToDateTime(dt_Cuotas.Rows[0]["FECHA_PROXIMO_PAGO"].ToString());
                txt_fproximoPago.Text = proximoPago.ToString("yyyy-MM-dd");

                txt_EstodoCuota.Text = dt_Cuotas.Rows[0]["ESTADO_CUOTA"].ToString();
                txt_valorCuota.Text = dt_Cuotas.Rows[0]["COSTO_CUOTA"].ToString();

                if (dt_Cuotas.Rows[0]["ESTADO_CUOTA"].ToString() == "PAGADO")
                {
                    //btn_AceptarCuotas.Visible = false;
                    txt_ValorPagarTarjeta.Text = dt_Cuotas.Rows[0]["VALOR_PAGADO_TARJETA"].ToString();
                    txt_ValorPagarTarjeta.Enabled = false;

                    txt_ValorPagarEfectivo.Text = dt_Cuotas.Rows[0]["VALOR_PAGADO_EFECTIVO"].ToString();
                    txt_ValorPagarEfectivo.Enabled = false;

                    txt_ValorPagarRecargo.Text = dt_Cuotas.Rows[0]["VALOR_RECARGO"].ToString();
                    txt_ValorPagarRecargo.Enabled = false;

                    txt_ObservacionCuota.Value = dt_Cuotas.Rows[0]["OBSERVACION"].ToString();
                    //txt_ObservacionCuota.EnableTheming = false;
                }
                else
                {
                    btn_AceptarCuotas.Visible = true;

                    txt_ValorPagarTarjeta.Text = "0";
                    txt_ValorPagarTarjeta.Enabled = true;

                    txt_ValorPagarEfectivo.Text = "0";
                    txt_ValorPagarEfectivo.Enabled = true;

                    txt_ValorPagarRecargo.Text = "0";
                    txt_ValorPagarRecargo.Enabled = true;

                    txt_ObservacionCuota.Value = "";
                    //txt_ObservacionCuota.ed = true;
                }
            }
            else
            {
                hf_IDCUOTA.Value = "";
                hf_ID_PRODUCTO_CUOTA.Value = "";
            }
        }

        private string GuardarArchivos(FileUpload archivo)
        {
            CLS_PRODUCTOS cls_produ = new CLS_PRODUCTOS();
            string idArchivo = "";
            Byte[] Archivo = null;
            string nombreArchivo = string.Empty;
            string extensionArchivo = string.Empty;

            if (archivo.HasFile == true)
            {
                using (BinaryReader reader = new BinaryReader(archivo.PostedFile.InputStream))
                {
                    Archivo = reader.ReadBytes(archivo.PostedFile.ContentLength);
                }
                nombreArchivo = Path.GetFileNameWithoutExtension(archivo.FileName);
                extensionArchivo = Path.GetExtension(archivo.FileName);

                DataTable data_archivo = cls_produ.SP_29_GUARDAR_ARCHIVOS(Archivo, nombreArchivo, extensionArchivo);


                if (data_archivo != null && data_archivo.Rows.Count > 0)
                {
                    idArchivo = data_archivo.Rows[0]["ID_ARCHIVO"].ToString();
                }

            }
            return idArchivo;
        }

        private void LimpiarControles(string tipo)
        {
            if (tipo == "NUEVO_PRODUCTO")
            {
                bl_TipoProducto.SelectedValue = "1";

                string id = bl_TipoProducto.SelectedValue;
                TiposProductos(Convert.ToInt32(id));

                bl_CatProduc.SelectedValue = "1";
                BL_EstadosProdu.SelectedValue = "1";
                BL_EstadosProdu.Enabled = false;
                txt_numPoliza.Text = "";
                txt_FechInicio.Text = Convert.ToString(DateTime.Now);
                txt_fechCaduci.Text = "";
                txt_CodInterno.Text = "";

                txt_valor.Text = "0";
                txt_Costo.Text = "0";
                txt_SerAdicional.Text = "0";
                txt_CashOut.Text = "0";
                txt_tarjetaCedito.Text = "0";
                txt_pagoEfectivo.Text = "0";
                txt_recargo.Text = "0";
                txt_Intsallmentfee.Text = "0";

                txt_ValorTramite.Text = "0";
                txt_ValorTerceros.Text = "0";
                txt_ValorServicio.Text = "0";
                txt_valorTotal.Text = "0";
                txt_Impuesto.Text = "0";
                txt_Exc_tramite.Text = "0";
                txt_totalCobrar.Text = "0";

                bl_Tipopago.SelectedValue = "1";

                bl_TipoProducto.Enabled = true;
                bl_CatProduc.Enabled = true;
                txt_numPoliza.Enabled = true;
                txt_FechInicio.Enabled = true;
                txt_fechCaduci.Enabled = true;
                bl_CompaniaSe.Enabled = true;
                txt_CodInterno.Enabled = true;

                txt_reserva.Enabled = true;
                txt_fechaRetiro.Enabled = true;

                bl_Tipopago.Enabled = true;
                bl_Numcuotas.Enabled = true;

                //bl_Numcuotas.SelectedValue = dt_product.Rows[0]["NUMERO_CUOTAS"].ToString();

                //DateTime proximoPago = Convert.ToDateTime(dt_product.Rows[0]["FECHA_PROXIMO_PAGO"]);
                txt_proximoPago.Text = "";

                //txtx_NombreEmpresa.Text = "";
                //cb_prospecto.Checked = dt_product.Rows[0]["NUMERO_CUOTAS"].ToString();
                txt_observacion.Value = "";
            }

            if (tipo == "VER_PRODUCTO")
            {
                BL_EstadosProdu.Enabled = true;
                bl_Numcuotas.Enabled = true;
                if (!string.IsNullOrEmpty(txt_tarjetaCedito.Text) || !string.IsNullOrWhiteSpace(txt_tarjetaCedito.Text))
                {
                    txt_recargo.Enabled = true;
                }

                bl_TipoProducto.Enabled = false;
                bl_CatProduc.Enabled = false;
                txt_numPoliza.Enabled = false;
                txt_FechInicio.Enabled = false;
                txt_fechCaduci.Enabled = false;
                bl_CompaniaSe.Enabled = false;
                txt_CodInterno.Enabled = false;

                txt_reserva.Enabled = false;
                txt_fechaRetiro.Enabled = false;

                bl_Tipopago.Enabled = false;
                bl_Numcuotas.Enabled = false;
            }


            if (bl_TipoProducto.SelectedItem.Text == "SEGURO")
            {
                div_estad.Visible = true;

                dv_poliza.Visible = true;
                lbl_fechaInicio.Visible = true;
                lbl_fechaFactura.Visible = false;

                dv_fechaRetiro.Visible = false;
                dv_Compania.Visible = true;

                dv_ValorTramite.Visible = false;
                dv_valorServicio.Visible = false;
                dv_Impuestos.Visible = false;

                dv_CostosSeguro.Visible = true;
                dv_ProximoPago.Visible = true;

            }
            else
            {

                dv_poliza.Visible = false;
                div_estad.Visible = false;

                lbl_fechaInicio.Visible = false;
                lbl_fechaFactura.Visible = true;

                dv_Compania.Visible = false;
                dv_fechaRetiro.Visible = true;
                txt_reserva.Enabled = false;

                if (tipo == "VER_PRODUCTO")
                {
                    dv_ValorTramite.Visible = true;
                }
                else
                {
                    dv_ValorTramite.Visible = false;
                }

                dv_valorServicio.Visible = true;
                dv_Impuestos.Visible = true;
                dv_CostosSeguro.Visible = false;
                dv_ProximoPago.Visible = false;

                if (bl_CatProduc.SelectedItem.Text == "TIKET")
                {
                    if (tipo == "VER_PRODUCTO")
                    {
                        txt_reserva.Enabled = false;
                    }
                    else
                    {
                        txt_reserva.Enabled = true;
                    }
                }
                else
                {
                    txt_reserva.Enabled = false;
                }
            }
        }
    }
}