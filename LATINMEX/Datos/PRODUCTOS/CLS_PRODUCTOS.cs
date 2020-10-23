using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using static LATINMEX.Datos.CORE.CLS_CORE;

namespace LATINMEX.Datos.PRODUCTOS
{
    public class CLS_PRODUCTOS : Conexion
    {
        int _commandTimeout = 6000;

        public DataTable SP_11_GET_PRODUCTOS()
        {
            Conectar();
            DataTable result = new DataTable();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_11_GET_PRODUCTOS", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                //command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_CLIENTE", System.Data.SqlDbType.NVarChar));
                //command.Parameters["@ID_CLIENTE"].Value = ID_CLIENTE;


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

        public DataTable SP_12_GET_TIPOS_PRODUCTO(int ID_PRODUCTO)
        {
            Conectar();
            DataTable result = new DataTable();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_12_GET_TIPOS_PRODUCTO", cnn);
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

        public DataTable SP_13_GET_ESTADOS_PRODUCTO(int ID_PRODUCTO)
        {
            Conectar();
            DataTable result = new DataTable();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_13_GET_ESTADOS_PRODUCTO", cnn);
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

        public DataTable SP_16_GET_LISTA_PRODUCTO(string ID_CLIENTE)
        {
            Conectar();
            DataTable result = new DataTable();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_16_GET_LISTA_PRODUCTO", cnn);
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
        }

        public DataTable SP_17_GET_LISTA_PRODUCTO_ASOCIADOS(string ID_PRODUCTO)
        {
            Conectar();
            DataTable result = new DataTable();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_17_GET_LISTA_PRODUCTO_ASOCIADOS", cnn);
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

        public DataTable SP_18_GET_DATOS_PRODUCTO(string ID_PRODUCTO)
        {
            Conectar();
            DataTable result = new DataTable();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_18_GET_DATOS_PRODUCTO", cnn);
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

        public DataTable SP_22_GET_DETALLES_CUOTA(string ID_CUOTA)
        {
            Conectar();
            DataTable result = new DataTable();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_22_GET_DETALLES_CUOTA", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_CUOTA", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ID_CUOTA"].Value = ID_CUOTA;

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

        public DataTable SP_15_GET_COMPANIAS()
        {
            Conectar();
            DataTable result = new DataTable();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_15_GET_COMPANIAS", cnn);
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

        public int SP_14_INSERTAR_PRODUCTO(LTM_PRODUCTO pro)
        {
            Conectar();
            int result;
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_14_INSERTAR_PRODUCTO", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TIPO_PRODUCTO", System.Data.SqlDbType.Int));
                command.Parameters["@TIPO_PRODUCTO"].Value = pro.TIPO_PRODUCTO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_CATEGORIA_TIPO_PRODUCTO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_CATEGORIA_TIPO_PRODUCTO"].Value = pro.ID_CATEGORIA_TIPO_PRODUCTO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ESTADO_PRODUCTO", System.Data.SqlDbType.Int));
                if (pro.ESTADO_PRODUCTO == null)
                {
                    command.Parameters["@ESTADO_PRODUCTO"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@ESTADO_PRODUCTO"].Value = pro.ESTADO_PRODUCTO;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NUMERO_POLIZA", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(pro.NUMERO_POLIZA) || string.IsNullOrWhiteSpace(pro.NUMERO_POLIZA))
                {
                    command.Parameters["@NUMERO_POLIZA"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@NUMERO_POLIZA"].Value = pro.NUMERO_POLIZA;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_INICIO", System.Data.SqlDbType.DateTime));
                command.Parameters["@FECHA_INICIO"].Value = pro.FECHA_INICIO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_CADUCIDAD", System.Data.SqlDbType.DateTime));
                command.Parameters["@FECHA_CADUCIDAD"].Value = pro.FECHA_CADUCIDAD;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_COMPANIA_SEGUROS", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ID_COMPANIA_SEGUROS"].Value = pro.ID_COMPANIA_SEGUROS;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CODIGO_INTERNO", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(pro.CODIGO_INTERNO) || string.IsNullOrWhiteSpace(pro.CODIGO_INTERNO))
                {
                    command.Parameters["@CODIGO_INTERNO"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@CODIGO_INTERNO"].Value = pro.CODIGO_INTERNO;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DATOS_AUXILIAR", System.Data.SqlDbType.Int));
                command.Parameters["@DATOS_AUXILIAR"].Value = pro.DATOS_AUXILIAR;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_CLIENTE", System.Data.SqlDbType.Int));
                command.Parameters["@ID_CLIENTE"].Value = pro.ID_CLIENTE;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VALOR_PRODUCTO", System.Data.SqlDbType.Decimal));
                command.Parameters["@VALOR_PRODUCTO"].Value = pro.VALOR_PRODUCTO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COSTO", System.Data.SqlDbType.Decimal));
                command.Parameters["@COSTO"].Value = pro.COSTO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SERVICIO_ADICIONAL", System.Data.SqlDbType.Decimal));
                if (pro.SERVICIO_ADICIONAL == null)
                {
                    command.Parameters["@SERVICIO_ADICIONAL"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@SERVICIO_ADICIONAL"].Value = pro.SERVICIO_ADICIONAL;
                }


                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CASH_OUT", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(pro.CASH_OUT) || string.IsNullOrWhiteSpace(pro.CASH_OUT))
                {
                    command.Parameters["@CASH_OUT"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@CASH_OUT"].Value = pro.CASH_OUT;
                }


                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TARJETA_CREDITO", System.Data.SqlDbType.NVarChar));
                if (pro.TARJETA_CREDITO == null)
                {
                    command.Parameters["@TARJETA_CREDITO"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@TARJETA_CREDITO"].Value = pro.TARJETA_CREDITO;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PAGO_EFECTIVO", System.Data.SqlDbType.Decimal));
                if (pro.PAGO_EFECTIVO == null)
                {
                    command.Parameters["@PAGO_EFECTIVO"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@PAGO_EFECTIVO"].Value = pro.PAGO_EFECTIVO;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RECARGO", System.Data.SqlDbType.Decimal));
                if (pro.RECARGO == null)
                {
                    command.Parameters["@RECARGO"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@RECARGO"].Value = pro.RECARGO;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TIPO_PAGO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@TIPO_PAGO"].Value = pro.TIPO_PAGO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NUMERO_CUOTAS", System.Data.SqlDbType.Int));
                if (pro.NUMERO_CUOTAS == null)
                {
                    command.Parameters["@NUMERO_CUOTAS"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@NUMERO_CUOTAS"].Value = pro.NUMERO_CUOTAS;
                }


                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_PROXIMO_PAGO", System.Data.SqlDbType.Date));
                if (pro.FECHA_PROXIMO_PAGO == null)
                {
                    command.Parameters["@FECHA_PROXIMO_PAGO"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@FECHA_PROXIMO_PAGO"].Value = pro.FECHA_PROXIMO_PAGO;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NOMBRE_EMPRESA", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(pro.NOMBRE_EMPRESA) || string.IsNullOrWhiteSpace(pro.NOMBRE_EMPRESA))
                {
                    command.Parameters["@NOMBRE_EMPRESA"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@NOMBRE_EMPRESA"].Value = pro.NOMBRE_EMPRESA;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PROSPECTO", System.Data.SqlDbType.Bit));
                if (pro.PROSPECTO == true)
                {
                    command.Parameters["@PROSPECTO"].Value = 1;
                }
                else
                {
                    command.Parameters["@PROSPECTO"].Value = 0;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OBSERVACION", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(pro.OBSERVACION) || string.IsNullOrWhiteSpace(pro.OBSERVACION))
                {
                    command.Parameters["@OBSERVACION"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@OBSERVACION"].Value = pro.OBSERVACION;
                }

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

        public int SP_19_ACTUALIZAR_PRODUCTO(LTM_PRODUCTO pro, string ID_PRODUCTO)
        {
            Conectar();
            int result;
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_19_ACTUALIZAR_PRODUCTO", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PRODUCTO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ID_PRODUCTO"].Value = ID_PRODUCTO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TIPO_PRODUCTO", System.Data.SqlDbType.Int));
                command.Parameters["@TIPO_PRODUCTO"].Value = pro.TIPO_PRODUCTO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_CATEGORIA_TIPO_PRODUCTO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_CATEGORIA_TIPO_PRODUCTO"].Value = pro.ID_CATEGORIA_TIPO_PRODUCTO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ESTADO_PRODUCTO", System.Data.SqlDbType.Int));
                if (pro.ESTADO_PRODUCTO == null)
                {
                    command.Parameters["@ESTADO_PRODUCTO"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@ESTADO_PRODUCTO"].Value = pro.ESTADO_PRODUCTO;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NUMERO_POLIZA", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(pro.NUMERO_POLIZA) || string.IsNullOrWhiteSpace(pro.NUMERO_POLIZA))
                {
                    command.Parameters["@NUMERO_POLIZA"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@NUMERO_POLIZA"].Value = pro.NUMERO_POLIZA;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_INICIO", System.Data.SqlDbType.DateTime));
                command.Parameters["@FECHA_INICIO"].Value = pro.FECHA_INICIO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_CADUCIDAD", System.Data.SqlDbType.DateTime));
                command.Parameters["@FECHA_CADUCIDAD"].Value = pro.FECHA_CADUCIDAD;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_COMPANIA_SEGUROS", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ID_COMPANIA_SEGUROS"].Value = pro.ID_COMPANIA_SEGUROS;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CODIGO_INTERNO", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(pro.CODIGO_INTERNO) || string.IsNullOrWhiteSpace(pro.CODIGO_INTERNO))
                {
                    command.Parameters["@CODIGO_INTERNO"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@CODIGO_INTERNO"].Value = pro.CODIGO_INTERNO;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DATOS_AUXILIAR", System.Data.SqlDbType.Int));
                command.Parameters["@DATOS_AUXILIAR"].Value = pro.DATOS_AUXILIAR;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_CLIENTE", System.Data.SqlDbType.Int));
                command.Parameters["@ID_CLIENTE"].Value = pro.ID_CLIENTE;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VALOR_PRODUCTO", System.Data.SqlDbType.Decimal));
                command.Parameters["@VALOR_PRODUCTO"].Value = pro.VALOR_PRODUCTO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COSTO", System.Data.SqlDbType.Decimal));
                command.Parameters["@COSTO"].Value = pro.COSTO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SERVICIO_ADICIONAL", System.Data.SqlDbType.Decimal));
                if (pro.SERVICIO_ADICIONAL == null)
                {
                    command.Parameters["@SERVICIO_ADICIONAL"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@SERVICIO_ADICIONAL"].Value = pro.SERVICIO_ADICIONAL;
                }


                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CASH_OUT", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(pro.CASH_OUT) || string.IsNullOrWhiteSpace(pro.CASH_OUT))
                {
                    command.Parameters["@CASH_OUT"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@CASH_OUT"].Value = pro.CASH_OUT;
                }


                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TARJETA_CREDITO", System.Data.SqlDbType.NVarChar));
                if (pro.TARJETA_CREDITO == null)
                {
                    command.Parameters["@TARJETA_CREDITO"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@TARJETA_CREDITO"].Value = pro.TARJETA_CREDITO;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PAGO_EFECTIVO", System.Data.SqlDbType.Decimal));
                if (pro.PAGO_EFECTIVO == null)
                {
                    command.Parameters["@PAGO_EFECTIVO"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@PAGO_EFECTIVO"].Value = pro.PAGO_EFECTIVO;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RECARGO", System.Data.SqlDbType.Decimal));
                if (pro.RECARGO == null)
                {
                    command.Parameters["@RECARGO"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@RECARGO"].Value = pro.RECARGO;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TIPO_PAGO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@TIPO_PAGO"].Value = pro.TIPO_PAGO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NUMERO_CUOTAS", System.Data.SqlDbType.Int));
                if (pro.NUMERO_CUOTAS == null)
                {
                    command.Parameters["@NUMERO_CUOTAS"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@NUMERO_CUOTAS"].Value = pro.NUMERO_CUOTAS;
                }


                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_PROXIMO_PAGO", System.Data.SqlDbType.Date));
                if (pro.FECHA_PROXIMO_PAGO == null)
                {
                    command.Parameters["@FECHA_PROXIMO_PAGO"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@FECHA_PROXIMO_PAGO"].Value = pro.FECHA_PROXIMO_PAGO;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NOMBRE_EMPRESA", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(pro.NOMBRE_EMPRESA) || string.IsNullOrWhiteSpace(pro.NOMBRE_EMPRESA))
                {
                    command.Parameters["@NOMBRE_EMPRESA"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@NOMBRE_EMPRESA"].Value = pro.NOMBRE_EMPRESA;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PROSPECTO", System.Data.SqlDbType.Bit));
                if (pro.PROSPECTO == true)
                {
                    command.Parameters["@PROSPECTO"].Value = 1;
                }
                else
                {
                    command.Parameters["@PROSPECTO"].Value = 0;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OBSERVACION", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(pro.OBSERVACION) || string.IsNullOrWhiteSpace(pro.OBSERVACION))
                {
                    command.Parameters["@OBSERVACION"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@OBSERVACION"].Value = pro.OBSERVACION;
                }

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

        public int SP_23_ACTUALIZAR_CUOTAS(string ID_PRODUCTO, string ID_PRODUCTO_ASOCIADO, string ESTADO, decimal VALOR_CUOTA, decimal VALOR_TERJETA, decimal VALOR_EFECTIVO, decimal VALOR_RECARGO, string OBSERVACION, int ID_USUARIO)
        {
            Conectar();
            int result;
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_23_ACTUALIZAR_CUOTAS", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PRODUCTO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_PRODUCTO"].Value = ID_PRODUCTO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PRODUCTO_ASOCIADO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_PRODUCTO_ASOCIADO"].Value = ID_PRODUCTO_ASOCIADO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ESTADO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ESTADO"].Value = ESTADO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VALOR_CUOTA", System.Data.SqlDbType.Decimal));
                command.Parameters["@VALOR_CUOTA"].Value = VALOR_CUOTA;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VALOR_TERJETA", System.Data.SqlDbType.Decimal));
                command.Parameters["@VALOR_TERJETA"].Value = VALOR_TERJETA;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VALOR_EFECTIVO", System.Data.SqlDbType.Decimal));
                command.Parameters["@VALOR_EFECTIVO"].Value = VALOR_EFECTIVO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VALOR_RECARGO", System.Data.SqlDbType.Decimal));
                command.Parameters["@VALOR_RECARGO"].Value = VALOR_RECARGO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OBSERVACION", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(OBSERVACION) || string.IsNullOrWhiteSpace(OBSERVACION))
                {
                    command.Parameters["@OBSERVACION"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@OBSERVACION"].Value = OBSERVACION;
                }

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
    }
}