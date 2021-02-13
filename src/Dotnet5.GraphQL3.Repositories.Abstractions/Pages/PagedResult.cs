using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dotnet5.GraphQL3.Repositories.Abstractions.Pages
{
    public class PagedResult<T>
    {
        private readonly int _index;
        private readonly IEnumerable<T> _items;
        private readonly int _size;

        public PagedResult(IEnumerable<T> items, int index, int size)
        {
            _items = items;
            _index = index;
            _size = size;
        }

        public IEnumerable<T> Items
            => _items.Take(_size);

        public PageInfo PageInfo
            => new()
            {
                Current = _index, 
                Size = Items.Count(), 
                HasNext = _size < _items.Count(), 
                HasPrevious = _index > 1
            };

        public static async Task<PagedResult<T>> CreateAsync(IQueryable<T> source, PageParams pageParams, CancellationToken cancellationToken)
        {
            pageParams ??= new();
            var items = await ApplyPagination(source, pageParams).ToListAsync(cancellationToken);
            return new PagedResult<T>(items, pageParams.Index, pageParams.Size);
        }

        public static PagedResult<T> Create(IQueryable<T> source, PageParams pageParams)
        {
            pageParams ??= new();
            var items = ApplyPagination(source, pageParams).ToList();
            return new PagedResult<T>(items, pageParams.Index, pageParams.Size);
        }

        private static IQueryable<T> ApplyPagination(IQueryable<T> source, PageParams pageParams)
            => source.Skip(pageParams.Size * (pageParams.Index - 1)).Take(pageParams.Size + 1);
    }
}