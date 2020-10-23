﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LATINMEX.Datos.MASTER
{
    public class CLS_MASTER : Conexion
    {
        int _commandTimeout = 600;

        public int SP_20_INSERTAR_GASTO(string ID_TIPO_GASTO, string ID_TIPO_PAGO,  decimal VALOR, string DESCRIPCION, int? ID_ARCHIVO, DateTime FECHA_PAGO, DateTime FECHA_REGISTRO, string OBSERVACION, int ID_USUARIO)
        {
            Conectar();
            int result;
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_20_INSERTAR_GASTO", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_TIPO_GASTO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_TIPO_GASTO"].Value = ID_TIPO_GASTO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_TIPO_PAGO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_TIPO_PAGO"].Value = ID_TIPO_PAGO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VALOR", System.Data.SqlDbType.Decimal));
                command.Parameters["@VALOR"].Value = VALOR;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DESCRIPCION", System.Data.SqlDbType.NVarChar));
                command.Parameters["@DESCRIPCION"].Value = DESCRIPCION;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_ARCHIVO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_ARCHIVO"].Value = DBNull.Value; ;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_PAGO", System.Data.SqlDbType.Date));
                command.Parameters["@FECHA_PAGO"].Value = FECHA_PAGO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_REGISTRO", System.Data.SqlDbType.Date));
                command.Parameters["@FECHA_REGISTRO"].Value = FECHA_REGISTRO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OBSERVACION", System.Data.SqlDbType.NVarChar));
                
                command.Parameters["@OBSERVACION"].Value = OBSERVACION;

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
        }// fin SP_08_NUEVA_NOTA


    }
}