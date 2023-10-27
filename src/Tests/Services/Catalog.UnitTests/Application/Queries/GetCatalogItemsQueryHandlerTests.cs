namespace Catalog.UnitTests.Application.Queries;

public class GetCatalogItemsQueryHandlerTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly IMapper _mapper;

    public GetCatalogItemsQueryHandlerTests()
    {
        ICatalogItemTestConfiguration testConfiguration = new CatalogItemTestConfiguration();
        _mockUnitOfWork = testConfiguration.MockUnitOfWork();
        _mapper = testConfiguration.DefineMapper();
    }

    [Fact]
    public async Task Handle_GetCatalogItems_ReturnsArgumentOutOfRangeException()
    {
        GetCatalogItemsQuery query = new () { PageNumber = -1, PageSize = 2 };
        GetCatalogItemsQueryHandler handler = new (_mockUnitOfWork.Object, _mapper);

        ArgumentOutOfRangeException exception = await Should.ThrowAsync<ArgumentOutOfRangeException>
        (
            async () =>
            {
                await handler.Handle(query, default);
            }
        );
        exception.ShouldNotBeNull();
    }
    
    [Fact]
    public async Task Handle_GetCatalogItems_ReturnsListOfItems()
    {
        GetCatalogItemsQuery query = new () { PageNumber = Constants.PageNumber, PageSize = Constants.PageSize };
        
        GetCatalogItemsQueryHandler handler = new (_mockUnitOfWork.Object, _mapper);

        PagedList<CatalogItemDto> result = await handler.Handle(query, default);

        result.ShouldBeOfType<PagedList<CatalogItemDto>>();
        result.Items.Count.ShouldBe(Constants.TotalRecords);
        result.CurrentPage.ShouldBe(query.PageNumber);
    }
}