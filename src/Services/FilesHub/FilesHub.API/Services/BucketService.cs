namespace FilesHub.API.Services;

public class BucketService : IBucketService
{
    private readonly IAmazonS3 _s3Client;
    private readonly IAwsConfiguration _awsConfiguration;
    
    public BucketService(IAwsConfiguration awsConfiguration)
    {
        _awsConfiguration = awsConfiguration;
        _s3Client = new AmazonS3Client(awsConfiguration.AccessKey, awsConfiguration.SecretAccessKey, RegionEndpoint.GetBySystemName(awsConfiguration.Region));
    }
    
    public async Task<byte[]> DownloadFileAsync(string fileName)
    {
        MemoryStream ms = null;

        GetObjectRequest getObjectRequest = new GetObjectRequest
        {
            BucketName = _awsConfiguration.BucketName,
            Key = fileName
        };

        using (var response = await _s3Client.GetObjectAsync(getObjectRequest))
        {
            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                using (ms = new MemoryStream())
                {
                    await response.ResponseStream.CopyToAsync(ms);
                }
            }
        }
        return ms.ToArray();
    }

    public async Task<bool> UploadFileAsync(IFormFile file)
    {
        using var newMemoryStream = new MemoryStream();
        await file.CopyToAsync(newMemoryStream);

        var uploadRequest = new TransferUtilityUploadRequest
        {
            InputStream = newMemoryStream,
            Key = file.FileName,
            BucketName = _awsConfiguration.BucketName,
            ContentType = file.ContentType
        };

        var fileTransferUtility = new TransferUtility(_s3Client);

        await fileTransferUtility.UploadAsync(uploadRequest);

        return true;
    }

    public async Task<DeleteObjectResponse> DeleteFileAsync(string fileName)
    {
        DeleteObjectRequest request = new DeleteObjectRequest
        {
            BucketName = _awsConfiguration.BucketName,
            Key = fileName
        };

        return await _s3Client.DeleteObjectAsync(request);
    }
}