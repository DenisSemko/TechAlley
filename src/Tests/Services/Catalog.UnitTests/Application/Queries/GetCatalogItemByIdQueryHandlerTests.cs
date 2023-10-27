namespace Catalog.UnitTests.Application.Queries;

public class GetCatalogItemByIdQueryHandlerTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly IMapper _mapper;

    public GetCatalogItemByIdQueryHandlerTests()
    {
        ICatalogItemTestConfiguration testConfiguration = new CatalogItemTestConfiguration();
        _mockUnitOfWork = testConfiguration.MockUnitOfWork();
        _mapper = testConfiguration.DefineMapper();
    }
    
    [Fact]
    public async Task Handle_GetCatalogItemById_ReturnsKeyNotFoundException()
    {
        GetCatalogItemByIdQuery query = new () { Id = new Guid("40c60a49-f64e-40a2-9057-8e96dc8047cf") };
        GetCatalogItemByIdQueryHandler handler = new (_mockUnitOfWork.Object, _mapper);

        KeyNotFoundException exception = await Should.ThrowAsync<KeyNotFoundException>
        (
            async () =>
            {
                await handler.Handle(query, default);
            }
        );
        
        exception.ShouldNotBeNull();
    }
    
    [Fact]
    public async Task Handle_GetCatalogItemById_ReturnsCatalogItem()
    {
        GetCatalogItemByIdQuery query = new () { Id = new Guid("5ddc604b-e52e-4499-bb07-8b6801634863") };
        GetCatalogItemByIdQueryHandler handler = new (_mockUnitOfWork.Object, _mapper);

        CatalogItemDto result = await handler.Handle(query, default);

        result.ShouldBeOfType<CatalogItemDto>();
        result.Id.ShouldBeEquivalentTo(new Guid("5ddc604b-e52e-4499-bb07-8b6801634863"));
    }
}