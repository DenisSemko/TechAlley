namespace Catalog.Application.Features.Catalog.Commands.DeleteCatalogItemFromCatalogWishlist;

public class DeleteCatalogItemFromWishlistCommandHandler : IRequestHandler<DeleteCatalogItemFromWishlistCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<DeleteCatalogItemFromWishlistCommandHandler> _logger;

    public DeleteCatalogItemFromWishlistCommandHandler(IUnitOfWork unitOfWork, ILogger<DeleteCatalogItemFromWishlistCommandHandler> logger)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
            _logger.LogInformation(Logs.CatalogWishlistUpdated, catalogWishlist.Id);
        }

        if (catalogWishlist.CatalogItems.Count == 0)
        {
            await _unitOfWork.CatalogWishlists.DeleteAsync(wishlist => wishlist.Id == catalogWishlist.Id);
            _logger.LogInformation(Logs.CatalogWishlistDeleted, catalogWishlist.Id);
        }
    }
}