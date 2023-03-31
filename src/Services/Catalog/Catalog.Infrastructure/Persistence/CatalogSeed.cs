namespace Catalog.Infrastructure.Persistence;

public static class CatalogSeed
{
    public static void SeedData(this IServiceCollection services)
    {
        using var serviceProvider = services.BuildServiceProvider();
        using var serviceScope = serviceProvider.CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();

        context.CatalogTypes.AddAsync(new CatalogType(new Guid("1606DBEE-17A6-417B-80A6-1E4BA38E0226"), "Test Type"));
        context.CatalogBrands.AddAsync(new CatalogBrand(new Guid("1606DBEE-17A6-417B-80A6-1E4BA38E0227"), "Test Brand"));

        context.CatalogItems.AddAsync(new CatalogItem(new Guid("1606DBEE-17A6-417B-80A6-1E4BA38E0228"), "Test Item",
            "Test Item", "image", "src/image.png",
            context.CatalogTypes.GetByIdAsync(new Guid("1606DBEE-17A6-417B-80A6-1E4BA38E0226")).Result,
            context.CatalogBrands.GetByIdAsync(new Guid("1606DBEE-17A6-417B-80A6-1E4BA38E0227")).Result,
            0, 1));
    }
}