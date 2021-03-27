using FluentValidation;

namespace Dotnet6.GraphQL4.Store.Domain.Entities.Products.Kayaks
{
    public class KayakValidator : ProductValidator<Kayak>
    {
        public KayakValidator()
        {
            RuleFor(x => x.KayakType)
                .NotNull()
                .WithMessage(Resource.Kayak_Type_Null);

            RuleFor(x => x.AmountOfPerson)
                .GreaterThan(0)
                .WithMessage(Resource.Kayak_Type_Null);
        }
    }
}