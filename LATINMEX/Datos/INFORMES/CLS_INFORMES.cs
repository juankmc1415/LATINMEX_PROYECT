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

        public DataTable SP_INFORME_GET_DETALLES_SEGURO(string ID_PRODUCTO)
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