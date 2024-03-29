namespace Catalog.Application.Features.Catalog.Commands.AddCatalogWishlist;

public class AddCatalogWishlistCommandHandler : IRequestHandler<AddCatalogWishlistCommand, CatalogWishlistDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddCatalogWishlistCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<CatalogWishlistDto> Handle(AddCatalogWishlistCommand request, CancellationToken cancellationToken)
    {
        CatalogWishlistDto catalogWishlistDto = _mapper.Map<CatalogWishlistDto>(request);
        List<CatalogItem> catalogItems = new();
        
        foreach (var catalogItemDto in catalogWishlistDto.CatalogItems)
        {
            CatalogTypeDto catalogType = _mapper.Map<CatalogTypeDto>(await _unitOfWork.CatalogTypes.GetTypeByName(catalogItemDto.CatalogType));
            CatalogBrandDto catalogBrand = _mapper.Map<CatalogBrandDto>(await _unitOfWork.CatalogBrands.GetBrandByName(catalogItemDto.CatalogBrand));
            catalogItems.Add(CatalogItemDtoToCatalogItem.Convert(catalogItemDto, catalogType, catalogBrand));
        }
        
        await _unitOfWork.CatalogWishlists.InsertOneAsync(new CatalogWishlist(catalogWishlistDto.Id, catalogItems, catalogWishlistDto.BuyerId));
        
        return catalogWishlistDto;
    }
}