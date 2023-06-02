namespace Basket.Infrastructure.DbSettings;

public interface IDbSettings
{
    string ConnectionString { get; set; }
}