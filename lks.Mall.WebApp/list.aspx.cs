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
        protected void Page_Load(object sender, EventArgs e)
        {
            BookList = _service.GetModelList(1, 20, null, "Id");
        }
    }
}