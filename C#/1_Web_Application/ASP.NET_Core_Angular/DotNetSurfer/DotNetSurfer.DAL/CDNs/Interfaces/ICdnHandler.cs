using System;
using System.Threading.Tasks;

namespace DotNetSurfer.DAL.CDNs.Interfaces
{
    public interface ICdnHandler
    {
        Task<Uri> UploadImageToStorageAsync(byte[] binaryFile, string fileName);
        Task<bool> DeleteImageFromStorageAsync(string fileName);
    }
}
