using lks.Mall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace lks.Mall.UI
{
    public class BasePage : Page
    {
        public Users CurrentUser { get; set; }

        protected override void OnPreInit(EventArgs e)
        {
            CurrentUser = Session[SessionKeys.CurrentUser] as Users;
            base.OnPreInit(e);
        }
    }
}
