namespace Catalog.Infrastructure.Persistence;

public static class CatalogSeed
{
    public static async Task SeedData(this IServiceCollection services)
    {
        using ServiceProvider serviceProvider = services.BuildServiceProvider();
        using IServiceScope serviceScope = serviceProvider.CreateScope();
        IUnitOfWork context = serviceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        
        bool catalogTypesExist = await context.CatalogTypes.AnyAsync();
        bool catalogBrandsExist = await context.CatalogBrands.AnyAsync();
        bool catalogItemsExist = await context.CatalogItems.AnyAsync();

        if (catalogTypesExist && catalogBrandsExist && catalogItemsExist)
        {
            return;
        }

        List<CatalogType> catalogTypes = GenerateCatalogTypes();
        List<CatalogBrand> catalogBrands = GenerateCatalogBrands();

        await context.CatalogTypes.InsertManyAsync(catalogTypes);
        await context.CatalogBrands.InsertManyAsync(catalogBrands);

        List<CatalogItem> catalogItems = new()
        {
            CatalogItem.Create(Guid.NewGuid(), "Major IV",
                "Meet Major IV, the iconic headphones from Marshall with 80+ solid hours of wireless playtime, wireless charging and a new, improved ergonomic design.", "marshall.png",
                catalogTypes.FirstOrDefault(catalogType => catalogType.Type == "On-Ear")!,
                catalogBrands.FirstOrDefault(catalogBrand => catalogBrand.Brand == "Marshall")!,
                269, 350),
            CatalogItem.Create(Guid.NewGuid(), "WH-XB910N ANC Wireless",
                "Sony’s WH-XB910N rely on a powerful bass boost and effective noise cancelling. They are a comfortable and fairly flexible accessory for everyday mobile use.", "sony.png",
                catalogTypes.FirstOrDefault(catalogType => catalogType.Type == "Over-Ear")!,
                catalogBrands.FirstOrDefault(catalogBrand => catalogBrand.Brand == "Sony")!,
                280, 134),
            CatalogItem.Create(Guid.NewGuid(), "Solo3 Wireless Matte Black",
                "Beats Solo3 Wireless on-ear headphones immerse you in rich, award-winning sound, everywhere you want to go.", "dre.png",
                catalogTypes.FirstOrDefault(catalogType => catalogType.Type == "On-Ear")!,
                catalogBrands.FirstOrDefault(catalogBrand => catalogBrand.Brand == "Beats By Dr.Dre")!,
                200, 400)
        };

        await context.CatalogItems.InsertManyAsync(catalogItems);
    }
    private static List<CatalogType> GenerateCatalogTypes()
    {
        return new()
        {
            new CatalogType(Guid.NewGuid(), "Over-Ear"),
            new CatalogType(Guid.NewGuid(), "On-Ear"),
            new CatalogType(Guid.NewGuid(), "In-Ear"),
        };
    }
    private static List<CatalogBrand> GenerateCatalogBrands()
    {
        return new()
        {
            new CatalogBrand(Guid.NewGuid(), "Sony"),
            new CatalogBrand(Guid.NewGuid(), "Marshall"),
            new CatalogBrand(Guid.NewGuid(), "Beats By Dr.Dre")
        };
    }
}