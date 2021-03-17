using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace LATINMEX.Datos.CORE
{
    public class CLS_MENUS : Conexion
    {
        int _commandTimeout = 600;

        public int SP_41_INSERTAR_MENUS(string TEXTO, string DESCRIPCION,  string ICONO, string URL, int? ID_MENU_PARENT)
        {
            Conectar();
            int result;
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_41_INSERTAR_MENUS", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TEXTO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@TEXTO"].Value = TEXTO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DESCRIPCION", System.Data.SqlDbType.NVarChar));
                command.Parameters["@DESCRIPCION"].Value = DESCRIPCION;

            
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ICONO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ICONO"].Value = ICONO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@URL", System.Data.SqlDbType.NVarChar));
                command.Parameters["@URL"].Value = URL;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_MENU_PARENT", System.Data.SqlDbType.Int));
                command.Parameters["@ID_MENU_PARENT"].Value = (object)ID_MENU_PARENT ?? DBNull.Value;

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
       
        public int SP_42_ACTUALIZAR_MENU( int ID_MENU, string TEXTO, string DESCRIPCION,  string ICONO, string URL, int? ID_MENU_PARENT)
        {
            Conectar();
            int result;
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_42_ACTUALIZAR_MENU", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_MENU", System.Data.SqlDbType.Int));
                command.Parameters["@ID_MENU"].Value = ID_MENU;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TEXTO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@TEXTO"].Value = TEXTO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DESCRIPCION", System.Data.SqlDbType.NVarChar));
                command.Parameters["@DESCRIPCION"].Value = DESCRIPCION;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ICONO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ICONO"].Value = ICONO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@URL", System.Data.SqlDbType.NVarChar));
                command.Parameters["@URL"].Value = URL;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_MENU_PARENT", System.Data.SqlDbType.Int));
                command.Parameters["@ID_MENU_PARENT"].Value = (object)ID_MENU_PARENT ?? DBNull.Value;

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
        
       public DataTable SP_40_GET_MENU(int ID_MENU)
        {
            Conectar();
            DataTable result = new DataTable();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_40_GET_MENU", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_MENU", System.Data.SqlDbType.Int));
                command.Parameters["@ID_MENU"].Value = ID_MENU;

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

        public DataTable SP_39_CONSULTAR_MENUS()
        {
            Conectar();
            DataTable result = new DataTable(); 
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_39_CONSULTAR_MENUS", cnn);
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

        public DataTable SP_48_LISTA_MENU_POR_ROLES(int ID_ROL)
        {
            Conectar();
            DataTable result = new DataTable();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_48_LISTA_MENU_POR_ROLES", cnn);
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

        public DataTable SP_50_CONSULTAR_MENUS_USUARIO (int ID_USUARIO)
        {
            Conectar();
            DataTable result = new DataTable();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_50_CONSULTAR_MENUS_USUARIO", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

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


        public int SP_43_DELETE_MENU(int ID_MENU)
        {
            Conectar();
            int result = -1;
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_43_DELETE_MENU", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_MENU", System.Data.SqlDbType.Int));
                command.Parameters["@ID_MENU"].Value = ID_MENU;


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

        public int SP_45_ASIGNACION_ROLES_MENUS(int ID_MENU, int ID_ROL)
        {
            Conectar();
            int result;
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_45_ASIGNACION_ROLES_MENUS", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;


                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_MENU", System.Data.SqlDbType.Int));
                command.Parameters["@ID_MENU"].Value = ID_MENU;

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

        public int SP_49_DESASIGNAR_ROLES_MENUS(int ID_MENU, int ID_ROL)
        {
            Conectar();
            int result;
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_49_DESASIGNAR_ROLES_MENUS", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_MENU", System.Data.SqlDbType.Int));
                command.Parameters["@ID_MENU"].Value = ID_MENU;

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

        public DataTable SP_47_LISTA_ROLES()
        {
            Conectar();
            DataTable result = new DataTable();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_47_LISTA_ROLES", cnn);
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

        public int FS_02_GET_ORDER_MENU()
        {
            Conectar();
            int result = 1;
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SELECT [dbo].[FS_02_GET_ORDER_MENU]()", cnn);
                command.CommandType = System.Data.CommandType.Text;
                command.CommandTimeout = _commandTimeout;

                result = (int)command.ExecuteScalar();
                command.Dispose();
            }
            catch (Exception e)
            {
                result = 1;
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }
            return result;
        }

        public static  List<TIPOS_MENUS_VIEW> LISTA_TIPOS_MENUS()
        {
            List<TIPOS_MENUS_VIEW> enums = ((TIPOS_MENUS[])Enum.GetValues(typeof(TIPOS_MENUS))).Select(c => new TIPOS_MENUS_VIEW() { ID = (int)c, NOMBRE = c.ToString() }).ToList();
            return enums;
        }

        public class TIPOS_MENUS_VIEW
        {
            public int ID { get; set; }
            public string NOMBRE { get; set; }
        }

    }
}