using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
namespace LATINMEX.Datos.CORE
{
    public class CLS_CORE
    {
        public static string Encrypt(string plainText)
        {
            if (plainText == null)
            {
                return null;
            }
            // Get the bytes of the string
            var bytesToBeEncrypted = Encoding.UTF8.GetBytes(plainText);
            var passwordBytes = Encoding.UTF8.GetBytes(plainText);

            // Hash the password with SHA256
            passwordBytes = SHA512.Create().ComputeHash(passwordBytes);

            var bytesEncrypted = Encrypt(bytesToBeEncrypted, passwordBytes);

            return Convert.ToBase64String(bytesEncrypted);
        }

        public static string Decrypt(string encryptedText)
        {
            if (encryptedText == null)
            {
                return null;
            }
            // Get the bytes of the string
            var bytesToBeDecrypted = Convert.FromBase64String(encryptedText);
            var passwordBytes = Encoding.UTF8.GetBytes(encryptedText);

            passwordBytes = SHA512.Create().ComputeHash(passwordBytes);

            var bytesDecrypted = Decrypt(bytesToBeDecrypted, passwordBytes);

            return Encoding.UTF8.GetString(bytesDecrypted);
        }

        private static byte[] Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;
            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);

                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }

                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        private static byte[] Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;
            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);

                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);
                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }

                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }

        public class LTM_CLIENTE
        {
            public string PRIMER_NOMBRE { get; set; }
            public string SEGUNDO_NOMBRE { get; set; }
            public string APELLIDOS { get; set; }            
            public string CORREO { get; set; }
            public string TELEFONO_MOVIL { get; set; }
            public string DIRECCION_RESIDENCIA { get; set; }
            public string DIRECCION_CORRESPONDENCIA { get; set; }
            public DateTime FECHA_NACIMIENTO { get; set; }
            public string ID_CONDUCCION { get; set; }
            public string CIUDAD { get; set; }
            public string ESTADO { get; set; }
            public string CODIGO_POSTAL { get; set; }
            public string NOMBRE_EMPRESA { get; set; }
            public string VIN_1 { get; set; }
            public DateTime? FECHA_VIN_1 { get; set; }
            public string VIN_2 { get; set; }
            public DateTime? FECHA_VIN_2 { get; set; }
            public string VIN_3 { get; set; }
            public DateTime? FECHA_VIN_3 { get; set; }

            public string VIN_4 { get; set; }
            public DateTime? FECHA_VIN_4 { get; set; }

            public string VIN_5 { get; set; }
            public DateTime? FECHA_VIN_5 { get; set; }

            public int ID_USUARIO_CREACION { get; set; }
            
            public int ID_USUARIO_ACTUALIZACION { get; set; }
            public DateTime FECHA_CREACION { get; set; }
            public DateTime FECHA_ACTULIZACION { get; set; }
           
        }

        public class LTM_PRODUCTO
        {
            public int TIPO_PRODUCTO { get; set; }
            public int ID_CATEGORIA_TIPO_PRODUCTO { get; set; }
            public int? ESTADO_PRODUCTO { get; set; }
            public string NUMERO_POLIZA { get; set; }
            public DateTime FECHA_INICIO { get; set; }
            public DateTime FECHA_CADUCIDAD { get; set; }
            public string ID_COMPANIA_SEGUROS { get; set; }
            public string CODIGO_INTERNO { get; set; }
            public int DATOS_AUXILIAR { get; set; }
            public int ID_CLIENTE { get; set; }
            public decimal? VALOR_PRODUCTO { get; set; }
            public decimal? COSTO { get; set; }
            public decimal? SERVICIO_ADICIONAL { get; set; }
            public string CASH_OUT { get; set; }
            public decimal? TARJETA_CREDITO { get; set; }
            public decimal? PAGO_EFECTIVO { get; set; }
            public decimal? RECARGO { get; set; }
            public string TIPO_PAGO { get; set; }
            public int? NUMERO_CUOTAS { get; set; }
            public DateTime? FECHA_PROXIMO_PAGO { get; set; }
            public string NOMBRE_EMPRESA { get; set; }
            public bool PROSPECTO { get; set; }
            public string OBSERVACION { get; set; }
            
        }

        public class Response
        {
            public int Res { get; set; }
            public bool Succ { get; set; }
            public string Message { get; set; }
            public object Objet { get; set; }
        }
    }
}