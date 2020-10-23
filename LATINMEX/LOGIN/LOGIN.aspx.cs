using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LATINMEX.Datos.CORE;
namespace LATINMEX.LOGIN
{
    public partial class LOGIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            string usuario = txt_Usuario.Text;
            string contraseña = txt_Contraseña.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrWhiteSpace(usuario))
            {
                lbl_Mensaje.Text = "Username is required";
                lbl_Mensaje.Visible = true;
                txt_Usuario.Focus();
            }

            if (string.IsNullOrEmpty(contraseña) || string.IsNullOrWhiteSpace(contraseña))
            {
                lbl_Mensaje.Text = "user password is required";
                lbl_Mensaje.Visible = true;
                txt_Contraseña.Focus();
            }

            string clave = Datos.CORE.CLS_CORE.Encrypt(txt_Contraseña.Text);

            Datos.LOGIN.DBA_LOGIN dba = new Datos.LOGIN.DBA_LOGIN();
            int result = dba.FS_00_GUI_CHECK_LOGIN(usuario, clave);

            if (result != -1)
            {
                Session.Remove("userID");

                string nombre = "";
                //string foto = "";

                DataSet dataUsuario = new DataSet();
                dataUsuario = dba.SP_04_GET_DATOS_USUARIO(usuario);

                if (dataUsuario != null && dataUsuario.Tables.Count > 0)
                {
                    nombre = dataUsuario.Tables[0].Rows[0]["NOMBRES"].ToString();

                    Session["usuario"] = usuario;
                    Session["userID"] = dataUsuario.Tables[0].Rows[0]["ID_USUARIO"].ToString();
                    Session["nombre_usuario"] = nombre;
                }

                //Registrar auditoria
                CLS_AUDITORIA audi = new CLS_AUDITORIA();
                string IP = Request.UserHostAddress;
                audi.SP_02_INSERTAR_AUDITORIA("INICIO SESION", $"El usuario {nombre} inicio sesión", "LOGIN", IP, result);

                Session.Remove("Retries");
                Session["Auth"] = "OK";
                Session["userID"] = result;
             
                Response.Redirect("/MODULOS/Default.aspx");
            }
            else
            {
                lbl_Mensaje.Visible = true;
                string configCaptcha = System.Web.Configuration.WebConfigurationManager.AppSettings["enableCaptcha"];
                string enableCaptcha = configCaptcha != null ? configCaptcha : "false";
                //Ext.Net.X.AddScript("error('" + enableCaptcha + "');");
            }


        }
    }
}