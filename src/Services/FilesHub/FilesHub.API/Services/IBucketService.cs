namespace FilesHub.API.Services;

public interface IBucketService
{
    Task<byte[]> DownloadFileAsync(string fileName);
    
    Task<bool> UploadFileAsync(IFormFile file);

    Task<DeleteObjectResponse> DeleteFileAsync(string fileName);
}