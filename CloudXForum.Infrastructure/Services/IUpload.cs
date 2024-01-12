using Microsoft.WindowsAzure.Storage.Blob;

namespace CloudXForum.Infrastructure.Services;

public interface IUpload
{
    CloudBlobContainer GetBlobContainer(string connectionString, string containerName);
}