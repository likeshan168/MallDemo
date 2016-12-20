﻿<%@ Page Title="" Language="C#" MasterPageFile="~/shared/Site.Master" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="lks.Mall.WebApp.list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="row clearfix">
        <div class="col-md-12 column">
            <%foreach (var book in BookList)
                {%>
            <div class="col-md-3">
                <div class="thumbnail">
                    <img alt="300x200" width="300" height="200" src="/content/BookCovers/<%=book.ISBN %>.jpg" />
                    <div class="caption">
                        <h3><%=book.Title %>
                        </h3>
                        <p>
                            <%=book.UnitPrice %>
                        </p>
                        <p>
                            <%=book.AurhorDescription %>
                        </p>
                        <p>
                            <a class="btn" href="#">加入购物车</a> <a class="btn" href="#">收藏</a>
                        </p>
                    </div>
                </div>
            </div>
            <%}%>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
