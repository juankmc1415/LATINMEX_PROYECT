<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LOGIN.aspx.cs" Inherits="LATINMEX.LOGIN.LOGIN" %>

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
    <link href="../Content/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awesome -->
    <link href="../Content/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <!-- NProgress -->
    <link href="../Content/nprogress/nprogress.css" rel="stylesheet" />
    <!-- Animate.css -->
    <link href="../Content/animate.css/animate.min.css" rel="stylesheet" />

    <!-- Custom Theme Style -->
    <link href="../Content/build/css/custom.min.css" rel="stylesheet" />

</head>
<body class="login">


    <a class="hiddenanchor" id="signup"></a>
    <a class="hiddenanchor" id="signin"></a>

    <div class="login_wrapper">
        <div class="animate form login_form">
            <section class="login_content">
                <form id="form2" runat="server">

                    <div>

                        <div>
                            <%--<img src="/resources/images/Latinmex.jpg" width="400" alt="..." class="" />--%>
                            <img src="../resources/images/logo.jpg" height="200" alt="..." class="" />
                        </div>
                    </div>

                    <h1>Login Form</h1>

                    <div>
                        <asp:TextBox runat="server" ID="txt_Usuario" CssClass="form-control" placeholder="Username" required=""></asp:TextBox>
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="txt_Contraseña" CssClass="form-control" placeholder="Password" required="" TextMode="Password"></asp:TextBox>
                    </div>

                    <div>
                        <asp:Button runat="server" ID="tst" OnClick="btn_login_Click" Text="Log In" CssClass="btn btn-secondary btn-xs" />
                        <a class="reset_pass" href="../WEB/frm_recuperarContraseña.aspx">Lost your password?</a>
                    </div>

                    <div class="clearfix"></div>

                    <div class="separator">

                        <div class="clearfix"></div>
                        <br />

                        <div>
                            <%-- <h1><i class="fa fa-paw"></i>LATINMEX!</h1>--%>
                            <p>©2020 CORPORATION JA</p>
                        </div>

                        <div>
                            <asp:Label ID="lbl_Mensaje" runat="server" Visible="false" CssClass="alert alert-error alert-dismissible" role="alert">Usuario o Contraseña incorrecto</asp:Label>
                        </div>

                    </div>
                </form>
            </section>
        </div>


    </div>


</body>
</html>
