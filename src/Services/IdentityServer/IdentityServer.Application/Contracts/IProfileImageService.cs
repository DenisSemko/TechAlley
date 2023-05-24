namespace IdentityServer.Application.Contracts;

public interface IProfileImageService
{
    public string UploadedFile(RegisterModel model);
}