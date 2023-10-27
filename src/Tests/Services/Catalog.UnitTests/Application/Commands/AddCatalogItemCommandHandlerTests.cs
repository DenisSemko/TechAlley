namespace Catalog.UnitTests.Application.Commands;

public class AddCatalogItemCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly IMapper _mapper;

    public AddCatalogItemCommandHandlerTests()
    {
        ICatalogItemTestConfiguration testConfiguration = new CatalogItemTestConfiguration();
        _mockUnitOfWork = testConfiguration.MockUnitOfWork();
        _mapper = testConfiguration.DefineMapper();
    }

    [Fact]
    public async Task Handle_AddInvalidCatalogItem_ReturnsValidationRules()
    {
        CatalogItemDto invalidDataItem = FakeData.InvalidCatalogItemDto;
        AddCatalogItemCommand command = new ()
        {
            Name = invalidDataItem.Name,
            Description = invalidDataItem.Description,
            CatalogBrand = invalidDataItem.CatalogBrand,
            CatalogType = invalidDataItem.CatalogType,
            ImageFileName = invalidDataItem.ImageFileName,
            Price = invalidDataItem.Price,
            Quantity = invalidDataItem.Quantity
        };
        
        AddCatalogItemCommandValidator validator = new (_mockUnitOfWork.Object);
        
        ValidationResult result = await validator.ValidateAsync(command);
    
        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldContain(e => e.PropertyName == "CatalogType" && e.ErrorMessage.Contains("required"));
        result.Errors.ShouldContain(e => e.PropertyName == "CatalogBrand" && e.ErrorMessage.Contains("required"));
        result.Errors.ShouldContain(e => e.PropertyName == "Price" && e.ErrorMessage.Contains("zero"));
        result.Errors.ShouldContain(e => e.PropertyName == "Quantity" && e.ErrorMessage.Contains("zero"));
    }
    
    [Fact]
    public async Task Handle_AddCatalogItem_ReturnsNewItem()
    {
        CatalogItem newItem = FakeData.SingleFakeCatalogItem;
        AddCatalogItemCommand command = new ()
        {
            Name = newItem.Name,
            Description = newItem.Description,
            CatalogBrand = newItem.CatalogBrand.Brand,
            CatalogType = newItem.CatalogType.Type,
            ImageFileName = newItem.ImageFileName,
            Price = newItem.Price,
            Quantity = newItem.Quantity
        };

        _mockUnitOfWork.Setup(uow => uow.CatalogTypes.GetTypeByName(command.CatalogType))
            .ReturnsAsync(newItem.CatalogType);
        _mockUnitOfWork.Setup(uow => uow.CatalogBrands.GetBrandByName(command.CatalogBrand))
            .ReturnsAsync(newItem.CatalogBrand);
        
        AddCatalogItemCommandHandler handler = new (_mockUnitOfWork.Object, _mapper);
        
        CatalogItemDto result = await handler.Handle(command, default);
    
        _mockUnitOfWork.Verify(uow => uow.CatalogTypes.GetTypeByName(command.CatalogType), Times.Once);
        _mockUnitOfWork.Verify(uow => uow.CatalogBrands.GetBrandByName(command.CatalogBrand), Times.Once);
        result.Name.ShouldBeEquivalentTo(newItem.Name);
    }
}