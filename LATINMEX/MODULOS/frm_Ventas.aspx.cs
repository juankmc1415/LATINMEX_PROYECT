using LATINMEX.Datos.CLIENTES;
using LATINMEX.Datos.CORE;
using LATINMEX.Datos.PRODUCTOS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using static LATINMEX.Datos.CORE.CLS_CORE;



namespace LATINMEX.MODULOS.VENTAS
{
    public partial class frm_Ventas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string idCliente = Page.Request.QueryString["CLIENT_ID"].ToString();
                    if (!string.IsNullOrEmpty(idCliente) && !string.IsNullOrWhiteSpace(idCliente) && idCliente != "0")
                    {
                        ListaProductos();
                        try
                        {
                            ProductosCliente(idCliente);
                        }
                        catch (Exception)
                        {

                        }

                        OcultarControles("ACTUALIZAR");

                        DatosCliente(idCliente);
                    }
                    else
                    {
                        OcultarControles("NUEVO");
                    }
                }
                catch (Exception)
                {
                    //OcultarControles("NUEVO");
                }

            }
        }

        #region REGISTRO Y ACTUALIZACIÓN DE CLIENTES
        /// <summary>
        /// Evento de creación de clientes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_registra_Click(object sender, EventArgs e)
        {
            //validar campos
            Response res = new Response();
            res = validarCampos("Nuevo_usuario");
            if (!res.Succ)
            {
                Message_warning.Text = res.Message;
                Message_warning.Visible = true;
                return;
            }

            LTM_CLIENTE cliente = new LTM_CLIENTE();
            cliente.PRIMER_NOMBRE = txt_PrimerNombre.Text;
            cliente.SEGUNDO_NOMBRE = txt_SegundoNombre.Text;
            cliente.APELLIDOS = txt_Apellidos.Text;

            cliente.CORREO = txt_Corre.Text;
            cliente.TELEFONO_MOVIL = txt_Telefono.Text;
            cliente.DIRECCION_RESIDENCIA = txt_DirecResidencia.Text;
            cliente.DIRECCION_CORRESPONDENCIA = txt_DireCorrespond.Text;
            cliente.FECHA_NACIMIENTO = Convert.ToDateTime(txt_fechaNacimiento.Text);
            cliente.ID_CONDUCCION = txt_IDconducion.Text;
            cliente.CIUDAD = txt_Ciudad.Text;
            cliente.ESTADO = txt_Estado.Text;
            cliente.CODIGO_POSTAL = txt_CodigoPostal.Text;
            cliente.NOMBRE_EMPRESA = txt_NombreEmpresa.Text;


            cliente.VIN_1 = txt_Vin1.Text;
            if (!String.IsNullOrEmpty(txt_FecVin1.Text) && !string.IsNullOrWhiteSpace(txt_FecVin1.Text))
            {
                cliente.FECHA_VIN_1 = Convert.ToDateTime(txt_FecVin1.Text);
            }
            else
            {
                cliente.FECHA_VIN_1 = null;
            }

            cliente.VIN_2 = txt_Vin2.Text;
            if (!String.IsNullOrEmpty(txt_FecVin2.Text) && !string.IsNullOrWhiteSpace(txt_FecVin2.Text))
            {
                cliente.FECHA_VIN_2 = Convert.ToDateTime(txt_FecVin2.Text);
            }
            else
            {
                cliente.FECHA_VIN_2 = null;
            }

            cliente.VIN_3 = txt_Vin3.Text;
            if (!String.IsNullOrEmpty(txt_FecVin3.Text) && !string.IsNullOrWhiteSpace(txt_FecVin3.Text))
            {
                cliente.FECHA_VIN_3 = Convert.ToDateTime(txt_FecVin3.Text);
            }
            else
            {
                cliente.FECHA_VIN_3 = null;
            }

            cliente.VIN_4 = txt_Vin4.Text;
            if (!String.IsNullOrEmpty(txt_FecVin4.Text) && !string.IsNullOrWhiteSpace(txt_FecVin4.Text))
            {
                cliente.FECHA_VIN_4 = Convert.ToDateTime(txt_FecVin4.Text);
            }
            else
            {
                cliente.FECHA_VIN_4 = null;
            }

            cliente.VIN_5 = txt_Vin5.Text;
            if (!String.IsNullOrEmpty(txt_FecVin5.Text) && !string.IsNullOrWhiteSpace(txt_FecVin5.Text))
            {
                cliente.FECHA_VIN_5 = Convert.ToDateTime(txt_FecVin5.Text);
            }
            else
            {
                cliente.FECHA_VIN_5 = null;
            }

            cliente.ID_USUARIO_CREACION = Convert.ToInt32(Session["userID"].ToString());
            cliente.ID_USUARIO_ACTUALIZACION = Convert.ToInt32(Session["userID"].ToString());
            cliente.FECHA_CREACION = DateTime.Now;
            cliente.FECHA_ACTULIZACION = DateTime.Now;

            CLS_CLIENTE cls_Cli = new CLS_CLIENTE();
            DataTable resul = cls_Cli.SP_05_INSERTAR_CLIENTE(cliente);

            if (resul != null && resul.Rows.Count > 0)
            {
                CLS_AUDITORIA audi = new CLS_AUDITORIA();
                string IP = Request.UserHostAddress;
                string nombreCliente = $"{txt_PrimerNombre.Text} {txt_SegundoNombre.Text} {txt_Apellidos.Text}";
                audi.SP_02_INSERTAR_AUDITORIA("REGISTRAR CLIENTE", $"El usuario {Session["nombre_usuario"]} regitro al cliente {nombreCliente}", "LOGIN", IP, Convert.ToInt32(Session["userID"].ToString()));


                Message_Succes.Text = "Cliente creado correctamente";
                Message_Succes.Visible = true;

                string clie = resul.Rows[0]["CLIENTE"].ToString();

                Response.Redirect($"/MODULOS/frm_Ventas.aspx?CLIENT_ID={clie}");
            }
            else
            {
                Message_danger.Text = "Error al crear cliente, por favor revise los datos";
                Message_danger.Visible = true;
            }
        }

        protected void btn_Actualizar_Click(object sender, EventArgs e)
        {
            string idCliente = "";
            try
            {
                idCliente = Page.Request.QueryString["CLIENT_ID"].ToString();
            }
            catch (Exception)
            {
            }
            //validar campos
            Response res = new Response();
            res = validarCampos("Nuevo_usuario");
            if (!res.Succ)
            {
                Message_warning.Text = res.Message;
                Message_warning.Visible = true;
                return;
            }

            LTM_CLIENTE cliente = new LTM_CLIENTE();
            cliente.PRIMER_NOMBRE = txt_PrimerNombre.Text;
            cliente.SEGUNDO_NOMBRE = txt_SegundoNombre.Text;
            cliente.APELLIDOS = txt_Apellidos.Text;
            cliente.CORREO = txt_Corre.Text;
            cliente.TELEFONO_MOVIL = txt_Telefono.Text;
            cliente.DIRECCION_RESIDENCIA = txt_DirecResidencia.Text;
            cliente.DIRECCION_CORRESPONDENCIA = txt_DireCorrespond.Text;
            cliente.FECHA_NACIMIENTO = Convert.ToDateTime(txt_fechaNacimiento.Text);
            cliente.ID_CONDUCCION = txt_IDconducion.Text;
            cliente.CIUDAD = txt_Ciudad.Text;
            cliente.ESTADO = txt_Estado.Text;
            cliente.CODIGO_POSTAL = txt_CodigoPostal.Text;
            cliente.NOMBRE_EMPRESA = txt_NombreEmpresa.Text;
            cliente.VIN_1 = txt_Vin1.Text;
            if (!String.IsNullOrEmpty(txt_FecVin1.Text) && !string.IsNullOrWhiteSpace(txt_FecVin1.Text))
            {
                cliente.FECHA_VIN_1 = Convert.ToDateTime(txt_FecVin1.Text);
            }
            else
            {
                cliente.FECHA_VIN_1 = null;
            }
            cliente.VIN_2 = txt_Vin2.Text;
            if (!String.IsNullOrEmpty(txt_FecVin2.Text) && !string.IsNullOrWhiteSpace(txt_FecVin2.Text))
            {
                cliente.FECHA_VIN_2 = Convert.ToDateTime(txt_FecVin2.Text);
            }
            else
            {
                cliente.FECHA_VIN_2 = null;
            }
            cliente.VIN_3 = txt_Vin3.Text;
            if (!String.IsNullOrEmpty(txt_FecVin3.Text) && !string.IsNullOrWhiteSpace(txt_FecVin3.Text))
            {
                cliente.FECHA_VIN_3 = Convert.ToDateTime(txt_FecVin3.Text);
            }
            else
            {
                cliente.FECHA_VIN_3 = null;
            }

            cliente.VIN_4 = txt_Vin4.Text;
            if (!String.IsNullOrEmpty(txt_FecVin4.Text) && !string.IsNullOrWhiteSpace(txt_FecVin4.Text))
            {
                cliente.FECHA_VIN_4 = Convert.ToDateTime(txt_FecVin4.Text);
            }
            else
            {
                cliente.FECHA_VIN_4 = null;
            }

            cliente.VIN_5 = txt_Vin5.Text;
            if (!String.IsNullOrEmpty(txt_FecVin5.Text) && !string.IsNullOrWhiteSpace(txt_FecVin5.Text))
            {
                cliente.FECHA_VIN_5 = Convert.ToDateTime(txt_FecVin5.Text);
            }
            else
            {
                cliente.FECHA_VIN_5 = null;
            }

            cliente.ID_USUARIO_ACTUALIZACION = Convert.ToInt32(Session["userID"].ToString());
            cliente.FECHA_ACTULIZACION = DateTime.Now;



            CLS_CLIENTE cls_Cli = new CLS_CLIENTE();
            int resul = cls_Cli.SP_07_ACTUALIZAR_CLIENTE(cliente, idCliente);

            if (resul > 0)
            {
                CLS_AUDITORIA audi = new CLS_AUDITORIA();
                string IP = Request.UserHostAddress;
                string nombreCliente = $"{txt_PrimerNombre.Text} {txt_SegundoNombre.Text} {txt_Apellidos.Text}";

                audi.SP_02_INSERTAR_AUDITORIA("ACTUALIZAR CLIENTE", $"El usuario {Session["nombre_usuario"]} actualizo los datos del cliente {nombreCliente}", "VENTAS", IP, Convert.ToInt32(Session["userID"].ToString()));

                OcultarControles("ACTUALIZAR");

                Message_Succes.Text = "Cliente actualizado correctamente";
                Message_Succes.Visible = true;
            }
            else
            {
                Message_danger.Text = "Error al actualizar cliente, por favor revise los datos";
                Message_danger.Visible = true;
                return;
            }
        }

        protected void btn_MostrarInfo_Click(object sender, EventArgs e)
        {
            btn_MostrarInfo.Visible = false;
            pnll_info2.Visible = true;
            OcultarControles("O_MENSAGE");
        }

        protected void btn_OcultarInfo_Click(object sender, EventArgs e)
        {
            btn_MostrarInfo.Visible = true;
            pnll_info2.Visible = false;

            OcultarControles("O_MENSAGE");

        }
        #endregion

        #region CREAR NOTAS
        protected void btn_NuevaNota_Click(object sender, EventArgs e)
        {
            txt_nota.Value = "";
            mpe_NuevaNota.Show();
            OcultarControles("O_MENSAGE");
        }

        protected void btn_cerrar_Click(object sender, EventArgs e)
        {
            txt_nota.Value = "";
            mpe_NuevaNota.Hide();
            OcultarControles("O_MENSAGE");
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
            int resul = cls_Cli.SP_08_NUEVA_NOTA(txt_nota.Value, Convert.ToInt32(Session["userID"].ToString()), "VISIBLE", "VENTAS", Convert.ToInt32(idCliente));

            if (resul > 0)
            {
                txt_nota.Value = "";

                CLS_AUDITORIA audi = new CLS_AUDITORIA();
                string IP = Request.UserHostAddress;
                string nombreCliente = $"{txt_PrimerNombre.Text} {txt_SegundoNombre.Text} {txt_Apellidos.Text}";
                audi.SP_02_INSERTAR_AUDITORIA("CREAR NOTA", $"El usuario {Session["nombre_usuario"]} creo una nota al cliente {nombreCliente}", "VENTAS", IP, Convert.ToInt32(Session["userID"].ToString()));

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

        protected void gv_Notas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string idCliente = "";
            try
            {
                idCliente = Page.Request.QueryString["CLIENT_ID"].ToString();
            }
            catch (Exception)
            {
            }

            if (e.CommandName == "EliminarNota")
            {
                GridViewRow gvRow = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int rowIndex = gvRow.RowIndex;
                string id = gv_Notas.DataKeys[gvRow.RowIndex].Value.ToString();


                CLS_NOTAS cls_Cli = new CLS_NOTAS();
                int resul = cls_Cli.SP_09_ELIMINAR_NOTA(Convert.ToInt32(id), "ELIMINADO", Convert.ToInt32(Session["userID"].ToString()));

                if (resul > 0)
                {
                    txt_nota.Value = "";

                    CLS_AUDITORIA audi = new CLS_AUDITORIA();
                    string IP = Request.UserHostAddress;
                    string nombreCliente = $"{txt_PrimerNombre.Text} {txt_SegundoNombre.Text} {txt_Apellidos.Text}";
                    audi.SP_02_INSERTAR_AUDITORIA("ELIMINAR NOTA", $"El usuario {Session["nombre_usuario"]} elimino la nota '{id}' del cliente {nombreCliente}", "VENTAS", IP, Convert.ToInt32(Session["userID"].ToString()));

                    NotasCliente(idCliente);

                    Message_Succes.Text = "Nota eliminada correctamente";
                    Message_Succes.Visible = true;
                }
                else
                {
                    Message_danger.Text = "Error al elimnar nota, por favor revise los datos";
                    Message_danger.Visible = true;
                }
            }
        }

        #endregion

        #region PRODUCTOS
        protected void btn_nuevoProducto_Click(object sender, EventArgs e)
        {
            mpe_Produc.Show();
            OcultarControles("O_MENSAGE");
            LimpiarControles("NUEVO_PRODUCTO");

            btn_ActualizarProduto.Visible = false;
            btn_aceptar.Visible = true;
            hf_Producto.Value = "";
        }

        //Cargar la lista de cuotas
        protected void gvEmployeeDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblEmpID = (Label)e.Row.FindControl("lbl_IdProducto");
                GridView gv_Child = (GridView)e.Row.FindControl("gv_Cuotas");

                string txtempid = lblEmpID.Text;

                CLS_PRODUCTOS cls_Cli = new CLS_PRODUCTOS();

                GridView gv_Endos = (GridView)e.Row.FindControl("gv_Endosos");
                DataTable dt_endoso = cls_Cli.SP_34_GET_LISTA_ENDOSOS(txtempid);
                if (dt_endoso != null && dt_endoso.Rows.Count > 0)
                {
                    gv_Endos.DataSource = dt_endoso;
                    gv_Endos.DataBind();
                }


                DataTable notas = cls_Cli.SP_17_GET_LISTA_PRODUCTO_ASOCIADOS(txtempid);
                if (notas != null && notas.Rows.Count > 0)
                {
                    gv_Child.DataSource = notas;
                    gv_Child.DataBind();
                }



            }
        }

        //opciones del grid de lista de productos asociados
        protected void gvEmployeeDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "VerProducto")
            {
                GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                string varName1 = Convert.ToString(((Label)gvRow.FindControl("lbl_IdProducto")).Text.ToString());

                btn_ActualizarProduto.Visible = true;
                btn_aceptar.Visible = false;
                hf_Producto.Value = varName1;
                DetallesProducto(varName1);
            }

            if (e.CommandName == "ImprimirProducto")
            {

            }

            if (e.CommandName == "VerArchivos")
            {
                GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                string varName1 = Convert.ToString(((Label)gvRow.FindControl("lbl_IdProducto")).Text.ToString());

                mpe_Archivos.Show();
                ListaArchivos(varName1, "PRODUCTOS");
            }
        }

        #region EVENTOS SELECCION
        protected void bl_TipoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            mpe_Produc.Show();
            string id = bl_TipoProducto.SelectedValue;
            TiposProductos(Convert.ToInt32(id));

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

                EstadosProductos(Convert.ToInt32(id));
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

                dv_ValorTramite.Visible = true;
                dv_valorServicio.Visible = true;
                dv_Impuestos.Visible = true;
                dv_CostosSeguro.Visible = false;
                dv_ProximoPago.Visible = false;
            }
        }

        protected void bl_CatProduc_SelectedIndexChanged(object sender, EventArgs e)
        {
            mpe_Produc.Show();

            string id = bl_CatProduc.SelectedValue;
            ListaCompañias(Convert.ToInt32(id));

            if (bl_CatProduc.SelectedItem.Text == "TIKET")
            {
                txt_reserva.Enabled = true;
            }
            else
            {
                txt_reserva.Enabled = false;
            }
        }

        protected void bl_CompaniaSe_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_CodInterno.Text = bl_CompaniaSe.SelectedValue;
            mpe_Produc.Show();
        }

        protected void bl_Tipopago_SelectedIndexChanged(object sender, EventArgs e)
        {
            OcultarControles("O_MENSAGE");

            if (Convert.ToInt32(txt_Costo.Text) >= Convert.ToInt32(txt_valor.Text))
            {
                bl_Tipopago.SelectedValue = "3";
                bl_Tipopago.Enabled = false;

                bl_Numcuotas.SelectedValue = "0";
                bl_Numcuotas.Enabled = false;
            }
            else
            {
                bl_Tipopago.SelectedValue = "2";
                bl_Tipopago.Enabled = true;

                bl_Numcuotas.SelectedValue = "1";
                bl_Numcuotas.Enabled = true;
            }

            if (bl_Tipopago.SelectedItem.Text == "Cuotas")
            {

                if (Convert.ToInt32(txt_Costo.Text) >= Convert.ToInt32(txt_valor.Text))
                {
                    bl_Tipopago.SelectedValue = "3";

                    bl_Numcuotas.SelectedValue = "0";
                    bl_Numcuotas.Enabled = false;
                }
                else
                {

                    bl_Numcuotas.SelectedValue = "1";
                    bl_Numcuotas.Enabled = true;
                }

                //bl_Numcuotas.Enabled = true;
                //bl_Numcuotas.SelectedValue = "1";
            }
            else
            {

                if (Convert.ToInt32(txt_Costo.Text) < Convert.ToInt32(txt_valor.Text))
                {
                    bl_Tipopago.SelectedValue = "2";
                    bl_Numcuotas.SelectedValue = "1";
                    bl_Numcuotas.Enabled = true;
                }
                else
                {
                    bl_Numcuotas.SelectedValue = "0";
                    bl_Numcuotas.Enabled = false;
                }
            }
            mpe_Produc.Show();
        }

        protected void txt_tarjetaCedito_TextChanged(object sender, EventArgs e)
        {
            OcultarControles("O_MENSAGE");

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
        #endregion

        //Nuevo seguro
        protected void btn_aceptar_Click(object sender, EventArgs e)
        {
            string idCliente = "";
            try
            {
                idCliente = Page.Request.QueryString["CLIENT_ID"].ToString();
            }
            catch (Exception)
            {
            }
            ////validar campos
            Response res = new Response();
            res = validarCampos("Nuevo_Producto");
            if (!res.Succ)
            {
                Message_warning.Text = res.Message;
                Message_warning.Visible = true;
                mpe_Produc.Show();
                return;
            }

            LTM_PRODUCTO cliente = new LTM_PRODUCTO();
            cliente.TIPO_PRODUCTO = Convert.ToInt32(bl_TipoProducto.SelectedValue);
            cliente.ID_CATEGORIA_TIPO_PRODUCTO = Convert.ToInt32(bl_CatProduc.SelectedValue);
            if (bl_TipoProducto.SelectedItem.Text == "SEGURO")
            {
                cliente.ESTADO_PRODUCTO = Convert.ToInt32(BL_EstadosProdu.SelectedValue);
                cliente.NUMERO_POLIZA = txt_numPoliza.Text;
            }
            else
            {
                cliente.ESTADO_PRODUCTO = null;
                cliente.NUMERO_POLIZA = bl_TipoProducto.SelectedItem.Text;
            }

            cliente.FECHA_INICIO = Convert.ToDateTime(txt_FechInicio.Text);
            cliente.FECHA_CADUCIDAD = Convert.ToDateTime(txt_fechCaduci.Text);
            cliente.ID_COMPANIA_SEGUROS = bl_CompaniaSe.SelectedValue;
            cliente.CODIGO_INTERNO = txt_CodInterno.Text;
            cliente.DATOS_AUXILIAR = Convert.ToInt32(Session["userID"].ToString());
            cliente.ID_CLIENTE = Convert.ToInt32(idCliente);



            if (!string.IsNullOrEmpty(txt_valor.Text) || !string.IsNullOrWhiteSpace(txt_valor.Text))
            {
                cliente.VALOR_PRODUCTO = Convert.ToDecimal(txt_valor.Text);
            }
            else
            {
                cliente.VALOR_PRODUCTO = null;
            }

            if (!string.IsNullOrEmpty(txt_Costo.Text) || !string.IsNullOrWhiteSpace(txt_Costo.Text))
            {
                cliente.COSTO = Convert.ToDecimal(txt_Costo.Text);
            }
            else
            {
                cliente.COSTO = null;
            }

            if (!string.IsNullOrEmpty(txt_SerAdicional.Text) || !string.IsNullOrWhiteSpace(txt_SerAdicional.Text))
            {
                cliente.SERVICIO_ADICIONAL = Convert.ToDecimal(txt_SerAdicional.Text);
            }
            else
            {
                cliente.SERVICIO_ADICIONAL = null;
            }

            cliente.CASH_OUT = txt_CashOut.Text;
            if (!string.IsNullOrEmpty(txt_tarjetaCedito.Text) || !string.IsNullOrWhiteSpace(txt_tarjetaCedito.Text))
            {
                cliente.TARJETA_CREDITO = Convert.ToDecimal(txt_tarjetaCedito.Text);
            }
            else
            {
                cliente.TARJETA_CREDITO = null;
            }

            if (!string.IsNullOrEmpty(txt_pagoEfectivo.Text) || !string.IsNullOrWhiteSpace(txt_pagoEfectivo.Text))
            {
                cliente.PAGO_EFECTIVO = Convert.ToDecimal(txt_pagoEfectivo.Text);
            }
            else
            {
                cliente.PAGO_EFECTIVO = null;
            }

            if (!string.IsNullOrEmpty(txt_recargo.Text) || !string.IsNullOrWhiteSpace(txt_recargo.Text))
            {
                cliente.RECARGO = Convert.ToDecimal(txt_recargo.Text);
            }
            else
            {
                cliente.RECARGO = null;
            }

            cliente.TIPO_PAGO = bl_Tipopago.SelectedItem.Text;
            if (bl_Tipopago.SelectedItem.Text == "Cuotas")
            {
                cliente.NUMERO_CUOTAS = Convert.ToInt32(bl_Numcuotas.SelectedValue);
            }
            else
            {
                cliente.NUMERO_CUOTAS = null;
            }

            if (!string.IsNullOrEmpty(txt_proximoPago.Text) || !string.IsNullOrWhiteSpace(txt_proximoPago.Text))
            {
                cliente.FECHA_PROXIMO_PAGO = Convert.ToDateTime(txt_proximoPago.Text);
            }
            else
            {
                cliente.FECHA_PROXIMO_PAGO = null;
            }

            if (!string.IsNullOrEmpty(txt_Intsallmentfee.Text) || !string.IsNullOrWhiteSpace(txt_Intsallmentfee.Text))
            {
                cliente.INTSALLMENTFEE = Convert.ToDecimal(txt_Intsallmentfee.Text);
            }
            else
            {
                cliente.INTSALLMENTFEE = null;
            }

            cliente.NOMBRE_EMPRESA = txtx_NombreEmpresa.Text;
            cliente.PROSPECTO = Convert.ToBoolean(cb_prospecto.Checked);


            cliente.FECHA_INICIO = Convert.ToDateTime(txt_FechInicio.Text);
            if (!string.IsNullOrEmpty(txt_reserva.Text) || !string.IsNullOrWhiteSpace(txt_reserva.Text))
            {
                cliente.RESERVA = Convert.ToDecimal(txt_reserva.Text);
            }
            else
            {
                cliente.RESERVA = null;
            }

            if (!string.IsNullOrEmpty(txt_ValorTramite.Text) || !string.IsNullOrWhiteSpace(txt_ValorTramite.Text))
            {
                cliente.VALOR_TRAMITE = Convert.ToDecimal(txt_ValorTramite.Text);
            }
            else
            {
                cliente.VALOR_TRAMITE = null;
            }

            if (!string.IsNullOrEmpty(txt_ValorTerceros.Text) || !string.IsNullOrWhiteSpace(txt_ValorTerceros.Text))
            {
                cliente.COSTO_TERCEROS = Convert.ToDecimal(txt_ValorTerceros.Text);
            }
            else
            {
                cliente.COSTO_TERCEROS = null;
            }

            if (!string.IsNullOrEmpty(txt_ValorServicio.Text) || !string.IsNullOrWhiteSpace(txt_ValorServicio.Text))
            {
                cliente.VALOR_SERVICIO = Convert.ToDecimal(txt_ValorServicio.Text);
            }
            else
            {
                cliente.VALOR_SERVICIO = null;
            }

            if (!string.IsNullOrEmpty(txt_valorTotal.Text) || !string.IsNullOrWhiteSpace(txt_valorTotal.Text))
            {
                cliente.VALOR_TOTAL = Convert.ToDecimal(txt_valorTotal.Text);
            }
            else
            {
                cliente.VALOR_TOTAL = null;
            }

            if (!string.IsNullOrEmpty(txt_Impuesto.Text) || !string.IsNullOrWhiteSpace(txt_Impuesto.Text))
            {
                cliente.EXCEDENTE_IMPUESTO = Convert.ToDecimal(txt_Impuesto.Text);
            }
            else
            {
                cliente.EXCEDENTE_IMPUESTO = null;
            }

            if (!string.IsNullOrEmpty(txt_Exc_tramite.Text) || !string.IsNullOrWhiteSpace(txt_Exc_tramite.Text))
            {
                cliente.EXCEDENTE_TRAMITE = Convert.ToDecimal(txt_Exc_tramite.Text);
            }
            else
            {
                cliente.EXCEDENTE_TRAMITE = null;
            }

            if (!string.IsNullOrEmpty(txt_totalCobrar.Text) || !string.IsNullOrWhiteSpace(txt_totalCobrar.Text))
            {
                cliente.TOTAL_COBRAR = Convert.ToDecimal(txt_totalCobrar.Text);
            }
            else
            {
                cliente.TOTAL_COBRAR = null;
            }

            //validar si es pago a la compañia de seguros
            string pagoCom = "";
            if (cbx_PagoCompania.Checked)
            {
                pagoCom = "True";
            }
            else
            {
                pagoCom = "False";
            }
            cliente.PAGO_COMPANIA = pagoCom;

            if (!string.IsNullOrEmpty(txt_pagoCompania.Text) || !string.IsNullOrWhiteSpace(txt_pagoCompania.Text))
            {
                cliente.VALOR_COMPANIA = Convert.ToDecimal(txt_pagoCompania.Text);
            }
            else
            {
                cliente.VALOR_COMPANIA = null;
            }

            cliente.OBSERVACION = txt_observacion.Value;

            CLS_PRODUCTOS cls_produ = new CLS_PRODUCTOS();
            string idArchivo = "";
            if (file_Producto.HasFile == true)
            {
                if (file_Producto.PostedFile.ContentLength > 1000000)
                {
                    Message_warning.Text = "El tamaño no puede ser mayo a 10 MB";
                    Message_warning.Visible = true;
                    mpe_Produc.Show();
                    return;
                }
                idArchivo = GuardarArchivos(file_Producto);
            }

            DataTable resul = null;
            resul = cls_produ.SP_14_INSERTAR_PRODUCTO(cliente);
            if (resul != null)
            {
                string idProducto = resul.Rows[0]["PRODUCTO"].ToString();

                if (!string.IsNullOrEmpty(idArchivo) && !string.IsNullOrWhiteSpace(idArchivo))
                {
                    cls_produ.SP_30_GUARDAR_FORMULARIO_ARCHIVOS(idArchivo, idCliente, idProducto, "PRODUCTOS");
                }


                CLS_AUDITORIA audi = new CLS_AUDITORIA();
                string IP = Request.UserHostAddress;
                string nombreCliente = $"{txt_PrimerNombre.Text} {txt_SegundoNombre.Text} {txt_Apellidos.Text}";

                audi.SP_02_INSERTAR_AUDITORIA("REGRISTAR PRODUCTO", $"El usuario {Session["nombre_usuario"]} registro un nuevo producto asociado al cliente cliente {nombreCliente}", "VENTAS", IP, Convert.ToInt32(Session["userID"].ToString()));

                OcultarControles("ACTUALIZAR");
                ProductosCliente(idCliente);

                Message_Succes.Text = "Producto registrado correctamente";
                Message_Succes.Visible = true;
            }
            else
            {
                Message_danger.Text = "Error al registrar producto, por favor revise los datos";
                Message_danger.Visible = true;
                return;
            }
        }

        protected void btn_imprimir_Click(object sender, EventArgs e)
        {

        }

        protected void btn_ActualizarProduto_Click(object sender, EventArgs e)
        {
            string idCliente = "";
            try
            {
                idCliente = Page.Request.QueryString["CLIENT_ID"].ToString();
            }
            catch (Exception)
            {
            }

            //validar campos
            Response res = new Response();
            res = validarCampos("Nuevo_Producto");
            if (!res.Succ)
            {
                Message_warning.Text = res.Message;
                Message_warning.Visible = true;
                mpe_Produc.Show();
                return;
            }

            LTM_PRODUCTO cliente = new LTM_PRODUCTO();
            cliente.TIPO_PRODUCTO = Convert.ToInt32(bl_TipoProducto.SelectedValue);
            cliente.ID_CATEGORIA_TIPO_PRODUCTO = Convert.ToInt32(bl_CatProduc.SelectedValue);
            if (bl_TipoProducto.SelectedItem.Text == "SEGURO")
            {
                cliente.ESTADO_PRODUCTO = Convert.ToInt32(BL_EstadosProdu.SelectedValue);

                if (BL_EstadosProdu.SelectedItem.Text.Contains("Cancelaci"))
                {
                    cliente.ESTADO_INTERNO = "CANCELADO";
                }
                else
                {
                    cliente.ESTADO_INTERNO = "ACTIVO";
                }
                //ESTADO_INTERNO
            }
            else
            {
                cliente.ESTADO_PRODUCTO = null;
                cliente.ESTADO_INTERNO = "ACTIVO";
            }

            cliente.NUMERO_POLIZA = txt_numPoliza.Text;
            cliente.FECHA_INICIO = Convert.ToDateTime(txt_FechInicio.Text);
            cliente.FECHA_CADUCIDAD = Convert.ToDateTime(txt_fechCaduci.Text);
            cliente.ID_COMPANIA_SEGUROS = bl_CompaniaSe.SelectedValue;
            cliente.CODIGO_INTERNO = txt_CodInterno.Text;
            cliente.DATOS_AUXILIAR = Convert.ToInt32(Session["userID"].ToString());
            cliente.ID_CLIENTE = Convert.ToInt32(idCliente);

            if (!string.IsNullOrEmpty(txt_valor.Text) || !string.IsNullOrWhiteSpace(txt_valor.Text))
            {
                cliente.VALOR_PRODUCTO = Convert.ToDecimal(txt_valor.Text);
            }
            else
            {
                cliente.VALOR_PRODUCTO = null;
            }

            if (!string.IsNullOrEmpty(txt_Costo.Text) || !string.IsNullOrWhiteSpace(txt_Costo.Text))
            {
                cliente.COSTO = Convert.ToDecimal(txt_Costo.Text);
            }
            else
            {
                cliente.COSTO = null;
            }

            if (!string.IsNullOrEmpty(txt_SerAdicional.Text) || !string.IsNullOrWhiteSpace(txt_SerAdicional.Text))
            {
                cliente.SERVICIO_ADICIONAL = Convert.ToDecimal(txt_SerAdicional.Text);
            }
            else
            {
                cliente.SERVICIO_ADICIONAL = null;
            }

            cliente.CASH_OUT = txt_CashOut.Text;

            if (!string.IsNullOrEmpty(txt_tarjetaCedito.Text) || !string.IsNullOrWhiteSpace(txt_tarjetaCedito.Text))
            {
                cliente.TARJETA_CREDITO = Convert.ToDecimal(txt_tarjetaCedito.Text);
            }
            else
            {
                cliente.TARJETA_CREDITO = null;
            }

            if (!string.IsNullOrEmpty(txt_pagoEfectivo.Text) || !string.IsNullOrWhiteSpace(txt_pagoEfectivo.Text))
            {
                cliente.PAGO_EFECTIVO = Convert.ToDecimal(txt_pagoEfectivo.Text);
            }
            else
            {
                cliente.PAGO_EFECTIVO = null;
            }

            if (!string.IsNullOrEmpty(txt_recargo.Text) || !string.IsNullOrWhiteSpace(txt_recargo.Text))
            {
                cliente.RECARGO = Convert.ToDecimal(txt_recargo.Text);
            }
            else
            {
                cliente.RECARGO = null;
            }

            cliente.TIPO_PAGO = bl_Tipopago.SelectedItem.Text;
            if (bl_Tipopago.SelectedItem.Text == "Cuotas")
            {
                cliente.NUMERO_CUOTAS = Convert.ToInt32(bl_Numcuotas.SelectedValue);
            }
            else
            {
                cliente.NUMERO_CUOTAS = null;
            }

            if (!string.IsNullOrEmpty(txt_proximoPago.Text) || !string.IsNullOrWhiteSpace(txt_proximoPago.Text))
            {
                cliente.FECHA_PROXIMO_PAGO = Convert.ToDateTime(txt_proximoPago.Text);
            }
            else
            {
                cliente.FECHA_PROXIMO_PAGO = null;
            }

            if (!string.IsNullOrEmpty(txt_Intsallmentfee.Text) || !string.IsNullOrWhiteSpace(txt_Intsallmentfee.Text))
            {
                cliente.INTSALLMENTFEE = Convert.ToDecimal(txt_Intsallmentfee.Text);
            }
            else
            {
                cliente.INTSALLMENTFEE = null;
            }

            cliente.NOMBRE_EMPRESA = txtx_NombreEmpresa.Text;
            cliente.PROSPECTO = Convert.ToBoolean(cb_prospecto.Checked);

            cliente.FECHA_INICIO = Convert.ToDateTime(txt_FechInicio.Text);
            if (!string.IsNullOrEmpty(txt_reserva.Text) || !string.IsNullOrWhiteSpace(txt_reserva.Text))
            {
                cliente.RESERVA = Convert.ToDecimal(txt_reserva.Text);
            }
            else
            {
                cliente.RESERVA = null;
            }

            if (!string.IsNullOrEmpty(txt_ValorTramite.Text) || !string.IsNullOrWhiteSpace(txt_ValorTramite.Text))
            {
                cliente.VALOR_TRAMITE = Convert.ToDecimal(txt_ValorTramite.Text);
            }
            else
            {
                cliente.VALOR_TRAMITE = null;
            }

            if (!string.IsNullOrEmpty(txt_ValorTerceros.Text) || !string.IsNullOrWhiteSpace(txt_ValorTerceros.Text))
            {
                cliente.COSTO_TERCEROS = Convert.ToDecimal(txt_ValorTerceros.Text);
            }
            else
            {
                cliente.COSTO_TERCEROS = null;
            }

            if (!string.IsNullOrEmpty(txt_ValorServicio.Text) || !string.IsNullOrWhiteSpace(txt_ValorServicio.Text))
            {
                cliente.VALOR_SERVICIO = Convert.ToDecimal(txt_ValorServicio.Text);
            }
            else
            {
                cliente.VALOR_SERVICIO = null;
            }

            if (!string.IsNullOrEmpty(txt_valorTotal.Text) || !string.IsNullOrWhiteSpace(txt_valorTotal.Text))
            {
                cliente.VALOR_TOTAL = Convert.ToDecimal(txt_valorTotal.Text);
            }
            else
            {
                cliente.VALOR_TOTAL = null;
            }

            if (!string.IsNullOrEmpty(txt_Impuesto.Text) || !string.IsNullOrWhiteSpace(txt_Impuesto.Text))
            {
                cliente.EXCEDENTE_IMPUESTO = Convert.ToDecimal(txt_Impuesto.Text);
            }
            else
            {
                cliente.EXCEDENTE_IMPUESTO = null;
            }

            if (!string.IsNullOrEmpty(txt_Exc_tramite.Text) || !string.IsNullOrWhiteSpace(txt_Exc_tramite.Text))
            {
                cliente.EXCEDENTE_TRAMITE = Convert.ToDecimal(txt_Exc_tramite.Text);
            }
            else
            {
                cliente.EXCEDENTE_TRAMITE = null;
            }

            if (!string.IsNullOrEmpty(txt_totalCobrar.Text) || !string.IsNullOrWhiteSpace(txt_totalCobrar.Text))
            {
                cliente.TOTAL_COBRAR = Convert.ToDecimal(txt_totalCobrar.Text);
            }
            else
            {
                cliente.TOTAL_COBRAR = null;
            }

            cliente.OBSERVACION = txt_observacion.Value;

            CLS_PRODUCTOS cls_produ = new CLS_PRODUCTOS();
            string idArchivo = "";
            //Byte[] Archivo = null;
            //string nombreArchivo = string.Empty;
            //string extensionArchivo = string.Empty;
            if (file_Producto.HasFile == true)
            {

                if (file_Producto.PostedFile.ContentLength > 10000000)
                {
                    Message_warning.Text = "El tamaño no puede ser mayo a 10 MB";
                    Message_warning.Visible = true;
                    mpe_Produc.Show();
                    return;
                }

                idArchivo = GuardarArchivos(file_Producto);
            }


            int resul = cls_produ.SP_19_ACTUALIZAR_PRODUCTO(cliente, hf_Producto.Value);

            if (resul > 0)
            {
                if (!string.IsNullOrEmpty(idArchivo) && !string.IsNullOrWhiteSpace(idArchivo))
                {
                    cls_produ.SP_30_GUARDAR_FORMULARIO_ARCHIVOS(idArchivo, idCliente, hf_Producto.Value, "PRODUCTOS");
                }

                CLS_AUDITORIA audi = new CLS_AUDITORIA();
                string IP = Request.UserHostAddress;
                string nombreCliente = $"{txt_PrimerNombre.Text} {txt_SegundoNombre.Text} {txt_Apellidos.Text}";

                audi.SP_02_INSERTAR_AUDITORIA("ACTUALIZAR PRODUCTO", $"El usuario {Session["nombre_usuario"]} actualizo el producto nuevo producto asociado al cliente cliente {nombreCliente}", "VENTAS", IP, Convert.ToInt32(Session["userID"].ToString()));

                OcultarControles("ACTUALIZAR");
                ProductosCliente(idCliente);

                Message_Succes.Text = "Producto registrado correctamente";
                Message_Succes.Visible = true;
            }
            else
            {
                Message_danger.Text = "Error al registrar producto, por favor revise los datos";
                Message_danger.Visible = true;
                return;
            }
        }

        protected void btn_cerrPro_Click(object sender, EventArgs e)
        {
            mpe_Produc.Hide();
            OcultarControles("O_MENSAGE");
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

            if (Convert.ToInt32(txt_Costo.Text) >= Convert.ToInt32(txt_valor.Text))
            {
                bl_Tipopago.SelectedValue = "3";
                bl_Tipopago.Enabled = false;

                bl_Numcuotas.SelectedValue = "0";
                bl_Numcuotas.Enabled = false;
            }
            else
            {
                bl_Tipopago.SelectedValue = "2";
                bl_Tipopago.Enabled = true;

                bl_Numcuotas.SelectedValue = "1";
                bl_Numcuotas.Enabled = true;
            }
            mpe_Produc.Show();
        }
        #endregion

        #region CUOTAS
        protected void gv_Cuotas_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "VerCuota")
            {
                GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                string varName1 = Convert.ToString(((Label)gvRow.FindControl("lblCuotasProduc")).Text.ToString());

                DetallesCuota(varName1);
                mpe_Cuotas.Show();
            }

            if (e.CommandName == "ImprimirCuota")
            {
                //btn_ActualizarProduto.Visible = true;
                //btn_aceptar.Visible = false;
                //hf_Producto.Value = varName1;

                //DetallesProducto(varName1);
            }

            if (e.CommandName == "VerArchivosCuota")
            {
                GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                string varName1 = Convert.ToString(((Label)gvRow.FindControl("lblCuotasProduc")).Text.ToString());

                mpe_Archivos.Show();
                ListaArchivos(varName1, "CUOTAS");

            }
        }

        protected void btn_cerrarCuota_Click(object sender, EventArgs e)
        {
            mpe_Cuotas.Hide();
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
            string estado = null;// "PAGADO";
            decimal valorCuota = Convert.ToDecimal(txt_valorCuota.Text);
            decimal valorTarjeta = Convert.ToDecimal(txt_ValorPagarTarjeta.Text);
            decimal valorEfectivo = Convert.ToDecimal(txt_ValorPagarEfectivo.Text);
            decimal valorRecargo = Convert.ToDecimal(txt_ValorPagarRecargo.Text);
            decimal valorCompañia = Convert.ToDecimal(txt_pago_CompaniaCuota.Text);

            decimal costo = Convert.ToDecimal(txt_costoCuota.Text);

            string observacion = txt_ObservacionCuota.Value;
            int idUser = Convert.ToInt32(Session["userID"].ToString());

            decimal totalV = valorTarjeta + valorEfectivo - valorRecargo;

            //validar si es pago a la compañia de seguros
            string pagoCom = "";
            if (cbx_pagocompaniaCuota.Checked)
            {
                pagoCom = "True";
            }
            else
            {
                pagoCom = "False";

                if (total < 1)
                {
                    Message_danger.Text = "El valor pagado no puede ser menor a 0";
                    Message_danger.Visible = true;
                    mpe_Cuotas.Show();
                    return;
                }

                if (totalV < valorCuota)
                {
                    if (!cbx_PagoInferior.Checked)
                    {
                        Message_warning.Text = "El valor ingresado no puede ser menos al valor de la cuota";
                        Message_warning.Visible = true;
                        mpe_Cuotas.Show();

                        return;
                    }
                }

            }

            if (totalV > Convert.ToDecimal(hf_ValTotalCuota.Value))
            {
                Message_warning.Text = "El valor ingresado es mayor al valor total de la cuota";
                Message_warning.Visible = true;
                mpe_Cuotas.Show();
                return;
            }


            CLS_PRODUCTOS cls_produ = new CLS_PRODUCTOS();
            string idArchivo = "";
            if (file_Cuotas.HasFile == true)
            {
                if (file_Producto.PostedFile.ContentLength > 10000000)
                {
                    Message_warning.Text = "El tamaño no puede ser mayo a 10 MB";
                    Message_warning.Visible = true;
                    mpe_Cuotas.Show();

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



            if (cbx_Renovacion.Checked)
            {
                estado = "REINSTALACION";
            }
            else
            {
                estado = null;
            }


            if (totalV > valorCuota)
            {
                p_inf = 0;
            }

            int resul = cls_produ.SP_23_ACTUALIZAR_CUOTAS(idProducto, idCuota, estado, valorCuota, valorTarjeta, valorEfectivo, valorRecargo, observacion, idUser, p_inf, costo, pagoCom, valorCompañia);

            if (resul > 0)
            {
                txt_nota.Value = "";

                if (!string.IsNullOrEmpty(idArchivo) && !string.IsNullOrWhiteSpace(idArchivo))
                {
                    cls_produ.SP_30_GUARDAR_FORMULARIO_ARCHIVOS(idArchivo, idCliente, idCuota, "CUOTAS");
                }

                CLS_AUDITORIA audi = new CLS_AUDITORIA();
                string IP = Request.UserHostAddress;
                string nombreCliente = $"{txt_PrimerNombre.Text} {txt_SegundoNombre.Text} {txt_Apellidos.Text}";
                audi.SP_02_INSERTAR_AUDITORIA("ACTUALIZAR CUOTA", $"El usuario {Session["nombre_usuario"]} actualizo el valor de una cuota {nombreCliente}", "VENTAS", IP, Convert.ToInt32(Session["userID"].ToString()));

                ProductosCliente(idCliente);

                Message_Succes.Text = "Cuota actulizada correctamente correctamente";
                Message_Succes.Visible = true;
            }
            else
            {
                Message_danger.Text = "Error al actulizar cuota, por favor revise los datos";
                Message_danger.Visible = true;
                mpe_Cuotas.Show();
            }

        }

        protected void btn_ImprimirCuota_Click(object sender, EventArgs e)
        {

        }
        #endregion


        private void DatosCliente(string idCLiente)
        {
            CLS_CLIENTE cls_Cli = new CLS_CLIENTE();

            DataSet data = new DataSet();

            data = cls_Cli.SP_06_GET_DATOS_CLIENTES(idCLiente);

            if (data != null && data.Tables.Count > 0)
            {
                DataTable notas = new DataTable();
                try
                {
                    notas = data.Tables[1];
                }
                catch (Exception)
                {
                    notas = null;
                }


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

                //datos de venta
                txt_NombreCliente.Text = $"{data.Tables[0].Rows[0]["PRIMER_NOMBRE"].ToString()} {data.Tables[0].Rows[0]["APELLIDOS"].ToString()}";
                txt_NombreAuxiliar.Text = $"{ Session["nombre_usuario"]}";
                txtx_NombreEmpresa.Text = data.Tables[0].Rows[0]["NOMBRE_EMPRESA"].ToString();

                txt_PrimerNombre.Text = data.Tables[0].Rows[0]["PRIMER_NOMBRE"].ToString();
                txt_SegundoNombre.Text = data.Tables[0].Rows[0]["SEGUNDO_NOMBRE"].ToString();
                txt_Apellidos.Text = data.Tables[0].Rows[0]["APELLIDOS"].ToString();
                txt_Corre.Text = data.Tables[0].Rows[0]["CORREO"].ToString();
                txt_Telefono.Text = data.Tables[0].Rows[0]["TELEFONO_MOVIL"].ToString();
                txt_DirecResidencia.Text = data.Tables[0].Rows[0]["DIRECCION_RESIDENCIA"].ToString();
                txt_DireCorrespond.Text = data.Tables[0].Rows[0]["DIRECCION_CORRESPONDENCIA"].ToString();

                DateTime FechaNacimiento = Convert.ToDateTime(data.Tables[0].Rows[0]["FECHA_NACIMIENTO"]);
                txt_fechaNacimiento.Text = FechaNacimiento.ToString("yyyy-MM-dd");

                txt_IDconducion.Text = data.Tables[0].Rows[0]["ID_CONDUCCION"].ToString();
                txt_Ciudad.Text = data.Tables[0].Rows[0]["CIUDAD"].ToString();
                txt_Estado.Text = data.Tables[0].Rows[0]["ESTADO"].ToString();
                txt_CodigoPostal.Text = data.Tables[0].Rows[0]["CODIGO_POSTAL"].ToString();
                txt_NombreEmpresa.Text = data.Tables[0].Rows[0]["NOMBRE_EMPRESA"].ToString();

                txt_Vin1.Text = data.Tables[0].Rows[0]["VIN_1"].ToString();
                if (!String.IsNullOrEmpty(data.Tables[0].Rows[0]["FECHA_VIN_1"].ToString()) && !String.IsNullOrWhiteSpace(data.Tables[0].Rows[0]["FECHA_VIN_1"].ToString()))
                {
                    DateTime FECHA_VIN_1 = Convert.ToDateTime(data.Tables[0].Rows[0]["FECHA_VIN_1"]);
                    txt_FecVin1.Text = FECHA_VIN_1.ToString("yyyy-MM-dd");
                }

                txt_Vin2.Text = data.Tables[0].Rows[0]["VIN_2"].ToString();
                if (!String.IsNullOrEmpty(data.Tables[0].Rows[0]["FECHA_VIN_2"].ToString()) && !String.IsNullOrWhiteSpace(data.Tables[0].Rows[0]["FECHA_VIN_2"].ToString()))
                {
                    DateTime FECHA_VIN_2 = Convert.ToDateTime(data.Tables[0].Rows[0]["FECHA_VIN_2"]);
                    txt_FecVin2.Text = FECHA_VIN_2.ToString("yyyy-MM-dd");
                }

                txt_Vin3.Text = data.Tables[0].Rows[0]["VIN_3"].ToString();
                if (!String.IsNullOrEmpty(data.Tables[0].Rows[0]["FECHA_VIN_3"].ToString()) && !String.IsNullOrWhiteSpace(data.Tables[0].Rows[0]["FECHA_VIN_3"].ToString()))
                {
                    DateTime FECHA_VIN_3 = Convert.ToDateTime(data.Tables[0].Rows[0]["FECHA_VIN_3"]);
                    txt_FecVin3.Text = FECHA_VIN_3.ToString("yyyy-MM-dd");
                }

                txt_Vin4.Text = data.Tables[0].Rows[0]["VIN_4"].ToString();
                if (!String.IsNullOrEmpty(data.Tables[0].Rows[0]["FECHA_VIN_4"].ToString()) && !String.IsNullOrWhiteSpace(data.Tables[0].Rows[0]["FECHA_VIN_4"].ToString()))
                {
                    DateTime FECHA_VIN_4 = Convert.ToDateTime(data.Tables[0].Rows[0]["FECHA_VIN_4"]);
                    txt_FecVin4.Text = FECHA_VIN_4.ToString("yyyy-MM-dd");
                }

                txt_Vin5.Text = data.Tables[0].Rows[0]["VIN_5"].ToString();
                if (!String.IsNullOrEmpty(data.Tables[0].Rows[0]["FECHA_VIN_5"].ToString()) && !String.IsNullOrWhiteSpace(data.Tables[0].Rows[0]["FECHA_VIN_5"].ToString()))
                {
                    DateTime FECHA_VIN_5 = Convert.ToDateTime(data.Tables[0].Rows[0]["FECHA_VIN_5"]);
                    txt_FecVin5.Text = FECHA_VIN_5.ToString("yyyy-MM-dd");
                }

            }

        }

        private void OcultarControles(string tipo)
        {
            if (tipo == "NUEVO")
            {
                btn_Registra.Visible = true;
                btn_Actualizar.Visible = false;

                btn_NuevaNota.Enabled = false;
                btn_nuevoProducto.Enabled = false;

                btn_MostrarInfo.Visible = false;
                pnll_info2.Visible = true;
                btn_OcultarInfo.Visible = false;

            }
            if (tipo == "ACTUALIZAR")
            {

                Message_danger.Visible = false;
                Message_warning.Visible = false;
                Message_info.Visible = false;
                Message_Succes.Visible = false;

                btn_Registra.Visible = false;
                btn_Actualizar.Visible = true;
                btn_NuevaNota.Enabled = false;

                btn_NuevaNota.Enabled = true;
                btn_nuevoProducto.Enabled = true;

                btn_MostrarInfo.Visible = true;
                pnll_info2.Visible = false;
            }
            if (tipo == "O_MENSAGE")
            {
                Message_danger.Visible = false;
                Message_warning.Visible = false;
                Message_info.Visible = false;
                Message_Succes.Visible = false;
            }
            if (tipo == "O_BTN_PRODUCTO")
            {
                Message_danger.Visible = false;
                Message_warning.Visible = false;
                Message_info.Visible = false;
                Message_Succes.Visible = false;
            }
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

                DateTime FechInicio = DateTime.Now;
                txt_FechInicio.Text = FechInicio.ToString("yyyy-MM-dd");

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
                txt_pagoCompania.Text = "0";
                txt_proximoPago.Text = "";

                txt_ValorTramite.Text = "0";
                txt_ValorTerceros.Text = "0";
                txt_ValorServicio.Text = "0";
                txt_valorTotal.Text = "0";
                txt_Impuesto.Text = "0";
                txt_Exc_tramite.Text = "0";
                txt_totalCobrar.Text = "0";

                bl_Tipopago.SelectedValue = "1";
                bl_Numcuotas.SelectedValue = "0";

                bl_Tipopago.Enabled = false;
                bl_Numcuotas.Enabled = false;


                bl_CatProduc.Enabled = true;
                txt_numPoliza.Enabled = true;
                txt_FechInicio.Enabled = true;
                txt_fechCaduci.Enabled = true;
                bl_CompaniaSe.Enabled = true;
                txt_CodInterno.Enabled = true;

                txt_reserva.Enabled = true;
                txt_fechaRetiro.Enabled = true;
                txt_pagoCompania.Enabled = false;
                cbx_PagoCompania.Checked = true;

                txt_proximoPago.Enabled = true;

                txt_proximoPago.Text = "";
                txt_observacion.Value = "";


                txt_valor.Enabled = true;
                txt_Costo.Enabled = true;
                txt_SerAdicional.Enabled = true;
                txt_CashOut.Enabled = true;
                txt_tarjetaCedito.Enabled = true;
                txt_pagoEfectivo.Enabled = true;
                txt_recargo.Enabled = true;
                txt_Intsallmentfee.Enabled = true;
                txt_pagoCompania.Enabled = true;
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

                txt_pagoCompania.Enabled = false;
                cbx_PagoCompania.Enabled = false;

                txt_valor.Enabled = false;
                txt_Costo.Enabled = false;
                txt_SerAdicional.Enabled = false;
                txt_CashOut.Enabled = false;
                txt_tarjetaCedito.Enabled = false;
                txt_pagoEfectivo.Enabled = false;
                txt_recargo.Enabled = false;
                txt_Intsallmentfee.Enabled = false;
                txt_pagoCompania.Enabled = false;

                txt_proximoPago.Enabled = false;

                if (BL_EstadosProdu.SelectedItem.Text.Contains("Endoso"))
                {
                    bl_Tipopago.Enabled = false;
                    bl_Numcuotas.Enabled = false;
                    txt_valor.Enabled = true;
                    txt_Costo.Enabled = true;
                    txt_SerAdicional.Enabled = true;
                    txt_CashOut.Enabled = true;
                    txt_tarjetaCedito.Enabled = true;
                    txt_pagoEfectivo.Enabled = true;
                    txt_recargo.Enabled = true;
                    txt_Intsallmentfee.Enabled = true;
                    txt_pagoCompania.Enabled = true;
                    txt_proximoPago.Enabled = true;
                }
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

        private void ProductosCliente(string idCLiente)
        {

            CLS_PRODUCTOS cls_Cli = new CLS_PRODUCTOS();
            DataTable notas = cls_Cli.SP_16_GET_LISTA_PRODUCTO(idCLiente);

            if (notas != null && notas.Rows.Count > 0)
            {
                gvEmployeeDetails.DataSource = notas;
                gvEmployeeDetails.DataBind();
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


        }

        private void TiposProductos(int tipo)
        {

            CLS_PRODUCTOS cls_Prod = new CLS_PRODUCTOS();
            DataTable data = cls_Prod.SP_12_GET_TIPOS_PRODUCTO(tipo);

            if (data != null && data.Rows.Count > 0)
            {
                bl_CatProduc.DataSource = data;
                bl_CatProduc.DataBind();

                int tipoP = Convert.ToInt32(data.Rows[0]["ID_TIPO_PRODUCTO"].ToString());

                ListaCompañias(tipoP);
            }
        }

        private void ListaCompañias(int tipo)
        {
            bl_CompaniaSe.Items.Clear();

            CLS_PRODUCTOS cls_Prod = new CLS_PRODUCTOS();

            DataTable dataCompa = cls_Prod.SP_15_GET_COMPANIAS(tipo);
            if (dataCompa != null && dataCompa.Rows.Count > 0)
            {
                bl_CompaniaSe.DataSource = dataCompa;
                bl_CompaniaSe.DataBind();

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
            OcultarControles("O_MENSAGE");
        }

        private Response validarCampos(string tipo)
        {
            Response res = new Response();
            res.Succ = true;

            if (tipo == "Nuevo_usuario")
            {
                if (string.IsNullOrEmpty(txt_PrimerNombre.Text) || string.IsNullOrWhiteSpace(txt_PrimerNombre.Text))
                {
                    txt_PrimerNombre.Focus();
                    res.Message = "El nombre del cliente es un campo obligatorio.";
                    res.Succ = false;
                    return res;
                }

                if (string.IsNullOrEmpty(txt_Apellidos.Text) || string.IsNullOrWhiteSpace(txt_Apellidos.Text))
                {
                    txt_Apellidos.Focus();
                    res.Message = "El apellido del cliente es un campo obligatorio.";
                    res.Succ = false;
                    return res;
                }

                if (string.IsNullOrEmpty(txt_Telefono.Text) || string.IsNullOrWhiteSpace(txt_Telefono.Text))
                {
                    res.Message = "El numero de telefonos del cliente es un campo obligatorio.";
                    res.Succ = false;
                    return res;
                }

                if (string.IsNullOrEmpty(txt_DirecResidencia.Text) || string.IsNullOrWhiteSpace(txt_DirecResidencia.Text))
                {
                    res.Message = "La dirección de residencia del cliente es un campo obligatorio.";
                    res.Succ = false;
                    return res;
                }

                if (string.IsNullOrEmpty(txt_fechaNacimiento.Text) || string.IsNullOrWhiteSpace(txt_fechaNacimiento.Text))
                {
                    res.Message = "La fecha de naciemiento del cliente es un campo obligatorio.";
                    res.Succ = false;
                    return res;
                }

                if (string.IsNullOrEmpty(txt_IDconducion.Text) || string.IsNullOrWhiteSpace(txt_IDconducion.Text))
                {
                    res.Message = "El ID de conducción del cliente es un campo obligatorio.";
                    res.Succ = false;
                    return res;
                }

                if (string.IsNullOrEmpty(txt_Ciudad.Text) || string.IsNullOrWhiteSpace(txt_Ciudad.Text))
                {
                    res.Message = "La ciudad del cliente es un campo obligatorio.";
                    res.Succ = false;
                    return res;
                }

                if (string.IsNullOrEmpty(txt_Estado.Text) || string.IsNullOrWhiteSpace(txt_Estado.Text))
                {
                    res.Message = "El estado es un campo obligatorio.";
                    res.Succ = false;
                    return res;
                }

                if (string.IsNullOrEmpty(txt_CodigoPostal.Text) || string.IsNullOrWhiteSpace(txt_CodigoPostal.Text))
                {
                    res.Message = "El codigo postal es un campo obligatorio.";
                    res.Succ = false;
                    return res;
                }

            }

            if (tipo == "Nuevo_Producto")
            {

                if (string.IsNullOrEmpty(txt_pagoEfectivo.Text) || string.IsNullOrWhiteSpace(txt_fechCaduci.Text))
                {
                    if (string.IsNullOrEmpty(txt_tarjetaCedito.Text) || string.IsNullOrWhiteSpace(txt_tarjetaCedito.Text))
                    {
                        res.Message = "Debe ingresar un valor en el campo tarjeta de credito o pago en efectivo";
                        res.Succ = false;
                        return res;
                    }
                }

                if (bl_Tipopago.SelectedItem.Text == "Seleccionar")
                {
                    res.Message = "El tipo de pago es un campo obligatorio.";
                    res.Succ = false;
                    return res;
                }


                if (bl_TipoProducto.SelectedItem.Text == "SEGURO")
                {
                    if (bl_CompaniaSe.SelectedItem.Text == "SELECCIONAR")
                    {
                        res.Message = "La compañia de seguros es un campo obligatorio.";
                        res.Succ = false;
                        return res;
                    }

                    if (string.IsNullOrEmpty(txt_numPoliza.Text) || string.IsNullOrWhiteSpace(txt_numPoliza.Text))
                    {
                        res.Message = "El numero de poliza es un campo obligatorio.";
                        res.Succ = false;
                        return res;
                    }

                    if (string.IsNullOrEmpty(txt_FechInicio.Text) || string.IsNullOrWhiteSpace(txt_FechInicio.Text))
                    {
                        res.Message = "El la fecha de inicio es un campo obligatorio.";
                        res.Succ = false;
                        return res;
                    }

                    if (string.IsNullOrEmpty(txt_fechCaduci.Text) || string.IsNullOrWhiteSpace(txt_fechCaduci.Text))
                    {
                        res.Message = "El la fecha de caducidad es un campo obligatorio.";
                        res.Succ = false;
                        return res;
                    }

                }
                else
                {
                    if (string.IsNullOrEmpty(txt_FechInicio.Text) || string.IsNullOrWhiteSpace(txt_FechInicio.Text))
                    {
                        res.Message = "El la fecha de inicio es un campo obligatorio.";
                        res.Succ = false;
                        return res;
                    }
                }

            }
            return res;
        }

        private void ListaArchivos(string idProducto, string tipo)
        {
            string idCliente = "";
            try
            {
                idCliente = Page.Request.QueryString["CLIENT_ID"].ToString();
            }
            catch (Exception)
            {
            }

            CLS_PRODUCTOS cls_Cli = new CLS_PRODUCTOS();
            DataTable dt_archivos = cls_Cli.SP_31_GET_ARCHIVOS_CLIENTE(idCliente, idProducto, tipo);

            if (dt_archivos != null && dt_archivos.Rows.Count > 0)
            {
                lbl_msgArchivos.Visible = false;
                int secu = 1;
                foreach (DataRow row in dt_archivos.Rows)
                {
                    Image img = new Image();
                    img.Width = 190;
                    img.Height = 170;
                    img.CssClass = "col-md-6 col-sm-6";

                    HyperLink hlink = new HyperLink();
                    hlink.Text = $"{Convert.ToString(secu)} - {row["NOMBRE_ARCHIVO"].ToString()}";
                    hlink.CssClass = "col-md-12 col-sm-12";
                    hlink.Target = "_blank";

                    //if (row["TIPO_ARVIVO"].ToString().ToUpper() == ".JPG" || row["TIPO_ARVIVO"].ToString().ToUpper() == ".PNG" || row["TIPO_ARVIVO"].ToString().ToUpper() == ".GIF" || row["TIPO_ARVIVO"].ToString().ToUpper() == ".JPEG")
                    //{
                    //    img.ImageUrl = "~/Datos/CARGA_ARCHIVOS/QSM_ALT_ImageHandler.ashx?PK=" + Convert.ToString(row["ID_ARCHIVO"].ToString());
                    //    pnl_Dinamic.Controls.Add(img);
                    //}
                    //else
                    //{
                    secu = secu + 1;
                    hlink.NavigateUrl = "~/Datos/CARGA_ARCHIVOS/QSM_ALT_DocumentHandler.ashx?documentID=" + Convert.ToString(row["ID_ARCHIVO"].ToString()) + "&form=View";// "&form=Down";
                    pnl_Dinamic.Controls.Add(hlink);
                    //}



                }
                ///img_test.ImageUrl = "~/Datos/CARGA_ARCHIVOS/QSM_ALT_ImageHandler.ashx?PK=" + Convert.ToString(dt_archivos.Rows[0]["ID_ARCHIVO"].ToString());
            }
            else
            {
                lbl_msgArchivos.Visible = true;
            }
        }

        protected void guardaArchivo(byte[] archivo, string nombreArchivo)
        {
            string excel_path = ConfigurationManager.AppSettings.Get("EXCELPATH");
            string excel_file = nombreArchivo;

            try
            {
                excel_path = excel_path + excel_file;

                FileStream archivo_fisico = new FileStream(excel_path, FileMode.Create, FileAccess.Write);
                foreach (byte b in archivo)
                {
                    archivo_fisico.WriteByte(b);
                }
                archivo_fisico.Close();
            }
            catch (Exception ex)
            {
                throw ex;
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

        private void DetallesCuota(string idCuota)
        {
            CLS_PRODUCTOS cls_Cli = new CLS_PRODUCTOS();
            DataTable dt_Cuotas = cls_Cli.SP_22_GET_DETALLES_CUOTA(idCuota);

            if (dt_Cuotas != null && dt_Cuotas.Rows.Count > 0)
            {
                hf_IDCUOTA.Value = dt_Cuotas.Rows[0]["ID_PRODUCTO_ASOCIADO"].ToString();
                hf_ID_PRODUCTO_CUOTA.Value = dt_Cuotas.Rows[0]["ID_PRODUCTO"].ToString();
                hf_ValTotalCuota.Value = dt_Cuotas.Rows[0]["TOTAL_CUOTAS"].ToString();

                txt_Cuotas_producto.Text = dt_Cuotas.Rows[0]["PRODUCTO"].ToString();
                txt_Cuotas_Categoria.Text = dt_Cuotas.Rows[0]["CATEGORIA"].ToString();
                txt_Cuotas_EstadoSeguro.Text = dt_Cuotas.Rows[0]["ESTADO_SEGURO"].ToString();
                txt_Cuota.Text = dt_Cuotas.Rows[0]["SECUENCIA"].ToString();

                DateTime proximoPago = Convert.ToDateTime(dt_Cuotas.Rows[0]["FECHA_PROXIMO_PAGO"].ToString());
                txt_fproximoPago.Text = proximoPago.ToString("yyyy-MM-dd");

                txt_EstodoCuota.Text = dt_Cuotas.Rows[0]["ESTADO_CUOTA"].ToString();
                txt_valorCuota.Text = dt_Cuotas.Rows[0]["COSTO_CUOTA"].ToString();

                if (dt_Cuotas.Rows[0]["ESTADO_CUOTA"].ToString() == "PAGADO" || dt_Cuotas.Rows[0]["ESTADO_CUOTA"].ToString() == "REINSTALACION")
                {
                    btn_AceptarCuotas.Visible = false;

                    txt_costoCuota.Text = dt_Cuotas.Rows[0]["COSTO_CUOTA"].ToString();
                    txt_costoCuota.Enabled = false;

                    txt_ValorPagarTarjeta.Text = dt_Cuotas.Rows[0]["VALOR_PAGADO_TARJETA"].ToString();
                    txt_ValorPagarTarjeta.Enabled = false;

                    txt_ValorPagarEfectivo.Text = dt_Cuotas.Rows[0]["VALOR_PAGADO_EFECTIVO"].ToString();
                    txt_ValorPagarEfectivo.Enabled = false;

                    txt_ValorPagarRecargo.Text = dt_Cuotas.Rows[0]["VALOR_RECARGO"].ToString();
                    txt_ValorPagarRecargo.Enabled = false;

                    txt_ObservacionCuota.Value = dt_Cuotas.Rows[0]["OBSERVACION"].ToString();
                    //txt_ObservacionCuota.EnableTheming = false;

                    cbx_Renovacion.Enabled = false;
                    if (dt_Cuotas.Rows[0]["ESTADO_CUOTA"].ToString() == "REINSTALACION")
                    {
                        cbx_Renovacion.Checked = true;
                    }
                    else
                    {
                        cbx_Renovacion.Checked = false;
                    }

                    decimal total = Convert.ToDecimal(dt_Cuotas.Rows[0]["VALOR_PAGADO_TARJETA"].ToString())
                        + Convert.ToDecimal(dt_Cuotas.Rows[0]["VALOR_PAGADO_TARJETA"].ToString());

                    cbx_PagoInferior.Enabled = false;
                    if (total < Convert.ToDecimal(dt_Cuotas.Rows[0]["COSTO_CUOTA"].ToString()))
                    {
                        cbx_PagoInferior.Checked = true;
                    }
                    else
                    {
                        cbx_PagoInferior.Checked = false;
                    }



                    txt_pago_CompaniaCuota.Text = dt_Cuotas.Rows[0]["VALOR_COMPANIA"].ToString();
                    txt_pago_CompaniaCuota.Enabled = false;

                    cbx_pagocompaniaCuota.Enabled = false;
                    if (dt_Cuotas.Rows[0]["PAGO_COMPANIA"].ToString() == "True")
                    {
                        cbx_pagocompaniaCuota.Checked = true;
                    }
                    else
                    {
                        cbx_pagocompaniaCuota.Checked = false;
                    }

                }
                else
                {
                    btn_AceptarCuotas.Visible = true;

                    txt_costoCuota.Text = "0";
                    txt_costoCuota.Enabled = true;

                    txt_ValorPagarTarjeta.Text = "0";
                    txt_ValorPagarTarjeta.Enabled = true;

                    txt_ValorPagarEfectivo.Text = "0";
                    txt_ValorPagarEfectivo.Enabled = true;

                    txt_ValorPagarRecargo.Text = "0";
                    txt_ValorPagarRecargo.Enabled = true;

                    txt_ObservacionCuota.Value = "";

                    txt_pago_CompaniaCuota.Text = "0";

                    cbx_Renovacion.Checked = false;
                    cbx_PagoInferior.Checked = false;
                    cbx_pagocompaniaCuota.Checked = false;

                    cbx_Renovacion.Enabled = true;
                    cbx_PagoInferior.Enabled = true;
                    cbx_pagocompaniaCuota.Enabled = true;
                    //txt_ObservacionCuota.ed = true;
                }
            }
            else
            {
                hf_IDCUOTA.Value = "";
                hf_ID_PRODUCTO_CUOTA.Value = "";
            }
        }

        protected void txt_valor_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txt_Costo.Text) >= Convert.ToInt32(txt_valor.Text))
            {
                bl_Tipopago.SelectedValue = "3";
                bl_Tipopago.Enabled = false;

                bl_Numcuotas.SelectedValue = "0";
                bl_Numcuotas.Enabled = false;
            }
            else
            {
                bl_Tipopago.SelectedValue = "2";
                bl_Tipopago.Enabled = true;

                bl_Numcuotas.SelectedValue = "1";
                bl_Numcuotas.Enabled = true;
            }
            mpe_Produc.Show();
        }

        protected void cbx_pagocompania_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_pagocompaniaCuota.Checked)
            {
                txt_pago_CompaniaCuota.Enabled = true;
            }
            else
            {
                txt_pago_CompaniaCuota.Enabled = false;
                txt_pago_CompaniaCuota.Text = "0";
            }

            mpe_Cuotas.Show();
        }

        protected void cbx_PagoCompania_CheckedChanged1(object sender, EventArgs e)
        {
            if (cbx_PagoCompania.Checked)
            {
                txt_pagoCompania.Enabled = true;
            }
            else
            {
                txt_pagoCompania.Enabled = false;
                txt_pagoCompania.Text = "0";
            }

            mpe_Produc.Show();
        }

        protected void BL_EstadosProdu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BL_EstadosProdu.SelectedItem.Text.Contains("Endoso"))
            {
                string idCliente = "";
                try
                {
                    idCliente = Page.Request.QueryString["CLIENT_ID"].ToString();
                }
                catch (Exception)
                {
                }

                string id = BL_EstadosProdu.SelectedValue;
                //hf_Producto.Value,
                // Convert.ToInt32(Session["userID"].ToString());
                CLS_PRODUCTOS cls_produ = new CLS_PRODUCTOS();
                int resul = cls_produ.SP_33_INSERTAR_ENDOSO(Convert.ToInt32(hf_Producto.Value), Convert.ToInt32(id), Convert.ToInt32(Session["userID"].ToString()));

                if (resul > 0)
                {

                    CLS_AUDITORIA audi = new CLS_AUDITORIA();
                    string IP = Request.UserHostAddress;
                    string nombreCliente = $"{txt_PrimerNombre.Text} {txt_SegundoNombre.Text} {txt_Apellidos.Text}";

                    audi.SP_02_INSERTAR_AUDITORIA("ACTUALIZAR PRODUCTO", $"El usuario {Session["nombre_usuario"]} actualizo el estado de un producto a 'ENDOSO', producto asociado al cliente cliente {nombreCliente}", "VENTAS", IP, Convert.ToInt32(Session["userID"].ToString()));

                    OcultarControles("ACTUALIZAR");
                    ProductosCliente(idCliente);
                }

                txt_valor.Text = "0";
                txt_Costo.Text = "0";
                txt_SerAdicional.Text = "0";
                txt_CashOut.Text = "0";
                txt_tarjetaCedito.Text = "0";
                txt_pagoEfectivo.Text = "0";
                txt_recargo.Text = "0";
                txt_Intsallmentfee.Text = "0";
                txt_pagoCompania.Text = "0";
                //bl_Numcuotas.SelectedValue = "0";
                //bl_Tipopago.SelectedValue = "1";
                //txt_proximoPago.Text = "";


                bl_Tipopago.Enabled = false;
                bl_Numcuotas.Enabled = false;
                txt_valor.Enabled = true;
                txt_Costo.Enabled = true;
                txt_SerAdicional.Enabled = true;
                txt_CashOut.Enabled = true;
                txt_tarjetaCedito.Enabled = true;
                txt_pagoEfectivo.Enabled = true;
                txt_recargo.Enabled = true;
                txt_Intsallmentfee.Enabled = true;
                txt_pagoCompania.Enabled = true;
                txt_proximoPago.Enabled = true;
            }

            if (BL_EstadosProdu.SelectedItem.Text.Contains("Renovaci"))
            {
            }
            mpe_Produc.Show();
        }
    }
}