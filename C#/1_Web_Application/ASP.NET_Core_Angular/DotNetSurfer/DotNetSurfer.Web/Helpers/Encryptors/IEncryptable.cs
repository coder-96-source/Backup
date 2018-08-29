namespace DotNetSurfer.Web.Helpers.Encryptors
{
    interface IEncryptable
    {
        bool IsEqual(string str, string encryptedStr);
        string Encrypt(string str);
    }
}
