using lks.Mall.Model.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace lks.Mall.WebApp.handler
{
    /// <summary>
    /// FileUploadHandler 的摘要说明
    /// </summary>
    public class FileUploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //for (int i = 0; i < context.Request.Files.Count; i++)
            //{
            //    HttpPostedFile file = context.Request.Files[i];
            //    string fileName = Path.GetFileName(file.FileName);
            //    file.SaveAs(context.Server.MapPath(string.Format("~/uploads/{0}", fileName)));
            //}

            HandlerAction action = context.Request.QueryString["action"].ToEnum<HandlerAction>();
            switch (action)
            {
                case HandlerAction.Upload:
                    HandleUploadFile(context);
                    break;
                case HandlerAction.Cut:
                    HandleCut(context);
                    break;
                default:
                    break;
            }
           
        }

        private void HandleCut(HttpContext context)
        {
            //接受客户端参数
            int width = context.Request["width"].ToInt32();
            int height = context.Request["height"].ToInt32();
            int top = context.Request["top"].ToInt32();
            int left = context.Request["left"].ToInt32();
            string filePath = context.Request["filePath"];

            //创建画布
            using (Bitmap map = new Bitmap(width, height))
            {
                //创建画笔
                using (Graphics g = Graphics.FromImage(map))
                {
                    //创建素材
                    using (Image img = Image.FromFile(context.Server.MapPath(filePath)))
                    {
                        g.DrawImage(img, new Rectangle(0, 0, map.Width, map.Height), new Rectangle(left, top, map.Width, map.Height),GraphicsUnit.Pixel);
                        string vpath = string.Format("/uploads/{0}.jpg",Guid.NewGuid().ToString("N"));
                        map.Save(context.Server.MapPath(vpath));
                        context.Response.Write(vpath);
                        context.Response.End();
                    }
                }
            }
        }

        private void HandleUploadFile(HttpContext context)
        {
            HttpPostedFile file = context.Request.Files[0];
            string fileName = Path.GetFileName(file.FileName);
            string vPath = string.Format("~/uploads/{0}", fileName);
            file.SaveAs(context.Server.MapPath(vPath));
            context.Response.Write(vPath);
            context.Response.End();
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