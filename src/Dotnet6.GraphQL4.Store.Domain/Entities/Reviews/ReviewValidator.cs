using System;
using FluentValidation;

namespace Dotnet6.GraphQL4.Store.Domain.Entities.Reviews
{
    public class ReviewValidator : AbstractValidator<Review>
    {
        public ReviewValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty()
                .WithMessage(Resource.Review_Comment_Empty);

            RuleFor(x => x.Comment)
                .NotNull()
                .NotEmpty()
                .WithMessage(Resource.Review_Title_Empty);

            RuleFor(x => x.ProductId)
                .NotNull()
                .NotEqual(Guid.Empty)
                .WithMessage(Resource.Review_Title_Empty);
        }
    }
}