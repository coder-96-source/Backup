using System.Threading.Tasks;

namespace DotNetSurfer.DAL.CDNs.Interfaces
{
    public interface ICdnHandler
    {
        Task<string> GetImageStorageBaseUrl();
        Task<bool> UpsertImageToStorageAsync(byte[] binaryFile, string storedUrl);
        Task<bool> DeleteImageFromStorageAsync(string fileName);
    }
}
