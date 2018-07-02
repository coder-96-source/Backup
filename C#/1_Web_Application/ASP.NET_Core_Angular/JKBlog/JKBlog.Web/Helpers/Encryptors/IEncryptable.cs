using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JKBlog.Helpers.Encryptors
{
    interface IEncryptable
    {
        bool IsEqual(string str, string encryptedStr);
        string Encrypt(string str);
    }
}
