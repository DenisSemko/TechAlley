namespace Catalog.Application.Features.Catalog.Commands.DeleteCatalogItemFromCatalogWishlist;

public class DeleteCatalogItemFromWishlistCommandHandler : IRequestHandler<DeleteCatalogItemFromWishlistCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCatalogItemFromWishlistCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task Handle(DeleteCatalogItemFromWishlistCommand request, CancellationToken cancellationToken)
    {
        CatalogWishlist catalogWishlist = await _unitOfWork.CatalogWishlists.GetAsync(wishlist => wishlist.BuyerId == request.BuyerId);
        if (catalogWishlist is null)
        {                
            throw new KeyNotFoundException(nameof(CatalogWishlist));
        }

        bool isUpdatedCatalogWishlist = catalogWishlist.CatalogItems.Remove(
            catalogWishlist.CatalogItems.Find(catalogItem => catalogItem.Id == request.CatalogItemId) ?? throw new ArgumentNullException(nameof(request)));

        if (isUpdatedCatalogWishlist)
        {
            await _unitOfWork.CatalogWishlists.UpdateAsync(catalogWishlist);
        }

        if (catalogWishlist.CatalogItems.Count == 0)
        {
            await _unitOfWork.CatalogWishlists.DeleteAsync(wishlist => wishlist.Id == catalogWishlist.Id);
        }
    }
}