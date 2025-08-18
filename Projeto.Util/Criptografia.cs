using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace Projeto.Util
{
    /// <summary>
    /// Classe para geração de criptografia
    /// </summary>
    public class Criptografia
    {
        //MD5 (hash) -> Message Digest 5 (128bits)
        public static string GetMD5Hash(string Param)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            //criptografando o parametro recebido no metodo...
            //para tal, precisamos converter o parametro de string para byte
            //a saida do método ComputeHash retorna um vetor de byte -> byte[]
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(Param));

            //converter o valor de byte[] para string...
            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }
    }
}
