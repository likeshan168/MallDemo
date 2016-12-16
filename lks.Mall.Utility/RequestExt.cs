using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace System.Web
{
    public static class RequestExt
    {
        public static bool IsPostBack(this HttpRequest Request)
        {
            return Request.HttpMethod.Equals("post", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
