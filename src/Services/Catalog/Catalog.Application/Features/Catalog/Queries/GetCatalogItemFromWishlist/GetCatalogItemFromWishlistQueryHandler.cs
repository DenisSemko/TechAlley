namespace Catalog.Application.Features.Catalog.Queries.GetCatalogItemFromWishlist;

public class GetCatalogItemFromWishlistQueryHandler : IRequestHandler<GetCatalogItemFromWishlistQuery, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCatalogItemFromWishlistQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<bool> Handle(GetCatalogItemFromWishlistQuery request, CancellationToken cancellationToken)
    {
        CatalogWishlist catalogWishlist = await _unitOfWork.CatalogWishlists.GetAsync(wishlist => wishlist.BuyerId == request.BuyerId);

        return catalogWishlist.CatalogItems.Find(catalogItem => catalogItem.Id == request.CatalogItemId) is not null;
    }
}