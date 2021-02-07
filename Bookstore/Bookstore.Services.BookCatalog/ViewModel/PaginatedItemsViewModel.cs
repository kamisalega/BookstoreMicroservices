using System.Collections.Generic;
using Bookstore.Services.BookCatalog.Models;

namespace Bookstore.Services.BookCatalog.ViewModel
{
    public class PaginatedItemsViewModel<TEntity> where TEntity : class
    {
        public PaginatedItemsViewModel(int pageSize, int pageIndex, long count, IEnumerable<TEntity> data)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.Count = count;
            this.Data = data;
        }

        public IEnumerable<TEntity> Data { get; set; }

        public long Count { get; set; }

        public int PageSize { get; set; }

        public int PageIndex { get; set; }
    }
}
