namespace IdentityServer.Application.Common;

public static class Constants
{
    public class Errors
    {
        public const string UsernameAlreadyExists = "User with such username already exists";
        public const string UserDoesNotExist = "User does not exist";
        public const string WrongCredentials = "User credentials are wrong";
    }

    public class Roles
    {
        public const string User = "User";
    }
}