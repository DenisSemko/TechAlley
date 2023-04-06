namespace Catalog.Infrastructure.Persistence;

public static class CatalogSeed
{
    public static async Task SeedData(this IServiceCollection services)
    {
        using var serviceProvider = services.BuildServiceProvider();
        using var serviceScope = serviceProvider.CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        
        var catalogTypesExist = await context.CatalogTypes.AnyAsync();
        var catalogBrandsExist = await context.CatalogBrands.AnyAsync();
        var catalogItemsExist = await context.CatalogItems.AnyAsync();

        if (catalogTypesExist && catalogBrandsExist && catalogItemsExist)
        {
            return;
        }

        var catalogType = new CatalogType(Guid.NewGuid(), "Test Type");
        var catalogBrand = new CatalogBrand(Guid.NewGuid(), "Test Brand");
        
        await context.CatalogTypes.InsertOneAsync(catalogType);
        await context.CatalogBrands.InsertOneAsync(catalogBrand);
        
        var catalogItem = new CatalogItem(Guid.NewGuid(), "Test Item",
            "Test Item", "image.png", "src/image.png",
            catalogType,
            catalogBrand,
            0, 1);

        await context.CatalogItems.InsertOneAsync(catalogItem);
    }
}