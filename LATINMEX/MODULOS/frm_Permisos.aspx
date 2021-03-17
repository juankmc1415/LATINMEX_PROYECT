<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frm_Permisos.aspx.cs" Inherits="LATINMEX.MODULOS.frm_Permisos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .btn-xs {
            padding: 1px 5px;
            font-size: 12px;
            line-height: 1.5;
            border-radius: 3px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript"> 
        function GetMessageFromServer(s, e) {
            console.log(e);
            UseCallBack(s.toString() + "," + e, "");
        }
        function JSCallback(TextBox1, context) {
            // when callback finishes execution this method will called 
        }

        function UseCallBack(arg, context) {
            WebForm_DoCallback('__Page', arg, JSCallback, context, null, false);
        }



     
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <form id="demo-form11" enctype="multipart/form-data">
                <div class="row" role="main">

                    <asp:Label runat="server" ID="Message_Succes" Visible="false" Font-Size="19px" Font-Bold="true" CssClass="alert alert-success alert-dismissible col-12"></asp:Label>
                    <asp:Label runat="server" ID="Message_info" Visible="false" Font-Size="19px" Font-Bold="true" CssClass="alert alert-info alert-dismissible col-12"></asp:Label>
                    <asp:Label runat="server" ID="Message_warning" Visible="false" Font-Size="19px" Font-Bold="true" CssClass="alert alert-warning alert-dismissible col-12"></asp:Label>
                    <asp:Label runat="server" ID="Message_danger" Visible="false" Font-Size="19px" Font-Bold="true" CssClass="alert alert-danger alert-dismissible  col-12"></asp:Label>

                    <div class="col-lg-5 col-md-5 col-sm-12">
                        <div class="x_panel">
                            <div class="x_title">
                                <h2>
                                    <asp:Label runat="server" ForeColor="#73879C" Text="Detalles del Permiso"></asp:Label>
                                </h2>
                                <div class="clearfix">
                                </div>
                            </div>

                            <div class="x_content">
                                <%--<form id="demo-form2" class="form-horizontal form-label-left">--%>
                                <asp:Panel runat="server" ID="pnll_info1">
                                    <div class="item form-group">
                                        <label class="col-form-label col-md-4 col-sm-4 label-align" for="first-name">
                                            Orden
                                        </label>
                                        <div class="col-md-7 col-sm-7 ">
                                            <asp:Label runat="server" ID="lb_orden" CssClass="form-control" Enabled="false"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="item form-group">
                                        <label class="col-form-label col-md-4 col-sm-4 label-align" for="first-name">
                                            Nomber <span class="required" style="color: red">*</span>
                                        </label>
                                        <div class="col-md-7 col-sm-7 ">
                                            <asp:TextBox runat="server" ID="txt_nombre" MaxLength="100" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="vls_nombre" runat="server"
                                                CssClass="text text-danger"
                                                ControlToValidate="txt_nombre"
                                                ValidationGroup="Registrar" Display="Dynamic"
                                                ErrorMessage="Campo obligatorio"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="item form-group">
                                        <label class="col-form-label col-md-4 col-sm-4 label-align" for="first-name">
                                            Descripcion <span class="required" style="color: red">*</span>
                                        </label>
                                        <div class="col-md-7 col-sm-7 ">
                                            <asp:TextBox runat="server" TextMode="MultiLine" MaxLength="100" row="4" ID="txt_descripcion" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="vsl_descripcion" runat="server"
                                                CssClass="text text-danger"
                                                ControlToValidate="txt_descripcion"
                                                ValidationGroup="Registrar" Display="Dynamic"
                                                ErrorMessage="Campo obligatorio"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="item form-group">
                                        <label class="col-form-label col-md-4 col-sm-4 label-align" for="last-name">
                                            Tipos permisos <span class="required" style="color: red">*</span>
                                        </label>
                                        <div class="col-md-7 col-sm-7 ">

                                            <div class="input-group">
                                                <asp:DropDownList ID="lst_tiposPermisos" runat="server" CssClass="form-control" DataTextField="Tipo" DataValueField="IdTipoPermiso">
                                                </asp:DropDownList>
                                                <span class="input-group-btn">
                                                    <asp:LinkButton ID="btn_tipoPermiso" OnClick="btn_tipoPermiso_Click" ToolTip="Crear / eliminar permisos" CssClass="btn btn-primary "
                                                        runat="server"><i class="fa fa-plus"></i></asp:LinkButton>
                                                </span>
                                            </div>

                                            <asp:RangeValidator ID="lst_tiposPermisosVls" runat="server"
                                                ControlToValidate="lst_tiposPermisos"
                                                CssClass="text text-danger"
                                                ValidationGroup="Registrar" Display="Dynamic"
                                                MinimumValue="1" MaximumValue="B" Type="String"
                                                ErrorMessage="Campo obligatorio"></asp:RangeValidator>
                                        </div>
                                    </div>

                                    <div class="item form-group">
                                        <label class="col-form-label col-md-4 col-sm-4 label-align" for="last-name">
                                        </label>
                                        <div class="col-md-7 col-sm-7 ">
                                            <asp:LinkButton runat="server" ValidationGroup="Registrar" ID="btn_registra" OnClick="btn_registra_Click" CssClass="btn btn-success">
                                               Registrar
                                            </asp:LinkButton>
                                        </div>
                                    </div>

                                </asp:Panel>
                                <%-- </form>--%>
                            </div>
                        </div>
                    </div>
                     
                    <div class="col-lg-7 col-md-7 col-sm-12">
                        <div class="x_panel">
                            <div class="x_title">
                                <h2>Gestión de Permisos</h2>
                                <div class="clearfix"></div>
                            </div>
                            <div class="x_content">
                                <%--<form id="demo-form2" class="form-horizontal form-label-left">--%>
                                <asp:Panel runat="server" ID="Panel1">
                                    <div class="row">
                                        <div class="col-lg-5 col-md-12 col-sm-12">
                                            <label>Roles</label>
                                            <asp:DropDownList ID="lst_Roles" runat="server" AutoPostBack="true" OnSelectedIndexChanged="lst_Roles_SelectedIndexChanged" CssClass="form-control" DataTextField="ROL" DataValueField="ID_ROL">
                                            </asp:DropDownList>
                                        </div>

                                        <div class="col-lg-7 col-md-12 col-sm-12">
                                            <label>Lista de Permisos</label>

                                            <asp:Repeater ID="Rp_ColumnaPermiso" OnItemCommand="Rp_ColumnaPermiso_ItemCommand" runat="server">
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
                                                                            OnRowCommand="gvRp_permiso_RowCommand"
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
                                                                                                onchange="GetMessageFromServer(this.checked,this.value)" />
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

                                                                                <asp:TemplateField>

                                                                                    <ItemTemplate>
                                                                                        <div class="text-center" style="padding-bottom: 0; padding-top: 0">
                                                                                            <div class="btn-group ">
                                                                                                <asp:LinkButton ID="btn_eliminarPermiso"
                                                                                                    OnClick="btn_eliminarPermiso_Click" TabIndex='<%# Convert.ToInt32(Eval("IdPermiso"))%>'
                                                                                                    OnClientClick="if (!confirm('¿Confirma eliminar este permiso?')) return false;"
                                                                                                    ToolTip="Eliminar" CssClass="btn btn-xs btn-danger text-center" runat="server">
                                                                                                         <i class="fa fa-trash"></i>
                                                                                                </asp:LinkButton>

                                                                                                <asp:LinkButton ID="btn_actualizarMenu" CommandName="Editar" CommandArgument='<%# Eval("IdPermiso") %>' ToolTip="Editar" CssClass="btn btn-xs btn-success" runat="server">
                                                                                                 <i class="fa fa-edit "></i>
                                                                                                </asp:LinkButton>
                                                                                            </div>
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

                                </asp:Panel>

                            </div>

                        </div>
                    </div>

                </div>

            </form>
        </ContentTemplate>
    </asp:UpdatePanel>


    <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
        <ContentTemplate>

            <asp:HiddenField runat="server" ID="hf_idPermiso"/>
            <asp:Label ID="lb_permisoMd" Visible="false" runat="server" Text="Label"></asp:Label>
            <asp:HiddenField runat="server" ID="hf_MenusDMV" />
            <ajaxToolkit:ModalPopupExtender ID="mpe_PermisosDMV" runat="server" BackgroundCssClass="modalBackground" TargetControlID="hf_MenusDMV" PopupControlID="pnl_PermiososDMV" OkControlID="btn_close_DMV" />
            <asp:Panel ID="pnl_PermiososDMV" runat="server" Width="900PX">
                <div class="modal-dialog" runat="server" style="max-width: 800px !important;">
                    <div class="modal-content">

                        <div class="modal-header" style="height: 48px">
                            <div class="left">
                                <h2>
                                    <asp:Label runat="server" ForeColor="#73879C" Text="Detalle de permiso"></asp:Label>
                                </h2>
                            </div>
                            <button id="btn_close_DMV" type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        </div>

                        <div class="modal-body">
                            <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                                <ContentTemplate>
                                    <div class="" role="main">
                                        <div class="item form-group">
                                            <label class="col-form-label col-md-4 col-sm-4 label-align" for="first-name">
                                                Orden
                                            </label>
                                            <div class="col-md-7 col-sm-7 ">
                                                <asp:Label runat="server" ID="lb_ordenModa" CssClass="form-control" Enabled="false"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="item form-group">
                                            <label class="col-form-label col-md-4 col-sm-4 label-align" for="first-name">
                                                Nombre <span class="required" style="color: red">*</span>
                                            </label>
                                            <div class="col-md-7 col-sm-7 ">
                                                <asp:TextBox runat="server" ID="txt_nombreModa" MaxLength="100" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="txt_nombreModaVls" runat="server"
                                                    CssClass="text text-danger"
                                                    ControlToValidate="txt_nombreModa"
                                                    ValidationGroup="RegistrarModaPer" Display="Dynamic"
                                                    ErrorMessage="Campo obligatorio"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="item form-group">
                                            <label class="col-form-label col-md-4 col-sm-4 label-align" for="first-name">
                                                Descripcion <span class="required" style="color: red">*</span>
                                            </label>
                                            <div class="col-md-7 col-sm-7 ">
                                                <asp:TextBox runat="server" TextMode="MultiLine" MaxLength="100" row="3" ID="txt_descripcionModa" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="txt_descripcionModaVls" runat="server"
                                                    CssClass="text text-danger"
                                                    ControlToValidate="txt_descripcionModa"
                                                    ValidationGroup="RegistrarModaPer" Display="Dynamic"
                                                    ErrorMessage="Campo obligatorio"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="item form-group">
                                        <label class="col-form-label col-md-4 col-sm-4 label-align" for="last-name">
                                            Tipos permisos <span class="required" style="color: red">*</span>
                                        </label>
                                        <div class="col-md-7 col-sm-7 ">

                                            <div class="input-group">
                                                <asp:DropDownList ID="Lst_tiposPermisoModal" runat="server" CssClass="form-control" DataTextField="Tipo" DataValueField="IdTipoPermiso">
                                                </asp:DropDownList>
                                            </div>

                                            <asp:RangeValidator ID="Lst_tiposPermisoModalVls" runat="server"
                                                ControlToValidate="Lst_tiposPermisoModal"
                                                CssClass="text text-danger"
                                                ValidationGroup="RegistrarModaPer" Display="Dynamic"
                                                MinimumValue="1" MaximumValue="B" Type="String"
                                                ErrorMessage="Campo obligatorio"></asp:RangeValidator>
                                        </div>
                                    </div>

                                       
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>

                        <div class="modal-footer">
                            <asp:LinkButton runat="server" ValidationGroup="RegistrarModa" ID="btn_GuardarPermisoM" OnClick="btn_GuardarPermisoM_Click"
                                CssClass="btn btn-success">
                                                      <i class="fa fa-save" aria-hidden="true"></i> Guardar Cambios
                            </asp:LinkButton>

                            <asp:LinkButton runat="server" ID="btn_cerrarCuotaDMV" CssClass="btn btn-secondary">
                                                     <i class="fa fa-close" aria-hidden="true"></i> Cancelar
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="server">
        <ContentTemplate>

            <asp:HiddenField runat="server" ID="HiddenField2" />
            <ajaxToolkit:ModalPopupExtender ID="mpe_TipoPemisoDMV" runat="server" BackgroundCssClass="modalBackground" TargetControlID="HiddenField2" PopupControlID="pnl_TipoPermiososDMV" OkControlID="btn_close_tipo_DMV" />
            <asp:Panel ID="pnl_TipoPermiososDMV" runat="server" Width="60%">
                <div class="modal-dialog" runat="server" style="max-width: 50% !important;">
                    <div class="modal-content">
                        <div class="modal-header" style="height: 48px">
                            <div class="left">
                                <h2>
                                    <asp:Label runat="server" ForeColor="#73879C" Text="Gestión de tipos permisos"></asp:Label>
                                </h2>
                            </div>
                            <button id="btn_close_tipo_DMV" type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        </div>

                        <div class="modal-body">
                            <asp:UpdatePanel runat="server" ID="UpdatePanel5">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12">
                                            <label>Nombre</label>
                                            <div class="input-group">
                                                <asp:TextBox runat="server" placeholder="Escriba el nombre del tipo de permiso" ID="txt_nombreTipo" MaxLength="100" CssClass="form-control"></asp:TextBox>

                                                <span class="input-group-btn">
                                                    <asp:LinkButton runat="server" ValidationGroup="RegistrarModaTipo" ID="btn_agregarTipoPermiso" OnClick="btn_agregarTipoPermiso_Click"
                                                        CssClass="btn btn-success">
                                                      <i class="fa fa-save" aria-hidden="true"></i> Guardar
                                                    </asp:LinkButton>
                                                </span>
                                            </div>
                                            <asp:RequiredFieldValidator ID="txt_nombreTipoVls" runat="server"
                                                CssClass="text text-danger"
                                                ControlToValidate="txt_nombreTipo"
                                                ValidationGroup="RegistrarModaTipo" Display="Dynamic"
                                                ErrorMessage="Campo obligatorio"></asp:RequiredFieldValidator>

                                        </div>

                                        <div class="col-md-12 col-sm-12 form-group">
                                            <asp:Repeater ID="Rp_ColumnasTipoPermisos" OnItemCommand="Rp_ColumnasTipoPermisos_ItemCommand" runat="server">
                                                <HeaderTemplate>

                                                    <table class="table">
                                                        <thead class="thead-dark">
                                                            <tr>
                                                                <th scope="col" style="width: 75%">Nombre tipo permiso</th>
                                                                <th scope="col">Opciones</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%# Eval("TIPO") %></td>
                                                        <td>
                                                            <asp:LinkButton ID="btn_eliminarTipoPermiso" Width="100px" OnClick="btn_eliminarTipoPermiso_Click" TabIndex='<%# Convert.ToInt32(Eval("ID_TIPO_PERMISO"))%>'
                                                                OnClientClick="if (!confirm('¿Confirma eliminar el tipo de permiso?')) return false;"
                                                                ToolTip="Eliminar" CssClass="btn  btn-sm btn-danger" runat="server">
                                                                                                <i class="fa fa-trash"></i> eliminar </asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    </tbody>
                                            </table>
                                                </FooterTemplate>
                                            </asp:Repeater>




                                        </div>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btn_agregarTipoPermiso" />
                                </Triggers>
                            </asp:UpdatePanel>

                        </div>


                    </div>
                </div>
            </asp:Panel>


        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
