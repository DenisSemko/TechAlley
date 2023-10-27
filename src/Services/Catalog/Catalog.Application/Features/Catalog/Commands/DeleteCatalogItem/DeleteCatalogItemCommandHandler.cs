namespace Catalog.Application.Features.Catalog.Commands.DeleteCatalogItem;

public class DeleteCatalogItemCommandHandler : IRequestHandler<DeleteCatalogItemCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCatalogItemCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task Handle(DeleteCatalogItemCommand request, CancellationToken cancellationToken)
    {
        CatalogItem result = await _unitOfWork.CatalogItems.DeleteAsync(item => item.Id == request.Id);
        if (result is null)
        {
            throw new KeyNotFoundException(string.Format(Constants.Exceptions.ItemNotFound, nameof(CatalogItem)));
        }
    }
}