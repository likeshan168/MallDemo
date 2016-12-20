using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace lks.Mall.UI
{
    public class MemberPage : BasePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (CurrentUser==null)
            {
                //没有登录就跳转到登录
                Response.Redirect("/account/login.aspx?returnurl=" + HttpUtility.UrlEncode(Request.Url.ToString()));
            }
        }
    }
}
