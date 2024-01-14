using Microsoft.WindowsAzure.Storage.Blob;

namespace CloudXForum.DataAccess.Services;

public interface IUpload
{
    CloudBlobContainer GetBlobContainer(string connectionString, string containerName);
}