<%@ Page Title="" Language="C#" MasterPageFile="~/shared/Site.master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="lks.Mall.WebApp.account.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <form class="form-horizontal" action="register.aspx" method="post">
            <div class="control-group">
                <label class="control-label" for="inputEmail">邮箱/用户名/手机号</label>
                <div class="controls">
                    <input id="inputEmail" name="userName" placeholder="邮箱/用户名/手机号" type="text">
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="inputPassword1">密码</label>

                <div class="controls">
                    <input id="inputPassword1" name="password" placeholder="密码" type="password">
                </div>
            </div>
            <div class="control-group">
                <label class="control-label"  for="inputPassword2">确认密码</label>

                <div class="controls">
                    <input id="inputPassword2" name="confirmPassword" placeholder="确认密码" type="password">
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="inputCode">验证码</label>
                <div class="controls">
                    <input id="inputCode" name="vcode" placeholder="验证码" type="text">
                    <span>
                        <img src="/handler/vcode.ashx" id="vcode_img" data-src="/handler/vcode.ashx" height="32" width="100"></span>
                </div>
            </div>
            <div class="control-group">
                <div class="controls">
                    <button type="submit" class="btn">登陆</button>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
    <script>
        $("#vcode_img").click(function () {
            $(this).attr("src",$(this).data("src")+"?"+Math.random());
        });
    </script>
</asp:Content>
