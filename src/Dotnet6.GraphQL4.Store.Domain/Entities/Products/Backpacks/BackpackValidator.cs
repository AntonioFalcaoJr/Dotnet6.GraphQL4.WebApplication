using FluentValidation;

namespace Dotnet6.GraphQL4.Store.Domain.Entities.Products.Backpacks
{
    public class BackpackValidator : ProductValidator<Backpack>
    {
        public BackpackValidator()
        {
            RuleFor(x => x.BackpackType)
                .NotNull()
                .WithMessage(Resource.Backpack_Type_Null);
        }
    }
}