namespace IdentityServer.Infrastructure.Services;

public class ProfileImageService : IProfileImageService
{
    public string UploadedFile(RegisterModel model)
    {
        string uniqueFileName = null;

        // if (model.ProfileImage is not null)
        // {
        //     string uploadsFolder = Path.Combine("Resources", "Images");
        //     uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
        //     string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //     using (var fileStream = new FileStream(filePath, FileMode.Create))
        //     {
        //         model.ProfileImage.CopyTo(fileStream);
        //     }
        // }
        return uniqueFileName;
    }
}