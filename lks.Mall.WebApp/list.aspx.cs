using lks.Mall.BLL;
using lks.Mall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lks.Mall.WebApp
{
    public partial class list : System.Web.UI.Page
    {
        public IEnumerable<Books> BookList { get; set; }
        private BooksService _service = new BooksService();
        private CategoriesService _catService = new CategoriesService();
        private int pageSize =20;

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public Categories CurrentCategory { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentPage = Request["page"].ToInt32(1);
            int category = Request["cat"].ToInt32();
            if (category == 0)
            {
                throw new HttpException(404, "Not Found");
            }
            CurrentCategory = _catService.QuerySingle(new { Id = category });
            if (CurrentCategory == null)
            {
                throw new HttpException(404, "Not Found");
            }
            var where = new { CategoryId = CurrentCategory.Id };
            TotalCount = _service.QueryCount(where);
            TotalPages = (int)Math.Ceiling(TotalCount / (double)pageSize);
            BookList = _service.QueryList(CurrentPage, 20, where, "Id");
        }
    }
}