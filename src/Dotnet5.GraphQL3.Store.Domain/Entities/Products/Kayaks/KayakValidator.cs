using FluentValidation;

namespace Dotnet5.GraphQL3.Store.Domain.Entities.Products.Kayaks
{
    public class KayakValidator : AbstractValidator<Kayak>
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