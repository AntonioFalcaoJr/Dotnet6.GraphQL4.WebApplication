using FluentValidation;

namespace Dotnet5.GraphQL.Store.Domain.Entities.Products
{
    public abstract class ProductValidator<TProduct> : AbstractValidator<TProduct>
        where TProduct : Product
    {
        protected ProductValidator()
        {
            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .WithMessage(DomainResource.Product_Description_Null_Empty);

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage(DomainResource.Product_Name_Null_Empty);

            RuleFor(x => x.Option)
                .NotNull()
                .WithMessage(DomainResource.Product_Option_Null);

            RuleFor(x => x.Price)
                .LessThanOrEqualTo(decimal.Zero)
                .WithMessage(DomainResource.Product_Price_Invalid);
        }
    }
}