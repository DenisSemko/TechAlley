namespace Catalog.Application.Features.Catalog.Commands.DeleteCatalogItem;

public class DeleteCatalogItemCommandHandler : IRequestHandler<DeleteCatalogItemCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<DeleteCatalogItemCommandHandler> _logger;

    public DeleteCatalogItemCommandHandler(IUnitOfWork unitOfWork, ILogger<DeleteCatalogItemCommandHandler> logger)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task Handle(DeleteCatalogItemCommand request, CancellationToken cancellationToken)
    {
        CatalogItem catalogItem = await _unitOfWork.CatalogItems.GetByIdAsync(request.Id);
        if (catalogItem is null)
        {                
            throw new KeyNotFoundException(nameof(CatalogItem));
        }

        await _unitOfWork.CatalogItems.DeleteAsync(item => item.Id == request.Id);
        _logger.LogInformation(Logs.CatalogItemDeleted, catalogItem.Name);
    }
}