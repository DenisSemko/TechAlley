namespace Catalog.UnitTests.Common.CatalogItems;

public class CatalogItemTestConfiguration : BaseTestConfiguration, ICatalogItemTestConfiguration
{
    public Mock<IUnitOfWork> MockUnitOfWork()
    {
        Mock<IUnitOfWork> mockUnitOfWork = new ();
        mockUnitOfWork.Setup(uow => uow.CatalogItems).Returns(MockCatalogItemRepository().Object);

        return mockUnitOfWork;
    }

    public Mock<IBaseRepository<CatalogItem>> MockCatalogItemRepository()
    {
        Mock<IBaseRepository<CatalogItem>> mockCatalogItemRepository = new ();
        List<CatalogItem> items = FakeData.FakeCatalogItems;
        
        PagedList<CatalogItem> dummyItems = new (Constants.PageNumber, Constants.PageSize, Constants.TotalRecords, items);
        
        mockCatalogItemRepository
            .Setup(repo => repo.GetPagedAsync(Constants.PageNumber, Constants.PageSize))
            .ReturnsAsync(dummyItems);
        
        mockCatalogItemRepository
            .Setup(repo => repo.GetByIdAsync(FakeData.FakeCatalogItems.FirstOrDefault().Id))
            .ReturnsAsync(FakeData.FakeCatalogItems.FirstOrDefault());

        mockCatalogItemRepository.Setup(repo => repo.InsertOneAsync(It.IsAny<CatalogItem>()))
            .Returns((CatalogItem catalogItem) =>
            {
                items.Add(catalogItem);
                return Task.CompletedTask;
            });
        
        mockCatalogItemRepository
            .Setup(repo => repo.DeleteAsync(item => item.Id == FakeData.FakeCatalogItems.FirstOrDefault().Id))
            .ReturnsAsync(FakeData.FakeCatalogItems.FirstOrDefault());

        return mockCatalogItemRepository;
    }
}