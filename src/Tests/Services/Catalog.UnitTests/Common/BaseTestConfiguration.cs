namespace Catalog.UnitTests.Common;

public class BaseTestConfiguration : IBaseTestConfiguration
{
    private readonly IMapper _mapper;

    public BaseTestConfiguration()
    {
        MapperConfiguration mapperConfig = new (configuration =>
        {
            configuration.AddProfile<CatalogItemProfile>();
            configuration.AddProfile<CatalogWishlistProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }

    public IMapper DefineMapper() => _mapper;
}