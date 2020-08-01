using FluentValidation;
using FluentValidation.Results;

namespace Dotnet5.GraphQL.Store.MVC.Models
{
    public abstract class ClientModel
    {
        public string Result { get; set; }

        public bool IsValid => ValidationResult?.IsValid ?? default;
        public ValidationResult ValidationResult { get; private set; }
    }
}