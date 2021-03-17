<%@ Page Title=" LATINMEX | Menus" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frm_Menus.aspx.cs" Inherits="LATINMEX.MODULOS.frm_Menus" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <style type="text/css">
        .btn-xs {
            padding: 1px 5px;
            font-size: 12px;
            line-height: 1.5;
            border-radius: 3px;
        }

        /* plus glyph for showing collapsible panels */
        .panel-heading .accordion-plus-toggle:before {
            font-family: FontAwesome;
            content: "\f068";
            float: right;
            color: silver;
        }

        .panel-heading .accordion-plus-toggle.collapsed:before {
            content: "\f067";
            color: silver;
        }

        /* arrow glyph for showing collapsible panels */
        .panel-heading .accordion-arrow-toggle:before {
            font-family: FontAwesome;
            content: "\f078";
            float: right;
            color: silver;
        }

        .panel-heading .accordion-arrow-toggle.collapsed:before {
            content: "\f054";
            color: silver;
        }

        /* sets the link to the width of the entire panel title */
        .panel-title > a {
            display: block;
        }
    </style>


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

        function allowDrop(ev) {
            ev.preventDefault();
        }

        function drop(ev) {
            ev.preventDefault();

            var data = ev.dataTransfer.getData("text");

            console.log(ev);
            var name = "";
            if (ev.path[0].localName == "div") {
                name = ev.path[0].firstElementChild.id;
            }
            if (ev.path[0].localName == "label") {
                name = ev.path[0].id;
            }

            if (ev.path[0].localName == "i") {
                name = "lb_up" + ev.path[2].firstElementChild.id;
            }

            //var text1 = document.getElementById(name).innerText;
            //var text2 = document.getElementById(data).innerText;
            //document.getElementById(name).innerText = text2;
            //document.getElementById(data).innerText = text1;
            //ev.target.appendChild(document.getElementById(data));
        }

        //arrastrar y pergar 
        function drag(ev) {

            ev.dataTransfer.setData("text", ev.target.childNodes[1].id);
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
                                    <asp:Label runat="server" ForeColor="#73879C" Text="Detalles del Menú"></asp:Label>
                                </h2>
                                <div class="clearfix"></div>
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
                                            Nombre <span class="required" style="color: red">*</span>
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
                                            <asp:TextBox runat="server" TextMode="MultiLine" MaxLength="100" row="3" ID="txt_descripcion" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="vsl_descripcion" runat="server"
                                                CssClass="text text-danger"
                                                ControlToValidate="txt_descripcion"
                                                ValidationGroup="Registrar" Display="Dynamic"
                                                ErrorMessage="Campo obligatorio"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="item form-group">
                                        <label class="col-form-label col-md-4 col-sm-4 label-align" for="last-name">
                                            Icono <span class="required" style="color: red">*</span>
                                        </label>
                                        <div class="col-md-7 col-sm-7 ">
                                            <asp:TextBox ID="txt_icono" CssClass="form-control" MaxLength="100" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="vls_icono" runat="server"
                                                CssClass="text text-danger"
                                                ControlToValidate="txt_icono"
                                                ValidationGroup="Registrar" Display="Dynamic"
                                                ErrorMessage="Campo obligatorio"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="item form-group">
                                        <label class="col-form-label col-md-4 col-sm-4 label-align">
                                            URL <span class="required" style="color: red">*</span>
                                        </label>
                                        <div class="col-md-7 col-sm-7 ">
                                            <asp:TextBox ID="txt_url" CssClass="form-control" MaxLength="500" runat="server"></asp:TextBox>

                                            <asp:RequiredFieldValidator ID="txt_urlVls" runat="server"
                                                CssClass="text text-danger"
                                                ControlToValidate="txt_url"
                                                ValidationGroup="Registrar" Display="Dynamic"
                                                ErrorMessage="Campo obligatorio"></asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                    <div class="item form-group">
                                        <label class="col-form-label col-md-4 col-sm-4 label-align" for="last-name">
                                            Menu padre
                                        </label>
                                        <div class="col-md-7 col-sm-7 ">
                                            <asp:DropDownList ID="lst_menuPadre" runat="server" CssClass="form-control" DataTextField="Texto" DataValueField="IdMenu">
                                                <asp:ListItem Selected="True" Value="0"> Selecione </asp:ListItem>
                                            </asp:DropDownList>


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
                                <h2>Gestión de Menús</h2>
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
                                            <br />

                                            <div class="text-right text-center">
                                                <span class="text-primary">Recargar menu principal</span>
                                                <asp:LinkButton ID="btn_recargar" OnClick="btn_recargar_Click" CssClass="btn btn-primary " runat="server"><i class="fa fa-refresh"> Recargar menu</i></asp:LinkButton>
                                            </div>

                                        </div>

                                        <div class="col-lg-7 col-md-12 col-sm-12 ">
                                            <label>Lista de Menus</label>

                                            <asp:Repeater ID="Rp_ColumnaMennu"  OnItemCommand="Rp_ColumnaMennu_ItemCommand" runat="server">
                                                <HeaderTemplate>
                                                    <div class="panel-group" id="accordion7401210" role="tablist" aria-multiselectable="false">
                                                </HeaderTemplate>
                                                <ItemTemplate>

                                                    <div class="panel panel-default">
                                                        <div class="panel-heading" role="tab" id='<%#"heading"+Eval("Text") %>'>
                                                            <h5 class="panel-title">
                                                                <%--data-parent="#accordion7401210"--%>
                                                                <a role="button" data-toggle="collapse" class="accordion-plus-toggle collapsed" href='<%# "#collapse"+Eval("Text") %>' aria-expanded="false" aria-controls='<%# "collapse"+Eval("Text") %>'>
                                                                    <i class='<%# Eval("Icono") %>'></i> <%# Eval("Text")!=null? !string.IsNullOrEmpty(Eval("Text").ToString())? Eval("Text"):"General":"General"%></a>
                                                            </h5>
                                                        </div>

                                                        <div id='<%# "collapse"+Eval("Text") %>' class="panel-collapse " role="tabpanel" aria-labelledby='<%#"heading"+Eval("Text") %>'>
                                                            <div class="panel-body">
                                                                <div class="row">
                                                                    <div class="col-md-6 col-md-6 col-sm-12 form-group">
                                                                        <div class="text-right">
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

                                                                    <div class="col-md-6 col-md-6 col-sm-12 form-group">
                                                                        <div class="text-right">
                                                                            <small class="text-success" >Eliminar / Actulizar</small>
                                                                            <div class="btn-group">
                                                                                <asp:LinkButton ID="btn_eliminarMenu" OnClick="btn_eliminarMenu_Click" TabIndex='<%# Convert.ToInt32(Eval("IdMenu"))%>'
                                                                                    OnClientClick="if (!confirm('¿Confirma eliminar este menu, tenga en cuenta que se eliminaran tambien los sub menus?')) return false;"
                                                                                    ToolTip="Eliminar" CssClass="btn btn-xs btn-danger" runat="server">
                                                                                                <i class="fa fa-trash"></i>
                                                                                </asp:LinkButton>

                                                                                <asp:LinkButton ID="btn_actualizarMenu" CommandName="Editar" CommandArgument='<%# Eval("IdMenu") %>' ToolTip="Editar" CssClass="btn btn-xs btn-success" runat="server">
                                                                                            <i class="fa fa-edit"></i>
                                                                                </asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="row">

                                                                    <div class="col-md-12 col-sm-12 form-group">
                                                                        <asp:GridView Width="100%" ID="gvRp_Menus" runat="server" DataSource='<%# Eval("data")%>' AutoGenerateColumns="false"
                                                                            ShowHeaderWhenEmpty="true"
                                                                            OnRowCommand="gv_Notas_RowCommand"
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
                                                                                        <div ondrop="drop(event)" ondragover="allowDrop(event)" id='<%#Eval("IdMenu").ToString() %>' style="padding: 0,0,0,0; width: 100%; height: 100%">

                                                                                            <div class="text-center" id='<%#Eval("IdMenu").ToString()%>'
                                                                                                title='<%# Eval("Orden") %>'
                                                                                                tabindex='<%#Eval("IdMenu").ToString()%>'
                                                                                                draggable="true" ondragstart="drag(event)" style="width: 100%; height: 100%">

                                                                                                <label class="badge badge-secondary" id='<%# "lb_up"+Eval("IdMenu").ToString()%>' tabindex='<%# Eval("IdMenu").ToString()%>' style="font-size: 11px; font-weight: bold"><%# Eval("Orden") %></label>
                                                                                                <i class="fa fa-arrows fa-1x" tabindex='<%# Eval("IdMenu").ToString()%>' aria-hidden="true"></i>

                                                                                            </div>
                                                                                        </div>
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
                                                                                            <div class="btn-group ">
                                                                                                <asp:LinkButton ID="btn_eliminarMenu"
                                                                                                    OnClick="btn_eliminarMenu_Click" TabIndex='<%# Convert.ToInt32(Eval("IdMenu"))%>'
                                                                                                    OnClientClick="if (!confirm('¿Confirma eliminar este menu?')) return false;"
                                                                                                    ToolTip="Eliminar" CssClass="btn btn-xs btn-danger text-center" runat="server">
                                                                                                         <i class="fa fa-trash"></i>
                                                                                                </asp:LinkButton>

                                                                                                <asp:LinkButton ID="btn_actualizarMenu" CommandName="Editar" CommandArgument='<%# Eval("IdMenu") %>' ToolTip="Editar" CssClass="btn btn-xs btn-success" runat="server">
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

            <asp:HiddenField runat="server" ID="hf_IdmenuDMV" />
            <asp:HiddenField runat="server" ID="hf_MenusDMV" />
            <ajaxToolkit:ModalPopupExtender ID="mpe_MenuDMV" runat="server" BackgroundCssClass="modalBackground" TargetControlID="hf_MenusDMV" PopupControlID="pnl_MenuDMV" OkControlID="btn_close_DMV" />
            <asp:Panel ID="pnl_MenuDMV" runat="server" Width="900PX">
                <div class="modal-dialog" runat="server" style="max-width: 800px !important;">
                    <div class="modal-content">

                        <div class="modal-header" style="height: 48px">
                            <div class="left">
                                <h2>
                                    <asp:Label runat="server" ForeColor="#73879C" Text="Detalle de menu"></asp:Label>
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
                                                    ValidationGroup="RegistrarModa" Display="Dynamic"
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
                                                    ValidationGroup="RegistrarModa" Display="Dynamic"
                                                    ErrorMessage="Campo obligatorio"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="item form-group">
                                            <label class="col-form-label col-md-4 col-sm-4 label-align" for="last-name">
                                                Icono <span class="required" style="color: red">*</span>
                                            </label>
                                            <div class="col-md-7 col-sm-7 ">
                                                <asp:TextBox ID="txt_iconoModa" CssClass="form-control" MaxLength="100" runat="server" required="required"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="txt_iconoModaVls" runat="server"
                                                    CssClass="text text-danger"
                                                    ControlToValidate="txt_iconoModa"
                                                    ValidationGroup="RegistrarModa" Display="Dynamic"
                                                    ErrorMessage="Campo obligatorio"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="item form-group">
                                            <label class="col-form-label col-md-4 col-sm-4 label-align">
                                                URL <span class="required" style="color: red">*</span>
                                            </label>
                                            <div class="col-md-7 col-sm-7 ">
                                                <asp:TextBox ID="txt_urlModa" CssClass="form-control" MaxLength="500" runat="server"></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="txt_urlModaVls" runat="server"
                                                    CssClass="text text-danger"
                                                    ControlToValidate="txt_urlModa"
                                                    ValidationGroup="RegistrarModa" Display="Dynamic"
                                                    ErrorMessage="Campo obligatorio"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="item form-group">
                                            <label class="col-form-label col-md-4 col-sm-4 label-align" for="last-name">
                                                Menu padre
                                            </label>
                                            <div class="col-md-7 col-sm-7 ">
                                                <asp:DropDownList ID="lsl_MenuPadreModa" runat="server" CssClass="form-control" DataTextField="Texto" DataValueField="IdMenu">
                                                    <asp:ListItem Selected="True" Value="0"> Selecione </asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="Rp_ColumnaMennu" />
                                </Triggers>
                            </asp:UpdatePanel>

                        </div>

                        <div class="modal-footer">
                            <asp:LinkButton runat="server" ValidationGroup="RegistrarModa" ID="btn_AceptarMenuDMV" OnClick="btn_AceptarMenuDMV_Click" CssClass="btn btn-success">
                                                      <i class="fa fa-save" aria-hidden="true"></i> Aceptar
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




</asp:Content>
