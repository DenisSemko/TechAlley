namespace Catalog.Application.Features.Catalog.Commands.AddCatalogItem;

public class AddCatalogItemCommandHandler : IRequestHandler<AddCatalogItemCommand, CatalogItem>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<AddCatalogItemCommandHandler> _logger;

    public AddCatalogItemCommandHandler(IUnitOfWork unitOfWork, ILogger<AddCatalogItemCommandHandler> logger)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<CatalogItem> Handle(AddCatalogItemCommand request, CancellationToken cancellationToken)
    {
        CatalogType catalogType = await _unitOfWork.CatalogTypes.GetTypeByName(request.CatalogType);
        CatalogBrand catalogBrand = await _unitOfWork.CatalogBrands.GetBrandByName(request.CatalogBrand);
        CatalogItem catalogItem = AddCatalogItemCommandToCatalogItem.Convert(request, catalogType, catalogBrand);
        
        await _unitOfWork.CatalogItems.InsertOneAsync(catalogItem);
        
        _logger.LogInformation(string.Format(Logs.CatalogItemCreated, catalogItem.Name));

        return catalogItem;
    }
}