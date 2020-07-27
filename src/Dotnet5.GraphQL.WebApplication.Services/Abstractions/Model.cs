namespace Dotnet5.GraphQL.WebApplication.Services.Abstractions
{
    public abstract class Model<TId>
        where TId : struct
    {
        private TId? Id { get; set; }
    }
}