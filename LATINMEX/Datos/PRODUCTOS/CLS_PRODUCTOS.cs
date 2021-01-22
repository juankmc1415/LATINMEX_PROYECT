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

        public DataTable SP_36_GET_LISTA_COUTAS_DMV(string ID_PRODUCTO)
        {
            Conectar();
            DataTable result = new DataTable();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_36_GET_LISTA_COUTAS_DMV", cnn);
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

        public DataTable SP_34_GET_LISTA_ENDOSOS(string ID_PRODUCTO)
        {
            Conectar();
            DataTable result = new DataTable();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_34_GET_LISTA_ENDOSOS", cnn);
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

        public DataTable SP_18_GET_DATOS_PRODUCTO_ENDOSO(string ID_PRODUCTO)
        {
            Conectar();
            DataTable result = new DataTable();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_18_GET_DATOS_PRODUCTO_ENDOSO", cnn);
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

        public DataTable SP_38_GET_DETALLES_COUTAS_DMV(string @ID_CUOTA_DMV)
        {
            Conectar();
            DataTable result = new DataTable();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_38_GET_DETALLES_COUTAS_DMV", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_CUOTA_DMV", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ID_CUOTA_DMV"].Value = @ID_CUOTA_DMV;

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

        public DataTable SP_15_GET_COMPANIAS(int ID_TIPO_PRODUCTO)
        {
            Conectar();
            DataTable result = new DataTable();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_15_GET_COMPANIAS", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_TIPO_PRODUCTO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_TIPO_PRODUCTO"].Value = ID_TIPO_PRODUCTO;

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

        public DataTable SP_14_INSERTAR_PRODUCTO(LTM_PRODUCTO pro)
        {
            Conectar();
            DataTable result = new DataTable();
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

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@INTSALLMENTFEE", System.Data.SqlDbType.Decimal));
                if (pro.INTSALLMENTFEE == null)
                {
                    command.Parameters["@INTSALLMENTFEE"].Value = "0";
                }
                else
                {
                    command.Parameters["@INTSALLMENTFEE"].Value = pro.INTSALLMENTFEE;
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

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_RETIRO", System.Data.SqlDbType.Date));
                if (pro.FECHA_RETIRO == null)
                {
                    command.Parameters["@FECHA_RETIRO"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@FECHA_RETIRO"].Value = pro.FECHA_RETIRO;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RESERVA", System.Data.SqlDbType.Decimal));
                if (pro.RESERVA == null)
                {
                    command.Parameters["@RESERVA"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@RESERVA"].Value = pro.RESERVA;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VALOR_TRAMITE", System.Data.SqlDbType.Decimal));
                if (pro.VALOR_TRAMITE == null)
                {
                    command.Parameters["@VALOR_TRAMITE"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@VALOR_TRAMITE"].Value = pro.VALOR_TRAMITE;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COSTO_TERCEROS", System.Data.SqlDbType.Decimal));
                if (pro.COSTO_TERCEROS == null)
                {
                    command.Parameters["@COSTO_TERCEROS"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@COSTO_TERCEROS"].Value = pro.COSTO_TERCEROS;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VALOR_SERVICIO", System.Data.SqlDbType.Decimal));
                if (pro.VALOR_SERVICIO == null)
                {
                    command.Parameters["@VALOR_SERVICIO"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@VALOR_SERVICIO"].Value = pro.VALOR_SERVICIO;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VALOR_TOTAL", System.Data.SqlDbType.Decimal));
                if (pro.VALOR_TOTAL == null)
                {
                    command.Parameters["@VALOR_TOTAL"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@VALOR_TOTAL"].Value = pro.VALOR_TOTAL;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EXCEDENTE_IMPUESTO", System.Data.SqlDbType.Decimal));
                if (pro.EXCEDENTE_IMPUESTO == null)
                {
                    command.Parameters["@EXCEDENTE_IMPUESTO"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@EXCEDENTE_IMPUESTO"].Value = pro.EXCEDENTE_IMPUESTO;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EXCEDENTE_TRAMITE", System.Data.SqlDbType.Decimal));
                if (pro.EXCEDENTE_TRAMITE == null)
                {
                    command.Parameters["@EXCEDENTE_TRAMITE"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@EXCEDENTE_TRAMITE"].Value = pro.EXCEDENTE_TRAMITE;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TOTAL_COBRAR", System.Data.SqlDbType.Decimal));
                if (pro.TOTAL_COBRAR == null)
                {
                    command.Parameters["@TOTAL_COBRAR"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@TOTAL_COBRAR"].Value = pro.TOTAL_COBRAR;
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


                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PAGO_COMPANIA", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(pro.PAGO_COMPANIA) || string.IsNullOrWhiteSpace(pro.PAGO_COMPANIA))
                {
                    command.Parameters["@PAGO_COMPANIA"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@PAGO_COMPANIA"].Value = pro.PAGO_COMPANIA;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VALOR_COMPANIA", System.Data.SqlDbType.Decimal));
                if (pro.VALOR_COMPANIA == null)
                {
                    command.Parameters["@VALOR_COMPANIA"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@VALOR_COMPANIA"].Value = pro.VALOR_COMPANIA;
                }
                //result = command.ExecuteNonQuery();
                //command.Dispose();

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
        }

        public DataTable SP_29_GUARDAR_ARCHIVOS(object DATA_ARCHIVO, string NOMBRE_ARCHIVO, string TIPO_ARCHIVO)
        {
            Conectar();
            DataTable result = new DataTable();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_29_GUARDAR_ARCHIVOS", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DATA_ARCHIVO", System.Data.SqlDbType.VarBinary));
                command.Parameters["@DATA_ARCHIVO"].Value = DATA_ARCHIVO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NOMBRE_ARCHIVO", SqlDbType.NVarChar));
                command.Parameters["@NOMBRE_ARCHIVO"].Value = NOMBRE_ARCHIVO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TIPO_ARCHIVO", SqlDbType.NVarChar));
                command.Parameters["@TIPO_ARCHIVO"].Value = TIPO_ARCHIVO;

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
        }

        public int SP_30_GUARDAR_FORMULARIO_ARCHIVOS(string ID_ARCHIVO, string ID_CLIENTE, string ID_PRODUCTO, string TIPO)
        {
            Conectar();
            int result;
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_30_GUARDAR_FORMULARIO_ARCHIVOS", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_ARCHIVO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ID_ARCHIVO"].Value = ID_ARCHIVO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_CLIENTE", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ID_CLIENTE"].Value = ID_CLIENTE;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PRODUCTO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ID_PRODUCTO"].Value = ID_PRODUCTO;

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

        public DataTable SP_31_GET_ARCHIVOS_CLIENTE(string ID_CLIENTE, string ID_PRODUCTO, string TIPO)
        {
            Conectar();
            DataTable result = new DataTable();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_31_GET_ARCHIVOS_CLIENTE", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_CLIENTE", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ID_CLIENTE"].Value = ID_CLIENTE;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PRODUCTO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ID_PRODUCTO"].Value = ID_PRODUCTO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TIPO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@TIPO"].Value = TIPO;

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

        public DataSet SP_32_GET_ARCHIVO(Int32 ID_ARCHIVO)
        {
            Conectar();
            DataSet result = new DataSet();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_32_GET_ARCHIVO", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_ARCHIVO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ID_ARCHIVO"].Value = ID_ARCHIVO;

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

        public int SP_19_ACTUALIZAR_PRODUCTO(LTM_PRODUCTO pro, string ID_PRODUCTO, string ESTADO_ENDOSO, string ESTADO_RENOVADO)
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

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@INTSALLMENTFEE", System.Data.SqlDbType.Decimal));
                if (pro.INTSALLMENTFEE == null)
                {
                    command.Parameters["@INTSALLMENTFEE"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@INTSALLMENTFEE"].Value = pro.INTSALLMENTFEE;
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


                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_RETIRO", System.Data.SqlDbType.Date));
                if (pro.FECHA_RETIRO == null)
                {
                    command.Parameters["@FECHA_RETIRO"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@FECHA_RETIRO"].Value = pro.FECHA_RETIRO;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RESERVA", System.Data.SqlDbType.Decimal));
                if (pro.RESERVA == null)
                {
                    command.Parameters["@RESERVA"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@RESERVA"].Value = pro.RESERVA;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VALOR_TRAMITE", System.Data.SqlDbType.Decimal));
                if (pro.VALOR_TRAMITE == null)
                {
                    command.Parameters["@VALOR_TRAMITE"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@VALOR_TRAMITE"].Value = pro.VALOR_TRAMITE;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COSTO_TERCEROS", System.Data.SqlDbType.Decimal));
                if (pro.COSTO_TERCEROS == null)
                {
                    command.Parameters["@COSTO_TERCEROS"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@COSTO_TERCEROS"].Value = pro.COSTO_TERCEROS;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VALOR_SERVICIO", System.Data.SqlDbType.Decimal));
                if (pro.VALOR_SERVICIO == null)
                {
                    command.Parameters["@VALOR_SERVICIO"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@VALOR_SERVICIO"].Value = pro.VALOR_SERVICIO;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VALOR_TOTAL", System.Data.SqlDbType.Decimal));
                if (pro.VALOR_TOTAL == null)
                {
                    command.Parameters["@VALOR_TOTAL"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@VALOR_TOTAL"].Value = pro.VALOR_TOTAL;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EXCEDENTE_IMPUESTO", System.Data.SqlDbType.Decimal));
                if (pro.EXCEDENTE_IMPUESTO == null)
                {
                    command.Parameters["@EXCEDENTE_IMPUESTO"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@EXCEDENTE_IMPUESTO"].Value = pro.EXCEDENTE_IMPUESTO;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EXCEDENTE_TRAMITE", System.Data.SqlDbType.Decimal));
                if (pro.EXCEDENTE_TRAMITE == null)
                {
                    command.Parameters["@EXCEDENTE_TRAMITE"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@EXCEDENTE_TRAMITE"].Value = pro.EXCEDENTE_TRAMITE;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TOTAL_COBRAR", System.Data.SqlDbType.Decimal));
                if (pro.TOTAL_COBRAR == null)
                {
                    command.Parameters["@TOTAL_COBRAR"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@TOTAL_COBRAR"].Value = pro.TOTAL_COBRAR;
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

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ESTADO_INTERNO", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(pro.ESTADO_INTERNO) || string.IsNullOrWhiteSpace(pro.ESTADO_INTERNO))
                {
                    command.Parameters["@ESTADO_INTERNO"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@ESTADO_INTERNO"].Value = pro.ESTADO_INTERNO;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VALOR_COMPANIA", System.Data.SqlDbType.Decimal));
                if (pro.VALOR_COMPANIA == null)
                {
                    command.Parameters["@VALOR_COMPANIA"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@VALOR_COMPANIA"].Value = pro.VALOR_COMPANIA;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ESTADO_ENDOSO", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(ESTADO_ENDOSO) || string.IsNullOrWhiteSpace(ESTADO_ENDOSO))
                {
                    command.Parameters["@ESTADO_ENDOSO"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@ESTADO_ENDOSO"].Value = ESTADO_ENDOSO;
                }

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ESTADO_RENOVADO", System.Data.SqlDbType.NVarChar));
                if (string.IsNullOrEmpty(ESTADO_RENOVADO) || string.IsNullOrWhiteSpace(ESTADO_RENOVADO))
                {
                    command.Parameters["@ESTADO_RENOVADO"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@ESTADO_RENOVADO"].Value = ESTADO_RENOVADO;
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

        public int SP_23_ACTUALIZAR_CUOTAS(string ID_PRODUCTO, string ID_PRODUCTO_ASOCIADO, string ESTADO, decimal VALOR_CUOTA, decimal VALOR_TERJETA, decimal VALOR_EFECTIVO, decimal VALOR_RECARGO, string OBSERVACION, int ID_USUARIO, int PAGO_INFERIOR, decimal COSTO_ADICIONAL, string PAGO_COMPANIA, decimal VALOR_COMPANIA, decimal VALORE_REINSTALACION, decimal VALORE_CUOTA_COMPANIA)
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
                if (string.IsNullOrEmpty(ESTADO) || string.IsNullOrWhiteSpace(ESTADO))
                {
                    command.Parameters["@ESTADO"].Value = DBNull.Value;
                }
                else
                {
                    command.Parameters["@ESTADO"].Value = ESTADO;
                }


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

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PAGO_INFERIOR", System.Data.SqlDbType.Int));
                command.Parameters["@PAGO_INFERIOR"].Value = PAGO_INFERIOR;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COSTO_ADICIONAL", System.Data.SqlDbType.Decimal));
                command.Parameters["@COSTO_ADICIONAL"].Value = COSTO_ADICIONAL;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PAGO_COMPANIA", System.Data.SqlDbType.NVarChar));
                command.Parameters["@PAGO_COMPANIA"].Value = PAGO_COMPANIA;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VALOR_COMPANIA", System.Data.SqlDbType.Decimal));
                command.Parameters["@VALOR_COMPANIA"].Value = VALOR_COMPANIA;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VALORE_REINSTALACION", System.Data.SqlDbType.Decimal));
                command.Parameters["@VALORE_REINSTALACION"].Value = VALORE_REINSTALACION;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VALORE_RECARGO_COMPANIA", System.Data.SqlDbType.Decimal));
                command.Parameters["@VALORE_RECARGO_COMPANIA"].Value = VALORE_CUOTA_COMPANIA;

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

        public int SP_37_ACTUALIZAR_CUOTA_DMV(string @ID_CUOTA_DMV, string ID_PRODUCTO, decimal VALOR_IMPUESTO, decimal EXCEDENTE_IMPUESTO, decimal VALOR_PAGO_TARJETA, decimal VALOR_RECARGO, decimal VALOR_PAGO_EFECTIVO, decimal VALOR_SERVICIO, decimal EXCEDENTE_TRAMITE, decimal TOTAL_COBRAR, string ESTADO, decimal CASH_OUT, DateTime FECHA, string TIPO_PAGO, int ID_USUARIO, string OBSERVACION)
        {
            Conectar();
            int result;
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_37_ACTUALIZAR_CUOTA_DMV", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_CUOTA_DMV", System.Data.SqlDbType.Int));
                command.Parameters["@ID_CUOTA_DMV"].Value = ID_CUOTA_DMV;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PRODUCTO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_PRODUCTO"].Value = @ID_PRODUCTO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VALOR_IMPUESTO", System.Data.SqlDbType.Decimal));
                command.Parameters["@VALOR_IMPUESTO"].Value = VALOR_IMPUESTO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EXCEDENTE_IMPUESTO", System.Data.SqlDbType.Decimal));
                command.Parameters["@EXCEDENTE_IMPUESTO"].Value = EXCEDENTE_IMPUESTO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VALOR_PAGO_TARJETA", System.Data.SqlDbType.Decimal));
                command.Parameters["@VALOR_PAGO_TARJETA"].Value = VALOR_PAGO_TARJETA;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VALOR_RECARGO", System.Data.SqlDbType.Decimal));
                command.Parameters["@VALOR_RECARGO"].Value = VALOR_RECARGO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VALOR_PAGO_EFECTIVO", System.Data.SqlDbType.Decimal));
                command.Parameters["@VALOR_PAGO_EFECTIVO"].Value = VALOR_PAGO_EFECTIVO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VALOR_SERVICIO", System.Data.SqlDbType.Decimal));
                command.Parameters["@VALOR_SERVICIO"].Value = VALOR_SERVICIO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EXCEDENTE_TRAMITE", System.Data.SqlDbType.Decimal));
                command.Parameters["@EXCEDENTE_TRAMITE"].Value = EXCEDENTE_TRAMITE;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TOTAL_COBRAR", System.Data.SqlDbType.Decimal));
                command.Parameters["@TOTAL_COBRAR"].Value = TOTAL_COBRAR;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ESTADO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ESTADO"].Value = ESTADO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CASH_OUT", System.Data.SqlDbType.Decimal));
                command.Parameters["@CASH_OUT"].Value = CASH_OUT;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA", System.Data.SqlDbType.DateTime));
                command.Parameters["@FECHA"].Value = FECHA;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TIPO_PAGO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@TIPO_PAGO"].Value = TIPO_PAGO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_USUARIO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ID_USUARIO"].Value = ID_USUARIO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OBSERVACION", System.Data.SqlDbType.NVarChar));
                command.Parameters["@OBSERVACION"].Value = OBSERVACION;

                //command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OBSERVACION", System.Data.SqlDbType.NVarChar));
                //if (string.IsNullOrEmpty(OBSERVACION) || string.IsNullOrWhiteSpace(OBSERVACION))
                //{
                //    command.Parameters["@OBSERVACION"].Value = DBNull.Value;
                //}
                //else
                //{
                //    command.Parameters["@OBSERVACION"].Value = OBSERVACION;
                //}

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


        public int SP_33_INSERTAR_ENDOSO(int ID_PRODUCTO, int ESTADO_PRODUCTO, int ID_USUARIO, int ESTADO_ENDOSO)
        {
            Conectar();
            int result;
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_33_INSERTAR_ENDOSO", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PRODUCTO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_PRODUCTO"].Value = ID_PRODUCTO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ESTADO_PRODUCTO", System.Data.SqlDbType.Int));
                command.Parameters["@ESTADO_PRODUCTO"].Value = ESTADO_PRODUCTO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_USUARIO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_USUARIO"].Value = ID_USUARIO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ESTADO_ENDOSO", System.Data.SqlDbType.Int));
                command.Parameters["@ESTADO_ENDOSO"].Value = ESTADO_ENDOSO;

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

        public DataTable SP_35_INSERTAR_REINSTALCION(int ID_PRODUCTO, int ESTADO_PRODUCTO, int ID_USUARIO)
        {
            Conectar();
            DataTable result = new DataTable();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_35_INSERTAR_REINSTALCION", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PRODUCTO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_PRODUCTO"].Value = ID_PRODUCTO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ESTADO_PRODUCTO", System.Data.SqlDbType.Int));
                command.Parameters["@ESTADO_PRODUCTO"].Value = ESTADO_PRODUCTO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_USUARIO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_USUARIO"].Value = ID_USUARIO;

                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(command);
                da.Fill(result);

                command.Dispose();

                //result = command.ExecuteNonQuery();
                //command.Dispose();

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