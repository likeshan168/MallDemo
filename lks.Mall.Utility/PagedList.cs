using System.Collections.Generic;
using System.Linq;

namespace lks.Mall.Utility
{
    public class PagedList<T> : List<T>, IPagedList
    {
        public int PageIndex
        {
            get; set;
        }

        public int PageSize
        {
            get; set;
        }

        public int TotalItemCount
        {
            get; set;
        }

        public int TotalPageCount
        {
            get
            {
                return TotalItemCount % PageSize == 0 ? (TotalItemCount / PageSize) : (TotalItemCount / PageSize + 1);
            }
        }

        public PagedList(IEnumerable<T> sources, int pageIndex, int pageSize)
        {
            if (sources != null && sources.Any())
            {
                AddRange(sources.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList());
            }
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalItemCount = sources.Count();
        }
    }
}
