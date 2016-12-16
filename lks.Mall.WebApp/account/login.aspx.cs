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
                Response.Write("用户名和密码不能为空");
                Response.End();
                return;
            }
            object scode = Session["user_vcode"];
            if (scode == null || !scode.ToString().Equals(vcode, StringComparison.InvariantCultureIgnoreCase))
            {
                Response.Write("验证码不正确");
                Response.End();
                return;
            }
            //3.调用业务逻辑验证用户名和密码是否正确
            _service = new UsersService();
            Users user;
            LoginResult rst = _service.Login(userName, password, out user);
            //4.根据验证结果返回给客户端
            Response.Write(rst.ToString());
            Response.End();
        }
    }
}