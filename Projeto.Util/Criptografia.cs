using System;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;
namespace Projeto.Util
{
    /// <summary>
    /// Classe para geração de criptografia
    /// </summary>
    public class Criptografia
    {
        public static string GetMD5Hash(string Param)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(Param));
            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }

        private static readonly string chaveSecreta = ConfigurationManager.AppSettings["ChaveSecretaAES"];

        public static string Criptografar(string texto)
        {
            byte[] key = Encoding.UTF8.GetBytes(chaveSecreta.PadRight(32).Substring(0, 32));
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform encryptor = aes.CreateEncryptor();
                byte[] buffer = Encoding.UTF8.GetBytes(texto);
                return Convert.ToBase64String(encryptor.TransformFinalBlock(buffer, 0, buffer.Length));
            }
        }

        public static string Descriptografar(string textoCriptografado)
        {
            byte[] key = Encoding.UTF8.GetBytes(chaveSecreta.PadRight(32).Substring(0, 32));
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform decryptor = aes.CreateDecryptor();
                byte[] buffer = Convert.FromBase64String(textoCriptografado);
                return Encoding.UTF8.GetString(decryptor.TransformFinalBlock(buffer, 0, buffer.Length));
            }
        }
    }
}
