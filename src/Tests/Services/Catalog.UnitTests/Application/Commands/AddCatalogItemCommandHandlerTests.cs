using Catalog.Domain.Entities;
using Catalog.UnitTests.Common;

namespace Catalog.UnitTests.Application.Commands;

public class AddCatalogItemCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<ICatalogItemRepository> _mockCatalogItemRepository;
    private readonly Mock<ILogger<AddCatalogItemCommandHandler>> _mockLogger;

    public AddCatalogItemCommandHandlerTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockCatalogItemRepository = new Mock<ICatalogItemRepository>();
        _mockLogger = new Mock<ILogger<AddCatalogItemCommandHandler>>();
        _mockUnitOfWork.Setup(uow => uow.CatalogItems).Returns(_mockCatalogItemRepository.Object);
    }

    [Fact]
    public async Task Handle_InvalidCatalogItem_ReturnsValidationRules()
    {
        //Arrange
        var command = new AddCatalogItemCommand()
        {
            Name = FakeData.ConfigureInvalidData().Name,
            Description = FakeData.ConfigureInvalidData().Description,
            CatalogBrand = FakeData.ConfigureInvalidData().CatalogBrand,
            CatalogType = FakeData.ConfigureInvalidData().CatalogType,
            ImageUri = FakeData.ConfigureInvalidData().ImageUri,
            Price = FakeData.ConfigureInvalidData().Price,
            Quantity = FakeData.ConfigureInvalidData().Quantity
        };
        var validator = new AddCatalogItemCommandValidator(_mockUnitOfWork.Object);
        
        //Act
        var result = await validator.ValidateAsync(command);

        //Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == "CatalogType" && e.ErrorMessage.Contains("required"));
        Assert.Contains(result.Errors, e => e.PropertyName == "CatalogBrand" && e.ErrorMessage.Contains("required"));
        Assert.Contains(result.Errors, e => e.PropertyName == "Price" && e.ErrorMessage.Contains("zero"));
        Assert.Contains(result.Errors, e => e.PropertyName == "Quantity" && e.ErrorMessage.Contains("zero"));
    }
    
    [Fact]
    public async Task Handle_InvalidCatalogType_ReturnsException()
    {
        //Arrange
        var catalogType = new CatalogType(Guid.NewGuid(), "Test Type");
        var catalogBrand = new CatalogBrand(Guid.NewGuid(), "Test Brand");
        var command = new AddCatalogItemCommand()
        {
            Name = FakeData.ConfigureData().Name,
            Description = FakeData.ConfigureData().Description,
            CatalogBrand = FakeData.ConfigureData().CatalogBrand,
            CatalogType = FakeData.ConfigureData().CatalogType,
            ImageUri = FakeData.ConfigureData().ImageUri,
            Price = FakeData.ConfigureData().Price,
            Quantity = FakeData.ConfigureData().Quantity
        };
        var catalogItem = new CatalogItem(Guid.NewGuid(), command.Name, command.Description, command.ImageUri, command.ImageUri, catalogType, catalogBrand, command.Price, command.Quantity);
        
        _mockUnitOfWork.Setup(uow => uow.CatalogTypes.GetTypeByName(command.CatalogType))
            .ReturnsAsync(catalogType);
        _mockUnitOfWork.Setup(uow => uow.CatalogBrands.GetBrandByName(command.CatalogBrand))
            .ReturnsAsync(catalogBrand);
        _mockUnitOfWork.Setup(uow => uow.CatalogItems.InsertOneAsync(It.IsAny<CatalogItem>()))
            .Returns(Task.CompletedTask);
        
        var handler = new AddCatalogItemCommandHandler(_mockUnitOfWork.Object, _mockLogger.Object);
        
        //Act
        var result = await handler.Handle(command, default);

        //Assert
        _mockUnitOfWork.Verify(uow => uow.CatalogTypes.GetTypeByName(command.CatalogType), Times.Once);
        _mockUnitOfWork.Verify(uow => uow.CatalogBrands.GetBrandByName(command.CatalogBrand), Times.Once);
        Assert.Equal(catalogItem.Name, result.Name);
        Assert.Equal(catalogItem.Description, result.Description);
        Assert.Equal(catalogItem.Price, result.Price);
        Assert.Equal(catalogItem.ImageUri, result.ImageUri);
        Assert.Equal(catalogItem.CatalogType.Type, result.CatalogType.Type);
        Assert.Equal(catalogItem.CatalogBrand.Brand, result.CatalogBrand.Brand);
        Assert.Equal(catalogItem.Quantity, result.Quantity);
    }
}