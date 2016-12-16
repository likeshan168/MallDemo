using lks.Mall.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace lks.Mall.WebApp.handler
{
    /// <summary>
    /// vcode 的摘要说明
    /// </summary>
    public class vcode : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "imagg/gif";
            string vcode = CaptchaHelper.CreateRandomCode(4);
            context.Session["user_vcode"] = vcode;
            context.Response.BinaryWrite(CaptchaHelper.DrawImage(vcode, 20, System.Drawing.Color.White));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}