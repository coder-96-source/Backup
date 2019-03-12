using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Threading.Tasks;

namespace DotNetSurfer.DAL.CDNs.Interfaces
{
    public class AzureBlobHandler : ICdnHandler
    {
        // Azure blob only allows lowercase
        public enum ContainerType { images };

        private readonly string _accountName;
        private readonly string _accountKey;

        #region Constructors
        public AzureBlobHandler(string accountName, string accountKey)
        {
            this._accountName = accountName;
            this._accountKey = accountKey;
        }

        public AzureBlobHandler(IConfiguration configuration)
        {
            this._accountName = configuration["Blob:AccountName"];
            this._accountKey = configuration["Blob:AccountKey"];
        }
        #endregion

        #region Public
        public async Task<Uri> UploadImageToStorageAsync(byte[] binaryFile, string fileName)
        {
            var blobContainer = GetBlobContainer(ContainerType.images);
            var blockBlob = blobContainer.GetBlockBlobReference(fileName);

            bool isSucess = await UploadBinaryFileToStorageAsync(binaryFile, fileName, blockBlob);
            if (!isSucess)
            {
                throw new AzureBlobFileUploadException();
            }

            return blockBlob.Uri;
        }

        public async Task<bool> DeleteImageFromStorageAsync(string fileName)
        {
            var blobContainer = GetBlobContainer(ContainerType.images);
            var blockBlob = blobContainer.GetBlockBlobReference(fileName);

            bool isSucess = await DeleteFileFromStorageAsync(fileName, blockBlob);
            if (!isSucess)
            {
                throw new AzureBlobFileUploadException();
            }

            return await Task.FromResult(isSucess);
        }
        #endregion

        #region Private
        private CloudBlobContainer GetBlobContainer(ContainerType containerType)
        {
            var storageCredentials = new StorageCredentials(this._accountName, this._accountKey);
            var storageAccount = new CloudStorageAccount(storageCredentials, true);
            var blobClient = storageAccount.CreateCloudBlobClient();

            return blobClient.GetContainerReference(containerType.ToString());
        }

        private async Task<bool> UploadBinaryFileToStorageAsync(byte[] binaryFile, string fileName, CloudBlockBlob blockBlob)
        {
            await blockBlob.UploadFromByteArrayAsync(binaryFile, 0, binaryFile.Length);

            return await Task.FromResult(true);
        }

        private async Task<bool> DeleteFileFromStorageAsync(string fileName, CloudBlockBlob blockBlob)
        {
            await blockBlob.DeleteIfExistsAsync();

            return await Task.FromResult(true);
        }
        #endregion

        #region Exceptions
        private class AzureBlobFileUploadException : Exception
        {
            public AzureBlobFileUploadException()
            {

            }

            public AzureBlobFileUploadException(string message)
                : base(message)
            {

            }

            public AzureBlobFileUploadException(string message, Exception inner)
                : base(message, inner)
            {

            }
        }
        #endregion
    }
}
