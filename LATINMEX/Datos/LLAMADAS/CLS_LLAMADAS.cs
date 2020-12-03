using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LATINMEX.Datos.LLAMADAS
{
    public class CLS_LLAMADAS : Conexion
    {
        int _commandTimeout = 600;

        public DataTable SP_28_GET_LISTA_PRODUCTO_LLAMADAS(DateTime? FECHA_CADUCUDAD, string ID_CATEGORIA, string ID_COMPAÑIA, string ID_CLIENTE)
        {
            Conectar();
            DataTable result = new DataTable();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_28_GET_LISTA_PRODUCTO_LLAMADAS", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_CADUCUDAD", System.Data.SqlDbType.DateTime));
                if (FECHA_CADUCUDAD == null)
                {
                    command.Parameters["@FECHA_CADUCUDAD"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@FECHA_CADUCUDAD"].Value = FECHA_CADUCUDAD;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_CATEGORIA", System.Data.SqlDbType.DateTime));
                if (string.IsNullOrEmpty(ID_CATEGORIA) || string.IsNullOrWhiteSpace(ID_CATEGORIA))
                {
                    command.Parameters["@ID_CATEGORIA"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@ID_CATEGORIA"].Value = ID_CATEGORIA;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_COMPAÑIA", System.Data.SqlDbType.DateTime));
                if (string.IsNullOrEmpty(ID_COMPAÑIA) || string.IsNullOrWhiteSpace(ID_COMPAÑIA))
                {
                    command.Parameters["@ID_COMPAÑIA"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@ID_COMPAÑIA"].Value = ID_COMPAÑIA;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_CLIENTE", System.Data.SqlDbType.DateTime));
                if (string.IsNullOrEmpty(ID_CLIENTE) || string.IsNullOrWhiteSpace(ID_CLIENTE))
                {
                    command.Parameters["@ID_CLIENTE"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@ID_CLIENTE"].Value = ID_CLIENTE;
                }

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
        }// fin SP_28_GET_LISTA_PRODUCTO_LLAMADAS

    }
}