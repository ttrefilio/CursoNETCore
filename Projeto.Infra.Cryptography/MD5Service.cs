using Projeto.Domain.Interfaces.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace Projeto.Infra.Cryptography
{
    public class MD5Service : IMD5Service
    {
        public string Encrypt(string value)
        {
            var hash = new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(value));

            //var result = string.Empty;
            var result = new StringBuilder();

            foreach (var item in hash)
            {
                //result += item.ToString("x2");
                result.Append(item.ToString("x2"));
            }
            //return result;
            return result.ToString();
        }
    }
}
