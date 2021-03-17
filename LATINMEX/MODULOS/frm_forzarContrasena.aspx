<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_forzarContrasena.aspx.cs" Inherits="LATINMEX.MODULOS.frm_forzarContrasena" %>

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
                        <div class="col-md-8 col-lg-6 offset-lg-3 offset-md-2">
                            <div class="x_panel">
                                <div class="x_title">
                                    <h2>
                                        <asp:Label runat="server" ForeColor="#73879C" Text="Cambio de Contraseña"></asp:Label>
                                    </h2>
                                    <div class="clearfix">
                                        <img src="/resources/images/logo.jpg" height="50" alt="..." class="pull-right" />
                                    </div>
                                </div>
                                <div class="x_content">
                                    <asp:Panel runat="server" ID="pnll_info1">
                                        <div class="row">
                                            <div class="col-lg-5 col-md-6">
                                                <h2 class="text-left">Nota</h2>
                                                <p>Para continiar con la normalidad de los procesos que se realizan en LATINMEX  debe realizar el cambio de contraseña.</p>
                                            </div>
                                            <div class="col-md-6 col-lg-7">
                                                <div class="col-lg-12 form-group">
                                                    <asp:TextBox runat="server" ID="txt_nuevaContrasena" CssClass="form-control" placeholder="Digite nueva contraseña" TextMode="Password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server"
                                                        ControlToValidate="txt_nuevaContrasena"
                                                        ValidationGroup="Registrar"
                                                        Display="Dynamic"
                                                        CssClass="text text-danger"
                                                        ErrorMessage="La longitud de la contraseña debe tener entre 7 y 10 caracteres" ToolTip="New Password is required." ValidationExpression="^[a-zA-Z0-9'@&#.\s]{8,10}$">
                                                    </asp:RequiredFieldValidator>
                                                </div>

                                                  <div class="col-lg-12 form-group">
                                                    <asp:TextBox runat="server" ID="txt_confirmarContrasena" CssClass="form-control" placeholder="Confirmar Contraseña" TextMode="Password"></asp:TextBox>

                                                    <asp:RequiredFieldValidator ID="ConfirmarContrasenaRequired" runat="server"
                                                        ControlToValidate="txt_confirmarContrasena"
                                                        CssClass="text text-danger"
                                                        Display="Dynamic"
                                                        ValidationGroup="Registrar"
                                                        ErrorMessage="La longitud de la contraseña debe tener entre 7 y 10 caracteres" ToolTip="New Password is required." ValidationExpression="^[a-zA-Z0-9'@&#.\s]{8,10}$">
                                                    </asp:RequiredFieldValidator>
                                                </div>

                                               <div class="col-lg-12 form-group">
                                                    <asp:Button runat="server" ID="btn_confirmar" ValidationGroup="Registrar" OnClick="btn_confirmar_Click" Text="Continuar" CssClass="btn btn-primary btn-xs" />
                                                    <a class="reset_pass" href="../LOGIN/LOGIN.aspx">Volver al Login</a>
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
