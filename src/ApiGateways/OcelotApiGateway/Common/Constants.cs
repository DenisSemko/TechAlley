namespace OcelotApiGateway.Common;

public class Constants
{
    public class AuthRequestPaths
    {
        public const string LoginPath = "Auth/login";
        public const string RegistrationPath = "Auth/registration";
        public const string RefreshPath = "https://localhost:7034/api/Auth/{0}";
        public const string CatalogPath = "Catalog";
    }
}