using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace LATINMEX.Datos.LOGIN
{
    public class DBA_LOGIN : Conexion //: IDisposable
    {
        int _commandTimeout = 600;

        //public DBA_LOGIN()
        //{
        //    System.Configuration.AppSettingsReader appReader = new System.Configuration.AppSettingsReader();
        //    string strCnn = appReader.GetValue("cnn_00_CORE_MASTER", typeof(string)).ToString();
        //    _sqlConnection = new SqlConnection(strCnn);

        //    _sqlConnection.Open();
        //}// 

        //public void Close()
        //{
        //    if (_sqlConnection != null && _sqlConnection.State != System.Data.ConnectionState.Closed)
        //    {
        //        _sqlConnection.Close();
        //    }
        //}// fin Close

        //public void Dispose()
        //{
        //    Close();
        //}// fin Dispose


        //public SqlTransaction StartTransaction()
        //{
        //    return _sqlConnection.BeginTransaction();
        //}// 

        /// <summary>
        /// Validar inicio de sesión
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int FS_00_GUI_CHECK_LOGIN(string username, string password)
        {
            Conectar();
            
            int result;
            try
            {
                System.Data.SqlClient.SqlCommand scalar = new System.Data.SqlClient.SqlCommand("SELECT [dbo].[FS_00_GUI_CHECK_LOGIN](@usuario, @contrasena)", cnn);
                scalar.CommandType = System.Data.CommandType.Text;
                scalar.CommandTimeout = _commandTimeout;

                scalar.Parameters.Add(new System.Data.SqlClient.SqlParameter("@usuario", System.Data.SqlDbType.NVarChar));
                scalar.Parameters["@usuario"].Value = username;

                scalar.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contrasena", System.Data.SqlDbType.NVarChar));
                scalar.Parameters["@contrasena"].Value = password;

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
        }// fin FS_CLI_05_CPA_GET_PLANT_CENTER_ID

        /// <summary>
        /// Metdodo que devuelve los datos de un usuario
        /// </summary>
        /// <param name="USUARIO"></param>
        /// <returns></returns>
        public DataSet SP_04_GET_DATOS_USUARIO(string USUARIO)
        {
            Conectar();
            DataSet result = new DataSet();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_04_GET_DATOS_USUARIO", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USUARIO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@USUARIO"].Value = USUARIO;

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
        }// fin SP_04_GET_DATOS_USUARIO
    }
}