using lks.Mall.BLL;
using lks.Mall.Model;
using lks.Mall.Model.Enum;
using System;
using System.Web;
using System.Web.UI;

namespace lks.Mall.WebApp.account
{
    public partial class login : Page
    {
        public string Message = string.Empty;
        private UsersService _service;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsPostBack())
            {
                Login();
            }
        }

        private void Login()
        {
            //1.获取表单内容
            string userName = Request.Form["userName"];
            string password = Request.Form["password"];
            string vcode = Request.Form["vcode"];
            string rememberMe = Request.Form["rememberMe"];
            //2.验证用户名，密码以及验证码
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                //Response.Write("用户名和密码不能为空");
                //Response.End();
                Message = "用户名和密码不能为空";

                return;
            }
            object scode = Session["user_vcode"];
            if (scode == null || !scode.ToString().Equals(vcode, StringComparison.InvariantCultureIgnoreCase))
            {
                //Response.Write("验证码不正确");
                //Response.End();

                Message = "验证码不正确";
                return;
            }
            //3.调用业务逻辑验证用户名和密码是否正确
            _service = new UsersService();
            Users user;
            LoginResult rst = _service.Login(userName, password, out user);
            //4.根据验证结果返回给客户端
            switch (rst)
            {
                case LoginResult.登录成功:
                    if (!string.IsNullOrWhiteSpace(rememberMe))
                    {
                        HttpCookie cuser = new HttpCookie("uid", userName) { Expires = DateTime.Now.AddDays(7) };
                        HttpCookie cpwd = new HttpCookie("pwd", password) { Expires = DateTime.Now.AddDays(7) };
                        Response.Cookies.Add(cuser);
                        Response.Cookies.Add(cpwd);
                    }
                    string returnUrl = Request[QueryStrKey.ReturnUrl];
                    if (string.IsNullOrWhiteSpace(returnUrl))
                    {
                        returnUrl = "/";
                    }
                    Session[SessionKeys.CurrentUser] = user;
                    Response.Redirect(returnUrl);
                    return;
                case LoginResult.用户名不存在:
                case LoginResult.密码错误:
                    Message = "用户名或密码错误";
                    break;
                case LoginResult.用户名异常:
                    Message = "用户名或密码错误";
                    break;
            }

        }
    }
}