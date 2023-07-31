namespace Catalog.Application.Features.Catalog.Commands.UpdateCatalogWishlist;

public class UpdateCatalogWishlistCommandHandler : IRequestHandler<UpdateCatalogWishlistCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UpdateCatalogWishlistCommandHandler> _logger;
    private readonly IMapper _mapper;

    public UpdateCatalogWishlistCommandHandler(IUnitOfWork unitOfWork, ILogger<UpdateCatalogWishlistCommandHandler> logger, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Unit> Handle(UpdateCatalogWishlistCommand request, CancellationToken cancellationToken)
    {
        List<CatalogItem> catalogItems = new();
        CatalogWishlist catalogWishlist =
            await _unitOfWork.CatalogWishlists.GetAsync(wishList => wishList.BuyerId == request.BuyerId);
        
        if (catalogWishlist == null)
        {                
            throw new KeyNotFoundException(nameof(CatalogWishlist));
        }

        foreach (var catalogItemDto in request.CatalogItems)
        {
            CatalogTypeDto catalogType = _mapper.Map<CatalogTypeDto>(await _unitOfWork.CatalogTypes.GetTypeByName(catalogItemDto.CatalogType));
            CatalogBrandDto catalogBrand = _mapper.Map<CatalogBrandDto>(await _unitOfWork.CatalogBrands.GetBrandByName(catalogItemDto.CatalogBrand));
            catalogItems.Add(CatalogItemDtoToCatalogItem.Convert(catalogItemDto, catalogType, catalogBrand));
        }

        List<CatalogItem> unionCatalogItems = catalogItems.Union(catalogWishlist.CatalogItems).ToList();
        CatalogWishlist updatedItem = UpdateCatalogWishlistCommandToCatalogWishlist.Convert(request, unionCatalogItems);

        await _unitOfWork.CatalogWishlists.UpdateAsync(updatedItem);
        
        _logger.LogInformation(Logs.CatalogWishlistUpdated, updatedItem.Id);

        return Unit.Value;
    }
}