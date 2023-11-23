using FluentValidation;

namespace Application.Product.Command.AddProduct;

public class AddProductValidator : AbstractValidator<AddProductRequest>
{
    public AddProductValidator()
    {
        RuleFor(p => p.Name)
            .MinimumLength(3)
            .WithMessage((x, y) => $"{y} is not ok for {nameof(x.Name)}");
    }
}