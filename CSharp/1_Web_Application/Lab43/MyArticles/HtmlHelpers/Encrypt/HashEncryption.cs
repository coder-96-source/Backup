using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MyArticles.HtmlHelpers.Encrypt
{
    public class HashEncryption : IEncryptable
    {
        public bool IsEqual(string str, string pwd)
        {
            return Encrypt(str) == pwd;
        }
        public string Encrypt(string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            var sha1 = SHA1.Create();
            byte[] hash = sha1.ComputeHash(bytes);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}