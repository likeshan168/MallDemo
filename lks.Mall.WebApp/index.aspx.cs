using lks.Mall.UI;
using lks.Mall.WebApp.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lks.Mall.WebApp
{
    public partial class Index : BasePage
    {

        protected Site CurrentMaster
        {
            get
            {
                return Master as Site;
            }
        }

        /// <summary>
        /// 该方法在模板页的page_load之前执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentMaster.CurrentUser = CurrentUser;
        }
    }
}