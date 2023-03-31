namespace Catalog.Infrastructure.DbSettings;

public class DbSettings : IDbSettings
{
    public string DatabaseName { get; set; }
    public string ConnectionString { get; set; }
}