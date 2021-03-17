using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LATINMEX.Datos;

using System.Data;
namespace LATINMEX.Datos.CORE
{
    public class CLS_PERMISOS : Conexion
    {
        int _commandTimeout = 600;

        #region Tipo permisos

        public DataTable SP_51_CONSULTAR_TIPOS_PERMISOS()
        {
            Conectar();
            DataTable result = new DataTable();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_51_CONSULTAR_TIPOS_PERMISOS", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

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

        public int SP_52_INSERTAR_TIPOS_PERMISOS(string TIPO)
        {
            Conectar();
            int result;
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_52_INSERTAR_TIPOS_PERMISOS", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TIPO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@TIPO"].Value = TIPO;


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

        public int SP_54_ELIMINAR_TIPO_PERMISO(int ID_TIPO_PERMISO)
        {
            Conectar();
            int result;
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_54_ELIMINAR_TIPO_PERMISO", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_TIPO_PERMISO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_TIPO_PERMISO"].Value = ID_TIPO_PERMISO;

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

        public int FS_06_CHECK_PERMISO_USUARIO(int ID_PERMISO, int ID_USUARIO) {
           
            Conectar();
            int result = 1;
            try
            {
                System.Data.SqlClient.SqlCommand scalar = new System.Data.SqlClient.SqlCommand("SELECT [dbo].[FS_06_CHECK_PERMISO_USUARIO](@ID_PERMISO, @ID_USUARIO)", cnn);
                scalar.CommandType = System.Data.CommandType.Text;
                scalar.CommandTimeout = _commandTimeout;

                scalar.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PERMISO", System.Data.SqlDbType.Int));
                scalar.Parameters["@ID_PERMISO"].Value = ID_PERMISO;

                scalar.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_USUARIO", System.Data.SqlDbType.Int));
                scalar.Parameters["@ID_USUARIO"].Value = ID_USUARIO;

                result = (int)scalar.ExecuteScalar();
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
        #endregion

        #region Permisos

        public int SP_55_INSERTAR_PERMISOS(string PERMISO, string DESCRIPCION, int ID_TIPO_PERIMISO)
        {
            Conectar();
            int result;
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_55_INSERTAR_PERMISOS", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PERMISO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@PERMISO"].Value = PERMISO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DESCRIPCION", System.Data.SqlDbType.NVarChar));
                command.Parameters["@DESCRIPCION"].Value = DESCRIPCION;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_TIPO_PERMISO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_TIPO_PERMISO"].Value = ID_TIPO_PERIMISO;
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

        public int SP_56_ACTUALIZAR_PERMISOS(int ID_PERIMISO, string PERMISO, string DESCRIPCION, int ID_TIPO_PERIMISO)
        {
            Conectar();
            int result;
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_56_ACTUALIZAR_PERMISOS", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PERMISO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_PERMISO"].Value = ID_PERIMISO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PERMISO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@PERMISO"].Value = PERMISO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DESCRIPCION", System.Data.SqlDbType.NVarChar));
                command.Parameters["@DESCRIPCION"].Value = DESCRIPCION;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_TIPO_PERMISO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_TIPO_PERMISO"].Value = ID_TIPO_PERIMISO;

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
            
        public DataTable SP_61_CONSULTAR_PERMISOS(int ID_ROL)
        {
            Conectar();
            DataTable result = new DataTable();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_61_CONSULTAR_PERMISOS", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;


                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_ROL", System.Data.SqlDbType.Int));
                command.Parameters["@ID_ROL"].Value = ID_ROL;


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


        public int SP_57_ASIGNAR_ROLES_PERMISOS(int ID_PERIMISO, int ID_ROL)
        {
            Conectar();
            int result;
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_57_ASIGNAR_ROLES_PERMISOS", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PERMISO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_PERMISO"].Value = ID_PERIMISO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_ROL", System.Data.SqlDbType.Int));
                command.Parameters["@ID_ROL"].Value = ID_ROL;

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

        public int SP_59_DESASIGNAR_ROLES_PERMISOS(int ID_PERIMISO, int ID_ROL)
        {
            Conectar();
            int result;
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_59_DESASIGNAR_ROLES_PERMISOS", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PERMISO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_PERMISO"].Value = ID_PERIMISO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_ROL", System.Data.SqlDbType.Int));
                command.Parameters["@ID_ROL"].Value = ID_ROL;

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


        public int SP_60_ELIMINAR_PERMISOS(int ID_PERMISO)
        {
            Conectar();
            int result;
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_60_ELIMINAR_PERMISOS", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PERMISO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_PERMISO"].Value = ID_PERMISO;

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

         public int FS_05_GET_ORDER_PERMISO()
        {
            Conectar();
            int result = 1;
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SELECT [dbo].[FS_05_GET_ORDER_PERMISO]()", cnn);
                command.CommandType = System.Data.CommandType.Text;
                command.CommandTimeout = _commandTimeout;

                result = (int)command.ExecuteScalar();
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


        public DataTable SP_62_GET_PERMISO(int ID_PERMISO)
        {
            Conectar();
            DataTable result = new DataTable();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_62_GET_PERMISO", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;


                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PERMISO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_PERMISO"].Value = ID_PERMISO;


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


       


        #endregion
    }
}