using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using static LATINMEX.Datos.CORE.CLS_CORE;

namespace LATINMEX.Datos.CLIENTES
{
    public class CLS_CLIENTE : Conexion
    {
        int _commandTimeout = 600;

        public DataTable SP_05_INSERTAR_CLIENTE(LTM_CLIENTE cliente)
        {
            Conectar();
            DataTable result = new DataTable();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_05_INSERTAR_CLIENTE", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PRIMER_NOMBRE", System.Data.SqlDbType.NVarChar));
                command.Parameters["@PRIMER_NOMBRE"].Value = cliente.PRIMER_NOMBRE;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SEGUNDO_NOMBRE", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(cliente.SEGUNDO_NOMBRE) || string.IsNullOrWhiteSpace(cliente.SEGUNDO_NOMBRE))
                {
                    command.Parameters["@SEGUNDO_NOMBRE"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@SEGUNDO_NOMBRE"].Value = cliente.SEGUNDO_NOMBRE;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@APELLIDOS", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(cliente.APELLIDOS) || string.IsNullOrWhiteSpace(cliente.APELLIDOS))
                {
                    command.Parameters["@APELLIDOS"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@APELLIDOS"].Value = cliente.APELLIDOS;
                }

                

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CORREO", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(cliente.CORREO) || string.IsNullOrWhiteSpace(cliente.CORREO))
                {
                    command.Parameters["@CORREO"].Value =  DBNull.Value;
                }
                else
                {
                    command.Parameters["@CORREO"].Value = cliente.CORREO;
                }
                

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TELEFONO_MOVIL", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(cliente.TELEFONO_MOVIL) || string.IsNullOrWhiteSpace(cliente.TELEFONO_MOVIL))
                {
                    command.Parameters["@TELEFONO_MOVIL"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@TELEFONO_MOVIL"].Value = cliente.TELEFONO_MOVIL;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DIRECCION_RESIDENCIA", System.Data.SqlDbType.NVarChar));
                command.Parameters["@DIRECCION_RESIDENCIA"].Value = cliente.DIRECCION_RESIDENCIA;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DIRECCION_CORRESPONDENCIA", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(cliente.DIRECCION_CORRESPONDENCIA) || string.IsNullOrWhiteSpace(cliente.DIRECCION_CORRESPONDENCIA))
                {
                    command.Parameters["@DIRECCION_CORRESPONDENCIA"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@DIRECCION_CORRESPONDENCIA"].Value = cliente.DIRECCION_CORRESPONDENCIA;
                }
                
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_NACIMIENTO", System.Data.SqlDbType.Date));
                if (cliente.FECHA_NACIMIENTO == null)
                {
                    command.Parameters["@FECHA_NACIMIENTO"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@FECHA_NACIMIENTO"].Value = cliente.FECHA_NACIMIENTO;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_CONDUCCION", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ID_CONDUCCION"].Value = cliente.ID_CONDUCCION;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CIUDAD", System.Data.SqlDbType.NVarChar));
                command.Parameters["@CIUDAD"].Value = cliente.CIUDAD;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ESTADO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ESTADO"].Value = cliente.ESTADO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CODIGO_POSTAL", System.Data.SqlDbType.NVarChar));
                command.Parameters["@CODIGO_POSTAL"].Value = cliente.CODIGO_POSTAL;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NOMBRE_EMPRESA", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(cliente.NOMBRE_EMPRESA) || string.IsNullOrWhiteSpace(cliente.NOMBRE_EMPRESA))
                {
                    command.Parameters["@NOMBRE_EMPRESA"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@NOMBRE_EMPRESA"].Value = cliente.NOMBRE_EMPRESA;
                }
                

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VIN_1", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(cliente.VIN_1) || string.IsNullOrWhiteSpace(cliente.VIN_1))
                {
                    command.Parameters["@VIN_1"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@VIN_1"].Value = cliente.VIN_1;
                }
                

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_VIN_1", System.Data.SqlDbType.Date));
                if (cliente.FECHA_VIN_1 == null)
                {
                    command.Parameters["@FECHA_VIN_1"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@FECHA_VIN_1"].Value = cliente.FECHA_VIN_1;
                }
                

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VIN_2", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(cliente.VIN_2) || string.IsNullOrWhiteSpace(cliente.VIN_2))
                {
                    command.Parameters["@VIN_2"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@VIN_2"].Value = cliente.VIN_2;
                }
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_VIN_2", System.Data.SqlDbType.Date));
                if (cliente.FECHA_VIN_2 == null)
                {
                    command.Parameters["@FECHA_VIN_2"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@FECHA_VIN_2"].Value = cliente.FECHA_VIN_2;
                }
                

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VIN_3", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(cliente.VIN_3) || string.IsNullOrWhiteSpace(cliente.VIN_3))
                {
                    command.Parameters["@VIN_3"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@VIN_3"].Value = cliente.VIN_3;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_VIN_3", System.Data.SqlDbType.Date));
                if (cliente.FECHA_VIN_3 == null )
                {
                    command.Parameters["@FECHA_VIN_3"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@FECHA_VIN_3"].Value = cliente.FECHA_VIN_3;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VIN_4", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(cliente.VIN_4) || string.IsNullOrWhiteSpace(cliente.VIN_4))
                {
                    command.Parameters["@VIN_4"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@VIN_4"].Value = cliente.VIN_4;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_VIN_4", System.Data.SqlDbType.DateTime));
                if (cliente.FECHA_VIN_4 == null)
                {
                    command.Parameters["@FECHA_VIN_4"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@FECHA_VIN_4"].Value = cliente.FECHA_VIN_4;
                }


                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VIN_5", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(cliente.VIN_5) || string.IsNullOrWhiteSpace(cliente.VIN_5))
                {
                    command.Parameters["@VIN_5"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@VIN_5"].Value = cliente.VIN_5;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_VIN_5", System.Data.SqlDbType.DateTime));
                if (cliente.FECHA_VIN_5 == null)
                {
                    command.Parameters["@FECHA_VIN_5"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@FECHA_VIN_5"].Value = cliente.FECHA_VIN_5;
                }


                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_USUARIO_CREACION", System.Data.SqlDbType.Int));
                command.Parameters["@ID_USUARIO_CREACION"].Value = cliente.ID_USUARIO_CREACION;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_USUARIO_ACTUALIZACION", System.Data.SqlDbType.Int));
                command.Parameters["@ID_USUARIO_ACTUALIZACION"].Value = cliente.ID_USUARIO_ACTUALIZACION;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_CREACION", System.Data.SqlDbType.DateTime));
                command.Parameters["@FECHA_CREACION"].Value = cliente.FECHA_CREACION;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_ACTULIZACION", System.Data.SqlDbType.DateTime));
                command.Parameters["@FECHA_ACTULIZACION"].Value = cliente.FECHA_ACTULIZACION;

                
                

                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(command);
                da.Fill(result);

                //result = command.ExecuteNonQuery();
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
        }// fin SP_05_INSERTAR_CLIENTE

        public int SP_07_ACTUALIZAR_CLIENTE(LTM_CLIENTE cliente, string ID_CLIENTE)
        {
            Conectar();
            int result;
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_07_ACTUALIZAR_CLIENTE", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_CLIENTE", System.Data.SqlDbType.Int));
                command.Parameters["@ID_CLIENTE"].Value = ID_CLIENTE;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PRIMER_NOMBRE", System.Data.SqlDbType.NVarChar));
                command.Parameters["@PRIMER_NOMBRE"].Value = cliente.PRIMER_NOMBRE;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SEGUNDO_NOMBRE", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(cliente.SEGUNDO_NOMBRE) || string.IsNullOrWhiteSpace(cliente.SEGUNDO_NOMBRE))
                {
                    command.Parameters["@SEGUNDO_NOMBRE"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@SEGUNDO_NOMBRE"].Value = cliente.SEGUNDO_NOMBRE;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@APELLIDOS", System.Data.SqlDbType.NVarChar));
                command.Parameters["@APELLIDOS"].Value = cliente.APELLIDOS;

               

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CORREO", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(cliente.CORREO) || string.IsNullOrWhiteSpace(cliente.CORREO))
                {
                    command.Parameters["@CORREO"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@CORREO"].Value = cliente.CORREO;
                }


                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TELEFONO_MOVIL", System.Data.SqlDbType.NVarChar));
                command.Parameters["@TELEFONO_MOVIL"].Value = cliente.TELEFONO_MOVIL;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DIRECCION_RESIDENCIA", System.Data.SqlDbType.NVarChar));
                command.Parameters["@DIRECCION_RESIDENCIA"].Value = cliente.DIRECCION_RESIDENCIA;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DIRECCION_CORRESPONDENCIA", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(cliente.DIRECCION_CORRESPONDENCIA) || string.IsNullOrWhiteSpace(cliente.DIRECCION_CORRESPONDENCIA))
                {
                    command.Parameters["@DIRECCION_CORRESPONDENCIA"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@DIRECCION_CORRESPONDENCIA"].Value = cliente.DIRECCION_CORRESPONDENCIA;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_NACIMIENTO", System.Data.SqlDbType.Date));
                if (cliente.FECHA_NACIMIENTO == null)
                {
                    command.Parameters["@FECHA_NACIMIENTO"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@FECHA_NACIMIENTO"].Value = cliente.FECHA_NACIMIENTO;
                }

                //command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_NACIMIENTO", System.Data.SqlDbType.DateTime));
                //command.Parameters["@FECHA_NACIMIENTO"].Value = cliente.FECHA_NACIMIENTO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_CONDUCCION", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ID_CONDUCCION"].Value = cliente.ID_CONDUCCION;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CIUDAD", System.Data.SqlDbType.NVarChar));
                command.Parameters["@CIUDAD"].Value = cliente.CIUDAD;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ESTADO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ESTADO"].Value = cliente.ESTADO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CODIGO_POSTAL", System.Data.SqlDbType.NVarChar));
                command.Parameters["@CODIGO_POSTAL"].Value = cliente.CODIGO_POSTAL;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NOMBRE_EMPRESA", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(cliente.NOMBRE_EMPRESA) || string.IsNullOrWhiteSpace(cliente.NOMBRE_EMPRESA))
                {
                    command.Parameters["@NOMBRE_EMPRESA"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@NOMBRE_EMPRESA"].Value = cliente.NOMBRE_EMPRESA;
                }


                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VIN_1", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(cliente.VIN_1) || string.IsNullOrWhiteSpace(cliente.VIN_1))
                {
                    command.Parameters["@VIN_1"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@VIN_1"].Value = cliente.VIN_1;
                }


                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_VIN_1", System.Data.SqlDbType.DateTime));
                if (cliente.FECHA_VIN_1 == null)
                {
                    command.Parameters["@FECHA_VIN_1"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@FECHA_VIN_1"].Value = cliente.FECHA_VIN_1;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VIN_2", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(cliente.VIN_2) || string.IsNullOrWhiteSpace(cliente.VIN_2))
                {
                    command.Parameters["@VIN_2"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@VIN_2"].Value = cliente.VIN_2;
                }
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_VIN_2", System.Data.SqlDbType.DateTime));
                if (cliente.FECHA_VIN_2 == null)
                {
                    command.Parameters["@FECHA_VIN_2"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@FECHA_VIN_2"].Value = cliente.FECHA_VIN_2;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VIN_3", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(cliente.VIN_3) || string.IsNullOrWhiteSpace(cliente.VIN_3))
                {
                    command.Parameters["@VIN_3"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@VIN_3"].Value = cliente.VIN_3;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_VIN_3", System.Data.SqlDbType.DateTime));
                if (cliente.FECHA_VIN_3 == null)
                {
                    command.Parameters["@FECHA_VIN_3"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@FECHA_VIN_3"].Value = cliente.FECHA_VIN_3;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VIN_4", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(cliente.VIN_4) || string.IsNullOrWhiteSpace(cliente.VIN_4))
                {
                    command.Parameters["@VIN_4"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@VIN_4"].Value = cliente.VIN_4;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_VIN_4", System.Data.SqlDbType.DateTime));
                if (cliente.FECHA_VIN_4 == null)
                {
                    command.Parameters["@FECHA_VIN_4"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@FECHA_VIN_4"].Value = cliente.FECHA_VIN_4;
                }


                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VIN_5", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(cliente.VIN_5) || string.IsNullOrWhiteSpace(cliente.VIN_5))
                {
                    command.Parameters["@VIN_5"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@VIN_5"].Value = cliente.VIN_5;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_VIN_5", System.Data.SqlDbType.DateTime));
                if (cliente.FECHA_VIN_5 == null)
                {
                    command.Parameters["@FECHA_VIN_5"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@FECHA_VIN_5"].Value = cliente.FECHA_VIN_5;
                }


                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_USUARIO_ACTUALIZACION", System.Data.SqlDbType.Int));
                command.Parameters["@ID_USUARIO_ACTUALIZACION"].Value = cliente.ID_USUARIO_ACTUALIZACION;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_ACTULIZACION", System.Data.SqlDbType.DateTime));
                command.Parameters["@FECHA_ACTULIZACION"].Value = cliente.FECHA_ACTULIZACION;

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
        
        public DataSet SP_06_GET_DATOS_CLIENTES(string ID_CLIENTE)
        {
            Conectar();
            DataSet result = new DataSet();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_06_GET_DATOS_CLIENTES", cnn);
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