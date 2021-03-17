<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_recuperarContraseña.aspx.cs" Inherits="LATINMEX.WEB.frm_recuperarContraseña" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />

    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="icon" href="/resources/images/icon_color.ico" type="image/ico" />

    <title>LATINMEX </title>

    <!-- Bootstrap -->
    <link href="~/Content/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awesome -->
    <link href="~/Content/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <!-- NProgress -->
    <link href="~/Content/nprogress/nprogress.css" rel="stylesheet" />
    <!-- Animate.css -->
    <link href="~/Content/animate.css/animate.min.css" rel="stylesheet" />

    <!-- Custom Theme Style -->
    <link href="~/Content/build/css/custom.min.css" rel="stylesheet" />

</head>
<body class="wrapper">
    <div class="dataTables_wrapper">
        <div class="animate form login_form">
            <section class="login_content">
                <form id="form2" runat="server">
                    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>

                    <div class="row">
                        <div class="col-md-6 col-lg-4 offset-lg-4 offset-md-3">
                            <div class="x_panel">
                                <div class="x_title">
                                    <h2>
                                        <asp:Label runat="server" ForeColor="#73879C" Text="Recuperar de Contraseña"></asp:Label>
                                    </h2>
                                    <div class="clearfix">
                                        <img src="/resources/images/logo.jpg" height="50" alt="..." class="pull-right" />
                                    </div>
                                </div>
                                <div class="x_content">
                                    <asp:Panel runat="server" ID="pnll_info1">
                                        <div class="row">

                                            <div class="col-md-12 col-lg-12">

                                                <h2 class="text-left ">Nota! </h2>
                                                <strong>
                                                    <p class="text-left text-info">
                                                        Ingrese su email,a éste será enviado un correo para recuperar su contraseña.
                                                    Tenga en cuenta de debe haber un usuario registrado con este email.
                                                    </p>
                                                </strong>


                                                <div class="input-group">

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
                                                     
                                                    <asp:TextBox runat="server" ID="txt_email" Style="margin-bottom: 0px" CssClass="form-control" placeholder="Digite su email"></asp:TextBox>
                                                
                                                    <span class="input-group-btn">
                                                           <asp:LinkButton ID="btn_confirmar" ValidationGroup="Registrar" OnClick="btn_confirmar_Click" CssClass="btn btn-success btn-xs" runat="server">
                                                     <i class="fa fa-send"></i> Enviar
                                                </asp:LinkButton>  
                                                        <a class="reset_pass" href="../LOGIN/LOGIN.aspx">Volver al Login</a>

                                                    </span>
                                                </div>

                                            
                                                <div class="clearfix">
                                                    <asp:Label ID="lbl_Mensaje" runat="server" Visible="false" CssClass="alert alert-error alert-dismissible" role="alert">Usuario o Contraseña incorrecto</asp:Label>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-12 col-lg-12">

                                                <div class="separator">

                                                    <div>
                                                        <%-- <h1><i class="fa fa-paw"></i>LATINMEX!</h1>--%>
                                                        <p>©2020 CORPORATION JA</p>

                                                    </div>




                                                </div>
                                            </div>
                                        </div>

                                    </asp:Panel>

                                </div>
                            </div>

                        </div>
                    </div>

                </form>
            </section>
        </div>


    </div>


</body>
</html>
