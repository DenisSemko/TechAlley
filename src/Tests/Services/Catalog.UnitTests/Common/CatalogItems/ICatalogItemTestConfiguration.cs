namespace Catalog.UnitTests.Common.CatalogItems;

public interface ICatalogItemTestConfiguration : IBaseTestConfiguration
{
    Mock<IUnitOfWork> MockUnitOfWork();
    Mock<IBaseRepository<CatalogItem>> MockCatalogItemRepository();
}