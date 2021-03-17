using LATINMEX.Datos.CORE;
using LATINMEX.MODELVIEW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LATINMEX.MODULOS
{
    public partial class frm_forzarContrasena : System.Web.UI.Page
    {
        CLS_USUARIOS cls_usuarios = new CLS_USUARIOS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] ==null)
            {
                Response.Redirect("../LOGIN/LOGIN.aspx");
            }
        }

        private Result ValidarCampos()
        {
            Result res = new Result();

            res.IsSuccess = true;
            if (string.IsNullOrEmpty(txt_nuevaContrasena.Text))
            {
                res.IsSuccess = false;
                return res;
            }

            if (string.IsNullOrEmpty(txt_confirmarContrasena.Text))
            {
                res.IsSuccess = false;
                return res;
            }

            if (txt_nuevaContrasena.Text.Length<7)
            {
                res.IsSuccess = false;
                return res;
            }

            if (txt_confirmarContrasena.Text.Length < 7)
            {
                res.IsSuccess = false;
                return res;
            }
            return res;
        }

        protected void btn_confirmar_Click(object sender, EventArgs e)
        {
            Result res = new Result();
            res = ValidarCampos();
            if (!res.IsSuccess)
            {
                return;
            }

            int id = Convert.ToInt32(Session["UserID"]);

            UsuariosView usuario = cls_usuarios.SP_69_GET_USUARIO(id);

            if (txt_nuevaContrasena.Text != txt_confirmarContrasena.Text)
            {
                lbl_Mensaje.Visible = true;
                lbl_Mensaje.Text = "Las contraseñas no coinciden";
                return;
            }

            string claveEncrip = CLS_CORE.Encrypt(txt_nuevaContrasena.Text);

            if (claveEncrip == usuario.Clave)
            {
                lbl_Mensaje.Visible = true;
                lbl_Mensaje.Text = "Las contraseña no puede ser igual a la actual";
                return;
            }

            int result = cls_usuarios.SP_74_CAMBIAR_CLAVE(id, claveEncrip);
            if (result > 0)
            {
                Session["forzar_contraseña"] = false;

                cls_usuarios.SP_72_FORZAR_CAMBIO_CONTRASEÑA(id,false);
                Response.Redirect("Default.aspx");
                
            }
            else
            {
                lbl_Mensaje.Visible = true;
                lbl_Mensaje.Text = "Se ha generado un error";

            }

        }
    }
}