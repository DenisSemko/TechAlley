namespace Catalog.UnitTests.Application.Commands;

// Not working
public class DeleteCatalogItemCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;

    public DeleteCatalogItemCommandHandlerTests()
    {
        ICatalogItemTestConfiguration testConfiguration = new CatalogItemTestConfiguration();
        _mockUnitOfWork = testConfiguration.MockUnitOfWork();
    }
    
    [Fact]
    public async Task Handle_DeleteCatalogItemById_ReturnsKeyNotFoundException()
    {
        DeleteCatalogItemCommand command = new () { Id = new Guid("40c60a49-f64e-40a2-9057-8e96dc8047cf") };
        DeleteCatalogItemCommandHandler handler = new (_mockUnitOfWork.Object);

        KeyNotFoundException exception = await Should.ThrowAsync<KeyNotFoundException>
        (
            async () =>
            {
                await handler.Handle(command, default);
            }
        );
        
        exception.ShouldNotBeNull();
    }
    
    [Fact]
    public async Task Handle_DeleteCatalogItemById_ReturnsSuccess()
    {
        List<CatalogItem> items = FakeData.FakeCatalogItems;
        DeleteCatalogItemCommand command = new () { Id = items.FirstOrDefault().Id };
        DeleteCatalogItemCommandHandler handler = new (_mockUnitOfWork.Object);
        
        await handler.Handle(command, default);
        
        // items.Count.ShouldBe(1);
    }
}