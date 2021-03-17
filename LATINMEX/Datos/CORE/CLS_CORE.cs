using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
namespace LATINMEX.Datos.CORE
{
    public class CLS_CORE
    {
        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "0x86Bd77318bA4524F8Ad22A1E2897A27A53a99561";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "0x86Bd77318bA4524F8Ad22A1E2897A27A53a99561";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }


        //public static string Encrypt(string plainText)
        //{
        //    if (plainText == null)
        //    {
        //        return null;
        //    }
        //    // Get the bytes of the string
        //    var bytesToBeEncrypted = Encoding.UTF8.GetBytes(plainText);
        //    var passwordBytes = Encoding.UTF8.GetBytes(plainText);

        //    // Hash the password with SHA256
        //    passwordBytes = SHA512.Create().ComputeHash(passwordBytes);

        //    var bytesEncrypted = Encrypt(bytesToBeEncrypted, passwordBytes);

        //    return Convert.ToBase64String(bytesEncrypted);
        //}

        //public static string Decrypt(string encryptedText)
        //{
        //    if (encryptedText == null)
        //    {
        //        return null;
        //    }
        //    // Get the bytes of the string
        //    var bytesToBeDecrypted = Convert.FromBase64String(encryptedText);
        //    var passwordBytes = Encoding.UTF8.GetBytes(encryptedText);

        //    passwordBytes = SHA512.Create().ComputeHash(passwordBytes);

        //    var bytesDecrypted = Decrypt(bytesToBeDecrypted, passwordBytes);

        //    return Encoding.UTF8.GetString(bytesDecrypted);
        //}

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

        public static string GenerarCodigo(int codeLength)
        {
            string result = "";
            // Nuestro patrón de caracteres para formar el código
            string pattern = "+-_#!?0123456789abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
            // Creamos una instancia del generador de números aleatorios
            // cogemos como semilla los Ticks de reloj de esta forma nos 
            // aseguramos de no generar códigos con la misma semilla.
            Random myRndGenerator = new Random((int)DateTime.Now.Ticks);
            // Procedemos a conformar el código
            for (int i = 0; i < codeLength; i++)
            {
                // Obtenemos un número aleatorio que se corresponde con una
                // posición dentro del pattern.
                int mIndex = myRndGenerator.Next(pattern.Length);
                // Vamos formando el código
                result += pattern[mIndex];
            }

            return result;
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
            public DateTime? FECHA_NACIMIENTO { get; set; }
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
            public decimal? INTSALLMENTFEE { get; set; }
            public string NOMBRE_EMPRESA { get; set; }
            public bool PROSPECTO { get; set; }

            public DateTime? FECHA_RETIRO { get; set; }
            public decimal? RESERVA { get; set; }
            public decimal? VALOR_TRAMITE { get; set; }
            public decimal? COSTO_TERCEROS { get; set; }
            public decimal? VALOR_SERVICIO { get; set; }
            public decimal? VALOR_TOTAL { get; set; }
            public decimal? EXCEDENTE_IMPUESTO { get; set; }
            public decimal? EXCEDENTE_TRAMITE { get; set; }
            public decimal? TOTAL_COBRAR { get; set; }
            public string OBSERVACION { get; set; }
            public string ESTADO_INTERNO { get; set; }

            public string PAGO_COMPANIA { get; set; }
            public decimal? VALOR_COMPANIA { get; set; }

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