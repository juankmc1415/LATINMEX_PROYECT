using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LATINMEX.Datos.CORE
{
    public class CLS_AUDITORIA : Conexion
    {
        int _commandTimeout = 600;

        public int SP_02_INSERTAR_AUDITORIA(string TIPO, string DESCRIPCION, string PAGINA, string IP, int ID_USUARIO)
        {
            Conectar();
            int result;
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_02_INSERTAR_AUDITORIA", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TIPO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@TIPO"].Value = TIPO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DESCRIPCION", System.Data.SqlDbType.NVarChar));
                command.Parameters["@DESCRIPCION"].Value = DESCRIPCION;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PAGINA", System.Data.SqlDbType.NVarChar));
                command.Parameters["@PAGINA"].Value = PAGINA;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IP", System.Data.SqlDbType.NVarChar));
                command.Parameters["@IP"].Value = IP;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_USUARIO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_USUARIO"].Value = ID_USUARIO;

                result = command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (Exception e)
            {
                result = -1;
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }
            return result;
        }// fin SP_02_INSERTAR_AUDITORIA

        public DataSet SP_03_GET_AUDITORIA_USUSARIO(string ID_USUARIO, DateTime FECHA_INICIO, DateTime FECHA_FIN)
        {
            Conectar();
            DataSet result = new DataSet();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_03_GET_AUDITORIA_USUSARIO", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_USUARIO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ID_USUARIO"].Value = @ID_USUARIO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_INICIO", System.Data.SqlDbType.DateTime));
                command.Parameters["@FECHA_INICIO"].Value = FECHA_INICIO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_FIN", System.Data.SqlDbType.NVarChar));
                command.Parameters["@FECHA_FIN"].Value = FECHA_FIN;

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
        }// fin SP_03_GET_AUDITORIA_USUSARIO
    }
}