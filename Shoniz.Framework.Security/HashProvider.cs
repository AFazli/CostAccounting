using System.Security.Cryptography;
using Shoniz.Framework.Core.Security;

namespace Shoniz.Framework.Security
{
    public class HashProvider : IHashProvider
    {
        public string Hash(string plainText, string saltedValue)
        {
            var bytePass = System.Text.Encoding.UTF8.GetBytes(plainText);
            var md5CryptoServiceProvider = new MD5CryptoServiceProvider();

            return md5CryptoServiceProvider.ComputeHash(bytePass).ToString();
        }
    }
}