<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frm_Ventas.aspx.cs" Inherits="LATINMEX.MODULOS.VENTAS.frm_Ventas" %>

<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <style>
        .stile_label {
            color: black;
            /*font-size: 18px;*/
        }

        .content {
            /* width: 300px;
            margin-bottom: 2px;
            padding: 2px;*/
        }

        .selected, .content {
            border: solid 1px #666666;
        }

        .tag_2 {
            -webkit-border-radius: 2px;
            display: block;
            float: right;
            padding: 5px 9px;
            text-decoration: none;
            background: #1ABB9C;
            color: #F1F6F7;
            margin-right: 5px;
            font-weight: 500;
            margin-bottom: 5px;
            font-family: helvetica;
        }

        .listoCuotas {
            background-color: #4ac1ef26;
            border-color: #8d9fb9;
            border-width: 1px;
            border-style: None;
            width: 95%;
            border-collapse: collapse;
            COLOR: BLACK;
        }
    </style>

    <script lang="ja" type="text/javascript">


        function divexpandcollapse(divname) {
            var div = document.getElementById(divname);
            var img = document.getElementById('img' + divname);
            if (div.style.display == "none") {
                div.style.display = "inline";
                img.src = "/resources/images/minus.gif";
            } else {
                div.style.display = "none";
                img.src = "/resources/images/plus.gif";
            }
        }

        function divexpandcollapseChild(divname) {
            var div1 = document.getElementById(divname);
            var img = document.getElementById('img' + divname);
            if (div1.style.display == "none") {
                div1.style.display = "inline";
                img.src = "/resources/images/minus.gif";
            } else {
                div1.style.display = "none";
                img.src = "/resources/images/plus.gif";;
            }
        }

    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%-- <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="" role="main">

                <div class="row">

                    <asp:Label runat="server" ID="Message_Succes" Visible="false" Font-Size="19px" Font-Bold="true" CssClass="alert alert-success alert-dismissible col-12"></asp:Label>
                    <asp:Label runat="server" ID="Message_info" Visible="false" Font-Size="19px" Font-Bold="true" CssClass="alert alert-info alert-dismissible col-12"></asp:Label>
                    <asp:Label runat="server" ID="Message_warning" Visible="false" Font-Size="19px" Font-Bold="true" CssClass="alert alert-warning alert-dismissible col-12"></asp:Label>
                    <asp:Label runat="server" ID="Message_danger" Visible="false" Font-Size="19px" Font-Bold="true" CssClass="alert alert-danger alert-dismissible  col-12"></asp:Label>

                    <div class="col-md-4 col-sm-4 ">
                        <div class="x_panel">

                            <div class="x_title">
                                <h2>
                                    <asp:Label runat="server" ForeColor="#73879C" Text="Datos del Cliente"></asp:Label>
                                </h2>

                                <div class="clearfix"></div>
                            </div>
                            <div class="x_content">
                                <br />
                                <form id="demo-form2" class="form-horizontal form-label-left">
                                    <asp:Panel runat="server" ID="pnll_info1">

                                        <div class="item form-group">
                                            <label class="col-form-label col-md-4 col-sm-4 label-align" for="first-name">
                                                Primer nombre <span class="required" style="color: red">*</span>
                                            </label>
                                            <div class="col-md-7 col-sm-7 ">
                                                <asp:TextBox runat="server" ID="txt_PrimerNombre" CssClass="form-control" required=""></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="item form-group">
                                            <label class="col-form-label col-md-4 col-sm-4 label-align" for="first-name">
                                                Segundo Nombre 
                                            </label>
                                            <div class="col-md-7 col-sm-7 ">
                                                <asp:TextBox runat="server" ID="txt_SegundoNombre" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="item form-group">
                                            <label class="col-form-label col-md-4 col-sm-4 label-align" for="last-name">
                                                Apellidos <span class="required" style="color: red">*</span>
                                            </label>
                                            <div class="col-md-7 col-sm-7 ">
                                                <asp:TextBox runat="server" ID="txt_Apellidos" CssClass="form-control" required=""></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="item form-group">
                                            <label class="col-form-label col-md-4 col-sm-4 label-align" for="last-name">
                                                ID. de Conducción <span class="required" style="color: red">*</span>
                                            </label>
                                            <div class="col-md-7 col-sm-7 ">
                                                <asp:TextBox runat="server" ID="txt_IDconducion" CssClass="form-control" required=""></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="item form-group">
                                            <label class="col-form-label col-md-4 col-sm-4 label-align">
                                                Fecha Nacimiento <span class="required" style="color: red">*</span>
                                            </label>
                                            <div class="col-md-7 col-sm-7 ">
                                                <asp:TextBox ID="txt_fechaNacimiento" CssClass="date-picker form-control" TextMode="Date" runat="server"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="item form-group">
                                            <label class="col-form-label col-md-4 col-sm-4 label-align" for="last-name">
                                                Correo 
                                            </label>
                                            <div class="col-md-7 col-sm-7 ">
                                                <asp:TextBox runat="server" ID="txt_Corre" AutoCompleteType="Email" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="item form-group">
                                            <label class="col-form-label col-md-4 col-sm-4 label-align" for="last-name">
                                                Tel. Movil <span class="required" style="color: red">*</span>
                                            </label>
                                            <div class="col-md-7 col-sm-7 ">
                                                <asp:TextBox runat="server" ID="txt_Telefono" CssClass="form-control" required=""></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="item form-group">
                                            <label class="col-form-label col-md-4 col-sm-4 label-align" for="last-name">
                                                D. Residencia <span class="required" style="color: red">*</span>
                                            </label>
                                            <div class="col-md-7 col-sm-7 ">
                                                <asp:TextBox runat="server" ID="txt_DirecResidencia" CssClass="form-control" required=""></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="item form-group">
                                            <label class="col-form-label col-md-4 col-sm-4 label-align" for="last-name">
                                                D. Correspondencia 
                                            </label>
                                            <div class="col-md-7 col-sm-7 ">
                                                <asp:TextBox runat="server" ID="txt_DireCorrespond" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>

                                        <asp:LinkButton runat="server" ID="btn_MostrarInfo" OnClick="btn_MostrarInfo_Click" CssClass="btn btn-primary">
                                                <i class="fa fa-plus-square" aria-hidden="true"></i>
                                        </asp:LinkButton>
                                    </asp:Panel>
                                    <asp:Panel runat="server" Visible="false" ID="pnll_info2">

                                        <div class="item form-group">
                                            <label class="col-form-label col-md-4 col-sm-4 label-align" for="last-name">
                                                Ciudad <span class="required" style="color: red">*</span>
                                            </label>
                                            <div class="col-md-7 col-sm-7">
                                                <asp:TextBox runat="server" ID="txt_Ciudad" CssClass="form-control" required=""></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="item form-group">
                                            <label class="col-form-label col-md-4 col-sm-4 label-align" for="last-name">
                                                Estado <span class="required" style="color: red">*</span>
                                            </label>
                                            <div class="col-md-7 col-sm-7 ">
                                                <asp:TextBox runat="server" ID="txt_Estado" CssClass="form-control" required=""></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="item form-group">
                                            <label class="col-form-label col-md-4 col-sm-4 label-align" for="last-name">
                                                Codg. Postal <span class="required" style="color: red">*</span>
                                            </label>
                                            <div class="col-md-7 col-sm-7 ">
                                                <asp:TextBox runat="server" ID="txt_CodigoPostal" CssClass="form-control" required=""></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="item form-group">
                                            <label class="col-form-label col-md-4 col-sm-4 label-align" for="last-name">
                                                Nombre de la Empresa 
                                            </label>
                                            <div class="col-md-8 col-sm-8 ">
                                                <asp:TextBox runat="server" ID="txt_NombreEmpresa" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="item form-group">
                                            <label class="col-form-label col-md-2 col-sm-2 label-align">
                                                Vin 1 
                                            </label>
                                            <div class="col-md-3 col-sm-3 ">
                                                <asp:TextBox runat="server" ID="txt_Vin1" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <label class="col-form-label col-md-2 col-sm-2 label-align">
                                                F. venci 1
                                            </label>
                                            <div class="col-md-5 col-sm-5 ">
                                                <asp:TextBox ID="txt_FecVin1" CssClass="date-picker form-control" TextMode="Date" runat="server"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="item form-group">
                                            <label class="col-form-label col-md-2 col-sm-2 label-align">
                                                Vin 2 
                                            </label>
                                            <div class="col-md-3 col-sm-3 ">
                                                <asp:TextBox runat="server" ID="txt_Vin2" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <label class="col-form-label col-md-2 col-sm-2 label-align">
                                                F. venci 2 
                                            </label>
                                            <div class="col-md-5 col-sm-5 ">

                                                <asp:TextBox ID="txt_FecVin2" CssClass="date-picker form-control" TextMode="Date" runat="server"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="item form-group">
                                            <label class="col-form-label col-md-2 col-sm-2 label-align">
                                                Vin 3 
                                            </label>
                                            <div class="col-md-3 col-sm-3 ">
                                                <asp:TextBox runat="server" ID="txt_Vin3" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <label class="col-form-label col-md-2 col-sm-2 label-align">
                                                F. venci 3 
                                            </label>
                                            <div class="col-md-5 col-sm-5">
                                                <asp:TextBox ID="txt_FecVin3" CssClass="date-picker form-control" TextMode="Date" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="item form-group">
                                            <label class="col-form-label col-md-2 col-sm-2 label-align">
                                                Vin 4
                                            </label>
                                            <div class="col-md-3 col-sm-3 ">
                                                <asp:TextBox runat="server" ID="txt_Vin4" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <label class="col-form-label col-md-2 col-sm-2 label-align">
                                                F. venci 4 
                                            </label>
                                            <div class="col-md-5 col-sm-5">
                                                <asp:TextBox ID="txt_FecVin4" CssClass="date-picker form-control" TextMode="Date" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="item form-group">
                                            <label class="col-form-label col-md-2 col-sm-2 label-align">
                                                Vin 5
                                            </label>
                                            <div class="col-md-3 col-sm-3 ">
                                                <asp:TextBox runat="server" ID="txt_Vin5" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <label class="col-form-label col-md-2 col-sm-2 label-align">
                                                F. venci 5 
                                            </label>
                                            <div class="col-md-5 col-sm-5">
                                                <asp:TextBox ID="txt_FecVin5" CssClass="date-picker form-control" TextMode="Date" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="ln_solid"></div>
                                        <div class="item form-group">
                                            <div class=" right col-md-12 col-sm-12 offset-md-12">
                                                <asp:LinkButton runat="server" ID="btn_Registra" OnClick="btn_registra_Click" CssClass="btn btn-primary">
                                                        <i class="fa fa-save" aria-hidden="true"></i> Registrar
                                                </asp:LinkButton>

                                                <asp:LinkButton runat="server" ID="btn_Actualizar" OnClick="btn_Actualizar_Click" CssClass="btn btn-success">
                                                        <i class="fa fa-edit" aria-hidden="true"></i>Actualizar
                                                </asp:LinkButton>

                                                <asp:LinkButton runat="server" ID="btn_OcultarInfo" OnClick="btn_OcultarInfo_Click" CssClass="btn btn-primary">
                                                        <i class="fa fa-minus-square" aria-hidden="true"></i>
                                                </asp:LinkButton>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </form>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-5 col-sm-5 ">
                        <div class="x_panel">
                            <div class="x_title">
                                <h2>Ventana de productos asociados</h2>

                                <div class="clearfix"></div>
                            </div>
                            <div class="x_content">

                                <div class="col-sm-12 ">
                                    <asp:LinkButton runat="server" ID="btn_nuevoProducto" OnClick="btn_nuevoProducto_Click" CssClass="btn btn-sm btn-primary">
                                        <i class="fa fa-plus-square" aria-hidden="true"></i> Agregar producto
                                    </asp:LinkButton>
                                    <asp:Button ID="btn_nuevoProducto1" Visible="false" class="btn btn-sm btn-primary" OnClick="btn_nuevoProducto_Click" runat="server" Text="Agregar producto" />
                                </div>

                                <asp:Panel runat="server">
                                    <asp:GridView ID="gvEmployeeDetails" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" Width="100%"
                                        OnRowDataBound="gvEmployeeDetails_RowDataBound" DataKeyNames="ID_PRODUCTO" OnRowCommand="gvEmployeeDetails_RowCommand" BackColor="White" BorderColor="#ffffff" BorderStyle="None" BorderWidth="1px" CellPadding="2">
                                        <Columns>

                                            <asp:TemplateField HeaderText="Lista">
                                                <ItemTemplate>
                                                    <div style="border: none;"></div>
                                                    <ul class="list-unstyled timeline" style="width: 100%; border: 1px solid #DBDBDB; margin-right: 5px;">
                                                        <li>
                                                            <div class="block" style="padding: 5px 5px -3px 4px;">

                                                                <div class="tags">
                                                                    <a href="JavaScript:divexpandcollapse('div<%# Eval("ID_PRODUCTO") %>');">
                                                                        <img id="imgdiv<%# Eval("ID_PRODUCTO") %>" width="9px" border="0" src="/resources/images/plus.gif" alt="" />
                                                                        <span class="tag_2">Activo</span>
                                                                    </a>
                                                                </div>
                                                                <asp:Label ID="lblEmpID" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ID_PRODUCTO") %>'></asp:Label>
                                                                <div class="block_content">

                                                                    <h2 class="title">Producto:
                                                                            <asp:Label runat="server" Font-Bold="true" Text='<%# Eval("PRODUCTO") %>'></asp:Label>
                                                                        &nbsp; &nbsp; &nbsp;Catego:
                                                                            <asp:Label runat="server" Font-Bold="true" Text='<%# Eval("CATEGORIA") %>'></asp:Label>
                                                                    </h2>

                                                                    <h4>Inicio:
                                                                            <asp:Label runat="server" Font-Bold="true" Text='<%#  Convert.ToDateTime(Eval("FECHA_INICIO")).ToString("yyyy-MM-dd") %>'></asp:Label>
                                                                        &nbsp; Caducidad
                                                                            <asp:Label runat="server" Font-Bold="true" Text='<%# Convert.ToDateTime(Eval("FECHA_CADUCIDAD")).ToString("yyyy-MM-dd") %>'></asp:Label>
                                                                    </h4>

                                                                    <p class="excerpt" style="font-size: 15px; margin-top: -9px; margin-bottom: -8px; padding: 1px 2px 1px;">
                                                                        <asp:Label Text="Tipo de pago:" Font-Bold="true" runat="server" />
                                                                        &nbsp;&nbsp;<%# Eval("TIPO_PAGO") %>
                                                                        <br />
                                                                        <%# Eval("OBSERVACION") %>
                                                                    </p>

                                                                    <div class="actionBar" style="padding: 3px 2px 1px !important;">

                                                                        <asp:LinkButton runat="server" ID="btn_verProducto" CommandName="VerProducto" CssClass="btn btn-sm btn-success">
                                                                            <i class="fa fa-eye" aria-hidden="true"></i>                                                                             
                                                                        </asp:LinkButton>

                                                                        <asp:LinkButton runat="server" ID="btn_ImprimirProduc" CommandName="ImprimirProducto" CssClass="btn btn-sm btn-secondary">
                                                                            <i class="fa fa-print" aria-hidden="true"></i> 
                                                                        </asp:LinkButton>

                                                                        <asp:LinkButton runat="server" ID="btn_cargarArchivos" CommandName="VerArchivos" CssClass="btn btn-sm btn-default">
                                                                            <i class="fa fa-paperclip" aria-hidden="true"></i> 
                                                                        </asp:LinkButton>

                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </li>
                                                    </ul>
                                                    <tr>

                                                        <td colspan="100%">
                                                            <div id="div<%# Eval("ID_PRODUCTO") %>" style="overflow: auto; display: none; position: relative; left: 15px; overflow: auto; top: -17px;">

                                                                <asp:GridView ID="gv_Cuotas" runat="server" Width="95%" OnRowCommand="gv_Cuotas_RowCommand" AutoGenerateColumns="false" DataKeyNames="ID_PRODUCTO" CssClass="listoCuotas" BorderStyle="None" BorderWidth="1px" CellPadding="2">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Salary ID" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCuotasProduc" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ID_PRODUCTO_ASOCIADO") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="ESTADO" ItemStyle-Width="100px">
                                                                            <ItemTemplate>
                                                                                <label class="" style="font-weight: bold; color: <%#DataBinder.Eval(Container.DataItem, "color")%>">
                                                                                    <%#DataBinder.Eval(Container.DataItem, "ESTADO") %>
                                                                                </label>
                                                                                <%--<asp:Label Text='<%#DataBinder.Eval(Container.DataItem, "ESTADO") %>' runat="server" />
                                                                                <asp:Label ID="lbl_estado" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ESTADO") %>' Font-Bold="true" ForeColor="Yellow"  ></asp:Label>--%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="FECHA_PROXIMO_PAGO" HeaderText="PROXIMO PAGO" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Width="120px" />
                                                                        <asp:BoundField DataField="COSTO" HeaderText="COSTO" ItemStyle-Width="80px" />
                                                                        <asp:BoundField DataField="OBSERVACION" HeaderText="OBSERVACION" />
                                                                        <asp:TemplateField ItemStyle-Width="95">
                                                                            <ItemTemplate>

                                                                                <asp:LinkButton runat="server" ID="btn_verProducto" ToolTip="Ver detalles" CommandName="VerCuota" Width="20" Height="20" CssClass="btn btn-sm btn-default">
                                                                                    <i class="fa fa-eye" aria-hidden="true"></i>                                                                             
                                                                                </asp:LinkButton>

                                                                                <asp:LinkButton runat="server" ID="btn_ImprimirProduc" ToolTip="Imprimir" CommandName="ImprimirCuota" Width="20" Height="20" CssClass="btn btn-sm btn-default">
                                                                                    <i class="fa fa-print" aria-hidden="true"></i> 
                                                                                </asp:LinkButton>

                                                                                <asp:LinkButton runat="server" ID="btn_cargarArchivos" ToolTip="Ver archivos" CommandName="VerArchivosCuota" Width="20" Height="20" CssClass="btn btn-sm btn-default">
                                                                                     <i class="fa fa-paperclip" aria-hidden="true"></i> 
                                                                                </asp:LinkButton>

                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                        </Columns>
                                        <HeaderStyle BackColor="#0063A6" ForeColor="White" />
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
                                        <asp:Button ID="btn_NuevaNota" class="btn btn-sm btn-success" OnClick="btn_NuevaNota_Click" runat="server" Text="Agregar" />
                                    </div>
                                    <asp:Panel runat="server">
                                        <asp:GridView ID="gv_Notas" runat="server" AutoGenerateColumns="false" DataKeyNames="ID_NOTA"
                                            ShowHeaderWhenEmpty="true"
                                            OnRowCommand="gv_Notas_RowCommand"
                                            BackColor="White" BorderColor="#ffffff" BorderStyle="None" BorderWidth="1px" CellPadding="2">

                                            <%--         <FooterStyle BackColor="White" ForeColor="#000066" />
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

            <asp:HiddenField runat="server" ID="hf_Producto" />
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
                                                <asp:DropDownList ID="bl_TipoProducto" AutoPostBack="true" OnSelectedIndexChanged="bl_TipoProducto_SelectedIndexChanged" runat="server" CssClass="form-control" DataTextField="PRODUCTO" DataValueField="ID_PRODUCTO">
                                                </asp:DropDownList>
                                            </div>

                                            <label class="col-form-label col-md-1 col-sm-1 label-align stile_label">
                                                Categoria
                                            </label>
                                            <div class="col-md-2 col-sm-2 ">
                                                <asp:DropDownList ID="bl_CatProduc" runat="server" CssClass="form-control" DataTextField="TIPO_PRODUCTO" DataValueField="ID_TIPO_PRODUCTO">
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
                                                <asp:DropDownList ID="bl_CompaniaSe" AutoPostBack="true" OnSelectedIndexChanged="bl_CompaniaSe_SelectedIndexChanged" runat="server" CssClass="form-control" DataTextField="NOMBRE" DataValueField="CODIGO_INTERNO">
                                                </asp:DropDownList>
                                            </div>

                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label" for="last-name">
                                                Codigo Interno 
                                            </label>
                                            <div class="col-md-4 col-sm-4 ">
                                                <asp:TextBox runat="server" ID="txt_CodInterno" AutoCompleteType="Email" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>

                                        <br />
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



                                        <br />
                                        <span class="section">Información de pago</span>

                                        <div class="item form-group">
                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label" for="last-name">
                                                Efectivo 
                                            </label>
                                            <div class="col-md-3 col-sm-3 ">
                                                <asp:TextBox runat="server" ID="txt_pagoEfectivo" TextMode="Number" CssClass="form-control"></asp:TextBox>
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
                                                <asp:TextBox runat="server" ID="txt_recargo" TextMode="Number" Enabled="false" CssClass="form-control"></asp:TextBox>
                                            </div>

                                        </div>

                                        <div class="item form-group">



                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label" style="width: 68px !important;" for="last-name">
                                                Costo 
                                            </label>
                                            <div class="col-md-3 col-sm-3">
                                                <asp:TextBox runat="server" ID="txt_Costo" TextMode="Number" CssClass="form-control"></asp:TextBox>
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
                                                <asp:DropDownList ID="bl_Tipopago" runat="server" AutoPostBack="true" OnSelectedIndexChanged="bl_Tipopago_SelectedIndexChanged" CssClass="form-control">
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
                                        <div class="item form-group">
                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label" for="last-name">
                                                Proximo Pago
                                            </label>
                                            <div class="col-md-4 col-sm-4 ">
                                                <asp:TextBox ID="txt_proximoPago" CssClass="date-picker form-control" TextMode="Date" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="item form-group">
                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label" for="last-name">
                                                Archivo <span class="required" style="color: red">*</span>
                                            </label>
                                            <div class="col-md-9 col-sm-9 ">
                                                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
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
                                    <asp:AsyncPostBackTrigger ControlID="bl_CompaniaSe" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="bl_Tipopago" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="txt_tarjetaCedito" EventName="TextChanged" />
                                </Triggers>
                            </asp:UpdatePanel>

                        </div>
                        <div class="modal-footer">
                            <asp:Button runat="server" ID="btn_ActualizarProduto" CssClass="btn btn-success" Text="Actualizar" OnClick="btn_ActualizarProduto_Click" />
                            <asp:Button runat="server" ID="btn_aceptar" CssClass="btn btn-success" Text="Aceptar" OnClick="btn_aceptar_Click" />
                            <asp:Button runat="server" ID="btn_imprimir" CssClass="btn btn-primary" Text="Imprimir  " OnClick="btn_imprimir_Click" />

                            <%--<asp:Button runat="server" ID="btn_cerrPro" CssClass="btn  btn-secondary" Text="Cancelar" OnClick="btn_cerrPro_Click" />--%>

                            <asp:LinkButton runat="server" ID="btn_cerrPro" OnClick="btn_cerrPro_Click" CssClass="btn btn-secondary">
                                <i class="fa fa-close" aria-hidden="true"></i> Cancelar
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
                                            <div class="col-md-2 col-sm-2">
                                                <asp:TextBox ID="txt_Cuota" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label">
                                                Estado Cuota
                                            </label>
                                            <div class="col-md-2 col-sm-2 ">
                                                <asp:TextBox ID="txt_EstodoCuota" Enabled="false" CssClass="date-picker form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <label class="col-form-label col-md-2 col-sm-2 label-align stile_label">
                                                Valor Cuota
                                            </label>
                                            <div class="col-md-2 col-sm-2">
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
                                                <asp:FileUpload ID="FileUpload2" runat="server" CssClass="form-control" />
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
                                <%--<Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="bl_TipoProducto" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="bl_CompaniaSe" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="bl_Tipopago" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="txt_tarjetaCedito" EventName="TextChanged" />
                                </Triggers>--%>
                            </asp:UpdatePanel>

                        </div>
                        <div class="modal-footer">

                            <asp:LinkButton runat="server" ID="btn_AceptarCuotas" OnClick="btn_AceptarCuotas_Click" CssClass="btn btn-success">
                                <i class="fa fa-save" aria-hidden="true"></i> Aceptar
                            </asp:LinkButton>

                            <%--<asp:Button runat="server" ID="btn_AceptarCuotas" CssClass="btn btn-success" Text="Aceptar" OnClick="btn_AceptarCuotas_Click" />--%>
                            <asp:Button runat="server" ID="btn_ImprimirCuota" CssClass="btn btn-primary" Text="Imprimir  " OnClick="btn_ImprimirCuota_Click" />

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
