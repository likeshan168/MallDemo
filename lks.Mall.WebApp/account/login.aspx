<%@ Page Title="" Language="C#" MasterPageFile="~/shared/Site.master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="lks.Mall.WebApp.account.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--hello-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <form class="form-horizontal" action="login.aspx" method="post">
            <div class="control-group">
                <label class="control-label" for="inputEmail">邮箱</label>
                <div class="controls">
                    <input id="inputEmail" name="userName" placeholder="Email" type="text">
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="inputPassword">密码</label>
                <div class="controls">
                    <input id="inputPassword" name="password" placeholder="Password" type="password">
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
                    <label class="checkbox">
                        <input type="checkbox" name="rememberMe">
                        Remember me
                    </label>
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
