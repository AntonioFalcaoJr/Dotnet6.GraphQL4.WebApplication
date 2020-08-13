namespace Dotnet5.GraphQL.Store.Services.Models
{
    public abstract class Model<TId>
        where TId : struct
    {
        private TId? Id { get; set; }
    }
}