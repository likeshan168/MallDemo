using lks.Mall.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.UI
{
    public static class PagerHelper
    {

        public static string Pager(string url, IPagedList pagedList)
        {
            StringBuilder builder = new StringBuilder();
            if (pagedList != null)
            {
                builder.Append("<script type='text/javascript'>");
                builder.Append("window.onload = function () {");
                builder.Append(" var elements = document.getElementById('pager').childNodes;");
                builder.Append(" for (var i = 0; i < elements.length; i++) {");
                builder.Append("var txt = elements[i].innerText || elements[i].textContent;");
                builder.Append(" if (elements[i].nodeType =='1' && txt == '" + pagedList.PageIndex + "') {");
                builder.Append("elements[i].style.textDecoration = 'underline';break; } } }");
                builder.Append("</script>");
                builder.Append("<div id='pager'>");

                builder.Append("<span class='p'>");
                builder.AppendFormat("共 {0} 条数据  页次：{1}/{2}", pagedList.TotalItemCount, pagedList.PageIndex, pagedList.TotalPageCount, "上一页");
                builder.Append("</span>");
                builder.Append(" ");
                builder.Append(" ");
                builder.Append(" ");
                builder.Append(" ");
                if (pagedList.PageIndex > 1 && pagedList.PageIndex <= pagedList.TotalPageCount)
                {
                    builder.Append("<span class='p'>");
                    builder.AppendFormat("<a href='{0}?PageIndex={1}'>{2}</a>", url, 1, "首页");
                    builder.Append("</span>");
                    builder.Append(" ");
                    builder.Append("<span class='p'>");
                    builder.AppendFormat("<a href='{0}?PageIndex={1}'>{2}</a>", url, pagedList.PageIndex - 1, "上一页");
                    builder.Append("</span>");
                    builder.Append(" ");
                }
                if (pagedList.TotalPageCount > 1 && pagedList.TotalPageCount <= 10)
                {
                    for (int i = 1; i <= pagedList.TotalPageCount; i++)
                    {
                        builder.Append("<span class='p'>");
                        builder.AppendFormat("<a href='{0}?PageIndex={1}'>{2}</a>", url, i, i);
                        builder.Append("</span>");
                        builder.Append(" ");
                    }
                }
                else if (pagedList.TotalPageCount > 10)
                {
                    if (pagedList.PageIndex < 11)
                    {
                        for (int i = 1; i <= 10; i++)
                        {
                            builder.Append("<span class='p'>");
                            builder.AppendFormat("<a href='{0}?PageIndex={1}'>{2}</a>", url, i, i);
                            builder.Append("</span>");
                            builder.Append(" ");
                        }
                        builder.Append("<span class='p'>");
                        builder.AppendFormat("<a href='{0}?PageIndex={1}'>{2}</a>", url, 11, "...");
                        builder.Append("</span>");
                        builder.Append(" ");
                    }
                    else
                    {
                        builder.Append("<span class='p'>");
                        builder.AppendFormat("<a href='{0}?PageIndex={1}'>{2}</a>", url, (pagedList.PageIndex - 6), "...");
                        builder.Append("</span>");
                        builder.Append(" ");
                        if (pagedList.PageIndex >= 11 && pagedList.TotalPageCount <= pagedList.PageIndex + 5)
                        {
                            for (int i = pagedList.PageIndex - 5; i <= pagedList.TotalPageCount; i++)
                            {
                                builder.Append("<span class='p'>");
                                builder.AppendFormat("<a href='{0}?PageIndex={1}'>{2}</a>", url, i, i);
                                builder.Append("</span>");
                                builder.Append(" ");
                            }
                        }
                        else
                        {
                            for (int i = pagedList.PageIndex - 5; i <= pagedList.PageIndex + 5; i++)
                            {
                                builder.Append("<span class='p'>");
                                builder.AppendFormat("<a href='{0}?PageIndex={1}'>{2}</a>", url, i, i);
                                builder.Append("</span>");
                                builder.Append(" ");
                            }
                            builder.Append("<span class='p'>");
                            builder.AppendFormat("<a href='{0}?PageIndex={1}'>{2}</a>", url, (pagedList.PageIndex + 6), "...");
                            builder.Append("</span>");
                            builder.Append(" ");
                        }
                    }

                }
                if (pagedList.PageIndex >= 1 && pagedList.PageIndex < pagedList.TotalPageCount)
                {
                    builder.Append("<span class='p'>");
                    builder.AppendFormat("<a href='{0}?PageIndex={1}'>{2}</a>", url, pagedList.PageIndex + 1, "下一页");
                    builder.Append("</span>");
                    builder.Append(" ");
                    builder.Append("<span class='p'>");
                    builder.AppendFormat("<a href='{0}?PageIndex={1}'>{2}</a>", url, pagedList.TotalPageCount, "尾页");
                    builder.Append("</span>");
                    builder.Append(" ");
                }
                builder.Append("</div>");
            }
            return builder.ToString();
        }


        public static string Pager(string url, IPagedList pagedList, dynamic objAttr)
        {
            StringBuilder builder = new StringBuilder();
            if (pagedList != null)
            {
                builder.Append("<script type='text/javascript'>");
                builder.Append("window.onload = function () {");
                builder.Append(" var elements = document.getElementById('pager').childNodes;");
                builder.Append(" for (var i = 0; i < elements.length; i++) {");
                builder.Append("var txt = elements[i].innerText || elements[i].textContent;");
                builder.Append(" if (elements[i].nodeType =='1' && txt == '" + pagedList.PageIndex + "') {");
                builder.Append("elements[i].style.textDecoration = 'underline';break; } } }");
                builder.Append("</script>");
                string paras = "";
                PropertyInfo[] infos = objAttr.GetType().GetProperties();
                if (infos != null && infos.Any())
                {
                    foreach (var item in infos)
                    {
                        paras += string.Format("{0}={1}", item.Name, item.GetValue(objAttr, null));
                        paras += "&";
                    }
                }
                paras = paras + "PageIndex=";
                builder.Append("<div id='pager'>");

                builder.Append("<span class='p'>");
                builder.AppendFormat("共 {0} 条数据  页次：{1}/{2}", pagedList.TotalItemCount, pagedList.PageIndex, pagedList.TotalPageCount, "上一页");
                builder.Append("</span>");
                builder.Append(" ");
                builder.Append(" ");
                builder.Append(" ");
                builder.Append(" ");


                if (pagedList.PageIndex > 1 && pagedList.PageIndex <= pagedList.TotalPageCount)
                {
                    builder.Append("<span class='p'>");
                    builder.AppendFormat("<a href='{0}?{1}'>{2}</a>", url, paras + 1, "首页");
                    builder.Append("</span>");
                    builder.Append(" ");
                    builder.Append("<span class='p'>");
                    builder.AppendFormat("<a href='{0}?{1}'>{2}</a>", url, paras + (pagedList.PageIndex - 1), "上一页");
                    builder.Append("</span>");
                    builder.Append(" ");
                }
                if (pagedList.TotalPageCount > 1 && pagedList.TotalPageCount <= 10)
                {
                    for (int i = 1; i <= pagedList.TotalPageCount; i++)
                    {
                        builder.Append("<span class='p'>");
                        builder.AppendFormat("<a href='{0}?{1}'>{2}</a>", url, paras + i, i);
                        builder.Append("</span>");
                        builder.Append(" ");
                    }
                }
                else if (pagedList.TotalPageCount > 10)
                {
                    if (pagedList.PageIndex < 11)
                    {
                        for (int i = 1; i <= 10; i++)
                        {
                            builder.Append("<span class='p'>");
                            builder.AppendFormat("<a href='{0}?{1}'>{2}</a>", url, paras + i, i);
                            builder.Append("</span>");
                            builder.Append(" ");
                        }
                        builder.Append("<span class='p'>");
                        builder.AppendFormat("<a href='{0}?{1}'>{2}</a>", url, paras + 11, "...");
                        builder.Append("</span>");
                        builder.Append(" ");
                    }
                    else
                    {
                        builder.Append("<span class='p'>");
                        builder.AppendFormat("<a href='{0}?{1}'>{2}</a>", url, paras + (pagedList.PageIndex - 6), "...");
                        builder.Append("</span>");
                        builder.Append(" ");
                        if (pagedList.PageIndex >= 11 && pagedList.TotalPageCount <= pagedList.PageIndex + 5)
                        {
                            for (int i = pagedList.PageIndex - 5; i <= pagedList.TotalPageCount; i++)
                            {
                                builder.Append("<span class='p'>");
                                builder.AppendFormat("<a href='{0}?{1}'>{2}</a>", url, paras + i, i);
                                builder.Append("</span>");
                                builder.Append(" ");
                            }
                        }
                        else
                        {
                            for (int i = pagedList.PageIndex - 5; i <= pagedList.PageIndex + 5; i++)
                            {
                                builder.Append("<span class='p'>");
                                builder.AppendFormat("<a href='{0}?{1}'>{2}</a>", url, paras + i, i);
                                builder.Append("</span>");
                                builder.Append(" ");
                            }
                            builder.Append("<span class='p'>");
                            builder.AppendFormat("<a href='{0}?{1}'>{2}</a>", url, paras + (pagedList.PageIndex + 6), "...");
                            builder.Append("</span>");
                            builder.Append(" ");
                        }

                    }

                }
                if (pagedList.PageIndex >= 1 && pagedList.PageIndex < pagedList.TotalPageCount)
                {
                    builder.Append("<span class='p'>");
                    builder.AppendFormat("<a href='{0}?{1}'>{2}</a>", url, paras + (pagedList.PageIndex + 1), "下一页");
                    builder.Append("</span>");
                    builder.Append(" ");
                    builder.Append("<span class='p'>");
                    builder.AppendFormat("<a href='{0}?{1}'>{2}</a>", url, paras + pagedList.TotalPageCount, "尾页");
                    builder.Append("</span>");
                    builder.Append(" ");
                }
                builder.Append("</div>");
            }
            return builder.ToString();
        }


        public static string RenderPager(string format, int totalPages, int current = 1, int showCount = 9, string ulContainerClass = "pagination", string activeClass = "active", char separator = '@')
        {
            #region 拆分字符串

            string[] tempArr = format.Split(separator);
            string prefix = tempArr[0];
            string suffix = string.Empty;
            if (tempArr.Length == 2)
            {
                suffix = tempArr[1];
            }

            #endregion

            #region 计算前后位置
            //计算前后留多少页
            int region = (int)Math.Floor(showCount / 2.0);
            //计算开始数
            int beginNum = current - region;
            if (beginNum < 1)
            {
                beginNum = 1;
            }
            //计算结束数
            int endNum = beginNum + showCount;
            if (endNum > totalPages)
            {
                endNum = totalPages + 1;
                beginNum = endNum - showCount;
                beginNum = beginNum < 1 ? 1 : beginNum;
            }
            #endregion

            //创建html
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<ul class = '{0}'>", ulContainerClass);
            if (current != 1)
            {
                sb.AppendFormat("\t<li><a href=\"{0}{1}{2}\">上一页</a></li>\r\n", prefix, current - 1, suffix);
            }
            if (beginNum != 1)
            {
                sb.Append("\t<li><span>&hellip;</span></li>\r\n");
            }
            for (int i = beginNum; i < endNum; i++)
            {
                if (i == current)
                {
                    sb.AppendFormat("\t<li class='{0}'><span>{1}</span></li>\r\n", activeClass, i);
                }
                else
                {
                    sb.AppendFormat("\t<li><a href=\"{0}{1}{2}\">{1}</a></li>\r\n", prefix, i, suffix);
                }
            }
            if (endNum != totalPages + 1)
            {
                sb.Append("\t<li><span>&hellip;</span></li>\r\n");
            }
            if (current != totalPages)
            {
                sb.AppendFormat("\t<li><a href=\"{0}{1}{2}\">下一页</a></li>\r\n", prefix, current + 1, suffix);
            }

            sb.Append("</ul>");

            return sb.ToString();

        }
    }
}
