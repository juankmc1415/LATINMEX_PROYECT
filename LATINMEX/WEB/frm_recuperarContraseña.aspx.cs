using LATINMEX.Datos.CORE;
using LATINMEX.MODELVIEW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LATINMEX.WEB
{
    public partial class frm_recuperarContraseña : System.Web.UI.Page
    {
        CLS_USUARIOS cls_usuarios = new CLS_USUARIOS();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_confirmar_Click(object sender, EventArgs e)
        {
            Result res = ValidarUsuario();
            if (!res.IsSuccess)
            {
                return;
            }

            UsuariosView usuario = cls_usuarios.SP_04_GET_DATOS_USUARIO_EMAIL(txt_email.Text);
            if (usuario != null)
            {
                lbl_Mensaje.Visible = true;
                lbl_Mensaje.CssClass ="alert alert-success alert-dismissible";
                lbl_Mensaje.Text = $"El mensaje de recuperación fue enviado correctamente";

                //Notifico al usuario
                string encritClave = CLS_CORE.Decrypt(usuario.Clave);
                int result = cls_usuarios.SP_72_FORZAR_CAMBIO_CONTRASEÑA(usuario.IdUsuario, true);

                if (result>0)
                {
                     CLS_NOTIFY.Email_RestaurarContseña(txt_email.Text, encritClave);
                }
            }
            else
            {
                lbl_Mensaje.Visible = true;
                lbl_Mensaje.Text = $"No se encontro ningun usuario con  el email {txt_email.Text}";
            }
        }

        private Result ValidarUsuario()
        {
            var res = new Result();
            res.IsSuccess = true;


            if (string.IsNullOrEmpty(txt_email.Text))
            {
                res.IsSuccess = false;
            }

            if (!string.IsNullOrEmpty(txt_email.Text) && !email_bien_escrito(txt_email.Text))
            {
                res.IsSuccess = false;
            }

            return res;
        }

        private bool email_bien_escrito(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}