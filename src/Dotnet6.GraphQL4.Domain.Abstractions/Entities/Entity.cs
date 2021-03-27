using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;

namespace Dotnet6.GraphQL4.Domain.Abstractions.Entities
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

        protected bool OnValidate<TValidator, TEntity>(TEntity entity, TValidator validator)
            where TValidator : AbstractValidator<TEntity>
            where TEntity : Entity<TId>
        {
            ValidationResult = validator.Validate(entity);
            return IsValid;
        }

        protected bool OnValidate<TValidator, TEntity>(TEntity entity, TValidator validator, Func<AbstractValidator<TEntity>, TEntity, ValidationResult> validation)
            where TValidator : AbstractValidator<TEntity>
            where TEntity : Entity<TId>
        {
            ValidationResult = validation(validator, entity);
            return IsValid;
        }

        protected void AddError(string errorMessage, ValidationResult validationResult = default)
        {
            ValidationResult.Errors.Add(new(default, errorMessage));
            validationResult?.Errors.ToList().ForEach(failure => ValidationResult.Errors.Add(failure));
        }

        protected abstract bool Validate();
    }
}