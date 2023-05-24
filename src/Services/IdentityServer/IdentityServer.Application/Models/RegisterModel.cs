namespace IdentityServer.Application.Models;

public class RegisterModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public IFormFile ProfileImage { get; set; }
}