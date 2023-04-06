namespace Catalog.Application.Features.Catalog.Queries.GetCatalogItems;

public class GetCatalogItemsQueryHandler : IRequestHandler<GetCatalogItemsQuery, List<CatalogItemDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCatalogItemsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<CatalogItemDto>> Handle(GetCatalogItemsQuery request, CancellationToken cancellationToken)
    {
        var catalogItems = await _unitOfWork.CatalogItems.GetAllAsync();
        return _mapper.Map<List<CatalogItemDto>>(catalogItems);
    }
}