namespace Catalog.Application.Features.Catalog.Queries.GetCatalogItemById;

public class GetCatalogItemByIdQueryHandler : IRequestHandler<GetCatalogItemByIdQuery, CatalogItemDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCatalogItemByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<CatalogItemDto> Handle(GetCatalogItemByIdQuery request, CancellationToken cancellationToken)
    {
        CatalogItem catalogItem = await _unitOfWork.CatalogItems.GetByIdAsync(request.Id);
        
        if (catalogItem is null)
        {
            throw new KeyNotFoundException();
        }
        
        return _mapper.Map<CatalogItemDto>(catalogItem);
    }
}