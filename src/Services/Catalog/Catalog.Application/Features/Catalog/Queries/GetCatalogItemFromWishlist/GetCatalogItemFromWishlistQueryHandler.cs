namespace Catalog.Application.Features.Catalog.Queries.GetCatalogItemFromWishlist;

public class GetCatalogItemFromWishlistQueryHandler : IRequestHandler<GetCatalogItemFromWishlistQuery, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCatalogItemFromWishlistQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<bool> Handle(GetCatalogItemFromWishlistQuery request, CancellationToken cancellationToken)
    {
        CatalogWishlist catalogWishlist = await _unitOfWork.CatalogWishlists.GetAsync(wishlist => wishlist.BuyerId == request.BuyerId);
        
        if (catalogWishlist is null)
        {
            throw new KeyNotFoundException(string.Format(Constants.Exceptions.ItemNotFound, nameof(catalogWishlist)));
        }

        return catalogWishlist.CatalogItems.Find(catalogItem => catalogItem.Id == request.CatalogItemId) is not null;
    }
}