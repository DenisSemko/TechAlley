namespace Catalog.Application.Features.Catalog.Queries.GetCatalogItems;

public class GetCatalogItemsQueryHandler : IRequestHandler<GetCatalogItemsQuery, PagedList<CatalogItemDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCatalogItemsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<PagedList<CatalogItemDto>> Handle(GetCatalogItemsQuery request, CancellationToken cancellationToken)
    {
        if (request is { PageNumber: < 1, PageSize: < 5 })
        {
            throw new ArgumentOutOfRangeException(nameof(request));
        }
        
        PagedList<CatalogItem> catalogItems = await _unitOfWork.CatalogItems.GetPagedAsync(request.PageNumber, request.PageSize);
        return _mapper.Map<PagedList<CatalogItemDto>>(catalogItems);
    }
}