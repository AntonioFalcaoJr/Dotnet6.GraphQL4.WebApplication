namespace Dotnet5.GraphQL3.Services.Abstractions.Models
{
    public abstract record Model<TId>(TId? Id) 
        where TId : struct { }
}