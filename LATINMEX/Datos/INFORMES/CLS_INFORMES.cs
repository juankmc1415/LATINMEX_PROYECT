using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LATINMEX.Datos.INFORMES
{
    public class CLS_INFORMES : Conexion
    {
        int _commandTimeout = 6000;

        public DataTable SP_INFORME_GET_DETALLES_SEGURO(string ID_PRODUCTO, string ID_FACTURA)
        {
            Conectar();
            DataTable result = new DataTable();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_INFORME_GET_DETALLES_SEGURO", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PRODUCTO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ID_PRODUCTO"].Value = ID_PRODUCTO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_FACTURA", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ID_FACTURA"].Value = ID_FACTURA;

                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(command);
                da.Fill(result);

                command.Dispose();
            }
            catch (Exception e)
            {
                result = null;
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }
            return result;
        }

        public DataTable SP_73_CREAR_SECUENCIA_FACTURA(string SEDE_ID, int ID_PRODUCTO, string FLAG_REIMPRESION, int ID_USUARIO)
        {
            Conectar();
            DataTable result = new DataTable();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_73_CREAR_SECUENCIA_FACTURA", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SEDE_ID", System.Data.SqlDbType.NVarChar));
                command.Parameters["@SEDE_ID"].Value = @SEDE_ID;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PRODUCTO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_PRODUCTO"].Value = ID_PRODUCTO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FLAG_REIMPRESION", System.Data.SqlDbType.NVarChar));
                command.Parameters["@FLAG_REIMPRESION"].Value = FLAG_REIMPRESION;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_USUARIO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_USUARIO"].Value = ID_USUARIO;

                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(command);
                da.Fill(result);

                command.Dispose();
            }
            catch (Exception e)
            {
                result = null;
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }
            return result;
        }

    }
}