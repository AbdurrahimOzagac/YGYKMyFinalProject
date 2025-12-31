using System.Data;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {

        RuleFor(p => p.ProductName).NotEmpty().WithMessage("Product name is required");
        RuleFor(p => p.ProductName).MinimumLength(2).WithMessage("Product name must be at least 2 characters");
        RuleFor(p => p.UnitPrice).NotEmpty().WithMessage("Unit price is required");
        RuleFor(p => p.UnitPrice).GreaterThan(0).WithMessage("Unit price must be greater than 0");
        RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
        RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Category is required");
        RuleFor(p => p.ProductName).Must(arg => StartWith(arg, "A")).WithMessage("Product Name must start with 'A' ");
    }

    private bool StartWith(string arg, string letter)
    {
        if (string.IsNullOrEmpty(arg)) return false;
        return arg.StartsWith(letter);
    }
}
