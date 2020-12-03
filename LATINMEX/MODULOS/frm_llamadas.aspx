<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frm_llamadas.aspx.cs" Inherits="LATINMEX.MODULOS.LLAMADAS.frm_llamadas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .listoCuotas {
            background-color: #4ac1ef26;
            border-color: #8d9fb9;
            border-width: 1px;
            border-style: None;
            border-collapse: collapse;
            COLOR: BLACK;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="" role="main">

                <div class="row">

                    <asp:Label runat="server" ID="Message_Succes" Visible="false" Font-Size="19px" Font-Bold="true" CssClass="alert alert-success alert-dismissible col-12"></asp:Label>
                    <asp:Label runat="server" ID="Message_info" Visible="false" Font-Size="19px" Font-Bold="true" CssClass="alert alert-info alert-dismissible col-12"></asp:Label>
                    <asp:Label runat="server" ID="Message_warning" Visible="false" Font-Size="19px" Font-Bold="true" CssClass="alert alert-warning alert-dismissible col-12"></asp:Label>
                    <asp:Label runat="server" ID="Message_danger" Visible="false" Font-Size="19px" Font-Bold="true" CssClass="alert alert-danger alert-dismissible  col-12"></asp:Label>


                    <div class="col-md-9 col-sm-9">
                        <div class="x_panel">
                            <div class="x_title">
                                <h2>Lista de llamadas</h2>

                                <div class="clearfix"></div>
                            </div>
                            <div class="x_content">

                                <asp:Panel runat="server">
                                    <div class="item form-group">

                                        <asp:LinkButton runat="server" ID="btn_MostrarInfo" OnClick="btn_MostrarInfo_Click" CssClass="  btn btn-default">
                                                <i class="fa fa-search" aria-hidden="true"></i>
                                        </asp:LinkButton>


                                        <label class="col-form-label col-md-2 col-sm-2 label-align">
                                            Fecha Caducidad <span class="required" style="color: red">*</span>
                                        </label>
                                        <div class="col-md-2 col-sm-2 ">
                                            <asp:TextBox ID="txt_fechaNacimiento" CssClass="date-picker form-control" TextMode="Date" runat="server"></asp:TextBox>
                                        </div>

                                        <label class="col-form-label  label-align stile_label">
                                            Categoria seguro
                                        </label>
                                        <div class="col-md-2 col-sm-2 ">
                                            <asp:DropDownList ID="bl_CatProducto" runat="server" CssClass="form-control" DataTextField="TIPO_PRODUCTO" DataValueField="ID_TIPO_PRODUCTO">
                                            </asp:DropDownList>
                                        </div>

                                        <label class="col-form-label  label-align stile_label" for="last-name">
                                            Comp. Seg<span class="required" style="color: red">*</span>
                                        </label>
                                        <div class="col-md-2 col-sm-2 ">
                                            <asp:DropDownList ID="bl_CompaniaSe" AutoPostBack="true" runat="server" CssClass="form-control" DataTextField="NOMBRE" DataValueField="CODIGO_INTERNO">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server">

                                    <asp:HiddenField runat="server" ID="Id_Cliente" />
                                    <asp:GridView ID="gv_Llamadas" runat="server" Width="100%" OnRowDataBound="gv_Llamadas_RowDataBound" OnRowCommand="gv_Llamadas_RowCommand" AutoGenerateColumns="false" DataKeyNames="ID_PRODUCTO" CssClass="listoCuotas" BorderStyle="None" BorderWidth="1px" CellPadding="2">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Salary ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Produc" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ID_PRODUCTO") %>'></asp:Label>
                                                    <asp:Label ID="lbl_Cliente" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ID_CLIENTE") %>'></asp:Label>
                                                    <asp:Label ID="lbl_tipo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "TIPO") %>'></asp:Label>
                                                    <asp:Label ID="lbl_producto_a" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ID_PRODUCTO_A") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%--<asp:TemplateField HeaderText="ESTADO" ItemStyle-Width="90px">
                                                <ItemTemplate>
                                                    <label class="" style="font-weight: bold; color: <%#DataBinder.Eval(Container.DataItem, "color")%>">
                                                        <%#DataBinder.Eval(Container.DataItem, "ESTADO") %>
                                                    </label>                                                  
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>

                                            <asp:BoundField DataField="NOMBRE_CLIENTE" HeaderText="Cliente" />
                                            <asp:BoundField DataField="TELEFONO" HeaderText="Telefono" />
                                            <asp:BoundField DataField="FECHA_CADUCIDAD" HeaderText="Fecha caducidad" DataFormatString="{0:dd/MM/yyyy}" />
                                            <asp:BoundField DataField="DESCRIPCION" HeaderText="Producto" />
                                            <asp:BoundField DataField="COMPANIA_SEGURO" HeaderText="Comp. Seguro" />
                                            <asp:BoundField DataField="FECHA_PAGO" HeaderText="Fecha Proximo pago" DataFormatString="{0:dd/MM/yyyy}" />
                                            <asp:BoundField DataField="CANTIDAD_DIAS" HeaderText="Dias a vencer" />
                                            <asp:BoundField DataField="ESTADO_LLAMADA" Visible="false" HeaderText="Fecha Proximo pago" />

                                            <asp:TemplateField ItemStyle-Width="95" HeaderText="Opciones">
                                                <ItemTemplate>

                                                    <asp:LinkButton runat="server" ID="btn_verProducto" ToolTip="Agregar nota" CommandName="AgregarNota" Width="20" Height="20" CssClass="btn btn-sm btn-default">
                                                       <i class="fa fa-th-list" aria-hidden="true"></i>                                                                                                                                     
                                                    </asp:LinkButton>

                                                    <asp:LinkButton runat="server" ID="LinkButton5" ToolTip="Ver detalles del producto " CommandName="VerProducto" Width="20" Height="20" CssClass="btn btn-sm btn-default">
                                                      <i class="fa fa-eye" aria-hidden="true"></i>                                                                              
                                                    </asp:LinkButton>

                                                    <asp:LinkButton runat="server" ID="LinkButton1" ToolTip="Detalles llamada " CommandName="llamada" Width="20" Height="20" CssClass="btn btn-sm btn-default">
                                                      <i class="fa fa-phone" aria-hidden="true"></i>                                                                              
                                                    </asp:LinkButton>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>


                                </asp:Panel>

                            </div>
                        </div>
                    </div>


                    <div class="col-md-3 col-sm-3">
                        <div class="x_panel">
                            <div class="x_title">
                                <h2>Notas</h2>
                                <div class="clearfix"></div>
                            </div>
                            <div class="x_content">
                                <div class="row">

                                    <div class="col-sm-12 ">
                                        <asp:Button ID="btn_NuevaNota" Visible="false" class="btn btn-sm btn-success" OnClick="btn_NuevaNota_Click" runat="server" Text="Agregar" />
                                    </div>
                                    <asp:Panel runat="server">
                                        <asp:GridView ID="gv_Notas" runat="server" AutoGenerateColumns="false" DataKeyNames="ID_NOTA"
                                            ShowHeaderWhenEmpty="true"
                                            BackColor="White" BorderColor="#ffffff" BorderStyle="None" BorderWidth="1px" CellPadding="2">

                                            <Columns>

                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <div style="width: 100%; border: 1px solid #DBDBDB; margin-right: 5px;">
                                                            <div class="" style="margin-left: 7px;">
                                                                <p style="font-size: 15px;">
                                                                    <asp:Label runat="server" Font-Bold="true" Text='<%# Eval("USUARIO") %>'></asp:Label>
                                                                    <label style="width: 10px"></label>
                                                                    <small><%# Eval("FECHA_CREACION") %> </small>
                                                                    <br />
                                                                    <%# Eval("DESCRIPCION") %>
                                                                    <br />
                                                                    <asp:Label runat="server" CssClass="badge badge-secondary" Font-Size="11px" Font-Bold="true" Text='<%# Eval("PAGINA") %>'></asp:Label>
                                                                </p>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <%-- <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:ImageButton runat="server" ImageUrl="~/resources/images/eliminar_3.png" CommandName="EliminarNota" ToolTip="Eliminar nota" Height="20px" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

            <asp:HiddenField runat="server" ID="hf_Nota" />
            <ajaxToolkit:ModalPopupExtender ID="mpe_NuevaNota" runat="server" BackgroundCssClass="modalBackground" TargetControlID="hf_Nota" PopupControlID="ModalPanel" OkControlID="btn_close" />
            <asp:Panel ID="ModalPanel" runat="server" Width="500px">
                <div class="modal-dialog" runat="server">
                    <div class="modal-content">

                        <div class="modal-header" style="height: 48px">
                            <div class="left">
                                <h2>
                                    <asp:Label runat="server" ForeColor="#73879C" Text="Notas"></asp:Label>
                                </h2>
                            </div>
                            <button id="btn_close" type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        </div>
                        <div class="modal-body">

                            <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                                <ContentTemplate>


                                    <div id="testmodal21" style="padding: 5px 20px;">
                                        <label class="" style="font-size: 15px; color: black;">Description</label>
                                        <textarea runat="server" id="txt_nota" class="form-control" style="height: 150px;"></textarea>
                                    </div>

                                    <div class="item form-group" runat="server" id="div_llamada">
                                        <div>
                                            <asp:CheckBox ID="cbx_llamada" Text="Si respondio la llamada?" CssClass="col-form-label label-align stile_label" runat="server" />
                                        </div>
                                    </div>

                                </ContentTemplate>
                                <Triggers>
                                 
                                    <asp:PostBackTrigger ControlID="btn_crear" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton runat="server" ID="btn_crear" OnClick="btn_crearNota_Click" CssClass="btn btn-primary">
                                <i class="fa fa-save" aria-hidden="true"></i> Crear
                            </asp:LinkButton>
                            <asp:LinkButton runat="server" ID="btn_cerrar" OnClick="btn_cerrar_Click" CssClass="btn btn-secondary">
                                <i class="fa fa-close" aria-hidden="true"></i> Cancelar
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </asp:Panel>


            <asp:HiddenField runat="server" ID="hf_Producto" />
            <asp:HiddenField runat="server" ID="hf_tipoProducto" />
            <asp:HiddenField runat="server" ID="pp" />
            <ajaxToolkit:ModalPopupExtender ID="mpe_Produc" runat="server" BackgroundCssClass="modalBackground" TargetControlID="pp" PopupControlID="pnl_NuevoPro" OkControlID="btn_close_V" />
            <asp:Panel ID="pnl_NuevoPro" runat="server" CssClass="" Width="800PX" ScrollBars="Auto">
                <div class="modal-dialog" runat="server" style="max-width: 800px !important;">
                    <div class="modal-content">

                        <div class="modal-header" style="height: 48px">
                            <div class="left">
                                <h2>
                                    <asp:Label runat="server" ForeColor="#73879C" Text="Agrega Producto"></asp:Label>
                                </h2>
                            </div>
                            <button id="btn_close_V" type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        </div>
                        <div class="modal-body">

                            <asp:UpdatePanel runat="server" ID="test">
                                <ContentTemplate>
                                    <div class="" role="main">
                                        <span class="section">Información del seguro</span>

                                        <div class="item form-group">
                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label">
                                                Producto <span class="required" style="color: red">*</span>
                                            </label>
                                            <div class="col-md-3 col-sm-3 ">
                                                <asp:DropDownList ID="bl_TipoProducto" AutoPostBack="true" runat="server" CssClass="form-control" DataTextField="PRODUCTO" DataValueField="ID_PRODUCTO">
                                                </asp:DropDownList>
                                            </div>

                                            <label class="col-form-label col-md-1 col-sm-1 label-align stile_label">
                                                Categoria
                                            </label>
                                            <div class="col-md-2 col-sm-2 ">
                                                <asp:DropDownList ID="bl_CatProduc" AutoPostBack="true" runat="server" CssClass="form-control" DataTextField="TIPO_PRODUCTO" DataValueField="ID_TIPO_PRODUCTO">
                                                </asp:DropDownList>
                                            </div>

                                            <div runat="server" id="div_estad" class=" col-md-4 col-sm-4">
                                                <label class="col-form-label col-md-6 col-sm-6 label-align stile_label">
                                                    Estado Seguro <span class="required" style="color: red">*</span>
                                                </label>
                                                <div class="col-md-6 col-sm-6">
                                                    <asp:DropDownList ID="BL_EstadosProdu" runat="server" CssClass="form-control" DataTextField="ESTADO_SEGURO" DataValueField="ID_ESTADO_SEGURO">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div runat="server" id="dv_poliza" class="item form-group">
                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label" for="last-name">
                                                Núm. Poliza <span class="required" style="color: red">*</span>
                                            </label>
                                            <div class="col-md-10 col-sm-10 ">
                                                <asp:TextBox runat="server" ID="txt_numPoliza" CssClass="form-control" required=""></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="item form-group">
                                            <asp:Label Text="Fecha Factura" ID="lbl_fechaFactura" Visible="false" CssClass="col-form-label col-md-2 col-sm-2 label-align stile_label" runat="server" />
                                            <label runat="server" id="lbl_fechaInicio" class="col-form-label col-md-2 col-sm-2 label-align stile_label">
                                                Fecha Inicio <span class="required" style="color: red">*</span>
                                            </label>
                                            <div class="col-md-4 col-sm-4 ">
                                                <asp:TextBox ID="txt_FechInicio" CssClass="date-picker form-control" TextMode="Date" runat="server"></asp:TextBox>
                                            </div>

                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label">
                                                F. Caducidad <span class="required" style="color: red">*</span>
                                            </label>
                                            <div class="col-md-4 col-sm-4 ">
                                                <asp:TextBox ID="txt_fechCaduci" CssClass="date-picker form-control" TextMode="Date" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="item form-group" runat="server" id="dv_Compania">
                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label" for="last-name">
                                                Comp. Seg<span class="required" style="color: red">*</span>
                                            </label>
                                            <div class="col-md-4 col-sm-4 ">
                                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" DataTextField="NOMBRE" DataValueField="CODIGO_INTERNO">
                                                </asp:DropDownList>
                                            </div>

                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label" for="last-name">
                                                Codigo Interno 
                                            </label>
                                            <div class="col-md-4 col-sm-4 ">
                                                <asp:TextBox runat="server" ID="txt_CodInterno" AutoCompleteType="Email" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="item form-group" runat="server" id="dv_fechaRetiro" visible="false">
                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label" for="last-name">
                                                Fecha de retiro<span class="required" style="color: red">*</span>
                                            </label>
                                            <div class="col-md-4 col-sm-4 ">
                                                <asp:TextBox ID="txt_fechaRetiro" CssClass="date-picker form-control" TextMode="Date" runat="server"></asp:TextBox>
                                            </div>

                                            <div runat="server" class="col-md-6 col-sm-6 " id="dv_Reserva">
                                                <label class="col-form-label col-md-2 col-sm-2 label-align stile_label" for="last-name">
                                                    Reserva
                                                </label>
                                                <div class="col-md-10 col-sm-10">
                                                    <asp:TextBox runat="server" ID="txt_reserva" Enabled="false" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <span class="section">Información del cliente</span>

                                        <div class="item form-group">
                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label" for="last-name">
                                                Auxiliar 
                                            </label>
                                            <div class="col-md-4 col-sm-4 ">
                                                <asp:TextBox runat="server" ID="txt_NombreAuxiliar" Enabled="false" AutoCompleteType="Email" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <label class="col-form-label col-md-1 col-sm-1 label-align stile_label" for="last-name">
                                                Cliente 
                                            </label>
                                            <div class="col-md-5 col-sm-5">
                                                <asp:TextBox runat="server" ID="txt_NombreCliente" Enabled="false" CssClass="form-control" required=""></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="item form-group">
                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label" for="last-name">
                                                Empresa 
                                            </label>

                                            <div class="col-md-10 col-sm-10">
                                                <asp:TextBox ID="txtx_NombreEmpresa" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>


                                        <span class="section">Información de pago</span>

                                        <div class="item form-group" runat="server" id="dv_ValorTramite" visible="false">
                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label" for="last-name">
                                                Valor Tramite 
                                            </label>
                                            <div class="col-md-4 col-sm-4">
                                                <asp:TextBox runat="server" ID="txt_ValorTramite" TextMode="Number" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label" style="width: 68px !important;" for="last-name">
                                                Costo a Terceros 
                                            </label>
                                            <div class="col-md-4 col-sm-4">
                                                <asp:TextBox runat="server" ID="txt_ValorTerceros" TextMode="Number" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>


                                        <div class="item form-group">
                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label" for="last-name">
                                                Efectivo 
                                            </label>
                                            <div class="col-md-3 col-sm-3 ">
                                                <asp:TextBox runat="server" ID="txt_pagoEfectivo" AutoPostBack="true" OnTextChanged="txt_Adicional_TextChanged" TextMode="Number" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <label class="col-form-label label-align stile_label" style="width: 68px !important;" for="last-name">
                                                T. Credito 
                                            </label>
                                            <div class="col-md-3 col-sm-3 ">
                                                <asp:TextBox runat="server" ID="txt_tarjetaCedito" AutoPostBack="true" OnTextChanged="txt_tarjetaCedito_TextChanged" TextMode="Number" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <label class="col-form-label col-md-1 col-sm-1 label-align stile_label" for="last-name">
                                                Recargo 
                                            </label>
                                            <div class="col-md-2 col-sm-2">
                                                <asp:TextBox runat="server" ID="txt_recargo" AutoPostBack="true" OnTextChanged="txt_Adicional_TextChanged" TextMode="Number" Enabled="false" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="item form-group" runat="server" id="dv_valorServicio" visible="false">
                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label" for="last-name">
                                                Valor Servicio 
                                            </label>
                                            <div class="col-md-4 col-sm-4">
                                                <asp:TextBox runat="server" ID="txt_ValorServicio" AutoPostBack="true" OnTextChanged="txt_Adicional_TextChanged" TextMode="Number" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label" style="width: 68px !important;" for="last-name">
                                                Valor Total inicial
                                            </label>
                                            <div class="col-md-4 col-sm-4">
                                                <asp:TextBox runat="server" ID="txt_valorTotal" TextMode="Number" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="item form-group" runat="server" id="dv_Impuestos" visible="false">
                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label" for="last-name">
                                                Excedente  impuesto 
                                            </label>
                                            <div class="col-md-3 col-sm-3 ">
                                                <asp:TextBox runat="server" ID="txt_Impuesto" TextMode="Number" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <label class="col-form-label label-align stile_label" style="width: 68px !important;" for="last-name">
                                                Excedente tramite
                                            </label>
                                            <div class="col-md-3 col-sm-3 ">
                                                <asp:TextBox runat="server" ID="txt_Exc_tramite" TextMode="Number" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <label class="col-form-label col-md-1 col-sm-1 label-align stile_label" for="last-name">
                                                Total a cobrar 
                                            </label>
                                            <div class="col-md-2 col-sm-2">
                                                <asp:TextBox runat="server" ID="txt_totalCobrar" TextMode="Number" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="item form-group" runat="server" id="dv_CostosSeguro" visible="true">

                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label" style="width: 68px !important;" for="last-name">
                                                Costo 
                                            </label>
                                            <div class="col-md-3 col-sm-3">
                                                <asp:TextBox runat="server" ID="txt_Costo" AutoPostBack="true" OnTextChanged="txt_Adicional_TextChanged" TextMode="Number" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <label class="col-form-label col-md-1 col-sm-1 label-align stile_label" for="last-name">
                                                Adicional 
                                            </label>
                                            <div class="col-md-2 col-sm-2 ">
                                                <asp:TextBox runat="server" ID="txt_SerAdicional" TextMode="Number" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <label class="col-form-label  label-align stile_label" for="last-name">
                                                Premium 
                                            </label>
                                            <div class="col-md-3 col-sm-3">
                                                <asp:TextBox runat="server" ID="txt_valor" TextMode="Number" CssClass="form-control"></asp:TextBox>
                                            </div>

                                        </div>
                                        <div class="item form-group">

                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label" for="last-name">
                                                Cash out
                                            </label>
                                            <div class="col-md-3 col-sm-3">
                                                <asp:TextBox runat="server" ID="txt_CashOut" TextMode="Number" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <label class="col-form-label label-align stile_label" style="width: 130px !important;" for="last-name">
                                                Tipo de Pago 
                                            </label>
                                            <div class="col-md-3 col-sm-3">
                                                <asp:DropDownList ID="bl_Tipopago" runat="server" AutoPostBack="true" CssClass="form-control">
                                                    <asp:ListItem Value="1" Text="Seleccionar"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Cuotas"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Completa"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>

                                            <label class="col-form-label  label-align stile_label" for="last-name">
                                                Cuotas
                                            </label>
                                            <div class="col-md-2 col-sm-2">
                                                <asp:DropDownList ID="bl_Numcuotas" Enabled="false" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="0" Text="Cantidad"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="3"></asp:ListItem>
                                                    <asp:ListItem Value="4" Text="4"></asp:ListItem>
                                                    <asp:ListItem Value="5" Text="5"></asp:ListItem>
                                                    <asp:ListItem Value="6" Text="6"></asp:ListItem>
                                                    <asp:ListItem Value="7" Text="7"></asp:ListItem>
                                                    <asp:ListItem Value="8" Text="8 "></asp:ListItem>
                                                    <asp:ListItem Value="9" Text="9"></asp:ListItem>
                                                    <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                                    <asp:ListItem Value="11" Text="11"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="item form-group" runat="server" id="dv_ProximoPago" visible="true">
                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label" for="last-name">
                                                Proximo Pago
                                            </label>
                                            <div class="col-md-4 col-sm-4 ">
                                                <asp:TextBox ID="txt_proximoPago" CssClass="date-picker form-control" TextMode="Date" runat="server"></asp:TextBox>
                                            </div>

                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label" for="last-name">
                                                Intsallmentfee 
                                            </label>
                                            <div class="col-md-4 col-sm-4">
                                                <asp:TextBox runat="server" ID="txt_Intsallmentfee" TextMode="Number" CssClass="form-control"></asp:TextBox>
                                            </div>

                                        </div>
                                        <div class="item form-group">
                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label" for="last-name">
                                                Archivo <span class="required" style="color: red">*</span>
                                            </label>
                                            <div class="col-md-9 col-sm-9 ">
                                                <asp:FileUpload ID="file_Producto" runat="server" CssClass="form-control" />
                                            </div>

                                            <div class=" ">
                                                <asp:CheckBox ID="cb_prospecto" Text="  Prospecto  " runat="server" />
                                            </div>

                                        </div>
                                        <div class="item form-group">
                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label" for="last-name">
                                                Observación
                                            </label>
                                            <div class="col-md-10 col-sm-10 ">
                                                <textarea runat="server" id="txt_observacion" class="form-control" style="height: 50px;"></textarea>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="bl_TipoProducto" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="bl_CatProduc" EventName="SelectedIndexChanged" />

                                    <asp:AsyncPostBackTrigger ControlID="bl_CompaniaSe" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="bl_Tipopago" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="txt_tarjetaCedito" EventName="TextChanged" />

                                    <%--<asp:PostBackTrigger ControlID="btn_aceptar" />--%>
                                    <%-- <asp:PostBackTrigger ControlID="btn_ActualizarProduto" />--%>
                                </Triggers>
                            </asp:UpdatePanel>

                        </div>
                        <div class="modal-footer">
                            <%--<asp:Button runat="server" ID="btn_ActualizarProduto" CssClass="btn btn-success" Text="Actualizar" OnClick="btn_ActualizarProduto_Click" />
                            <asp:Button runat="server" ID="btn_aceptar" CssClass="btn btn-success" Text="Aceptar" OnClick="btn_aceptar_Click" />
                            <asp:Button runat="server" ID="btn_imprimir" CssClass="btn btn-primary" Text="Imprimir  " OnClick="btn_imprimir_Click" />--%>

                            <asp:LinkButton runat="server" ID="btn_cerrPro" OnClick="btn_cerrPro_Click" CssClass="btn btn-secondary">
                                <i class="fa fa-close" aria-hidden="true"></i> Cerrar
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </asp:Panel>


            <asp:HiddenField runat="server" ID="hf_Cuotas" />
            <asp:HiddenField runat="server" ID="hf_IDCUOTA" />
            <asp:HiddenField runat="server" ID="hf_ID_PRODUCTO_CUOTA" />
            <ajaxToolkit:ModalPopupExtender ID="mpe_Cuotas" runat="server" BackgroundCssClass="modalBackground" TargetControlID="hf_Cuotas" PopupControlID="pnl_Cuotas" OkControlID="btn_close_C" />
            <asp:Panel ID="pnl_Cuotas" runat="server" Width="900PX">
                <div class="modal-dialog" runat="server" style="max-width: 800px !important;">
                    <div class="modal-content">

                        <div class="modal-header" style="height: 48px">
                            <div class="left">
                                <h2>
                                    <asp:Label runat="server" ForeColor="#73879C" Text="DETALLES CUOTA"></asp:Label>
                                </h2>
                            </div>
                            <button id="btn_close_C" type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        </div>
                        <div class="modal-body">

                            <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                                <ContentTemplate>

                                    <div class="" role="main">

                                        <%-- <span class="section">Información de la cuota</span>--%>

                                        <div class="item form-group">
                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label">
                                                Producto
                                            </label>
                                            <div class="col-md-2 col-sm-2 ">
                                                <asp:TextBox ID="txt_Cuotas_producto" Enabled="false" CssClass="date-picker form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <label class=" col-form-label label-align stile_label">
                                                Catergoria
                                            </label>
                                            <div class="col-md-3 col-sm-3 ">
                                                <asp:TextBox ID="txt_Cuotas_Categoria" Enabled="false" CssClass="date-picker form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <label class="col-form-label  label-align stile_label">
                                                Es. Seguro
                                            </label>
                                            <div class="col-md-3 col-sm-3 ">
                                                <asp:TextBox ID="txt_Cuotas_EstadoSeguro" Enabled="false" CssClass="date-picker form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="item form-group">
                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label">
                                                Cuota
                                            </label>
                                            <div class="col-md-4 col-sm-4">
                                                <asp:TextBox ID="txt_Cuota" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label">
                                                Fecha de Pago
                                            </label>
                                            <div class="col-md-4 col-sm-4">
                                                <asp:TextBox ID="txt_fproximoPago" Enabled="false" CssClass="date-picker form-control" TextMode="Date" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="item form-group">

                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label">
                                                Estado Cuota
                                            </label>
                                            <div class="col-md-4 col-sm-4">
                                                <asp:TextBox ID="txt_EstodoCuota" Enabled="false" CssClass="date-picker form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label">
                                                Valor Cuota
                                            </label>
                                            <div class="col-md-4 col-sm-4">
                                                <asp:TextBox ID="txt_valorCuota" Enabled="false" CssClass="date-picker form-control" runat="server"></asp:TextBox>
                                            </div>

                                        </div>

                                        <div class="item form-group">

                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label">
                                                pago tarjeta
                                            </label>
                                            <div class="col-md-2 col-sm-2">
                                                <asp:TextBox ID="txt_ValorPagarTarjeta" TextMode="Number" CssClass="date-picker form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label">
                                                Pago efectivo
                                            </label>
                                            <div class="col-md-2 col-sm-2">
                                                <asp:TextBox ID="txt_ValorPagarEfectivo" TextMode="Number" CssClass="date-picker form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label">
                                                Recargo tarjeta
                                            </label>
                                            <div class="col-md-2 col-sm-2">
                                                <asp:TextBox ID="txt_ValorPagarRecargo" TextMode="Number" CssClass="date-picker form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="item form-group">
                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label" for="last-name">
                                                Archivo 
                                            </label>
                                            <div class="col-md-10 col-sm-10 ">
                                                <asp:FileUpload ID="file_Cuotas" runat="server" CssClass="form-control" />
                                            </div>
                                        </div>


                                        <div class="item form-group">

                                            <div class="col-md-2 col-sm-2 ">
                                            </div>
                                            <div>
                                                <asp:CheckBox ID="cbx_PagoInferior" Text="Pago Inferior a l valor de la cuota" CssClass="col-form-label label-align stile_label" runat="server" />
                                            </div>
                                        </div>

                                        <div class="item form-group">
                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label" for="last-name">
                                                Observación
                                            </label>
                                            <div class="col-md-10 col-sm-10 ">
                                                <textarea runat="server" id="txt_ObservacionCuota" class="form-control" style="height: 50px;"></textarea>
                                            </div>
                                        </div>

                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="btn_AceptarCuotas" />
                                    <asp:PostBackTrigger ControlID="btn_ImprimirCuota" />
                                </Triggers>
                            </asp:UpdatePanel>

                        </div>
                        <div class="modal-footer">

                            <asp:LinkButton runat="server" ID="btn_AceptarCuotas" OnClick="btn_AceptarCuotas_Click" CssClass="btn btn-success">
                                <i class="fa fa-save" aria-hidden="true"></i> Aceptar
                            </asp:LinkButton>

                            <asp:Button runat="server" ID="btn_ImprimirCuota" CssClass="btn btn-primary" Text="Imprimir" />

                            <asp:LinkButton runat="server" ID="btn_cerrarCuota" OnClick="btn_cerrarCuota_Click" CssClass="btn btn-secondary">
                                <i class="fa fa-close" aria-hidden="true"></i> Cancelar
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="gvCustomers" EventName="RowDataBound" />
        </Triggers>--%>
    </asp:UpdatePanel>

</asp:Content>
