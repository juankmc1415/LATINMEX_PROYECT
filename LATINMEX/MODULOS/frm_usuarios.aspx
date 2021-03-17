<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frm_usuarios.aspx.cs" Inherits="LATINMEX.MODULOS.frm_usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="col-md-12 col-lg-10 offset-lg-1">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <form id="demo-form11" enctype="multipart/form-data">
                    <div class="row" role="main">

                        <asp:Label runat="server" ID="Message_Succes" Visible="false" Font-Size="19px" Font-Bold="true" CssClass="alert alert-success alert-dismissible col-12"></asp:Label>
                        <asp:Label runat="server" ID="Message_info" Visible="false" Font-Size="19px" Font-Bold="true" CssClass="alert alert-info alert-dismissible col-12"></asp:Label>
                        <asp:Label runat="server" ID="Message_warning" Visible="false" Font-Size="19px" Font-Bold="true" CssClass="alert alert-warning alert-dismissible col-12"></asp:Label>
                        <asp:Label runat="server" ID="Message_danger" Visible="false" Font-Size="19px" Font-Bold="true" CssClass="alert alert-danger alert-dismissible  col-12"></asp:Label>

                        <div class="col-lg-9 col-md-9 col-sm-12">
                            <div class="x_panel">
                                <div class="x_title">
                                    <h2>
                                        <asp:Label runat="server" ForeColor="#73879C" Text="Detalles del usuario"></asp:Label>
                                    </h2>
                                    <div class="clearfix">
                                        <div class="pull-right">
                                            <strong>
                                                <label style="color: black" class="text-center">
                                                    <asp:CheckBox ID="ck_forzarCambio" AutoPostBack="true" OnCheckedChanged="ck_forzarCambio_CheckedChanged" CssClass="form-check-input text-center" runat="server" />
                                                    Forzar cambio de Contraseña</label></strong>
                                            <a class="btn btn-default btn-sm" href="frm_ListaUsuarios.aspx" title="Volver a  lista de usuarios"><i class="fa fa-list"></i>Volver a lista</a>
                                        </div>
                                    </div>
                                </div>

                                <div class="x_content">
                                    <%--<form id="demo-form2" class="form-horizontal form-label-left">--%>
                                    <asp:Panel runat="server" ID="pnll_info1">
                                        <div class="row">
                                            <div class="col-lg-3 col-md-3">
                                                <img id="img_usuarios" src="../Files/Usuarios/perfilusuarios.png" width="150" runat="server" height="150" class="img-circle" />
                                               <br />
                                                <div class="text-center">
                                                    <strong>
                                                        <asp:Label ID="lb_nombre" ForeColor="Black" runat="server" Text="Nombre usuario"></asp:Label></strong>
                                                </div>
                                            </div>
                                            <div class="col-md-9 col-lg-9">

                                                <div class="item form-group">
                                                    <label class="col-form-label col-md-2 col-sm-2 label-align" for="first-name">
                                                        Nombres <span class="required" style="color: red">*</span>
                                                    </label>
                                                    <div class="col-md-10 col-sm-10">
                                                        <asp:TextBox runat="server" ID="txt_nombres" placeholder="Digite nombres" MaxLength="100" CssClass="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="nombresVls" runat="server"
                                                            CssClass="text text-danger"
                                                            ControlToValidate="txt_nombres"
                                                            ValidationGroup="Registrar" Display="Dynamic"
                                                            ErrorMessage="Campo obligatorio"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>

                                                <div class="item form-group">
                                                    <label class="col-form-label col-md-2 col-sm-2 label-align" for="first-name">
                                                        Apellidos <span class="required" style="color: red">*</span>
                                                    </label>
                                                    <div class="col-md-10 col-sm-10">
                                                        <asp:TextBox runat="server" ID="txt_apellidos" placeholder="Digite apellidos" MaxLength="100" CssClass="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="apellidosVls" runat="server"
                                                            CssClass="text text-danger"
                                                            ControlToValidate="txt_apellidos"
                                                            ValidationGroup="Registrar" Display="Dynamic"
                                                            ErrorMessage="Campo obligatorio"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>


                                                <div class="item form-group">
                                                    <label class="col-form-label col-md-2 col-sm-2 label-align" for="first-name">
                                                        Email <span class="required" style="color: red">*</span>
                                                    </label>
                                                    <div class="col-md-10 col-sm-10">
                                                        <asp:TextBox runat="server" ID="txt_email" placeholder="Digite Email" MaxLength="100" CssClass="form-control"></asp:TextBox>

                                                        <asp:RequiredFieldValidator ID="emailVLs" runat="server"
                                                            CssClass="text text-danger"
                                                            ControlToValidate="txt_email"
                                                            ValidationGroup="Registrar" Display="Dynamic"
                                                            ErrorMessage="Campo obligatorio"></asp:RequiredFieldValidator>

                                                        <asp:RegularExpressionValidator ID="ValidEmailVld"
                                                            CssClass="text text-danger"
                                                            ValidationGroup="Registrar" Display="Dynamic"
                                                            ControlToValidate="txt_email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                            runat="server" ErrorMessage="Email no válido"></asp:RegularExpressionValidator>
                                                    </div>
                                                </div>

                                                <div class="item form-group">
                                                    <label class="col-form-label col-md-2 col-sm-2 label-align" for="first-name">
                                                        Estado <span class="required" style="color: red">*</span>
                                                    </label>
                                                    <div class="col-md-10 col-sm-10">

                                                        <asp:DropDownList ID="lst_estados" CssClass="form-control"
                                                            DataValueField="Id" DataTextField="Nombre"
                                                            runat="server">
                                                            <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                                            <asp:ListItem Value="1">Activo</asp:ListItem>
                                                            <asp:ListItem Value="2">Inactivo</asp:ListItem>
                                                        </asp:DropDownList>

                                                        <asp:RangeValidator ID="EstadoVls" runat="server"
                                                            ControlToValidate="lst_estados"
                                                            CssClass="text text-danger"
                                                            ValidationGroup="Registrar" Display="Dynamic"
                                                            MinimumValue="1" MaximumValue="B" Type="String"
                                                            ErrorMessage="Campo obligatorio"></asp:RangeValidator>
                                                    </div>
                                                </div>

                                                <div class="item form-group">
                                                    <label class="col-form-label col-md-2 col-sm-2 label-align" for="first-name">
                                                        Fecha Creación 
                                                    </label>
                                                    <div class="col-md-10 col-sm-10">
                                                        <asp:TextBox runat="server" ID="lb_fechaCreacion" Enabled="false" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="item form-group">
                                                    <label class="col-form-label col-md-2 col-sm-2 label-align" for="first-name">
                                                        Fecha Actualización
                                                    </label>
                                                    <div class="col-md-10 col-sm-10">
                                                        <asp:TextBox runat="server" ID="lb_fechaActulizacion" Enabled="false" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="item form-group">
                                                    <div class="col-md-2 col-sm-2">
                                                    </div>
                                                    <div class="col-md-10 col-sm-10">
                                                        <asp:LinkButton ID="btn_registrar"
                                                            ValidationGroup="Registrar"
                                                            CssClass="btn btn-success btn-sm"
                                                            OnClick="btn_registrar_Click" runat="server">
                                                                  Registrar
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="btn_crearNuevo" Visible="false" class="btn btn-primary btn-sm" PostBackUrl="frm_usuarios.aspx" runat="server"> <i class="fa fa-plus"></i> Nuevo usuario</asp:LinkButton>
                                                    </div>

                                                </div>


                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <%-- </form>--%>
                                </div>
                            </div>

                            <div class="x_panel">
                                <div class="x_title">
                                    <h2>
                                        <asp:Label runat="server" ForeColor="#73879C" Text="Auditorias"></asp:Label>
                                    </h2>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="x_content">
                                    <%--<form id="demo-form2" class="form-horizontal form-label-left">--%>
                                    <asp:Panel runat="server" ID="Panel2">


                                        <asp:Repeater ID="Rp_AuditoriasUsuario" runat="server">
                                            <HeaderTemplate>
                                                <table class="table">
                                                    <thead>
                                                        <tr class="table-active">
                                                            <th scope="col">Fecha Registro</th>
                                                            <th scope="col">Descripcion</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Convert.ToDateTime(Eval("FechaHoraRegistro")).ToShortDateString() %></td>
                                                    <td><%# Eval("DESCRIPCION") %></td>
                                                </tr>

                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </tbody>
                                          </table>
                                            </FooterTemplate>
                                        </asp:Repeater>



                                    </asp:Panel>
                                    <%-- </form>--%>
                                </div>
                            </div>
                        </div>


                        <div class="col-lg-3 col-md-3 col-sm-12">
                            <div class="x_panel">
                                <div class="x_title">
                                    <h2>
                                        <asp:Label runat="server" ForeColor="#73879C" Text="Lista de roles"></asp:Label>
                                    </h2>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="x_content">
                                    <%--<form id="demo-form2" class="form-horizontal form-label-left">--%>
                                    <asp:Panel runat="server" ID="Panel1">

                                        <asp:GridView Width="100%" ID="gvRp_Roles" runat="server" AutoGenerateColumns="false"
                                            ShowHeaderWhenEmpty="true"
                                            ShowHeader="false"
                                            HeaderStyle-CssClass="d-lg-none"
                                            BackColor="White" CssClass="col-sm-11 col-md-11  form-group" BorderWidth="1px" CellPadding="2">
                                            <Columns>
                                                <asp:TemplateField HeaderText="0.15">
                                                    <ItemTemplate>
                                                        <div class="text-center no-padding">
                                                            <asp:CheckBox ID="ckh_rol" Checked='<%# !String.IsNullOrEmpty(Eval("ID_USUARIO").ToString())%>' TabIndex='<%# Convert.ToInt32(Eval("ID_ROL")) %>' runat="server" />
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <div class="text-left" style="padding-bottom: 0; padding-top: 0">
                                                            <asp:Label runat="server" Font-Bold="true" Text='<%# Eval("ROL") %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                            </Columns>
                                        </asp:GridView>


                                    </asp:Panel>
                                    <%-- </form>--%>
                                </div>
                            </div>
                        </div>

                    </div>

                </form>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>
