using lks.Mall.BLL;
using lks.Mall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lks.Mall.WebApp.account
{
    public partial class register : System.Web.UI.Page
    {
        private UsersService _service;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsPostBack())
            {
                return;
            }
            //1. 获取表单数据
            string userName = Request.Form["userName"];
            string password = Request.Form["password"];
            string confirmPassword = Request.Form["confirmPassword"];
            string vcode = Request.Form["vcode"];
            //2. 验证表单数据
            if (string.IsNullOrWhiteSpace(userName))
            {
                Response.Write("shit：userName");
                Response.End();
                return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                Response.Write("shit:password");
                Response.End();
                return;
            }
            if (string.IsNullOrWhiteSpace(confirmPassword))
            {
                Response.Write("shit:confirmPassword");
                Response.End();
                return;
            }

            var sCode = Session["user_vcode"];
            Session["user_vcode"] = null;
            if (sCode == null || sCode.ToString() != vcode)
            {
                Response.Write("验证码错误");
                Response.End();
                return;
            }
            //3. 执行业务逻辑
            _service = new UsersService();
            Users user;
            int result = _service.Register(userName, password, out user);


            //4. 根据业务逻辑返回响应结果给客户端

            string msg = string.Empty;
            switch (result)
            {
                case 0:
                    msg = "注册成功！";
                    break;
                case 1:
                    msg = "该用户名已经存在！";
                    break;
                case 2:
                    msg = "注册失败！";
                    break;
                default:
                    break;
            }

            Response.Write(msg);
            Response.End();
        }
    }
}