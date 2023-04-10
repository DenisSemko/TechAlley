using AutoMapper;
using Catalog.Domain.Entities;

namespace Catalog.UnitTests.Application.Queries;

public class GetCatalogItemsQueryHandlerTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<ICatalogItemRepository> _mockCatalogItemRepository;
    private readonly Mock<IMapper> _mockMapper;

    public GetCatalogItemsQueryHandlerTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockCatalogItemRepository = new Mock<ICatalogItemRepository>();
        _mockMapper = new Mock<IMapper>();
        _mockUnitOfWork.Setup(uow => uow.CatalogItems).Returns(_mockCatalogItemRepository.Object);
    }

    [Fact]
    public async Task Handle_GetCatalogItems_ReturnsListOfItems()
    {
        //Arrange
        IReadOnlyList<CatalogItem> catalogItems = new List<CatalogItem>();
        GetCatalogItemsQuery query = new GetCatalogItemsQuery();

        //FIND OUT WHY IT'S NOT WORKING
        // _mockUnitOfWork.Setup(uow => uow.CatalogItems.GetAllAsync())
        //     .Returns(catalogItems);
        
        var handler = new GetCatalogItemsQueryHandler(_mockUnitOfWork.Object, _mockMapper.Object);
        
        //Act
        var result = await handler.Handle(query, default);
        
        //Assert
        _mockUnitOfWork.Verify(uow => uow.CatalogItems.GetAllAsync(), Times.Once);
        
        
    }
    
}