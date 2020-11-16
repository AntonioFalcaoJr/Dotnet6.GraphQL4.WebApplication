namespace Dotnet5.GraphQL3.Repositories.Abstractions.Pages
{
    public class PageParams
    {
        private const int DefaultSize = 10;
        private const int DefaultIndex = 1;
        
        private int _index;
        private int _size;

        public int Size
        {
            get => _size <= 0 ? DefaultSize : _size;
            set => _size = value;
        }

        public int Index
        {
            get => _index <= 0 ? DefaultIndex : _index;
            set => _index = value;
        }
    }
}