using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LATINMEX.Datos
{
    public class Conexion
    {
        protected SqlConnection cnn;

        protected void Conectar()
        {
            //string MyCnnString = System.Configuration.ConfigurationManager.AppSettings.Get("cnn_CORE_MASTER");
            string MyCnnString = ConfigurationManager.ConnectionStrings["cnn_CORE_MASTER"].ConnectionString;

            try
            {
                cnn = new SqlConnection(MyCnnString);
                
                cnn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        protected void Desconectar() 
        {
            try
            {
                cnn.Close();
                cnn.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            
        }
    }
}