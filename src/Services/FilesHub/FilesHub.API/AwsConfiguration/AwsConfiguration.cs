namespace FilesHub.API.AwsConfiguration;

public class AwsConfiguration : IAwsConfiguration
{
    public string AccessKey { get; set; }
    public string SecretAccessKey { get; set; }
    public string SessionToken { get; set; }
    public string BucketName { get; set; }
    public string Region { get; set; }
}