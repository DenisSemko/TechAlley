namespace Catalog.Application.Extensions;

public static class AddCatalogItemCommandValidatorExtensions
{
    public static IRuleBuilderOptions<T, string> BeUniqueName<T>( this IRuleBuilder<T, string> ruleBuilder, IUnitOfWork unitOfWork)
    {
        return ruleBuilder.MustAsync(async (name, cancellation) =>
        {
            return await unitOfWork.CatalogItems.GetAsync(catalogItem => catalogItem.Name == name) == null;
        }).WithMessage("{PropertyName} must be unique");
    }
}