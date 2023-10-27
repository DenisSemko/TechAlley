namespace Catalog.Application.Features.Catalog.Commands.UpdateCatalogItem;

public class UpdateCatalogItemCommandHandler : IRequestHandler<UpdateCatalogItemCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCatalogItemCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
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
        
        return Unit.Value;
    }
}