namespace Dotnet5.GraphQL3.Repositories.Abstractions.Pages
{
    public record PageInfo
    {
        public int Current { get; init; }
        public int Size { get; init; }
        public bool HasPrevious { get; init; }
        public bool HasNext { get; init; }
    }
}