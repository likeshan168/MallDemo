using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lks.Mall.Utility
{
    public interface IPagedList
    {
        int PageIndex { get; set; }
        int PageSize { get; set; }
        int TotalItemCount { get; set; }
        int TotalPageCount { get; }
    }
}
