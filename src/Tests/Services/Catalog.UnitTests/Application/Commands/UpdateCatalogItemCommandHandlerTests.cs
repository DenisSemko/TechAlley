namespace Catalog.UnitTests.Application.Commands;

public class UpdateCatalogItemCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;

    public UpdateCatalogItemCommandHandlerTests()
    {
        ICatalogItemTestConfiguration testConfiguration = new CatalogItemTestConfiguration();
        _mockUnitOfWork = testConfiguration.MockUnitOfWork();
    }
    
    [Fact]
    public async Task Handle_UpdateInvalidCatalogItem_ReturnsValidationRules()
    {
        CatalogItemDto catalogItem = FakeData.InvalidCatalogItemDto;
        UpdateCatalogItemCommand command = new ()
        {
            Id = catalogItem.Id,
            Name = catalogItem.Name,
            Description = catalogItem.Description,
            CatalogBrand = catalogItem.CatalogBrand,
            CatalogType = catalogItem.CatalogType,
            ImageFileName = catalogItem.ImageFileName,
            Price = catalogItem.Price,
            Quantity = catalogItem.Quantity
        };
        
        UpdateCatalogItemCommandValidator validator = new (_mockUnitOfWork.Object);
        
        ValidationResult result = await validator.ValidateAsync(command);
    
        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldContain(e => e.PropertyName == "CatalogType" && e.ErrorMessage.Contains("required"));
        result.Errors.ShouldContain(e => e.PropertyName == "CatalogBrand" && e.ErrorMessage.Contains("required"));
        result.Errors.ShouldContain(e => e.PropertyName == "Price" && e.ErrorMessage.Contains("zero"));
        result.Errors.ShouldContain(e => e.PropertyName == "Quantity" && e.ErrorMessage.Contains("zero"));
    }
    
    [Fact]
    public async Task Handle_UpdateCatalogItem_ReturnsUpdatedItem()
    {
        List<CatalogItem> items = FakeData.FakeCatalogItems;
        CatalogItem catalogItemToUpdate = items.FirstOrDefault();
        UpdateCatalogItemCommand command = new ()
        {
            Id = catalogItemToUpdate.Id,
            Name = "New test",
            Description = catalogItemToUpdate.Description,
            CatalogBrand = catalogItemToUpdate.CatalogBrand.Brand,
            CatalogType = catalogItemToUpdate.CatalogType.Type,
            ImageFileName = catalogItemToUpdate.ImageFileName,
            Price = catalogItemToUpdate.Price,
            Quantity = catalogItemToUpdate.Quantity
        };

        _mockUnitOfWork.Setup(uow => uow.CatalogTypes.GetTypeByName(command.CatalogType))
            .ReturnsAsync(catalogItemToUpdate.CatalogType);
        _mockUnitOfWork.Setup(uow => uow.CatalogBrands.GetBrandByName(command.CatalogBrand))
            .ReturnsAsync(catalogItemToUpdate.CatalogBrand);
        
        UpdateCatalogItemCommandHandler handler = new (_mockUnitOfWork.Object);
        
        await handler.Handle(command, default);
    
        _mockUnitOfWork.Verify(uow => uow.CatalogTypes.GetTypeByName(command.CatalogType), Times.Once);
        _mockUnitOfWork.Verify(uow => uow.CatalogBrands.GetBrandByName(command.CatalogBrand), Times.Once);
    }
}