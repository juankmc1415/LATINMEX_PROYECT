using LATINMEX.MODELVIEW;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LATINMEX.Datos.CORE
{
    public class CLS_USUARIOS:Conexion
    {
        int _commandTimeout = 600;

        public List<UsuariosView> SP_62_CONSULTAR_USUARIOS()
        {
            Conectar();
            _commandTimeout = 600;

            DataTable result = new DataTable();
            List<UsuariosView> listaUsuarios = new List<UsuariosView>();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_62_CONSULTAR_USUARIOS", cnn);
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

            if (result!=null)
            {
                if (result != null && result.Rows.Count > 0)
                {
                   listaUsuarios = result.AsEnumerable().Select(x => new UsuariosView
                    {
                        IdUsuario  = x.Field<int>("ID_USUARIO"),
                        Usuario = x.Field<string>("USUARIO"),
                        Clave = x.Field<string>("CLAVE"),
                        Nombres = x.Field<string>("NOMBRES"),
                        Apellidos= x.Field<string>("APELLIDOS"),
                        Email = x.Field<string>("EMAIL"),
                        ForzarContraseña= x.Field<bool>("FORZAR_CAMBIO"),
                        Foto = x.Field<byte[]>("FOTO"),
                        IdEstado = x.Field<int>("ID_ESTADO"),
                        Roles = x.Field<string>("ROLES"),
                        IdUsuarioCreacion= x.Field<int>("ID_USUARIO_CREACION"),
                        IdUsuarioActualizacion = x.Field<int>("ID_USUARIO_ACTUALIZACION"),
                        FechaHoraCreacion = x.Field<DateTime>("FECHA_HORA_CREACION"),
                        FechaHoraActualizacion = x.Field<DateTime>("FECHA_HORA_ACTUALIZACION")
                    }).ToList();
                }
           }

            return listaUsuarios;
        }

    

        public UsuariosView SP_69_GET_USUARIO(int ID_USUARIO)
        {
            Conectar();
            _commandTimeout = 600;

            DataTable result = new DataTable();
            UsuariosView usuario = new UsuariosView();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_69_GET_USUARIO", cnn);
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

            if (result != null)
            {
                if (result != null && result.Rows.Count > 0)
                {
                    DataRow user = result.Rows[0];

                    usuario.IdUsuario = user.Field<int>("ID_USUARIO");
                    usuario.Usuario = user.Field<string>("USUARIO");
                    usuario.Clave = user.Field<string>("CLAVE");
                    usuario.Nombres = user.Field<string>("NOMBRES");
                    usuario.Apellidos = user.Field<string>("APELLIDOS");
                    usuario.Email = user.Field<string>("EMAIL");
                    usuario.ForzarContraseña = user.Field<bool>("FORZAR_CAMBIO");
                    usuario.Foto = user.Field<byte[]>("FOTO");
                    usuario.IdEstado = user.Field<int>("ID_ESTADO");
                    usuario.IdUsuarioCreacion = user.Field<int>("ID_USUARIO_CREACION");
                    usuario.IdUsuarioActualizacion = user.Field<int>("ID_USUARIO_ACTUALIZACION");
                    usuario.FechaHoraCreacion = user.Field<DateTime>("FECHA_HORA_CREACION");
                    usuario.FechaHoraActualizacion = user.Field<DateTime>("FECHA_HORA_ACTUALIZACION");

                }
                else
                    usuario = null;
            }

            return usuario;
        }

        public UsuariosView SP_04_GET_DATOS_USUARIO_EMAIL(string EMAIL)
        {
            Conectar();
            _commandTimeout = 600;

            DataTable result = new DataTable();
            UsuariosView usuario = new UsuariosView();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_04_GET_DATOS_USUARIO_EMAIL", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EMAIL", System.Data.SqlDbType.NVarChar));
                command.Parameters["@EMAIL"].Value = EMAIL;

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

            if (result != null)
            {
                if (result != null && result.Rows.Count > 0)
                {
                    DataRow user = result.Rows[0];

                    usuario.IdUsuario = user.Field<int>("ID_USUARIO");
                    usuario.Usuario = user.Field<string>("USUARIO");
                    usuario.Clave = user.Field<string>("CLAVE");
                    usuario.Nombres = user.Field<string>("NOMBRES");
                    usuario.Apellidos = user.Field<string>("APELLIDOS");
                    usuario.Email = user.Field<string>("EMAIL");
                    usuario.ForzarContraseña = user.Field<bool>("FORZAR_CAMBIO");
                   
                    usuario.IdEstado = user.Field<int>("ID_ESTADO");
                    usuario.IdUsuarioCreacion = user.Field<int>("ID_USUARIO_CREACION");
                    usuario.IdUsuarioActualizacion = user.Field<int>("ID_USUARIO_ACTUALIZACION");
                    usuario.FechaHoraCreacion = user.Field<DateTime>("FECHA_HORA_CREACION");
                    usuario.FechaHoraActualizacion = user.Field<DateTime>("FECHA_HORA_ACTUALIZACION");

                }
                else
                    usuario = null;
            }

            return usuario;
        }


        public DataTable SP_71_CONSULTAR_AUDITORIA(int ID_USUARIO)
        {
            Conectar();
            _commandTimeout = 600;

            DataTable result = new DataTable();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_71_CONSULTAR_AUDITORIA", cnn);
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

        public int SP_72_FORZAR_CAMBIO_CONTRASEÑA(int ID_USUARIO, bool FORZAR)
        {
            Conectar();
            int result;
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_72_FORZAR_CAMBIO_CONTRASEÑA", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_USUARIO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_USUARIO"].Value = ID_USUARIO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FORZAR_CAMBIO", System.Data.SqlDbType.Bit));
                command.Parameters["@FORZAR_CAMBIO"].Value = FORZAR;

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

        public int SP_74_CAMBIAR_CLAVE(int ID_USUARIO, string CLAVE)
        {
            Conectar();
            int result;
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_74_CAMBIAR_CLAVE", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_USUARIO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_USUARIO"].Value = ID_USUARIO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CLAVE", System.Data.SqlDbType.NVarChar));
                command.Parameters["@CLAVE"].Value = CLAVE;

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

        public int SP_73_CAMBIAR_ESTADO_USUARIO(int ID_USUARIO, int ID_ESTADO)
        {
            Conectar();
            int result;
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_73_CAMBIAR_ESTADO_USUARIO", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_USUARIO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_USUARIO"].Value = ID_USUARIO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_ESTADO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_ESTADO"].Value = ID_ESTADO;

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


        public DataTable SP_63_CREAR_USUARIO(string USUARIO, string CLAVE, string NOMBRE, string APELLIDO, 
                                        string EMAIL, int ID_ESTADO, int ID_USUARIO_CREACION, string ROlES)
        {
            Conectar();
            DataTable result = new DataTable();

            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_63_CREAR_USUARIO", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USUARIO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@USUARIO"].Value = USUARIO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CLAVE", System.Data.SqlDbType.NVarChar));
                command.Parameters["@CLAVE"].Value = CLAVE;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NOMBRE", System.Data.SqlDbType.NVarChar));
                command.Parameters["@NOMBRE"].Value = NOMBRE;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@APELLIDO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@APELLIDO"].Value = APELLIDO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EMAIL", System.Data.SqlDbType.NVarChar));
                command.Parameters["@EMAIL"].Value = EMAIL;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FORZAR_CAMBIO", System.Data.SqlDbType.Bit));
                command.Parameters["@FORZAR_CAMBIO"].Value = 1;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_ESTADO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_ESTADO"].Value = ID_ESTADO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_ARCHIVOFOTO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_ARCHIVOFOTO"].Value = DBNull.Value;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_USUARIO_CREACION", System.Data.SqlDbType.Int));
                command.Parameters["@ID_USUARIO_CREACION"].Value = ID_USUARIO_CREACION;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_USUARIO_ACTUALIZACION", System.Data.SqlDbType.Int));
                command.Parameters["@ID_USUARIO_ACTUALIZACION"].Value = ID_USUARIO_CREACION;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_HORA_CREACION", System.Data.SqlDbType.DateTime));
                command.Parameters["@FECHA_HORA_CREACION"].Value = DateTime.Now;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_HORA_ACTUALIZACION", System.Data.SqlDbType.DateTime));
                command.Parameters["@FECHA_HORA_ACTUALIZACION"].Value = DateTime.Now;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ROLES", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ROLES"].Value = ROlES;

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


        public int SP_64_ACTUALIZAR_USUARIO(int ID_USUARIO, string NOMBRE, string APELLIDOS, string EMAIL, int ID_ESTADO, int ID_USUARIO_ACTUALIZACION,string ROLES)
        {
            Conectar();
            int result;
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_64_ACTUALIZAR_USUARIO", cnn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = _commandTimeout;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_USUARIO", System.Data.SqlDbType.Int));
                command.Parameters["@ID_USUARIO"].Value = ID_USUARIO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NOMBRE", System.Data.SqlDbType.NVarChar));
                command.Parameters["@NOMBRE"].Value = NOMBRE;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EMAIL", System.Data.SqlDbType.NVarChar));
                command.Parameters["@EMAIL"].Value = EMAIL;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@APELLIDO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@APELLIDO"].Value = APELLIDOS;


                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_ESTADO", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ID_ESTADO"].Value = ID_ESTADO;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_USUARIO_ACTUALIZACION", System.Data.SqlDbType.Int));
                command.Parameters["@ID_USUARIO_ACTUALIZACION"].Value = ID_USUARIO_ACTUALIZACION;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FECHA_HORA_ACTUALIZACION", System.Data.SqlDbType.DateTime));
                command.Parameters["@FECHA_HORA_ACTUALIZACION"].Value = DateTime.Now;

                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ROLES", System.Data.SqlDbType.NVarChar));
                command.Parameters["@ROLES"].Value = ROLES;

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

        public DataTable SP_66_CONSULTAR_ROLES_USUARIOS(int ID_USUARIO)
        {
            Conectar();
            DataTable result = new DataTable();
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("SP_66_CONSULTAR_ROLES_USUARIOS", cnn);
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

    }
}