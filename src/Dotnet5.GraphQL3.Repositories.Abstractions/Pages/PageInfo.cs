namespace Dotnet5.GraphQL3.Repositories.Abstractions.Pages
{
    public class PageInfo
    {
        public int Current { get; set; }
        public int Size { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
    }
}