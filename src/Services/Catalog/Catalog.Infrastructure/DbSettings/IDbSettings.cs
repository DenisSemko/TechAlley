namespace Catalog.Infrastructure.DbSettings;

public interface IDbSettings
{
    string DatabaseName { get; set; }
    string ConnectionString { get; set; }
}