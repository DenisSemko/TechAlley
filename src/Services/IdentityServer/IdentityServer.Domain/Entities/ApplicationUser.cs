namespace IdentityServer.Domain.Entities
{
    public sealed class ApplicationUser : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string? MiddleName { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string ProfileImage { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
