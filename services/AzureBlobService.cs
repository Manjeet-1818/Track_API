using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace BuildAPI.services
{
    public class AzureBlobService
    {
        private readonly BlobContainerClient _containerClient;

        public AzureBlobService()
        {
            var blobServiceClinet = new BlobServiceClient(
                new Uri("https://manjeet18storage.blob.core.windows.net"),
                new DefaultAzureCredential()
            );

            _containerClient = blobServiceClinet.GetBlobContainerClient("documents");
        }

        public async Task UploadFileAsync(Stream fileStream,string fileName,string contentType)
        {
            var blobClient = _containerClient.GetBlobClient(fileName);

                await blobClient.UploadAsync(fileStream, new BlobUploadOptions
                {
                    HttpHeaders = new BlobHttpHeaders
                    {
                        ContentType = contentType
                    }
                });
        }
    }
}