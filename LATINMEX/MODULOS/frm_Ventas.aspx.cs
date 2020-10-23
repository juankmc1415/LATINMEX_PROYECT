using LATINMEX.Datos.CLIENTES;
using LATINMEX.Datos.CORE;
using LATINMEX.Datos.PRODUCTOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
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
            cliente.NOMBRES = txt_Nombre.Text;
            cliente.PRIMER_APELLIDO = txt_PrimerApellido.Text;
            cliente.SEGUNDO_APELLIDO = txt_SegunApellido.Text;
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
                string nombreCliente = $"{txt_Nombre.Text} {txt_PrimerApellido.Text} {txt_SegunApellido.Text}";
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
            cliente.NOMBRES = txt_Nombre.Text;
            cliente.PRIMER_APELLIDO = txt_PrimerApellido.Text;
            cliente.SEGUNDO_APELLIDO = txt_SegunApellido.Text;
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
            cliente.ID_USUARIO_ACTUALIZACION = Convert.ToInt32(Session["userID"].ToString());
            cliente.FECHA_ACTULIZACION = DateTime.Now;

            CLS_CLIENTE cls_Cli = new CLS_CLIENTE();
            int resul = cls_Cli.SP_07_ACTUALIZAR_CLIENTE(cliente, idCliente);

            if (resul > 0)
            {
                CLS_AUDITORIA audi = new CLS_AUDITORIA();
                string IP = Request.UserHostAddress;
                string nombreCliente = $"{txt_Nombre.Text} {txt_PrimerApellido.Text} {txt_SegunApellido.Text}";

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

        #endregion

        #region CREAR NOTAS
        protected void btn_NuevaNota_Click(object sender, EventArgs e)
        {
            txt_nota.Value = "";
            mpe_NuevaNota.Show();
            OcultarControles("O_MENSAGE");
            //HOLA MUNDO

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
                string nombreCliente = $"{txt_Nombre.Text} {txt_PrimerApellido.Text} {txt_SegunApellido.Text}";
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
                    string nombreCliente = $"{txt_Nombre.Text} {txt_PrimerApellido.Text} {txt_SegunApellido.Text}";
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

        protected void btn_nuevoProducto_Click(object sender, EventArgs e)
        {
            mpe_Produc.Show();
            OcultarControles("O_MENSAGE");
            LimpiarControles("NUEVO_PRODUCTO");

            btn_ActualizarProduto.Visible = false;
            btn_aceptar.Visible = true;
            hf_Producto.Value = "";
        }

        protected void btn_cerrPro_Click(object sender, EventArgs e)
        {
            mpe_Produc.Hide();
            OcultarControles("O_MENSAGE");
        }

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
            }
            else
            {
                cliente.ESTADO_PRODUCTO = null;
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

            cliente.NOMBRE_EMPRESA = txtx_NombreEmpresa.Text;
            cliente.PROSPECTO = Convert.ToBoolean(cb_prospecto.Checked);
            cliente.OBSERVACION = txt_observacion.Value;

            CLS_PRODUCTOS cls_produ = new CLS_PRODUCTOS();
            int resul = cls_produ.SP_14_INSERTAR_PRODUCTO(cliente);

            if (resul > 0)
            {
                CLS_AUDITORIA audi = new CLS_AUDITORIA();
                string IP = Request.UserHostAddress;
                string nombreCliente = $"{txt_Nombre.Text} {txt_PrimerApellido.Text} {txt_SegunApellido.Text}";

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

        protected void bl_TipoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            mpe_Produc.Show();
            string id = bl_TipoProducto.SelectedValue;
            TiposProductos(Convert.ToInt32(id));

            if (bl_TipoProducto.SelectedItem.Text == "SEGURO")
            {
                div_estad.Visible = true;
                EstadosProductos(Convert.ToInt32(id));
            }
            else
            {
                div_estad.Visible = false;
            }
        }

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
                txt_NombreCliente.Text = $"{data.Tables[0].Rows[0]["NOMBRES"].ToString()} {data.Tables[0].Rows[0]["PRIMER_APELLIDO"].ToString()}";
                txt_NombreAuxiliar.Text = $"{ Session["nombre_usuario"]}";
                txtx_NombreEmpresa.Text = data.Tables[0].Rows[0]["NOMBRE_EMPRESA"].ToString();

                txt_Nombre.Text = data.Tables[0].Rows[0]["NOMBRES"].ToString();
                txt_PrimerApellido.Text = data.Tables[0].Rows[0]["PRIMER_APELLIDO"].ToString();
                txt_SegunApellido.Text = data.Tables[0].Rows[0]["SEGUNDO_APELLIDO"].ToString();
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

                DateTime FECHA_VIN_1 = Convert.ToDateTime(data.Tables[0].Rows[0]["FECHA_VIN_1"]);
                txt_FecVin1.Text = FECHA_VIN_1.ToString("yyyy-MM-dd");

                txt_Vin2.Text = data.Tables[0].Rows[0]["VIN_2"].ToString();

                DateTime FECHA_VIN_2 = Convert.ToDateTime(data.Tables[0].Rows[0]["FECHA_VIN_2"]);
                txt_FecVin2.Text = FECHA_VIN_2.ToString("yyyy-MM-dd");

                txt_Vin3.Text = data.Tables[0].Rows[0]["VIN_3"].ToString();

                DateTime FECHA_VIN_3 = Convert.ToDateTime(data.Tables[0].Rows[0]["FECHA_VIN_3"]);
                txt_FecVin3.Text = FECHA_VIN_3.ToString("yyyy-MM-dd");


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
                bl_CatProduc.SelectedValue = "1";
                BL_EstadosProdu.SelectedValue = "1";
                BL_EstadosProdu.Enabled = false;
                txt_numPoliza.Text = "";
                txt_FechInicio.Text = "";
                txt_fechCaduci.Text = "";
                txt_CodInterno.Text = "";

                txt_valor.Text = "0";
                txt_Costo.Text = "0";
                txt_SerAdicional.Text = "0";
                txt_CashOut.Text = "0";
                txt_tarjetaCedito.Text = "0";
                txt_pagoEfectivo.Text = "0";
                txt_recargo.Text = "0";
                bl_Tipopago.SelectedValue = "1";

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
            //else
            //{
            //    notas.Rows.Add(notas.NewRow());
            //    gv_Notas.DataSource = notas;
            //    gv_Notas.DataBind();
            //    gv_Notas.Rows[0].Cells.Clear();
            //    gv_Notas.Rows[0].Cells.Add(new TableCell());
            //    gv_Notas.Rows[0].Cells[0].ColumnSpan = notas.Columns.Count;
            //    gv_Notas.Rows[0].Cells[0].Text = "El usuario no tiene notas";
            //    gv_Notas.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            //}
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

            DataTable dataCompa = cls_Prod.SP_15_GET_COMPANIAS();
            if (dataCompa != null && dataCompa.Rows.Count > 0)
            {
                bl_CompaniaSe.DataSource = dataCompa;
                bl_CompaniaSe.DataBind();


                txt_CodInterno.Text = dataCompa.Rows[0]["CODIGO_INTERNO"].ToString();
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
                bl_CatProduc.SelectedValue = dt_product.Rows[0]["ID_CATEGORIA_TIPO_PRODUCTO"].ToString();
                BL_EstadosProdu.SelectedValue = dt_product.Rows[0]["ESTADO_PRODUCTO"].ToString();
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

                if (!string.IsNullOrEmpty(dt_product.Rows[0]["FECHA_PROXIMO_PAGO"].ToString()) || !string.IsNullOrWhiteSpace(dt_product.Rows[0]["FECHA_PROXIMO_PAGO"].ToString()))
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
                if (string.IsNullOrEmpty(txt_Nombre.Text) || string.IsNullOrWhiteSpace(txt_Nombre.Text))
                {
                    res.Message = "El nombre del cliente es un campo obligatorio.";
                    res.Succ = false;
                    return res;
                }

                if (string.IsNullOrEmpty(txt_PrimerApellido.Text) || string.IsNullOrWhiteSpace(txt_PrimerApellido.Text))
                {
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

                if (bl_CompaniaSe.SelectedItem.Text == "SELECCIONAR")
                {
                    res.Message = "La compañia de seguros es un campo obligatorio.";
                    res.Succ = false;
                    return res;
                }

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

            }
            return res;
        }

        protected void bl_CompaniaSe_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_CodInterno.Text = bl_CompaniaSe.SelectedValue;
            mpe_Produc.Show();
        }

        protected void bl_Tipopago_SelectedIndexChanged(object sender, EventArgs e)
        {
            OcultarControles("O_MENSAGE");

            if (bl_Tipopago.SelectedItem.Text == "Cuotas")
            {
                bl_Numcuotas.Enabled = true;
                bl_Numcuotas.SelectedValue = "1";
            }
            else
            {
                bl_Numcuotas.SelectedValue = "0";
                bl_Numcuotas.Enabled = false;
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

            mpe_Produc.Show();
        }

        //Cargar la lista de cuotas
        protected void gvEmployeeDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblEmpID = (Label)e.Row.FindControl("lblEmpID");
                GridView gv_Child = (GridView)e.Row.FindControl("gv_Cuotas");

                string txtempid = lblEmpID.Text;

                CLS_PRODUCTOS cls_Cli = new CLS_PRODUCTOS();
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
                string varName1 = Convert.ToString(((Label)gvRow.FindControl("lblEmpID")).Text.ToString());
                btn_ActualizarProduto.Visible = true;
                btn_aceptar.Visible = false;
                hf_Producto.Value = varName1;
                DetallesProducto(varName1);
            }

            if (e.CommandName == "ImprimirProducto")
            {
                //GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                //int rowIndex = gvRow.RowIndex;
                //string id = gv_Notas.DataKeys[gvRow.RowIndex].Value.ToString();
            }

            if (e.CommandName == "VerArchivos")
            {
                //GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                //int rowIndex = gvRow.RowIndex;
                //string id = gv_Notas.DataKeys[gvRow.RowIndex].Value.ToString();
            }

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
            }
            else
            {
                cliente.ESTADO_PRODUCTO = null;
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


            cliente.NOMBRE_EMPRESA = txtx_NombreEmpresa.Text;
            cliente.PROSPECTO = Convert.ToBoolean(cb_prospecto.Checked);
            cliente.OBSERVACION = txt_observacion.Value;

            CLS_PRODUCTOS cls_produ = new CLS_PRODUCTOS();
            int resul = cls_produ.SP_19_ACTUALIZAR_PRODUCTO(cliente, hf_Producto.Value);

            if (resul > 0)
            {
                CLS_AUDITORIA audi = new CLS_AUDITORIA();
                string IP = Request.UserHostAddress;
                string nombreCliente = $"{txt_Nombre.Text} {txt_PrimerApellido.Text} {txt_SegunApellido.Text}";

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

        protected void gv_Cuotas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            string varName1 = Convert.ToString(((Label)gvRow.FindControl("lblCuotasProduc")).Text.ToString());


            if (e.CommandName == "VerCuota")
            {
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
                //btn_ActualizarProduto.Visible = true;
                //btn_aceptar.Visible = false;
                //hf_Producto.Value = varName1;

                //DetallesProducto(varName1);
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

            if (total < Convert.ToDecimal(txt_valorCuota.Text))
            {
                Message_danger.Text = "El valor pagado no puede ser menor al valor  de la cuota ";
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

            CLS_PRODUCTOS cls_Cli = new CLS_PRODUCTOS();
            int resul = cls_Cli.SP_23_ACTUALIZAR_CUOTAS(idProducto, idCuota, estado, valorCuota, valorTarjeta, valorEfectivo, valorRecargo, observacion, idUser);

            if (resul > 0)
            {
                txt_nota.Value = "";

                CLS_AUDITORIA audi = new CLS_AUDITORIA();
                string IP = Request.UserHostAddress;
                string nombreCliente = $"{txt_Nombre.Text} {txt_PrimerApellido.Text} {txt_SegunApellido.Text}";
                audi.SP_02_INSERTAR_AUDITORIA("ACTUALIZAR CUOTA", $"El usuario {Session["nombre_usuario"]} actualizo el valor de una cuota {nombreCliente}", "VENTAS", IP, Convert.ToInt32(Session["userID"].ToString()));


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
                txt_EstodoCuota.Text = dt_Cuotas.Rows[0]["ESTADO_CUOTA"].ToString();
                txt_valorCuota.Text = dt_Cuotas.Rows[0]["COSTO_CUOTA"].ToString();

                if (dt_Cuotas.Rows[0]["ESTADO_CUOTA"].ToString() == "PAGADO")
                {
                    btn_AceptarCuotas.Visible = false;
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
    }
}