using FluentValidation;

namespace Dotnet5.GraphQL3.Store.Domain.Entities.Products.Boots
{
    public class BootValidator : AbstractValidator<Boot>
    {
        public BootValidator()
        {
            RuleFor(x => x.Size)
                .GreaterThan(0)
                .WithMessage(Resource.Boot_Size_Invalid);

            RuleFor(x => x.BootType)
                .NotNull()
                .WithMessage(Resource.Boot_Type_Null);
        }
    }
}