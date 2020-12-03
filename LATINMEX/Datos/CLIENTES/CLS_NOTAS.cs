using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using static LATINMEX.Datos.CORE.CLS_CORE;

namespace LATINMEX.Datos.CLIENTES
{
    public class CLS_NOTAS:Conexion
    {
        int _commandTimeout = 600;

        public int SP_08_NUEVA_NOTA(string DESCRIPCION, int ID_USUARIO, string ESTADO, string PAGINA, int ID_CLENTE)
        {
            Conectar();
            int result;
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_08_NUEVA_NOTA", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DESCRIPCION", System.Data.SqlDbType.NVarChar));
                command.Parameters["@DESCRIPCION"].Value = DESCRIPCION;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_USUARIO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_USUARIO"].Value = ID_USUARIO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ESTADO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ESTADO"].Value = ESTADO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PAGINA", System.Data.SqlDbType.NVarChar));
                command.Parameters["@PAGINA"].Value = PAGINA;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_CLENTE", System.Data.SqlDbType.Int));
                command.Parameters["@ID_CLENTE"].Value = ID_CLENTE;

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
        }// fin SP_08_NUEVA_NOTA

        public int SP_31_NUEVA_NOTA_LLAMADA(string DESCRIPCION, int ID_USUARIO, string ESTADO, string PAGINA, int ID_CLENTE, string ID_PRODUCTO, string TIPO_PRODUCTO, string ESTADO_PRODUCTO)
        {
            Conectar();
            int result;
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_31_NUEVA_NOTA_LLAMADA", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DESCRIPCION", System.Data.SqlDbType.NVarChar));
                command.Parameters["@DESCRIPCION"].Value = DESCRIPCION;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_USUARIO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_USUARIO"].Value = ID_USUARIO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ESTADO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ESTADO"].Value = ESTADO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PAGINA", System.Data.SqlDbType.NVarChar));
                command.Parameters["@PAGINA"].Value = PAGINA;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_CLENTE", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ID_CLENTE"].Value = ID_CLENTE;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PRODUCTO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ID_PRODUCTO"].Value = ID_PRODUCTO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TIPO_PRODUCTO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@TIPO_PRODUCTO"].Value = TIPO_PRODUCTO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ESTADO_PRODUCTO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ESTADO_PRODUCTO"].Value = ESTADO_PRODUCTO;

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
        }// fin SP_08_NUEVA_NOTA


        public int SP_09_ELIMINAR_NOTA(int ID_NOTA, string ESTADO, int ID_USUARIO)
        {
            Conectar();
            int result;
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_09_ELIMINAR_NOTA", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_NOTA", System.Data.SqlDbType.Int));
                command.Parameters["@ID_NOTA"].Value = ID_NOTA;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ESTADO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ESTADO"].Value = ESTADO;

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
        }

        public DataTable SP_10_GET_LISTA_NOTAS(string ID_CLIENTE)
        {
            Conectar();
            DataTable result = new DataTable();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_10_GET_LISTA_NOTAS", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_CLIENTE", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ID_CLIENTE"].Value = ID_CLIENTE;


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
        }// fin SP_06_GET_DATOS_CLIENTES

    }
}