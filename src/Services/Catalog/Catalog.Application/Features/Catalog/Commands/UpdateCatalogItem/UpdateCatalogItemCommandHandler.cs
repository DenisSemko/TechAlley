namespace Catalog.Application.Features.Catalog.Commands.UpdateCatalogItem;

public class UpdateCatalogItemCommandHandler : IRequestHandler<UpdateCatalogItemCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UpdateCatalogItemCommandHandler> _logger;

    public UpdateCatalogItemCommandHandler(IUnitOfWork unitOfWork, ILogger<UpdateCatalogItemCommandHandler> logger)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Unit> Handle(UpdateCatalogItemCommand request, CancellationToken cancellationToken)
    {
        CatalogType catalogType = await _unitOfWork.CatalogTypes.GetTypeByName(request.CatalogType);
        CatalogBrand catalogBrand = await _unitOfWork.CatalogBrands.GetBrandByName(request.CatalogBrand);
        CatalogItem catalogItem = await _unitOfWork.CatalogItems.GetByIdAsync(request.Id);
        if (catalogItem == null)
        {                
            throw new KeyNotFoundException(nameof(CatalogItem));
        }

        CatalogItem updatedItem = UpdateCatalogItemCommandToCatalogItem.Convert(request, catalogType, catalogBrand);

        await _unitOfWork.CatalogItems.UpdateAsync(updatedItem);
        
        _logger.LogInformation(Logs.CatalogItemUpdated, catalogItem.Name);

        return Unit.Value;
    }
}