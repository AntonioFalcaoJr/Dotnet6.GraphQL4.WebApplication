using FluentValidation;

namespace Dotnet5.GraphQL.Store.Domain.Entities.Reviews
{
    public class ReviewValidator : AbstractValidator<Review>
    {
        public ReviewValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty()
                .WithMessage(DomainResource.Review_Comment_Empty);

            RuleFor(x => x.Comment)
                .NotNull()
                .NotEmpty()
                .WithMessage(DomainResource.Review_Title_Empty);
        }
    }
}