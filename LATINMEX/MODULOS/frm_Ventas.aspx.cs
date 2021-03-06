﻿using DevExpress.Web;
using LATINMEX.Datos.CLIENTES;
using LATINMEX.Datos.CORE;
using LATINMEX.Datos.INFORMES;
using LATINMEX.Datos.PRODUCTOS;
using LATINMEX.MODELVIEW;
using Microsoft.Reporting.WebForms;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading;
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
            this.Master.btn_buscar.Click += new EventHandler(bnt_buscar_Click);

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
                ConsularLista();
            }
            RegisterClient();

            if (IsPostBack)
            {
                if (!string.IsNullOrEmpty(hf_InfoPop.Value) && !string.IsNullOrWhiteSpace(hf_InfoPop.Value))
                {
                    if (hf_InfoPop.Value.Contains("True"))
                    {
                        mpe_Informes.Show();
                    }
                    else
                    {
                        mpe_Informes.Hide();
                    }
                }
                else
                {
                    mpe_Informes.Hide();
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
            //res = validarCampos("Nuevo_usuario");
            //if (!res.Succ)
            //{
            //    Message_warning.Text = res.Message;
            //    Message_warning.Visible = true;
            //    return;
            //}

            LTM_CLIENTE cliente = new LTM_CLIENTE();
            cliente.PRIMER_NOMBRE = txt_PrimerNombre.Text;
            cliente.SEGUNDO_NOMBRE = txt_SegundoNombre.Text;
            cliente.APELLIDOS = txt_Apellidos.Text;

            cliente.CORREO = txt_Corre.Text;
            cliente.TELEFONO_MOVIL = txt_Telefono.Text;
            cliente.DIRECCION_RESIDENCIA = txt_DirecResidencia.Text;
            cliente.DIRECCION_CORRESPONDENCIA = txt_DireCorrespond.Text;
            if (!string.IsNullOrEmpty(txt_fechaNacimiento.Text) || !string.IsNullOrEmpty(txt_fechaNacimiento.Text))
            {
                cliente.FECHA_NACIMIENTO = Convert.ToDateTime(txt_fechaNacimiento.Text);
            }
            else
            {
                cliente.FECHA_NACIMIENTO = null;
            }

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
            //res = validarCampos("Nuevo_usuario");
            //if (!res.Succ)
            //{
            //    Message_warning.Text = res.Message;
            //    Message_warning.Visible = true;
            //    return;
            //}

            LTM_CLIENTE cliente = new LTM_CLIENTE();
            cliente.PRIMER_NOMBRE = txt_PrimerNombre.Text;
            cliente.SEGUNDO_NOMBRE = txt_SegundoNombre.Text;
            cliente.APELLIDOS = txt_Apellidos.Text;
            cliente.CORREO = txt_Corre.Text;
            cliente.TELEFONO_MOVIL = txt_Telefono.Text;
            cliente.DIRECCION_RESIDENCIA = txt_DirecResidencia.Text;
            cliente.DIRECCION_CORRESPONDENCIA = txt_DireCorrespond.Text;

            if (!string.IsNullOrEmpty(txt_fechaNacimiento.Text) || !string.IsNullOrEmpty(txt_fechaNacimiento.Text))
            {
                cliente.FECHA_NACIMIENTO = Convert.ToDateTime(txt_fechaNacimiento.Text);
            }
            else
            {
                cliente.FECHA_NACIMIENTO = null;
            }

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
       
        public void ConsularLista()
        {
            var lista = (List<ClientesView>)Session["clientes"];
            if (lista != null)
            {
                lista = lista.GroupBy(x => x.IdCliente).Select(y => new ClientesView
                {
                    IdCliente = y.FirstOrDefault().IdCliente,
                    Cliente = y.FirstOrDefault().Cliente,
                }).ToList();

                foreach (var item in lista)
                {
                    item.Active = false;
                }
                if (Request.QueryString["CLIENT_ID"] != null)
                {
                    string idCliente = Page.Request.QueryString["CLIENT_ID"].ToString();
                    var cliente = lista.FirstOrDefault(x => x.IdCliente == Convert.ToInt32(idCliente));
                    if (cliente != null)
                    {
                        cliente.Active = true;
                    }
                }

            }

            rp_listaClientes.DataSource = lista;
            rp_listaClientes.DataBind();

            UpdatePanel6.Update();
        }

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
            btn_ActualizarEndoso.Visible = false;
            btn_imprimir.Visible = false;

            btn_aceptar.Visible = true;
            hf_Producto.Value = "";
        }

        //Cargar la lista de cuotas
        protected void gvEmployeeDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblEmpID = (Label)e.Row.FindControl("lbl_IdProducto");

                string txtempid = lblEmpID.Text;

                CLS_PRODUCTOS cls_Cli = new CLS_PRODUCTOS();

                GridView gv_Endos = (GridView)e.Row.FindControl("gv_Endosos");
                DataTable dt_endoso = cls_Cli.SP_34_GET_LISTA_ENDOSOS(txtempid);
                if (dt_endoso != null && dt_endoso.Rows.Count > 0)
                {
                    gv_Endos.DataSource = dt_endoso;
                    gv_Endos.DataBind();
                }

                GridView gv_Child = (GridView)e.Row.FindControl("gv_Cuotas");
                DataTable notas = cls_Cli.SP_17_GET_LISTA_PRODUCTO_ASOCIADOS(txtempid);
                if (notas != null && notas.Rows.Count > 0)
                {
                    gv_Child.DataSource = notas;
                    gv_Child.DataBind();
                }

                GridView gv_cuotas_DMV = (GridView)e.Row.FindControl("gv_cuotas_DMV");
                DataTable dt_cuotas_DMV = cls_Cli.SP_36_GET_LISTA_COUTAS_DMV(txtempid);
                if (dt_cuotas_DMV != null && dt_cuotas_DMV.Rows.Count > 0)
                {
                    gv_cuotas_DMV.DataSource = dt_cuotas_DMV;
                    gv_cuotas_DMV.DataBind();
                }

            }
        }

        //opciones del grid de lista de productos asociados
        protected void gvEmployeeDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerProducto")
            {
                GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                string idProducto = Convert.ToString(((Label)gvRow.FindControl("lbl_IdProducto")).Text.ToString());
                string estadoP = Convert.ToString(((Label)gvRow.FindControl("lbl_estadProduc")).Text.ToString());

                btn_ActualizarProduto.Visible = true;
                btn_ActualizarEndoso.Visible = false;
                btn_imprimir.Visible = true;
                btn_aceptar.Visible = false;
                hf_Producto.Value = idProducto;
                hf_estado_producto.Value = estadoP;
                DetallesProducto(idProducto);
            }

            if (e.CommandName == "ImprimirProducto")
            {
                GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                string idProducto = Convert.ToString(((Label)gvRow.FindControl("lbl_IdProducto")).Text.ToString());

                Informe_Detalles_Seguro(idProducto);

                //ModalPopupExtender1.Show();
                //mpe_Informes.Show();

                hf_InfoPop.Value = "True";
                metodoTest();
            }

            if (e.CommandName == "VerArchivos")
            {
                GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                string varName1 = Convert.ToString(((Label)gvRow.FindControl("lbl_IdProducto")).Text.ToString());

                mpe_Archivos.Show();
                ListaArchivos(varName1, "PRODUCTOS");
            }
        }

        private void metodoTest()
        {
            //Response.Redirect("~/MODULOS/frm_Ventas.aspx?CLIENT_ID=0");
            mpe_Informes.Show();
        }

        #region EVENTOS SELECCION
        protected void bl_TipoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            mpe_Produc.Show();
            string id = bl_TipoProducto.SelectedValue;
            TiposProductos(Convert.ToInt32(id));

            if (bl_TipoProducto.SelectedItem.Text == "SEGURO")
            {
                dv_fechaRetiro.Visible = false;
                div_Expiration.Visible = true;

                div_estad.Visible = true;
                div_fechaRetiro.Visible = true;
                dv_poliza.Visible = true;
                lbl_fechaInicio.Visible = true;
                lbl_fechaFactura.Visible = false;
                dv_Compania.Visible = true;
                dv_valorServicio.Visible = false;
                dv_CostosSeguro.Visible = true;
                div_adicional.Visible = true;
                lbl_Premium.Visible = true;
                txt_valor.Visible = true;
                dv_ProximoPago.Visible = true;
                dv_tipoPago.Visible = true;
                div_tipoPago.Visible = true;
                dv_fechaRetiro.Visible = false;

                EstadosProductos(Convert.ToInt32(id));
            }
            else if (bl_TipoProducto.SelectedItem.Text == "LATINMEX")
            {
                div_Expiration.Visible = false;
                div_fechaRetiro.Visible = false;
                txt_reserva.Visible = true;
                txt_reserva.Enabled = false;
                dv_poliza.Visible = false;
                div_estad.Visible = false;
                lbl_fechaInicio.Visible = false;
                lbl_fechaFactura.Visible = true;
                dv_Compania.Visible = false;
                dv_fechaRetiro.Visible = true;
                dv_valorServicio.Visible = false;
                dv_CostosSeguro.Visible = true;
                div_adicional.Visible = true;
                lbl_Premium.Visible = false;
                txt_valor.Visible = false;
                dv_ProximoPago.Visible = false;
                dv_tipoPago.Visible = false;
                div_tipoPago.Visible = false;

            }
            else if (bl_TipoProducto.SelectedItem.Text == "DMV")
            {
                div_Expiration.Visible = true;
                div_fechaRetiro.Visible = true;
                txt_reserva.Visible = false;
                txt_reserva.Enabled = false;
                dv_poliza.Visible = false;
                div_estad.Visible = false;
                lbl_fechaInicio.Visible = false;
                lbl_fechaFactura.Visible = true;
                dv_Compania.Visible = false;
                dv_fechaRetiro.Visible = false;
                dv_valorServicio.Visible = false;
                dv_CostosSeguro.Visible = true;
                div_adicional.Visible = false;
                dv_ProximoPago.Visible = false;
                dv_tipoPago.Visible = true;
                div_tipoPago.Visible = false;

                if (bl_CatProduc.SelectedItem.Text.Contains("Sticker") || bl_CatProduc.SelectedItem.Text.Contains("Placa y Titulo"))
                {
                    dv_valorServicio.Visible = true;
                }
                else
                {
                    dv_valorServicio.Visible = false;
                }

            }
            else
            {

                dv_poliza.Visible = false;
                div_estad.Visible = false;
                lbl_fechaInicio.Visible = false;
                lbl_fechaFactura.Visible = true;
                dv_Compania.Visible = false;
                dv_fechaRetiro.Visible = true;
                dv_valorServicio.Visible = true;
                dv_CostosSeguro.Visible = false;
                div_adicional.Visible = false;
                dv_ProximoPago.Visible = false;
                dv_tipoPago.Visible = true;
                div_tipoPago.Visible = true;

            }
        }

        protected void bl_CatProduc_SelectedIndexChanged(object sender, EventArgs e)
        {
            mpe_Produc.Show();

            string id = bl_CatProduc.SelectedValue;
            ListaCompañias(Convert.ToInt32(id));

            if (bl_CatProduc.SelectedItem.Text.Contains("AIRLINE TICKETS"))
            {
                txt_reserva.Enabled = true;
                dv_fechaRetiro.Visible = true;
            }
            else
            {
                txt_reserva.Enabled = false;
                dv_fechaRetiro.Visible = false;
            }

            if (bl_CatProduc.SelectedItem.Text.Contains("Sticker") || bl_CatProduc.SelectedItem.Text.Contains("Placa y Titulo") || bl_CatProduc.SelectedItem.Text.Contains("Multa"))
            {
                dv_valorServicio.Visible = true;
            }
            else
            {
                dv_valorServicio.Visible = false;
            }

            if (bl_TipoProducto.SelectedItem.Text == "LATINMEX")
            {
                if (bl_CatProduc.SelectedItem.Text.Contains("Corporaci"))
                {
                    div_Expiration.Visible = true;
                }
                else
                {
                    div_Expiration.Visible = false;
                }
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
            if (hf_estado_endoso.Value != "POR_ACTUALIZAR")
            {

                if (Convert.ToDecimal(txt_Costo.Text) >= Convert.ToDecimal(txt_valor.Text))
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

                    if (Convert.ToDecimal(txt_Costo.Text) >= Convert.ToDecimal(txt_valor.Text))
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

                    if (Convert.ToDecimal(txt_Costo.Text) < Convert.ToDecimal(txt_valor.Text))
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
                //total = Convert.ToDecimal(txt_pagoEfectivo.Text)
                // + Convert.ToDecimal(txt_tarjetaCedito.Text)
                // - Convert.ToDecimal(txt_recargo.Text)
                // - Convert.ToDecimal(txt_Costo.Text);


                total = Convert.ToDecimal(txt_pagoEfectivo.Text == "" ? "0" : txt_pagoEfectivo.Text)
              + Convert.ToDecimal(txt_tarjetaCedito.Text == "" ? "0" : txt_tarjetaCedito.Text)
              - Convert.ToDecimal(txt_recargo.Text == "" ? "0" : txt_recargo.Text)
              - Convert.ToDecimal(txt_Costo.Text == "" ? "0" : txt_Costo.Text);

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
                // total = Convert.ToDecimal(txt_pagoEfectivo.Text)
                //+ Convert.ToDecimal(txt_tarjetaCedito.Text)
                //- Convert.ToDecimal(txt_recargo.Text);

                total = Convert.ToDecimal(txt_pagoEfectivo.Text == "" ? "0" : txt_pagoEfectivo.Text)
                + Convert.ToDecimal(txt_tarjetaCedito.Text == "" ? "0" : txt_tarjetaCedito.Text)
                - Convert.ToDecimal(txt_recargo.Text == "" ? "0" : txt_recargo.Text)
                - Convert.ToDecimal(txt_ValorServicio.Text == "" ? "0" : txt_ValorServicio.Text);


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
            if (!string.IsNullOrEmpty(txt_fechCaduci.Text) || !string.IsNullOrWhiteSpace(txt_fechCaduci.Text))
            {
                cliente.FECHA_CADUCIDAD = Convert.ToDateTime(txt_fechCaduci.Text);
            }
            else
            {
                cliente.FECHA_CADUCIDAD = DateTime.Now;
            }

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
            string arrayArchivos = "";
            //Gestion de archivos
            if (file_Producto.HasFile)
            {
                HttpFileCollection hfc = Request.Files;

                if (hfc.Count <= 5)
                {
                    for (int i = 0; i <= hfc.Count - 1; i++)
                    {

                        HttpPostedFile hpf = hfc[i];
                        if (hpf.ContentLength > 0)
                        {
                            idArchivo = GuardarArchivos(hpf);

                            arrayArchivos += idArchivo + ";";
                        }
                    }
                }
            }

            DataTable resul = null;
            resul = cls_produ.SP_14_INSERTAR_PRODUCTO(cliente);
            if (resul != null)
            {
                string idProducto = resul.Rows[0]["PRODUCTO"].ToString();

                if (!string.IsNullOrEmpty(arrayArchivos) && !string.IsNullOrWhiteSpace(arrayArchivos))
                {
                    string[] words = arrayArchivos.Split(';');
                    foreach (var word in words)
                    {
                        System.Console.WriteLine($"<{word}>");
                        cls_produ.SP_30_GUARDAR_FORMULARIO_ARCHIVOS(word, idCliente, hf_Producto.Value, "PRODUCTOS");
                    }
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

            if (!string.IsNullOrEmpty(txt_fechCaduci.Text) || !string.IsNullOrWhiteSpace(txt_fechCaduci.Text))
            {
                cliente.FECHA_CADUCIDAD = Convert.ToDateTime(txt_fechCaduci.Text);
            }
            else
            {
                cliente.FECHA_CADUCIDAD = DateTime.Now;
            }

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
            string arrayArchivos = "";
            //Gestion de archivos
            if (file_Producto.HasFile)
            {
                HttpFileCollection hfc = Request.Files;

                if (hfc.Count <= 5)   
                {
                    for (int i = 0; i <= hfc.Count - 1; i++)
                    {

                        HttpPostedFile hpf = hfc[i];
                        if (hpf.ContentLength > 0)
                        {
                            idArchivo = GuardarArchivos(hpf);

                            arrayArchivos += idArchivo + ";";
                        }
                    }
                }
            }

            int resul = cls_produ.SP_19_ACTUALIZAR_PRODUCTO(cliente, hf_Producto.Value, hf_estado_endoso.Value, hf_estado_renovado.Value);

            if (resul > 0)
            {
                if (!string.IsNullOrEmpty(arrayArchivos) && !string.IsNullOrWhiteSpace(arrayArchivos))
                {
                    string[] words = arrayArchivos.Split(';');
                    foreach (var word in words)
                    {
                        System.Console.WriteLine($"<{word}>");
                        cls_produ.SP_30_GUARDAR_FORMULARIO_ARCHIVOS(word, idCliente, hf_Producto.Value, "PRODUCTOS");
                    }
                }

                if (bl_TipoProducto.SelectedItem.Text == "SEGURO")
                {
                    if (hf_estado_producto.Value != BL_EstadosProdu.SelectedItem.Text)
                    {
                        CambioEstado();
                    }
                }

                CLS_AUDITORIA audi = new CLS_AUDITORIA();
                string IP = Request.UserHostAddress;
                string nombreCliente = $"{txt_PrimerNombre.Text} {txt_SegundoNombre.Text} {txt_Apellidos.Text}";

                audi.SP_02_INSERTAR_AUDITORIA("ACTUALIZAR PRODUCTO", $"El usuario {Session["nombre_usuario"]} actualizo el producto nuevo producto asociado al cliente cliente {nombreCliente}", "VENTAS", IP, Convert.ToInt32(Session["userID"].ToString()));

                OcultarControles("ACTUALIZAR");
                ProductosCliente(idCliente);

                Message_Succes.Text = "Producto actualizado correctamente";
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
                total = Convert.ToDecimal(txt_pagoEfectivo.Text == "" ? "0" : txt_pagoEfectivo.Text)
                + Convert.ToDecimal(txt_tarjetaCedito.Text == "" ? "0" : txt_tarjetaCedito.Text)
                - Convert.ToDecimal(txt_recargo.Text == "" ? "0" : txt_recargo.Text)
                - Convert.ToDecimal(txt_Costo.Text == "" ? "0" : txt_Costo.Text)
                - Convert.ToDecimal(txt_ValorServicio.Text == "" ? "0" : txt_ValorServicio.Text);


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
                // total = Convert.ToDecimal(txt_pagoEfectivo.Text)
                //+ Convert.ToDecimal(txt_tarjetaCedito.Text)
                //- Convert.ToDecimal(txt_recargo.Text)
                //- Convert.ToDecimal(txt_ValorServicio.Text);

                total = Convert.ToDecimal(txt_pagoEfectivo.Text == "" ? "0" : txt_pagoEfectivo.Text)
              + Convert.ToDecimal(txt_tarjetaCedito.Text == "" ? "0" : txt_tarjetaCedito.Text)
              - Convert.ToDecimal(txt_recargo.Text == "" ? "0" : txt_recargo.Text)
              - Convert.ToDecimal(txt_Costo.Text == "" ? "0" : txt_Costo.Text)
              - Convert.ToDecimal(txt_ValorServicio.Text == "" ? "0" : txt_ValorServicio.Text);

                if (total > 0)
                {
                    txt_valorTotal.Text = Convert.ToString(total);
                }
                else
                {
                    txt_valorTotal.Text = Convert.ToString(0);
                }
            }

            if (hf_estado_endoso.Value != "POR_ACTUALIZAR")
            {
                if (Convert.ToDecimal(txt_Costo.Text) >= Convert.ToDecimal(txt_valor.Text))
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
            decimal valorReinstalacion = Convert.ToDecimal(txt_Reinstalacion.Text);
            decimal valorRecargoCompania = Convert.ToDecimal(txt_recargoCompania.Text);

            decimal costo = Convert.ToDecimal(txt_costoCuota.Text);

            string observacion = txt_ObservacionCuota.Value;
            int idUser = Convert.ToInt32(Session["userID"].ToString());

            decimal totalV = valorTarjeta + valorEfectivo - valorRecargo - (valorRecargoCompania + valorReinstalacion);

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
            string arrayArchivos = "";
            //Gestion de archivos
            if (file_Cuotas.HasFile)
            {
                HttpFileCollection hfc = Request.Files;
                if (hfc.Count <= 5)
                {
                    for (int i = 0; i <= hfc.Count - 1; i++)
                    {
                        HttpPostedFile hpf = hfc[i];
                        if (hpf.ContentLength > 0)
                        {
                            idArchivo = GuardarArchivos(hpf);
                            arrayArchivos += idArchivo + ";";
                        }
                    }
                }
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



            if (cbx_Reinstalacion.Checked)
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

            int resul = cls_produ.SP_23_ACTUALIZAR_CUOTAS(idProducto, idCuota, estado, valorCuota, valorTarjeta, valorEfectivo, valorRecargo, observacion, idUser, p_inf, costo, pagoCom, valorCompañia, valorReinstalacion, valorRecargoCompania);

            if (resul > 0)
            {
                txt_nota.Value = "";
                if (!string.IsNullOrEmpty(arrayArchivos) && !string.IsNullOrWhiteSpace(arrayArchivos))
                {
                    string[] words = arrayArchivos.Split(';');
                    foreach (var word in words)
                    {
                        System.Console.WriteLine($"<{word}>");
                        cls_produ.SP_30_GUARDAR_FORMULARIO_ARCHIVOS(word, idCliente, idCuota, "CUOTAS");
                    }
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

        #region METODOS
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
                txt_fechaNacimiento.Text = FechaNacimiento.ToString("MM-dd-yyyy");

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
                bl_TipoProducto.Enabled = true;
                bl_TipoProducto.SelectedValue = "1";

                string id = bl_TipoProducto.SelectedValue;
                TiposProductos(Convert.ToInt32(id));

                EstadosProductos(Convert.ToInt32(bl_TipoProducto.SelectedValue));

                bl_CatProduc.SelectedValue = "1";
                BL_EstadosProdu.SelectedValue = "1";
                BL_EstadosProdu.Enabled = false;
                txt_numPoliza.Text = "";

                DateTime FechInicio = DateTime.Now;
                txt_FechInicio.Text = FechInicio.ToString("yyyy-MM-dd");
                txt_proximoPago.Text = FechInicio.AddDays(30).ToString("yyyy-MM-dd");

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

                //txt_ValorTramite.Text = "0";
                //txt_ValorTerceros.Text = "0";
                txt_ValorServicio.Text = "0";
                txt_valorTotal.Text = "0";
                //txt_Impuesto.Text = "0";
                //txt_Exc_tramite.Text = "0";
                //txt_totalCobrar.Text = "0";

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
                cbx_PagoCompania.Checked = false;
                cbx_PagoCompania.Enabled = true;

                txt_proximoPago.Enabled = true;

                txt_proximoPago.Text = "";
                txt_observacion.Value = "";


                txt_valor.Enabled = true;
                txt_Costo.Enabled = true;
                txt_SerAdicional.Enabled = true;
                txt_CashOut.Enabled = true;
                txt_tarjetaCedito.Enabled = true;
                txt_pagoEfectivo.Enabled = true;
                txt_recargo.Enabled = false;
                txt_Intsallmentfee.Enabled = true;
                dv_tipoPago.Visible = true;
                div_tipoPago.Visible = true;

                txt_ValorServicio.Enabled = true;
                txt_valorTotal.Enabled = true;
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

                txt_ValorServicio.Enabled = false;
                txt_valorTotal.Enabled = false;

                if (BL_EstadosProdu.SelectedItem.Text.Contains("Endoso") && hf_estado_endoso.Value == "POR_ACTUALIZAR")
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

                if (BL_EstadosProdu.SelectedItem.Text.Contains("Renova") && hf_estado_renovado.Value == "POR_ACTUALIZAR")
                {
                    txt_numPoliza.Enabled = true;
                    txt_FechInicio.Enabled = true;
                    txt_fechCaduci.Enabled = true;

                    bl_Tipopago.Enabled = false;
                    bl_Numcuotas.Enabled = false;
                    txt_valor.Enabled = true;
                    txt_Costo.Enabled = true;
                    txt_SerAdicional.Enabled = true;
                    txt_CashOut.Enabled = true;
                    txt_tarjetaCedito.Enabled = true;
                    txt_pagoEfectivo.Enabled = true;
                    txt_recargo.Enabled = false;
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
                dv_valorServicio.Visible = false;
                dv_CostosSeguro.Visible = true;
                div_adicional.Visible = true;
                lbl_Premium.Visible = true;
                txt_valor.Visible = true;
                dv_ProximoPago.Visible = true;
                dv_tipoPago.Visible = true;
                div_tipoPago.Visible = true;

            }
            else if (bl_TipoProducto.SelectedItem.Text == "LATINMEX")
            {
                txt_reserva.Visible = true;
                txt_reserva.Enabled = false;

                dv_poliza.Visible = false;
                div_estad.Visible = false;

                lbl_fechaInicio.Visible = false;
                lbl_fechaFactura.Visible = true;
                dv_Compania.Visible = false;
                dv_fechaRetiro.Visible = true;
                dv_valorServicio.Visible = false;
                dv_CostosSeguro.Visible = false;
                div_adicional.Visible = false;
                dv_ProximoPago.Visible = false;
                dv_tipoPago.Visible = false;
                div_tipoPago.Visible = false;
            }
            else
            {

                dv_poliza.Visible = false;
                div_estad.Visible = false;
                lbl_fechaInicio.Visible = false;
                lbl_fechaFactura.Visible = true;
                dv_Compania.Visible = false;
                dv_fechaRetiro.Visible = false;
                txt_reserva.Enabled = false;
                dv_valorServicio.Visible = true;
                dv_CostosSeguro.Visible = false;
                div_adicional.Visible = false;
                dv_ProximoPago.Visible = false;
                dv_tipoPago.Visible = true;
                div_tipoPago.Visible = false;

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
                //DataTextField="ESTADO_SEGURO" DataValueField="ID_ESTADO_SEGURO"
                BL_EstadosProdu.DataValueField = "ID_ESTADO_SEGURO";
                BL_EstadosProdu.DataTextField = "ESTADO_SEGURO";

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

                hf_Producto.Value = idProducto;
                bl_TipoProducto.SelectedValue = dt_product.Rows[0]["TIPO_PRODUCTO"].ToString();
                TiposProductos(Convert.ToInt32(bl_TipoProducto.SelectedValue));
                bl_CatProduc.SelectedValue = dt_product.Rows[0]["ID_CATEGORIA_TIPO_PRODUCTO"].ToString();

                if (bl_TipoProducto.SelectedItem.Text == "SEGURO")
                {
                    EstadosProductos(Convert.ToInt32(bl_TipoProducto.SelectedValue));
                    BL_EstadosProdu.SelectedValue = dt_product.Rows[0]["ESTADO_PRODUCTO"].ToString();
                    hf_estado_producto.Value = BL_EstadosProdu.SelectedItem.Text;
                }

                txt_numPoliza.Text = dt_product.Rows[0]["NUMERO_POLIZA"].ToString();

                DateTime FechInicio = Convert.ToDateTime(dt_product.Rows[0]["FECHA_INICIO"]);
                txt_FechInicio.Text = FechInicio.ToString("yyyy-MM-dd");

                if (!string.IsNullOrEmpty(dt_product.Rows[0]["FECHA_CADUCIDAD"].ToString()) || !string.IsNullOrWhiteSpace(dt_product.Rows[0]["FECHA_CADUCIDAD"].ToString()))
                {
                    DateTime fechCaduci = Convert.ToDateTime(dt_product.Rows[0]["FECHA_CADUCIDAD"]);
                    txt_fechCaduci.Text = fechCaduci.ToString("yyyy-MM-dd");
                }
                else
                {
                    txt_fechCaduci.Text = "";
                }


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
                    txt_proximoPago.Text = proximoPago.ToString("yyyy-MM-dd");
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
                //txt_ValorTramite.Text = dt_product.Rows[0]["VALOR_TRAMITE"].ToString();
                //txt_ValorTerceros.Text = dt_product.Rows[0]["COSTO_TERCEROS"].ToString();
                txt_ValorServicio.Text = dt_product.Rows[0]["VALOR_SERVICIO"].ToString();
                txt_valorTotal.Text = dt_product.Rows[0]["VALOR_TOTAL"].ToString();
                //txt_Impuesto.Text = dt_product.Rows[0]["EXCEDENTE_IMPUESTO"].ToString();
                //txt_Exc_tramite.Text = dt_product.Rows[0]["EXCEDENTE_TRAMITE"].ToString();
                //txt_totalCobrar.Text = dt_product.Rows[0]["TOTAL_COBRAR"].ToString();
                txt_observacion.Value = dt_product.Rows[0]["OBSERVACION"].ToString();

                if (string.IsNullOrEmpty(dt_product.Rows[0]["ESTADO_ENDOSO"].ToString()) || string.IsNullOrWhiteSpace(dt_product.Rows[0]["ESTADO_ENDOSO"].ToString()) || dt_product.Rows[0]["ESTADO_ENDOSO"].ToString() == null)
                {
                    hf_estado_endoso.Value = "ACTUALIZADO";
                }
                else
                {
                    hf_estado_endoso.Value = dt_product.Rows[0]["ESTADO_ENDOSO"].ToString();
                }

                if (string.IsNullOrEmpty(dt_product.Rows[0]["ESTADO_RENOVADO"].ToString()) || string.IsNullOrWhiteSpace(dt_product.Rows[0]["ESTADO_RENOVADO"].ToString()) || dt_product.Rows[0]["ESTADO_RENOVADO"].ToString() == null)
                {
                    hf_estado_renovado.Value = "ACTUALIZADO";
                }
                else
                {
                    hf_estado_renovado.Value = dt_product.Rows[0]["ESTADO_RENOVADO"].ToString();
                }

            }

            mpe_Produc.Show();
            OcultarControles("O_MENSAGE");
            LimpiarControles("VER_PRODUCTO");

            if (dt_product != null && dt_product.Rows.Count > 0)
            {
                if (dt_product.Rows[0]["ESTADO_INTERNO"].ToString() == "ACTIVO")
                {

                    btn_ActualizarProduto.Visible = true;
                    //btn_ActualizarEndoso.Visible = true;
                }
                else
                {
                    btn_ActualizarProduto.Visible = false;
                    //btn_ActualizarEndoso.Visible = false;
                }
            }

            else
            {
                btn_ActualizarProduto.Visible = false;
                //btn_ActualizarEndoso.Visible = false;
            }
        }

        private void DetallesProducto_Endoso(string idProducto)
        {
            CLS_PRODUCTOS cls_Cli = new CLS_PRODUCTOS();
            DataTable dt_product = cls_Cli.SP_18_GET_DATOS_PRODUCTO_ENDOSO(idProducto);

            if (dt_product != null && dt_product.Rows.Count > 0)
            {
                List<KeyValuePair<int, string>> datos = new List<KeyValuePair<int, string>>()
                {
                    new KeyValuePair<int, string> (4, "Endoso"),
                    new KeyValuePair<int, string> (5, "Nuevo Endoso"),
                };

                //DataTextField="ESTADO_SEGURO" DataValueField="ID_ESTADO_SEGURO"

                BL_EstadosProdu.DataSource = datos;
                BL_EstadosProdu.DataValueField = "Key";
                BL_EstadosProdu.DataTextField = "Value";

                BL_EstadosProdu.DataBind();

                //hf_Producto.Value = idProducto;
                bl_TipoProducto.SelectedValue = dt_product.Rows[0]["TIPO_PRODUCTO"].ToString();
                TiposProductos(Convert.ToInt32(bl_TipoProducto.SelectedValue));
                bl_CatProduc.SelectedValue = dt_product.Rows[0]["ID_CATEGORIA_TIPO_PRODUCTO"].ToString();

                if (bl_TipoProducto.SelectedItem.Text == "SEGURO")
                {
                    BL_EstadosProdu.SelectedValue = dt_product.Rows[0]["ESTADO_PRODUCTO"].ToString();
                    hf_estado_producto.Value = BL_EstadosProdu.SelectedItem.Text;
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
                //txt_ValorTramite.Text = dt_product.Rows[0]["VALOR_TRAMITE"].ToString();
                //txt_ValorTerceros.Text = dt_product.Rows[0]["COSTO_TERCEROS"].ToString();
                txt_ValorServicio.Text = dt_product.Rows[0]["VALOR_SERVICIO"].ToString();
                txt_valorTotal.Text = dt_product.Rows[0]["VALOR_TOTAL"].ToString();
                //txt_Impuesto.Text = dt_product.Rows[0]["EXCEDENTE_IMPUESTO"].ToString();
                //txt_Exc_tramite.Text = dt_product.Rows[0]["EXCEDENTE_TRAMITE"].ToString();
                //txt_totalCobrar.Text = dt_product.Rows[0]["TOTAL_COBRAR"].ToString();
                txt_observacion.Value = dt_product.Rows[0]["OBSERVACION"].ToString();

                if (string.IsNullOrEmpty(dt_product.Rows[0]["ESTADO_ENDOSO"].ToString()) || string.IsNullOrWhiteSpace(dt_product.Rows[0]["ESTADO_ENDOSO"].ToString()) || dt_product.Rows[0]["ESTADO_ENDOSO"].ToString() == null)
                {
                    hf_estado_endoso.Value = "ACTUALIZADO";
                }
                else
                {
                    hf_estado_endoso.Value = dt_product.Rows[0]["ESTADO_ENDOSO"].ToString();
                }

                if (string.IsNullOrEmpty(dt_product.Rows[0]["ESTADO_RENOVADO"].ToString()) || string.IsNullOrWhiteSpace(dt_product.Rows[0]["ESTADO_RENOVADO"].ToString()) || dt_product.Rows[0]["ESTADO_RENOVADO"].ToString() == null)
                {
                    hf_estado_renovado.Value = "ACTUALIZADO";
                }
                else
                {
                    hf_estado_renovado.Value = dt_product.Rows[0]["ESTADO_RENOVADO"].ToString();
                }


            }

            mpe_Produc.Show();
            OcultarControles("O_MENSAGE");
            LimpiarControles("VER_PRODUCTO");

            bl_Tipopago.Enabled = false;
            bl_Numcuotas.Enabled = false;
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

            if (BL_EstadosProdu.SelectedItem.Text.Contains("Endoso") && hf_estado_endoso.Value == "POR_ACTUALIZAR")
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
                //txt_proximoPago.Enabled = true;
            }

            if (dt_product != null && dt_product.Rows.Count > 0)
            {
                if (dt_product.Rows[0]["ESTADO_INTERNO"].ToString() == "ACTIVO")
                {
                    btn_ActualizarEndoso.Visible = true;
                    BL_EstadosProdu.Enabled = true;
                    btn_ActualizarProduto.Visible = false;
                }
                else
                {
                    btn_ActualizarEndoso.Visible = false;
                    BL_EstadosProdu.Enabled = false;
                    btn_ActualizarProduto.Visible = false;
                }
            }
            else
            {
                btn_ActualizarEndoso.Visible = true;
                BL_EstadosProdu.Enabled = true;
                btn_ActualizarProduto.Visible = false;
            }
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

                    if (bl_Tipopago.SelectedItem.Text == "Seleccionar")
                    {
                        res.Message = "El tipo de pago es un campo obligatorio.";
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

        private string GuardarArchivos(HttpPostedFile archivo)
        {
            CLS_PRODUCTOS cls_produ = new CLS_PRODUCTOS();
            string idArchivo = "";
            Byte[] Archivo = null;
            string nombreArchivo = string.Empty;
            string extensionArchivo = string.Empty;


            if (archivo.ContentLength > 0)
            {
                using (BinaryReader reader = new BinaryReader(archivo.InputStream))
                {
                    Archivo = reader.ReadBytes(archivo.ContentLength);
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

                    txt_costoCuota.Text = dt_Cuotas.Rows[0]["VALOR_T"].ToString();
                    txt_costoCuota.Enabled = false;

                    txt_ValorPagarTarjeta.Text = dt_Cuotas.Rows[0]["VALOR_PAGADO_TARJETA"].ToString();
                    txt_ValorPagarTarjeta.Enabled = false;

                    txt_ValorPagarEfectivo.Text = dt_Cuotas.Rows[0]["VALOR_PAGADO_EFECTIVO"].ToString();
                    txt_ValorPagarEfectivo.Enabled = false;

                    txt_ValorPagarRecargo.Text = dt_Cuotas.Rows[0]["VALOR_RECARGO"].ToString();
                    txt_ValorPagarRecargo.Enabled = false;

                    txt_ObservacionCuota.Value = dt_Cuotas.Rows[0]["OBSERVACION"].ToString();
                    //txt_ObservacionCuota.EnableTheming = false;

                    cbx_Reinstalacion.Enabled = false;
                    if (dt_Cuotas.Rows[0]["ESTADO_CUOTA"].ToString() == "REINSTALACION")
                    {
                        cbx_Reinstalacion.Checked = true;
                    }
                    else
                    {
                        cbx_Reinstalacion.Checked = false;
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


                    txt_Reinstalacion.Text = dt_Cuotas.Rows[0]["VALORE_REINSTALACION"].ToString();
                    txt_Reinstalacion.Enabled = false;

                    txt_recargoCompania.Text = dt_Cuotas.Rows[0]["VALORE_RECARGO_COMPANIA"].ToString();
                    txt_recargoCompania.Enabled = false;

                    cbx_pagocompaniaCuota.Enabled = false;
                    if (dt_Cuotas.Rows[0]["PAGO_COMPANIA"].ToString() == "True")
                    {
                        cbx_pagocompaniaCuota.Checked = true;
                    }
                    else
                    {
                        cbx_pagocompaniaCuota.Checked = false;
                    }


                    cbx_RecargoCompania.Enabled = false;
                    if (dt_Cuotas.Rows[0]["VALORE_RECARGO_COMPANIA"].ToString() != "0")
                    {
                        cbx_RecargoCompania.Checked = true;
                    }
                    else
                    {
                        cbx_RecargoCompania.Checked = false;
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
                    txt_Reinstalacion.Text = "0";

                    txt_recargoCompania.Text = "0";

                    cbx_RecargoCompania.Checked = false;
                    cbx_Reinstalacion.Checked = false;
                    cbx_PagoInferior.Checked = false;
                    cbx_pagocompaniaCuota.Checked = false;

                    cbx_Reinstalacion.Enabled = true;
                    cbx_RecargoCompania.Enabled = true;
                    cbx_PagoInferior.Enabled = true;
                    cbx_pagocompaniaCuota.Enabled = true;
                    //txt_ObservacionCuota.ed = true;
                }

                if (dt_Cuotas.Rows[0]["ESTADO_CUOTA"].ToString() == "CANCELADO")
                {
                    btn_AceptarCuotas.Visible = true;
                }
                else
                {
                    btn_AceptarCuotas.Visible = false;
                }

                if (dt_Cuotas.Rows[0]["ESTADO_INTERNO"].ToString() == "ACTIVO")
                {
                    btn_AceptarCuotas.Visible = true;
                }
                else
                {
                    btn_AceptarCuotas.Visible = false;
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
            if (hf_estado_endoso.Value != "POR_ACTUALIZAR")
            {

                if (Convert.ToDecimal(txt_Costo.Text) >= Convert.ToDecimal(txt_valor.Text))
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

        }

        protected void CambioEstado()
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
                CLS_PRODUCTOS cls_produ = new CLS_PRODUCTOS();

                DataTable resul = null;
                resul = cls_produ.SP_33_INSERTAR_ENDOSO(Convert.ToInt32(hf_Producto.Value), Convert.ToInt32(id), Convert.ToInt32(Session["userID"].ToString()), 0, "NUEVO");
                if (resul != null)
                {
                    string idProducto = resul.Rows[0]["PRODUCTO_ENDOSO"].ToString();

                    CLS_AUDITORIA audi = new CLS_AUDITORIA();
                    string IP = Request.UserHostAddress;
                    string nombreCliente = $"{txt_PrimerNombre.Text} {txt_SegundoNombre.Text} {txt_Apellidos.Text}";
                    audi.SP_02_INSERTAR_AUDITORIA("ACTUALIZAR PRODUCTO", $"El usuario {Session["nombre_usuario"]} actualizo el estado de un producto a 'ENDOSO', producto asociado al cliente cliente {nombreCliente}", "VENTAS", IP, Convert.ToInt32(Session["userID"].ToString()));

                    hf_Producto.Value = idProducto;

                    DetallesProducto_Endoso(hf_Producto.Value);
                    //DetallesProducto(hf_Producto.Value);
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
                DataTable resul = cls_produ.SP_35_INSERTAR_REINSTALCION(Convert.ToInt32(hf_Producto.Value), Convert.ToInt32(id), Convert.ToInt32(Session["userID"].ToString()));

                if (resul != null && resul.Rows.Count > 0)
                {
                    string id_pro = resul.Rows[0]["ID_PRODUCTO"].ToString();
                    //
                    DetallesProducto(id_pro);

                    CLS_AUDITORIA audi = new CLS_AUDITORIA();
                    string IP = Request.UserHostAddress;
                    string nombreCliente = $"{txt_PrimerNombre.Text} {txt_SegundoNombre.Text} {txt_Apellidos.Text}";

                    audi.SP_02_INSERTAR_AUDITORIA("ACTUALIZAR PRODUCTO", $"El usuario {Session["nombre_usuario"]} actualizo el estado de un producto a 'ENDOSO', producto asociado al cliente cliente {nombreCliente}", "VENTAS", IP, Convert.ToInt32(Session["userID"].ToString()));

                    OcultarControles("ACTUALIZAR");
                    ProductosCliente(idCliente);
                }
            }

        }

        #endregion

        #region ENDOSO

        protected void gv_Endosos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerEndoso")
            {
                GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                //
                string idProducto = Convert.ToString(((Label)gvRow.FindControl("lbl_IdProducto_p")).Text.ToString());
                string idEndoso = Convert.ToString(((Label)gvRow.FindControl("lbl_IdProducto_endoso")).Text.ToString());
                string estadoP = Convert.ToString(((Label)gvRow.FindControl("lbl_estadProduc_endoso")).Text.ToString());

                btn_ActualizarProduto.Visible = false;
                btn_ActualizarEndoso.Visible = true;
                btn_aceptar.Visible = false;
                hf_Producto.Value = idEndoso;
                hf_estado_producto.Value = estadoP;

                DetallesProducto_Endoso(idEndoso);

                //BL_EstadosProdu.Enabled = false;
            }

        }


        protected void cbx_Reinstalacion_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_Reinstalacion.Checked)
            {
                txt_Reinstalacion.Enabled = true;
            }
            else
            {
                txt_Reinstalacion.Enabled = false;
                txt_Reinstalacion.Text = "0";
            }

            mpe_Cuotas.Show();
        }

        protected void cbx_RecargoCompania_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_RecargoCompania.Checked)
            {
                txt_recargoCompania.Enabled = true;
            }
            else
            {
                txt_recargoCompania.Enabled = false;
                txt_recargoCompania.Text = "0";
            }

            mpe_Cuotas.Show();
        }

        protected void btn_ActualizarEndoso_Click(object sender, EventArgs e)
        {
            string idCliente = "";
            try
            {
                idCliente = Page.Request.QueryString["CLIENT_ID"].ToString();
            }
            catch (Exception)
            {
            }

            decimal VALOR_PRODUCTO = 0;
            decimal COSTO = 0;
            decimal SERVICIO_ADICIONAL = 0;
            decimal CASH_OUT = 0;
            decimal TARJETA_CREDITO = 0;
            decimal PAGO_EFECTIVO = 0;
            decimal RECARGO = 0;
            decimal INTSALLMENTFEE = 0;
            decimal VALOR_COMPANIA = 0;
            string NUMERO_CUOTAS = "1";
            int ID_USUARIO = Convert.ToInt32(Session["userID"].ToString());


            if (!string.IsNullOrEmpty(txt_valor.Text) || !string.IsNullOrWhiteSpace(txt_valor.Text))
            {
                VALOR_PRODUCTO = Convert.ToDecimal(txt_valor.Text);
            }
            else
            {
                VALOR_PRODUCTO = 0;
            }

            if (!string.IsNullOrEmpty(txt_Costo.Text) || !string.IsNullOrWhiteSpace(txt_Costo.Text))
            {
                COSTO = Convert.ToDecimal(txt_Costo.Text);
            }
            else
            {
                COSTO = 0;
            }

            if (!string.IsNullOrEmpty(txt_SerAdicional.Text) || !string.IsNullOrWhiteSpace(txt_SerAdicional.Text))
            {
                SERVICIO_ADICIONAL = Convert.ToDecimal(txt_SerAdicional.Text);
            }
            else
            {
                SERVICIO_ADICIONAL = 0;
            }

            if (!string.IsNullOrEmpty(txt_CashOut.Text) || !string.IsNullOrWhiteSpace(txt_CashOut.Text))
            {
                CASH_OUT = Convert.ToDecimal(txt_CashOut.Text);
            }
            else
            {
                CASH_OUT = 0;
            }

            if (!string.IsNullOrEmpty(txt_tarjetaCedito.Text) || !string.IsNullOrWhiteSpace(txt_tarjetaCedito.Text))
            {
                TARJETA_CREDITO = Convert.ToDecimal(txt_tarjetaCedito.Text);
            }
            else
            {
                TARJETA_CREDITO = 0;
            }

            if (!string.IsNullOrEmpty(txt_pagoEfectivo.Text) || !string.IsNullOrWhiteSpace(txt_pagoEfectivo.Text))
            {
                PAGO_EFECTIVO = Convert.ToDecimal(txt_pagoEfectivo.Text);
            }
            else
            {
                PAGO_EFECTIVO = 0;
            }

            if (!string.IsNullOrEmpty(txt_recargo.Text) || !string.IsNullOrWhiteSpace(txt_recargo.Text))
            {
                RECARGO = Convert.ToDecimal(txt_recargo.Text);
            }
            else
            {
                RECARGO = 0;
            }

            if (!string.IsNullOrEmpty(txt_Intsallmentfee.Text) || !string.IsNullOrWhiteSpace(txt_Intsallmentfee.Text))
            {
                INTSALLMENTFEE = Convert.ToDecimal(txt_Intsallmentfee.Text);
            }
            else
            {
                INTSALLMENTFEE = 0;
            }

            if (!string.IsNullOrEmpty(txt_pagoCompania.Text) || !string.IsNullOrWhiteSpace(txt_pagoCompania.Text))
            {
                VALOR_COMPANIA = Convert.ToDecimal(txt_pagoCompania.Text);
            }
            else
            {
                VALOR_COMPANIA = 0;
            }

            string OBSERVACION = txt_observacion.Value;

            if (bl_Tipopago.SelectedItem.Text == "Cuotas")
            {
                NUMERO_CUOTAS = bl_Numcuotas.SelectedValue;
            }
            else
            {
                NUMERO_CUOTAS = null;
            }

            CLS_PRODUCTOS cls_produ = new CLS_PRODUCTOS();
            string idArchivo = "";
            string arrayArchivos = "";
            //Gestion de archivos
            if (file_Producto.HasFile)
            {
                HttpFileCollection hfc = Request.Files;

                if (hfc.Count <= 5)
                {
                    for (int i = 0; i <= hfc.Count - 1; i++)
                    {
                        HttpPostedFile hpf = hfc[i];
                        if (hpf.ContentLength > 0)
                        {
                            idArchivo = GuardarArchivos(hpf);
                            arrayArchivos += idArchivo + ";";
                        }
                    }
                }
            }
            //string ID_PRODUCTO,  decimal VALOR_PRODUCTO, decimal COSTO, decimal SERVICIO_ADICIONAL,
            //decimal CASH_OUT, decimal TARJETA_CREDITO, decimal PAGO_EFECTIVO,
            //decimal RECARGO, decimal NUMERO_CUOTAS, decimal INTSALLMENTFEE,
            //string OBSERVACION, string ID_USUARIO, string ESTADO_ENDOSO, string PAGO_COMPANIA, string VALOR_COMPANIA

            int resul = cls_produ.SP_62_ACTUALIZAR_PRODUCTO_ENDOSO(hf_Producto.Value,
                VALOR_PRODUCTO, COSTO, SERVICIO_ADICIONAL, CASH_OUT, TARJETA_CREDITO,
                PAGO_EFECTIVO, RECARGO, NUMERO_CUOTAS, INTSALLMENTFEE, OBSERVACION,
                ID_USUARIO, hf_estado_endoso.Value, VALOR_COMPANIA);


            if (resul > 0)
            {
                if (!string.IsNullOrEmpty(arrayArchivos) && !string.IsNullOrWhiteSpace(arrayArchivos))
                {
                    string[] words = arrayArchivos.Split(';');
                    foreach (var word in words)
                    {
                        System.Console.WriteLine($"<{word}>");
                        cls_produ.SP_30_GUARDAR_FORMULARIO_ARCHIVOS(word, idCliente, hf_Producto.Value, "PRODUCTOS");
                    }
                }

                CLS_AUDITORIA audi = new CLS_AUDITORIA();
                string IP = Request.UserHostAddress;
                string nombreCliente = $"{txt_PrimerNombre.Text} {txt_SegundoNombre.Text} {txt_Apellidos.Text}";

                audi.SP_02_INSERTAR_AUDITORIA("ACTUALIZAR PRODUCTO", $"El usuario {Session["nombre_usuario"]} actualizo el producto nuevo producto asociado al cliente cliente {nombreCliente}", "VENTAS", IP, Convert.ToInt32(Session["userID"].ToString()));

                if (bl_TipoProducto.SelectedItem.Text == "SEGURO")
                {
                    if (BL_EstadosProdu.SelectedItem.Text.Contains("Nuevo Endoso"))
                    {

                        string id = BL_EstadosProdu.SelectedValue;
                        //CLS_PRODUCTOS cls_produ = new CLS_PRODUCTOS();
                        DataTable resul2 = null;
                        resul2 = cls_produ.SP_33_INSERTAR_ENDOSO(Convert.ToInt32(hf_Producto.Value), Convert.ToInt32(4), Convert.ToInt32(Session["userID"].ToString()), 1, "NNUEVO_ENDOSO");
                        if (resul2 != null)
                        {
                            string idProducto = resul2.Rows[0]["PRODUCTO_ENDOSO"].ToString();
                            audi.SP_02_INSERTAR_AUDITORIA("ACTUALIZAR PRODUCTO", $"El usuario {Session["nombre_usuario"]} actualizo el estado de un producto a 'ENDOSO', producto asociado al cliente cliente {nombreCliente}", "VENTAS", IP, Convert.ToInt32(Session["userID"].ToString()));

                            hf_Producto.Value = idProducto;

                            DetallesProducto_Endoso(hf_Producto.Value);
                            //DetallesProducto(hf_Producto.Value);
                            //btn_ActualizarEndoso.Visible = false;
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


                OcultarControles("ACTUALIZAR");
                ProductosCliente(idCliente);

                Message_Succes.Text = "Producto actualizado correctamente";
                Message_Succes.Visible = true;
            }
            else
            {
                Message_danger.Text = "Error al actualizar producto";
                Message_danger.Visible = true;
            }
            //hf_Producto.Value = idProducto;
            //txt_valor.Enabled = true;
            //txt_Costo.Enabled = true;
            //txt_SerAdicional.Enabled = true;
            //txt_CashOut.Enabled = true;
            //txt_tarjetaCedito.Enabled = true;
            //txt_pagoEfectivo.Enabled = true;
            //txt_recargo.Enabled = true;
            //txt_Intsallmentfee.Enabled = true;
            //txt_pagoCompania.Enabled = true;
            //txt_proximoPago.Enabled = true;


        }

        #endregion

        #region COUTAS DMV
        protected void gv_cuotas_DMV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerCuotaDMV")
            {
                GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                string varName1 = Convert.ToString(((Label)gvRow.FindControl("lbl_COUTAS_DMV_1")).Text.ToString());

                hf_IDCUOTADMV.Value = varName1;

                DetallesCuotaDMV(varName1);
                mpe_CuotasDMV.Show();
            }

            //if (e.CommandName == "ImprimirCuota")
            //{
            //    //btn_ActualizarProduto.Visible = true;
            //    //btn_aceptar.Visible = false;
            //    //hf_Producto.Value = varName1;

            //    //DetallesProducto(varName1);
            //}

            //if (e.CommandName == "VerArchivosCuota")
            //{
            //    GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            //    string varName1 = Convert.ToString(((Label)gvRow.FindControl("lblCuotasProduc")).Text.ToString());

            //    mpe_Archivos.Show();
            //    ListaArchivos(varName1, "CUOTAS");

            //}
        }

        //detalles cuotas
        private void DetallesCuotaDMV(string idCuota)
        {
            CLS_PRODUCTOS cls_Cli = new CLS_PRODUCTOS();
            DataTable dt_CuotasDMV = cls_Cli.SP_38_GET_DETALLES_COUTAS_DMV(idCuota);

            if (dt_CuotasDMV != null && dt_CuotasDMV.Rows.Count > 0)
            {
                hf_IDCUOTADMV.Value = dt_CuotasDMV.Rows[0]["ID_COUTAS_DMV"].ToString();
                hf_ID_PRODUCTO_CUOTA.Value = dt_CuotasDMV.Rows[0]["ID_PRODUCTO"].ToString();

                txt_ValorImpuesto.Text = dt_CuotasDMV.Rows[0]["VALOR_IMPUESTO"].ToString();
                txt_ExcedenteImpuesto.Text = dt_CuotasDMV.Rows[0]["EXCEDENTE_IMPUESTO"].ToString();
                txt_tarjetaCeditoDMV.Text = dt_CuotasDMV.Rows[0]["VALOR_PAGO_TARJETA"].ToString();
                txt_recargoDMV.Text = dt_CuotasDMV.Rows[0]["VALOR_RECARGO"].ToString();
                txt_pagoEfectivoDMV.Text = dt_CuotasDMV.Rows[0]["VALOR_PAGO_EFECTIVO"].ToString();
                txt_ValorServicioDMV.Text = dt_CuotasDMV.Rows[0]["VALOR_SERVICIO"].ToString();
                txt_Exc_tramite.Text = dt_CuotasDMV.Rows[0]["EXCEDENTE_TRAMITE"].ToString();
                txt_totalCobrar.Text = dt_CuotasDMV.Rows[0]["TOTAL_COBRAR"].ToString();
                txt_cashout_DMV.Text = dt_CuotasDMV.Rows[0]["CASH_OUT"].ToString();

                DateTime fecha = Convert.ToDateTime(dt_CuotasDMV.Rows[0]["FECHA"]);
                txt_FechaDMV.Text = fecha.ToString("yyyy-MM-dd");

                txt_ObservacionDMV.Value = dt_CuotasDMV.Rows[0]["OBSERVACION"].ToString();

                if (dt_CuotasDMV.Rows[0]["ESTADO"].ToString() == "PAGADO")
                {
                    btn_AceptarCuotasDMV.Visible = false;

                    txt_ValorImpuesto.Enabled = false;
                    txt_ExcedenteImpuesto.Enabled = false;
                    txt_tarjetaCeditoDMV.Enabled = false;
                    txt_recargoDMV.Enabled = false;
                    txt_pagoEfectivoDMV.Enabled = false;
                    txt_ValorServicioDMV.Enabled = false;
                    txt_Exc_tramite.Enabled = false;
                    txt_totalCobrar.Enabled = false;
                    txt_cashout_DMV.Enabled = false;
                    txt_FechaDMV.Enabled = false;

                    cbx_Reinstalacion.Enabled = false;
                    cbx_pagoCompleto.Visible = false;
                    if (dt_CuotasDMV.Rows[0]["TIPO_PAGO"].ToString() == "TRASACTION")
                    {
                        cbx_transactin.Checked = true;
                        cbx_pagoCompleto.Checked = false;
                    }
                    else
                    {
                        cbx_pagoCompleto.Checked = true;
                        cbx_transactin.Checked = false;
                    }

                    if (dt_CuotasDMV.Rows[0]["ESTADO_INTERNO"].ToString() == "ACTIVO")
                    {
                        //btn_AceptarCuotasDMV.Visible = true;
                    }
                    else
                    {
                        btn_AceptarCuotasDMV.Visible = false;
                        btn_ActualizarCuotasDMV.Visible = false;
                    }

                    if (dt_CuotasDMV.Rows[0]["SEGUNDO_ESTADO"].ToString() == "SIN_FINALIZAR")
                    {
                        btn_AceptarCuotasDMV.Visible = false;
                        btn_ActualizarCuotasDMV.Visible = true;

                        txt_ValorImpuesto.Enabled = true;
                        txt_ExcedenteImpuesto.Enabled = true;
                        txt_tarjetaCeditoDMV.Enabled = true;
                        txt_recargoDMV.Enabled = true;
                        txt_pagoEfectivoDMV.Enabled = true;
                        txt_ValorServicioDMV.Enabled = true;
                        txt_Exc_tramite.Enabled = true;
                        txt_totalCobrar.Enabled = true;

                        txt_cashout_DMV.Enabled = true;
                        txt_FechaDMV.Enabled = true;

                        cbx_Reinstalacion.Enabled = true;
                        cbx_pagoCompleto.Visible = true;


                        //cbx_transactin.Checked = true;
                        //cbx_pagoCompleto.Checked = false;
                    }
                    else
                    {
                        btn_AceptarCuotasDMV.Visible = false;
                        btn_ActualizarCuotasDMV.Visible = false;
                    }

                }
                else
                {
                    btn_AceptarCuotasDMV.Visible = true;
                    btn_ActualizarCuotasDMV.Visible = false;

                    txt_ValorImpuesto.Enabled = true;
                    txt_ExcedenteImpuesto.Enabled = true;
                    txt_tarjetaCeditoDMV.Enabled = true;
                    txt_recargoDMV.Enabled = true;
                    txt_pagoEfectivoDMV.Enabled = true;
                    txt_ValorServicioDMV.Enabled = true;
                    txt_Exc_tramite.Enabled = true;
                    txt_totalCobrar.Enabled = true;

                    txt_cashout_DMV.Enabled = true;
                    txt_FechaDMV.Enabled = true;

                    cbx_Reinstalacion.Enabled = true;
                    cbx_pagoCompleto.Visible = true;


                    cbx_transactin.Checked = true;
                    cbx_pagoCompleto.Checked = false;

                    txt_ValorImpuesto.Text = "0";
                    txt_ExcedenteImpuesto.Text = "0";
                    txt_tarjetaCeditoDMV.Text = "0";
                    txt_recargoDMV.Text = "0";
                    txt_pagoEfectivoDMV.Text = "0";
                    txt_ValorServicioDMV.Text = "0";
                    txt_Exc_tramite.Text = "0";
                    txt_totalCobrar.Text = "0";

                    if (dt_CuotasDMV.Rows[0]["ESTADO_INTERNO"].ToString() == "ACTIVO")
                    {
                        //btn_AceptarCuotasDMV.Visible = true;
                    }
                    else
                    {
                        btn_AceptarCuotasDMV.Visible = false;
                        btn_ActualizarCuotasDMV.Visible = false;
                    }

                }

                //txt_ValorImpuesto.Text
                //txt_ExcedenteImpuesto.Text
                //txt_tarjetaCeditoDMV.Text
                //txt_recargoDMV.Text
                //txt_pagoEfectivoDMV.Text
                //txt_ValorServicioDMV.Text
                //txt_Exc_tramite.Text
                //txt_totalCobrar.Text

            }
            else
            {
                hf_IDCUOTADMV.Value = "";
            }
        }

        protected void btn_AceptarCuotasDMV_Click(object sender, EventArgs e)
        {
            string idCliente = "";
            try
            {
                idCliente = Page.Request.QueryString["CLIENT_ID"].ToString();
            }
            catch (Exception)
            {
            }

            string idCuota = hf_IDCUOTADMV.Value;
            string idProducto = hf_ID_PRODUCTO_CUOTA.Value;
            decimal valorImpuesto = Convert.ToDecimal(txt_ValorImpuesto.Text);
            decimal excedenteImpuesto = Convert.ToDecimal(txt_ExcedenteImpuesto.Text);
            decimal valortarjeta = Convert.ToDecimal(txt_tarjetaCeditoDMV.Text);
            decimal valorRecargo = Convert.ToDecimal(txt_recargoDMV.Text);
            decimal valorEfectivo = Convert.ToDecimal(txt_pagoEfectivoDMV.Text);
            decimal valorServicio = Convert.ToDecimal(txt_ValorServicioDMV.Text);
            decimal excedenteTramite = Convert.ToDecimal(txt_Exc_tramite.Text);
            decimal totalCobrar = Convert.ToDecimal(txt_totalCobrar.Text);

            decimal cashout = Convert.ToDecimal(txt_cashout_DMV.Text);

            DateTime fecha = DateTime.Now;
            if (!string.IsNullOrEmpty(txt_fechaNacimiento.Text) || !string.IsNullOrEmpty(txt_fechaNacimiento.Text))
            {
                fecha = Convert.ToDateTime(txt_FechaDMV.Text);
            }

            string observacion = txt_ObservacionDMV.Value;

            string estado = "TRASACTION";
            string tipoPago = "PAGADO";

            if (cbx_transactin.Checked)
            {
                tipoPago = "TRASACTION";
                estado = "PAGADO";
            }
            else
            {
                tipoPago = "PAGO_COMPLETO";
                estado = "PAGADO";
            }
            //Codigo de prueba

            int idUser = Convert.ToInt32(Session["userID"].ToString());

            CLS_PRODUCTOS cls_produ = new CLS_PRODUCTOS();
            int resul = cls_produ.SP_37_ACTUALIZAR_CUOTA_DMV(idCuota, idProducto, valorImpuesto, excedenteImpuesto, valortarjeta, valorRecargo, valorEfectivo, valorServicio, excedenteTramite, totalCobrar, estado, cashout, fecha, tipoPago, idUser, observacion);

            if (resul > 0)
            {
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
                mpe_CuotasDMV.Show();
            }

        }

        protected void btn_ActualizarCuotasDMV_Click(object sender, EventArgs e)
        {
            string idCliente = "";
            try
            {
                idCliente = Page.Request.QueryString["CLIENT_ID"].ToString();
            }
            catch (Exception)
            {
            }

            string idCuota = hf_IDCUOTADMV.Value;
            string idProducto = hf_ID_PRODUCTO_CUOTA.Value;
            decimal valorImpuesto = Convert.ToDecimal(txt_ValorImpuesto.Text);
            decimal excedenteImpuesto = Convert.ToDecimal(txt_ExcedenteImpuesto.Text);
            decimal valortarjeta = Convert.ToDecimal(txt_tarjetaCeditoDMV.Text);
            decimal valorRecargo = Convert.ToDecimal(txt_recargoDMV.Text);
            decimal valorEfectivo = Convert.ToDecimal(txt_pagoEfectivoDMV.Text);
            decimal valorServicio = Convert.ToDecimal(txt_ValorServicioDMV.Text);
            decimal excedenteTramite = Convert.ToDecimal(txt_Exc_tramite.Text);
            decimal totalCobrar = Convert.ToDecimal(txt_totalCobrar.Text);

            decimal cashout = Convert.ToDecimal(txt_cashout_DMV.Text);

            DateTime fecha = DateTime.Now;
            if (!string.IsNullOrEmpty(txt_fechaNacimiento.Text) || !string.IsNullOrEmpty(txt_fechaNacimiento.Text))
            {
                fecha = Convert.ToDateTime(txt_FechaDMV.Text);
            }

            string observacion = txt_ObservacionDMV.Value;

            string estado = "TRASACTION";
            string tipoPago = "PAGADO";

            if (cbx_transactin.Checked)
            {
                tipoPago = "TRASACTION";
                estado = "PAGADO";
            }
            else
            {
                tipoPago = "PAGO_COMPLETO";
                estado = "PAGADO";
            }
            //Codigo de prueba

            int idUser = Convert.ToInt32(Session["userID"].ToString());

            CLS_PRODUCTOS cls_produ = new CLS_PRODUCTOS();
            int resul = cls_produ.SP_72_ESTADO_ACTUALIZAR_ESTADO_CUOTA_DMV(idCuota, idProducto, valorImpuesto, excedenteImpuesto, valortarjeta, valorRecargo, valorEfectivo, valorServicio, excedenteTramite, totalCobrar, estado, cashout, fecha, tipoPago, idUser, observacion);

            if (resul > 0)
            {
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
                mpe_CuotasDMV.Show();
            }

        }

        protected void btn_cerrarCuotaDMV_Click(object sender, EventArgs e)
        {
            mpe_CuotasDMV.Hide();
        }

        protected void btn_CerrarInfo_Click(object sender, EventArgs e)
        {
            hf_InfoPop.Value = "False";
            mpe_Informes.Hide();
        }
        #endregion

        #region INFORMES

        private void Informe_Detalles_Seguro(string idProducto)
        {
            int idUser = Convert.ToInt32(Session["userID"].ToString());
            string sede = "S1";
            string secuencia = DateTime.Now.ToString("mmddyyyMMss_");
            secuencia += sede + "_" + idUser;

            CLS_INFORMES cls_Cli = new CLS_INFORMES();

            DataTable resul = null;
            resul = cls_Cli.SP_73_CREAR_SECUENCIA_FACTURA(sede, Convert.ToInt32(idProducto), secuencia, idUser);
            string idFactura = "0";
            if (resul != null)
            {
                idFactura = resul.Rows[0]["ID_FACTURA"].ToString();
            }

            DataTable dt_seguro = cls_Cli.SP_INFORME_GET_DETALLES_SEGURO(idProducto, idFactura);

            view_Reporte.LocalReport.DataSources.Clear();
            ReportDataSource re = new ReportDataSource("DataSet_Detalles_Seguro", dt_seguro);
            view_Reporte.LocalReport.DataSources.Add(re);
            view_Reporte.LocalReport.ReportPath = Server.MapPath("~/REPORTES/REPORT_PRODUCTOS/REPORT_SEGUROS/Report_Detalles_Seguro.rdlc");
            view_Reporte.InteractivityPostBackMode = InteractivityPostBackMode.AlwaysSynchronous;

            mpe_Informes.Show();
        }

        private void RegisterClient()
        {
            ClientScript.RegisterStartupScript(GetType(), "MostrarMensaje", "MostrarMensaje()", true);
        }

        #endregion

        protected void btn_Cliente_Click(object sender, EventArgs e)
        {
            ASPxButton btn = sender as ASPxButton;
            int idCliente = Convert.ToInt32(btn.TabIndex);
            Response.Redirect($"CLIENT_ID?CLIENT_ID={idCliente}");
        }

        protected void bnt_buscar_Click(object sender, EventArgs e)
        {
            ASPxComboBox cmb = this.Master.cmbpro_cliente;

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

                ConsularLista();
            }

        }

        protected void btn_close_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;

            int id = Convert.ToInt32(btn.TabIndex);
            var lista = (List<ClientesView>)Session["clientes"];
            var clientes = lista.Where(x => x.IdCliente == id).ToList();

            foreach (var item in clientes)
            {
                lista.Remove(item);
            }

            Session["clientes"] = lista;
            ConsularLista();
        }
    }
}