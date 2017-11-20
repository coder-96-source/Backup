using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArticles.HtmlHelpers.Encrypt
{
    public interface IEncryptable
    {
        bool IsEqual(string str, string encryptedStr);
        string Encrypt(string str);
    }
}
