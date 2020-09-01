using FluentValidation;

namespace Dotnet5.GraphQL.Store.Domain.Entities.Products.Backpacks
{
    public class BackpackValidator : ProductValidator<Backpack>
    {
        public BackpackValidator()
        {
            RuleFor(x => x.BackpackType)
                .NotNull()
                .WithMessage(DomainResource.Backpack_Type_Null);
        }
    }
}