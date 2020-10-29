<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frm_llamadas.aspx.cs" Inherits="LATINMEX.MODULOS.LLAMADAS.frm_llamadas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

                                        <asp:LinkButton runat="server" ID="btn_MostrarInfo" CssClass="  btn btn-default">
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
                                            <asp:DropDownList ID="bl_CatProduc" runat="server" CssClass="form-control" DataTextField="TIPO_PRODUCTO" DataValueField="ID_TIPO_PRODUCTO">
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

                                    <div class="col-md-12 col-sm-12">

                                        <asp:GridView ID="gv_ListaEmpresas" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="ID_COMPANIA" CssClass="listoCuotas" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                            <Columns>
                                                <asp:BoundField DataField="NOMBRE" HeaderText="COMPAÑIA">
                                                    <ItemStyle />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CODIGO_INTERNO" HeaderText="CODIGI INTERNO" ItemStyle-Width="200px">
                                                    <ItemStyle Width="200px" Font-Size="Medium" />
                                                </asp:BoundField>
                                                <asp:TemplateField ItemStyle-Width="95">
                                                    <ItemTemplate>
                                                        <a href='<%#DataBinder.Eval(Container.DataItem, "URL_COMPANIA") %>' target="_blank">View</a>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="95px" Font-Size="Medium" />
                                                </asp:TemplateField>
                                            </Columns>
                                           <%-- <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                            <RowStyle ForeColor="#000066" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#00547E" />--%>
                                        </asp:GridView>
                                    </div>

                                    <table class="table">
                                        <thead>
                                            <tr>
                                                <th>Cliente</th>
                                                <th>Fecha caducidad</th>
                                                <th>número de poliza</th>
                                                <th>Fecha Proximo pago</th>
                                                <th style="width: 30px">Opciones</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr style="background-color: #fd0e2f6b;">
                                                <td>YOYITO CARRASCAL</td>
                                                <td>10/11/2020</td>
                                                <td>xxxxxxxx-123</td>
                                                <td>Sin fecha</td>
                                                <td>
                                                    <asp:LinkButton runat="server" ID="LinkButton2" ToolTip="Ver detalles" CommandName="VerCuota" Width="20" Height="20" CssClass="btn btn-sm btn-default">
                                                         <i class="fa fa-eye" aria-hidden="true"></i>                                                                             
                                                    </asp:LinkButton>
                                                    <asp:LinkButton runat="server" ID="btn_NuevaNota" ToolTip="Agregar Nota" CommandName="VerCuota" Width="20" Height="20" CssClass="btn btn-sm btn-default">
                                                         <i class="fa fa-th-list" aria-hidden="true"></i>                                                                             
                                                    </asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr style="background-color: #abfdc1;">

                                                <td>JUAN MARTINEZ</td>
                                                <td>23/10/2021</td>
                                                <td>xxxxxxxx-456</td>
                                                <td>Sin fecha</td>
                                                <td>
                                                    <asp:LinkButton runat="server" ID="LinkButton1" ToolTip="Ver detalles" CommandName="VerCuota" Width="20" Height="20" CssClass="btn btn-sm btn-default">
                                                         <i class="fa fa-eye" aria-hidden="true"></i>                                                                             
                                                    </asp:LinkButton>
                                                    <asp:LinkButton runat="server" ID="LinkButton4" ToolTip="Agregar Nota" CommandName="VerCuota" Width="20" Height="20" CssClass="btn btn-sm btn-default">
                                                         <i class="fa fa-th-list" aria-hidden="true"></i>                                                                             
                                                    </asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr style="background-color: #abfdc1;">
                                                <td>CAMILO CARRASCAL</td>
                                                <td>10/11/2021</td>
                                                <td>xxxxxxxx-789</td>
                                                <td>Sin fecha</td>
                                                <td>
                                                    <asp:LinkButton runat="server" ID="btn_verProducto" ToolTip="Ver detalles" CommandName="VerCuota" Width="20" Height="20" CssClass="btn btn-sm btn-default">
                                                         <i class="fa fa-eye" aria-hidden="true"></i>                                                                             
                                                    </asp:LinkButton>
                                                    <asp:LinkButton runat="server" ID="LinkButton5" ToolTip="Agregar Nota" CommandName="VerCuota" Width="20" Height="20" CssClass="btn btn-sm btn-default">
                                                         <i class="fa fa-th-list" aria-hidden="true"></i>                                                                             
                                                    </asp:LinkButton>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>

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

                                    <%--<div class="col-sm-12 ">
                                        <asp:Button ID="btn_NuevaNota" class="btn btn-sm btn-success" OnClick="btn_NuevaNota_Click" runat="server" Text="Agregar" />
                                    </div>--%>
                                    <asp:Panel runat="server">
                                        <asp:GridView ID="gv_Notas" runat="server" AutoGenerateColumns="false" DataKeyNames="ID_NOTA"
                                            ShowHeaderWhenEmpty="true"
                                            BackColor="White" BorderColor="#ffffff" BorderStyle="None" BorderWidth="1px" CellPadding="2">

                                            <%-- <FooterStyle BackColor="White" ForeColor="#000066" />
                                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                <RowStyle ForeColor="#000066" />
                                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                <SortedDescendingHeaderStyle BackColor="#00547E" />--%>

                                            <Columns>
                                                <%--<asp:BoundField HeaderText="DESCRIPCION"  DataField="DESCRIPCION"/>--%>

                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <div style="width: 100%; border: 1px solid #DBDBDB; margin-right: 5px;">
                                                            <div class="" style="margin-left: 7px;">
                                                                <%--<h3>--%>
                                                                <%--  <asp:Label runat="server" Text='<%# Eval("USUARIO") %>'></asp:Label>
                                                                    <small><%# Eval("FECHA_CREACION") %> </small>--%>

                                                                <%--  </h3>--%>
                                                                <p style="font-size: 15px;">
                                                                    <asp:Label runat="server" Font-Bold="true" Text='<%# Eval("USUARIO") %>'></asp:Label>
                                                                    <label style="width: 10px"></label>
                                                                    <small><%# Eval("FECHA_CREACION") %> </small>
                                                                    <br />
                                                                    <%# Eval("DESCRIPCION") %>
                                                                    <br />
                                                                    <small><%# Eval("PAGINA") %> </small>
                                                                    <%-- <asp:Label runat="server" Text='<%# Eval("PAGINA") %>'></asp:Label>--%>
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

            <ajaxToolkit:ModalPopupExtender ID="mpe_NuevaNota" runat="server" BackgroundCssClass="modalBackground" TargetControlID="btn_NuevaNota" PopupControlID="ModalPanel" OkControlID="btn_close" />
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

                            <div id="testmodal21" style="padding: 5px 20px;">

                                <label class="" style="font-size: 15px; color: black;">Description</label>
                                <textarea runat="server" id="txt_nota" class="form-control" style="height: 150px;"></textarea>

                            </div>
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


        </ContentTemplate>
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="gvCustomers" EventName="RowDataBound" />
        </Triggers>--%>
    </asp:UpdatePanel>

</asp:Content>
