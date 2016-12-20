using lks.Mall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lks.Mall.WebApp.shared
{
    public partial class Site : MasterPage
    {
        public Users CurrentUser { get; set; }
         
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}