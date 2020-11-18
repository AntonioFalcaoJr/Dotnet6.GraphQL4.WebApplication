using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;

namespace Dotnet5.GraphQL3.Domain.Abstractions.Entities
{
    public abstract class Entity<TId>
        where TId : struct
    {
        public TId Id { get; protected init; }

        [NotMapped]
        public bool IsValid
            => ValidationResult?.IsValid ?? Validate();

        [NotMapped]
        public ValidationResult ValidationResult { get; private set; }

        protected bool OnValidate<TEntity>(TEntity entity, AbstractValidator<TEntity> validator)
        {
            ValidationResult = validator.Validate(entity);
            return IsValid;
        }

        protected void AddError(string errorMessage, ValidationResult validationResult = default)
        {
            ValidationResult.Errors.Add(new ValidationFailure(default, errorMessage));
            validationResult?.Errors.ToList().ForEach(failure => ValidationResult.Errors.Add(failure));
        }

        protected abstract bool Validate();
    }
}