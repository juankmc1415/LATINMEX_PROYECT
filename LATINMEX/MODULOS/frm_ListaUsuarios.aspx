<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frm_ListaUsuarios.aspx.cs" Inherits="LATINMEX.MODULOS.frm_ListaUsuarios" %>

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

                        <div class="col-lg-12 col-md-12 col-sm-12">
                            <div class="x_panel">
                                <div class="x_title">
                                    <h2>
                                        <asp:Label runat="server" ForeColor="#73879C" Text="Lista de usuarios"></asp:Label>
                                    </h2>
                                    <div class="clearfix">

                                    <div class="pull-right"> 
                                        <a class="btn btn-primary btn-sm" href="frm_usuarios.aspx"><i class="fa fa-user-plus"></i> Nuevo Usuario</a>
                                    </div>
                                    </div>
                                </div>
                                <div class="x_content">
                                    <%--<form id="demo-form2" class="form-horizontal form-label-left">--%>
                                    <asp:Panel runat="server" ID="pnll_info1">

                                        <asp:Repeater ID="Rp_ColumnaUsuario" OnItemCommand="Rp_ColumnaUsuario_ItemCommand" runat="server">
                                            <HeaderTemplate>
                                                <table class="table">
                                                    <thead>
                                                        <tr class="table-active">
                                                            <th scope="col">Imagen</th>
                                                            <th scope="col">Nombre</th>
                                                            <th scope="col">Email</th>
                                                            <th scope="col">Roles</th>
                                                            <th scope="col" title="Forzar Cambio de contraseña">F.Contraseña</th>
                                                            <th scope="col">Estado</th>
                                                            <th scope="col">Creación</th>
                                                            <th scope="col">Actualización</th>
                                                            <th scope="col">Opciones</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <th>
                                                        <asp:Image ID="Profile" ImageUrl='<%# Eval("FotoBase64") %>' CssClass="img-circle" runat="server" Width="45px" Height="45px" />

                                                    <td><%# Eval("Nombres") +" "+ Eval("Apellidos") %></td>
                                                    <td><%# Eval("Email") %></td>
                                                    <td><%# Eval("Roles") %></td>
                                                    <td><%# Convert.ToBoolean(Eval("ForzarContraseña"))?"SI":"NO"%></td>
                                                    <td><%# Eval("Estado") %></td>
                                                    <td><%# Eval("FechaHoraCreacion") %></td>
                                                    <td><%# Eval("FechaHoraActualizacion") %></td>
                                                    <td>
                                                        <div class="btn-group">
                                                            <asp:LinkButton ID="LinkButton1" runat="server"
                                                                Visible='<%# !(Eval("IdEstado").ToString()=="1") %>'
                                                                ToolTip="Cambiar estado al usuario"
                                                                CommandName="Estado"
                                                                CommandArgument='<%# Eval("IdEstado")+","+Eval("IdUsuario") %>'
                                                                  OnClientClick="if (!confirm('¿Confirma cambiar de estado a este usuario?')) return false;"
                                                                CssClass="btn btn-danger btn-sm"><i class="fa fa-ban"></i></asp:LinkButton>

                                                                  <asp:LinkButton ID="LinkButton3" runat="server"
                                                                Visible='<%# (Eval("IdEstado").ToString()=="1") %>'
                                                                CommandArgument='<%# Eval("IdEstado")+","+Eval("IdUsuario")%>'
                                                                CommandName="Estado"
                                                                   OnClientClick="if (!confirm('¿Confirma cambiar de estado a este usuario?')) return false;"
                                                                ToolTip="Cambiar estado al usuario"
                                                                CssClass="btn btn-info btn-sm"><i class="fa fa-check-circle"></i></asp:LinkButton>


                                                            <asp:LinkButton ID="LinkButton2" runat="server"
                                                                CommandArgument='<%# Eval("Email")+","+Eval("Clave")+","+Eval("Usuario")%>'
                                                                CommandName="Contrasena"
                                                                OnClientClick="if (!confirm('¿Confirma restaurar la contraseña de este usuario?')) return false;"
                                                                ToolTip="Envia un email al correo del usuaio con sus credenciales"
                                                                CssClass="btn btn-primary btn-sm"><i class="fa fa-refresh"></i></asp:LinkButton>


                                                            <a class="btn btn-sm btn-success" href='<%# "frm_usuarios.aspx?idusuario="+ Eval("IdUsuario") %>'  style="color: white"><i class="fa fa-edit"></i></a>
                                                        </div>
                                                    </td>
                                                </tr>

                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </tbody>
                                          </table>
                                            </FooterTemplate>
                                        </asp:Repeater>

                                        <div class="pull-left">


                                        <asp:Repeater ID="Rp_Pajinacion" OnItemCommand="Rp_ColumnaUsuario_ItemCommand" runat="server">
                                            <HeaderTemplate>
                                                     <nav aria-label="...">
                                            <ul class="pagination">
                                             
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                               <li class='<%# Eval("CssClass") %>'>
                                                   <a class="page-link" href='<%# "frm_ListaUsuarios?page="+ Eval("Id")%>'>  <%# Eval("Id")%></a>
                                               </li>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                          
                                       </ul>
                                        </nav>
                                            </FooterTemplate>
                                        </asp:Repeater>



                                               
                                           
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
