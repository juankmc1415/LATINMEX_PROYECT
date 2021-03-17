using LATINMEX.NOTIFY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LATINMEX.Datos.CORE
{
    public class CLS_NOTIFY
    {
        private static  Email em =new Email();
      
        public static void Email_ForzarCambioContraseña(string email)
        {
            string body = $@"<style>
                            h1{"color":dodgerblue;}
                            h2{"color":darkorange;}
                            </style>
                            <h1>Cambio de Contraseña</h1></br>
                            <h2>Se le notifica que su usuario deberá realizar un cambio de contraseña, para mayor seguridad de su información</h2>
                            <p>Acceda a este link: <a href='https://localhost:44372/LOGIN/LOGIN.aspx'> https://localhost:44372/LOGIN/LOGIN.aspx </a></p> ";
            em.sendMail(email, "CAMBIO DE CONTRASEÑA", body);
        }


        public static void Email_CreacionDeUsuario(string email, string contraseña, string usuario)
        {
            string body = $@"<style>
                            h1{"color":dodgerblue;}
                            h2{"color":darkorange;}
                            </style>
                            <h1>Creación de usuario</h1></br>
                            <h2>HOLA! Se notifica la creación de un usuario en la plataforma LATINMEX</h2>
                            <p><strong> Sus credenciales son : </strong></p>
                            <p>Usuario: {usuario}</p>
                            <p>Contraseña: {contraseña}</p>
                            <p>Acceda a este link: <a href='https://localhost:44372/LOGIN/LOGIN.aspx'> https://localhost:44372/LOGIN/LOGIN.aspx </a></p> ";
            em.sendMail(email, "CREACION DE USUARIO", body);
        }

        public static void Email_RestaurarContseña(string email, string contraseña)
        {
            string body = $@"<style>
                            h1{"color":dodgerblue;}
                            h2{"color":darkorange;}
                            </style>
                            <h1>Restaura contraseña</h1></br>
                            <h2>Se le notifica  que su contraseña ha sido restaurada</h2>
                            <p><strong> Sus credenciales son : </strong></p>
                            <p> Nueva Contraseña: {contraseña}</p>
                            <p>Acceda a este link: <a href='https://localhost:44372/LOGIN/LOGIN.aspx'> https://localhost:44372/LOGIN/LOGIN.aspx </a></p> ";
            em.sendMail(email, "RESTAURAR CONTRASEÑA", body);
        }

        public static void Email_RecuperarContraseña(string email, string contraseña,string usuario)
        {
            string body = $@"<style>
                            h1{"color":dodgerblue;}
                            h2{"color":darkorange;}
                            </style>
                            <h1>Recuperar  contraseña</h1></br>
                            <h2>Desde el área de administración se le notifica que su usuario actual es el siguiente</h2>
                            <p><strong> Credenciales son : </strong></p>
                            <p>Usuario: {usuario}</p>
                            <p>Contraseña: {contraseña}</p>
                            <p>Acceda a este link: <a href='https://localhost:44372/LOGIN/LOGIN.aspx'> https://localhost:44372/LOGIN/LOGIN.aspx </a></p> ";
            em.sendMail(email, "RECUPERAR CONTRASEÑA", body);
        }

    }
}