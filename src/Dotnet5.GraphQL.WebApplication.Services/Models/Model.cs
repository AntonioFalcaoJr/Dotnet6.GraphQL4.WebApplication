namespace Dotnet5.GraphQL.WebApplication.Services.Models
{
    public abstract class Model<TId>
        where TId : struct
    {
        private TId? Id { get; set; }
    }
}