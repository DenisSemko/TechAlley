namespace Catalog.Application.Features.Catalog.Commands.AddCatalogItem;

public class AddCatalogItemCommandHandler : IRequestHandler<AddCatalogItemCommand, CatalogItemDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddCatalogItemCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<CatalogItemDto> Handle(AddCatalogItemCommand request, CancellationToken cancellationToken)
    {
        CatalogTypeDto catalogType = _mapper.Map<CatalogTypeDto>(await _unitOfWork.CatalogTypes.GetTypeByName(request.CatalogType));
        CatalogBrandDto catalogBrand = _mapper.Map<CatalogBrandDto>(await _unitOfWork.CatalogBrands.GetBrandByName(request.CatalogBrand));
        CatalogItemDto catalogItemDto = _mapper.Map<CatalogItemDto>(request);
        
        await _unitOfWork.CatalogItems.InsertOneAsync(CatalogItemDtoToCatalogItem.Convert(catalogItemDto, catalogType, catalogBrand));

        return catalogItemDto;
    }
}