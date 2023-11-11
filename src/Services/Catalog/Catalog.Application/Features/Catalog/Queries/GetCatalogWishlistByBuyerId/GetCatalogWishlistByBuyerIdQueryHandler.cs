namespace Catalog.Application.Features.Catalog.Queries.GetCatalogWishlistByBuyerId;

public class GetCatalogWishlistByBuyerIdQueryHandler : IRequestHandler<GetCatalogWishlistByBuyerIdQuery, CatalogWishlistDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCatalogWishlistByBuyerIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<CatalogWishlistDto> Handle(GetCatalogWishlistByBuyerIdQuery request, CancellationToken cancellationToken)
    {
        CatalogWishlist catalogWishlist = await _unitOfWork.CatalogWishlists.GetAsync(wishlist => wishlist.BuyerId == request.BuyerId);
        
        if (catalogWishlist is null)
        {
            throw new KeyNotFoundException(string.Format(Constants.Exceptions.ItemNotFound, nameof(catalogWishlist)));
        }
        
        return _mapper.Map<CatalogWishlistDto>(catalogWishlist);
    }
}