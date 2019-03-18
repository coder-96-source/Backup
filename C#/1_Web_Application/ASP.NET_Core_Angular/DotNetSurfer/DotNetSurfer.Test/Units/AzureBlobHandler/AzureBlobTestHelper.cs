using DotNetSurfer.DAL.CDNs.Interfaces;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DotNetSurfer.Test.Units.AzureBlobHandler
{
    public static class AzureBlobTestHelper
    {
        private static IConfigurationRoot _configuration;
        private static ICdnHandler _cdnHandler;
        private static string _fileName;

        static AzureBlobTestHelper()
        {
            string appsettingPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\DotNetSurfer.Web"));
            _configuration = new ConfigurationBuilder()
                .SetBasePath(appsettingPath)
                .AddJsonFile("appsettings.json")
                .Build();

            string accountName = _configuration["Blob:AccountName"];
            string accountKey = _configuration["Blob:AccountKey"];
            _cdnHandler = new DAL.CDNs.AzureBlobHandler(accountName, accountKey);

            _fileName = "TEST";
        }

        public static ICdnHandler GetAzureBlobHandler()
        {
            return _cdnHandler;
        }

        public static string GetTestFileName()
        {
            return _fileName;
        }
    }
}
