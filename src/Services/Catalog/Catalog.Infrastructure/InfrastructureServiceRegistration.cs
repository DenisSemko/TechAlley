namespace Catalog.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<DbSettings.DbSettings>(configuration.GetSection("ApplicationDatabase"));
        services.AddSingleton<IDbSettings>(serviceProvider =>
            serviceProvider.GetRequiredService<IOptions<DbSettings.DbSettings>>().Value);

        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<ICatalogBrandRepository, CatalogBrandRepository>();
        services.AddScoped<ICatalogTypeRepository, CatalogTypeRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}