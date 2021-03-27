namespace Dotnet6.GraphQL4.Repositories.Abstractions.Pages
{
    public record PageParams
    {
        private const int DefaultSize = 10;
        private const int DefaultIndex = 1;

        private readonly int _index;
        private readonly int _size;

        public int Size
        {
            get => _size <= 0 ? DefaultSize : _size;
            init => _size = value;
        }

        public int Index
        {
            get => _index <= 0 ? DefaultIndex : _index;
            init => _index = value;
        }
    }
}