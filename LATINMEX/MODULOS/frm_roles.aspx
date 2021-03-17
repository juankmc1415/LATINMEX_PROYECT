<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frm_roles.aspx.cs" Inherits="LATINMEX.MODULOS.frm_roles" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-12 col-lg-10 offset-lg-1">


        <script type="text/javascript"> 
            function GetMessageFromServer(s, e, op='') {
                UseCallBack(s.toString() + ","+op+ e, "");

            }
            function JSCallback(TextBox1, context) {
                //when callback finishes execution this method will called 
                if (TextBox1 == 'Correcto') {
                    $('#<%=Message_Succes.ClientID%>').show();
                    $('#<%=Message_Succes.ClientID%>').html("Menu/permiso asignado correctamente");
                }

                if (TextBox1 == 'Incorrecto') {
                    $('#<%=Message_danger.ClientID%>').show();
                    $('#<%=Message_danger.ClientID%>').html("Menu/permiso asignado correctamente");

                }

                if (TextBox1 == 'Permiso') {
                    $('#<%=Message_warning.ClientID%>').show();
                    $('#<%=Message_warning.ClientID%>').html("El suario no cuenta con permisos para este asignar o desasignar");
                }
              
               
            }

            function UseCallBack(arg, context) {
                WebForm_DoCallback('__Page', arg, JSCallback, context, null, false);
            }

        </script>


        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <form id="demo-form11" enctype="multipart/form-data">
                    <div class="row" role="main">

                        <asp:Label runat="server" ID="Message_Succes" style="display:none;" Font-Size="19px" Font-Bold="true" CssClass="alert alert-success alert-dismissible col-12" ></asp:Label>
                        <asp:Label runat="server" ID="Message_info" style="display:none;" Font-Size="19px" Font-Bold="true" CssClass="alert alert-info alert-dismissible col-12"></asp:Label>
                        <asp:Label runat="server" ID="Message_warning" style="display:none;" Font-Size="19px" Font-Bold="true" CssClass="alert alert-warning alert-dismissible col-12"></asp:Label>
                        <asp:Label runat="server" ID="Message_danger" style="display:none;" Font-Size="19px" Font-Bold="true" CssClass="alert alert-danger alert-dismissible  col-12"></asp:Label>

                        <div class="col-lg-12 col-md-12 col-sm-12">
                            <div class="x_panel">
                                <div class="x_title">
                                    <h2>
                                        <asp:Label runat="server" ForeColor="#73879C" Text="Roles"></asp:Label>
                                    </h2>
                                    <div class="clearfix"></div>
                                </div>

                                <div class="x_content">
                                    <%--<form id="demo-form2" class="form-horizontal form-label-left">--%>
                                    <asp:Panel runat="server" ID="pnll_info1">
                                        <div class="row">
                                            <div class="col-md-12 col-lg-12">
                                                <span class="text-success">Seleccione rol </span>
                                                <asp:DropDownList ID="lst_roles"
                                                    Width="30%"
                                                    CssClass="form-control"
                                                    AutoPostBack="true"
                                                    OnSelectedIndexChanged="lst_roles_SelectedIndexChanged"
                                                    DataValueField="IdRol"
                                                    DataTextField="Rol"
                                                    runat="server">
                                                </asp:DropDownList>
                                                <br />
                                            </div>

                                        </div>

                                        <div class="col-md-12 col-lg-12">
                                            <div class="container">

                                                <ul class="nav nav-tabs">
                                                    <li class="active"><a data-toggle="tab"  href="#home">Menus</a></li>
                                                    <li><a data-toggle="tab" href="#menu1"  >Permisos</a></li>
                                                </ul>
                                                <div class="tab-content">
                                                    <div id="home" class="tab-pane fade in active show">

                                                        <label>Lista de Menus</label>

                                                        <asp:Repeater ID="Rp_ColumnaMennu" OnItemCommand="Rp_ColumnaMennu_ItemCommand" runat="server">
                                                            <HeaderTemplate>
                                                                <div class="panel-group" id="accordion7401210" role="tablist" aria-multiselectable="false">
                                                            </HeaderTemplate>
                                                            <ItemTemplate>

                                                                <div class="panel panel-default">
                                                                    <div class="panel-heading" role="tab" id='<%#"heading"+Eval("Text") %>'>
                                                                        <h5 class="panel-title">
                                                                            <%--data-parent="#accordion7401210"--%>
                                                                            <a role="button" data-toggle="collapse" class="accordion-plus-toggle collapsed" href='<%# "#collapse"+Eval("Text") %>' aria-expanded="false" aria-controls='<%# "collapse"+Eval("Text") %>'>
                                                                                <i class='<%# Eval("Icono") %>'></i><%# Eval("Text")!=null? !string.IsNullOrEmpty(Eval("Text").ToString())? Eval("Text"):"General":"General"%></a>
                                                                        </h5>
                                                                    </div>

                                                                    <div id='<%# "collapse"+Eval("Text") %>' class="panel-collapse " role="tabpanel" aria-labelledby='<%#"heading"+Eval("Text") %>'>
                                                                        <div class="panel-body">
                                                                            <div class="row">
                                                                                <div class="col-md-6 col-md-6 col-sm-12 form-group">
                                                                                    <div class="text-left">
                                                                                        <small class="text-success text-lg-left"
                                                                                            <%# Convert.ToInt32(Eval("Count"))>0 ? "style='display:none'" : "" %>>Activar como Menu principal</small>
                                                                                        <input type="checkbox"
                                                                                            <%# Eval("IdRol") !=null ? "checked" : "" %>
                                                                                            <%# Convert.ToInt32(Eval("Count"))>0 ? "style='display:none'" : "" %>
                                                                                            title='<%# Eval("IdRol")== null ?false:Eval("IdRol") %>'
                                                                                            value='<%# Eval("IdMenu") %>'
                                                                                            onchange="GetMessageFromServer(this.checked,this.value)" />
                                                                                    </div>
                                                                                </div>


                                                                            </div>

                                                                            <div class="row">
                                                                                <div class="col-md-12 col-sm-12 form-group">
                                                                                    <asp:GridView Width="100%" ID="gvRp_Menus" runat="server" DataSource='<%# Eval("data")%>' AutoGenerateColumns="false"
                                                                                        ShowHeaderWhenEmpty="true"
                                                                                        ShowHeader="false"
                                                                                        HeaderStyle-CssClass="d-lg-none"
                                                                                        BackColor="White" CssClass="col-sm-11 col-md-11  form-group" BorderWidth="1px" CellPadding="2">
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="0.15">
                                                                                                <ItemTemplate>
                                                                                                    <div class="text-center no-padding">
                                                                                                        <input type="checkbox"
                                                                                                            <%# Eval("IdRol") !=null ? "checked" : "" %>
                                                                                                            title='<%# Eval("IdRol")== null ?false:Eval("IdRol") %>'
                                                                                                            value='<%# Eval("IdMenu") %>'
                                                                                                            onchange="GetMessageFromServer(this.checked,this.value)" />

                                                                                                    </div>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField HeaderText="0.35">
                                                                                                <ItemTemplate>
                                                                                                    <div class="text-center" id='<%#Eval("IdMenu").ToString()%>'
                                                                                                        title='<%# Eval("Orden") %>'
                                                                                                        tabindex='<%#Eval("IdMenu").ToString()%>'
                                                                                                        style="width: 100%; height: 100%">
                                                                                                        <label class="badge badge-secondary" id='<%# "lb_up"+Eval("IdMenu").ToString()%>' tabindex='<%# Eval("IdMenu").ToString()%>' style="font-size: 11px; font-weight: bold"><%# Eval("Orden") %></label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <div class="text-center" style="padding-bottom: 0; padding-top: 0">
                                                                                                        <i class='<%# Eval("Icono") %>'></i>
                                                                                                        <asp:Label runat="server" Font-Bold="true" Text='<%# Eval("Texto") %>'></asp:Label>
                                                                                                    </div>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <div class="text-center" style="padding-bottom: 0; padding-top: 0">
                                                                                                        <asp:Label runat="server" Font-Bold="true" Text='<%# Eval("Descripcion") %>'></asp:Label>
                                                                                                    </div>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>


                                                                                        </Columns>
                                                                                    </asp:GridView>

                                                                                </div>
                                                                            </div>


                                                                        </div>

                                                                    </div>

                                                                </div>

                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                </div>
                                                            </FooterTemplate>
                                                        </asp:Repeater>

                                                        <div class="text-right">
                                                            <span class="text-primary">Recargar menu principal</span>
                                                            <asp:LinkButton ID="btn_recargar" OnClick="btn_recargar_Click" CssClass="btn btn-primary " runat="server"><i class="fa fa-refresh"> Recargar menu</i></asp:LinkButton>
                                                        </div>

                                                    </div>

                                                    <div id="menu1" class="tab-pane fade">
                                                        <label>Lista de Permisos</label>

                                                        <asp:Repeater ID="Rp_ColumnaPermiso"  runat="server">
                                                            <HeaderTemplate>
                                                                <div class="panel-group" id="accordion7401210" role="tablist" aria-multiselectable="false">
                                                            </HeaderTemplate>
                                                            <ItemTemplate>

                                                                <div class="panel panel-default">
                                                                    <div class="panel-heading" role="tab" id='<%#"heading"+Eval("Tipo") %>'>
                                                                        <h5 class="panel-title">
                                                                            <%--data-parent="#accordion7401210"--%>
                                                                            <a role="button" data-toggle="collapse" class="accordion-plus-toggle collapsed" href='<%# "#collapse"+Eval("Tipo") %>' aria-expanded="false" aria-controls='<%# "collapse"+Eval("Tipo") %>'>
                                                                                <%# Eval("Tipo")!=null? !string.IsNullOrEmpty(Eval("Tipo").ToString())? Eval("Tipo"):"General":"General"%></a>
                                                                        </h5>
                                                                    </div>

                                                                    <div id='<%# "collapse"+Eval("Tipo") %>' class="panel-collapse " role="tabpanel" aria-labelledby='<%#"heading"+Eval("Tipo") %>'>
                                                                        <div class="panel-body">
                                                                            <div class="row">

                                                                                <div class="col-md-12 col-sm-12 form-group">
                                                                                    <asp:GridView Width="100%" ID="gvRp_permiso" runat="server" DataSource='<%# Eval("data") %>' AutoGenerateColumns="false"
                                                                                        ShowHeaderWhenEmpty="true"
                                                                                        ShowHeader="false"
                                                                                        HeaderStyle-CssClass="d-lg-none"
                                                                                        BackColor="White" CssClass="col-sm-11 col-md-11 form-group" BorderWidth="1px" CellPadding="2">
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="0.15">
                                                                                                <ItemTemplate>
                                                                                                    <div class="text-center no-padding">
                                                                                                        <input type="checkbox"
                                                                                                            <%# Eval("IdRol") !=null ? "checked" : "" %>
                                                                                                            title='<%# Eval("IdRol")== null ?false:Eval("IdRol") %>'
                                                                                                            value='<%# Eval("IdPermiso") %>'
                                                                                                            onchange="GetMessageFromServer(this.checked,this.value,'permiso')" />
                                                                                                    </div>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField HeaderText="0.35">
                                                                                                <ItemTemplate>
                                                                                                    <div class="text-center"
                                                                                                        style="width: 100%; height: 100%">
                                                                                                        <label class="badge badge-secondary" style="font-size: 11px; font-weight: bold"><%# Eval("Orden") %></label>
                                                                                                    </div>

                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <div class="text-center">
                                                                                                        <%# Eval("Permiso") %>
                                                                                                    </div>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <div class="text-left" style="padding-bottom: 0; padding-top: 0">
                                                                                                        <%# Eval("Descripcion") %>
                                                                                                    </div>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>

                                         

                                                                                        </Columns>
                                                                                    </asp:GridView>

                                                                                </div>
                                                                            </div>


                                                                        </div>

                                                                    </div>

                                                                </div>

                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                </div>
                                                            </FooterTemplate>
                                                        </asp:Repeater>



                                                    </div>
                                                </div>
                                            </div>
                                        </div>
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

