namespace Catalog.Application.Features.Catalog.Commands.UpdateCatalogItem;

public class UpdateCatalogItemCommandValidator : AbstractValidator<AddCatalogItemCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    public UpdateCatalogItemCommandValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{Name} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{Name} must not exceed 50 characters.")
            .BeUniqueName(unitOfWork);

        RuleFor(p => p.Price)
            .NotEmpty().WithMessage("{Price} is required.")
            .GreaterThan(0).WithMessage("{Price} should be greater than zero.");

        RuleFor(p => p.CatalogType)
            .NotEmpty().WithMessage("{CatalogType} is required.")
            .NotNull();

        RuleFor(p => p.CatalogBrand)
            .NotEmpty().WithMessage("{CatalogBrand} is required.")
            .NotNull();
        
        RuleFor(p => p.Quantity)
            .NotEmpty().WithMessage("{Quantity} is required.")
            .GreaterThan(0).WithMessage("{Quantity} should be greater than zero.");
    }
}
