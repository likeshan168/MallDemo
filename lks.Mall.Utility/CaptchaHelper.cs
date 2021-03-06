﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lks.Mall.Utility
{
    public class CaptchaHelper
    {
        #region 随机验证码 +CreateRandomCode(int length)
        /// <summary>
        /// 随机验证码
        /// </summary>
        /// <param name="length">随机码个数</param>
        /// <returns>返回指定个数的随机码</returns>
        public static string CreateRandomCode(int length)
        {
            return Guid.NewGuid().ToString("N").Substring(0, length);
        } 
        #endregion
        #region 创建随机码图片 +DrawImage(string vcode, float fontSize = 14, Color backGround = default(Color), Color border = default(Color))
        /// <summary>
        /// 创建随机码图片
        /// </summary>
        /// <param name="vcode">验证码</param>
        /// <param name="fontSize">字体大小</param>
        /// <param name="backGround">背景颜色</param>
        /// <param name="border">边框颜色</param>
        /// <returns>Gif图片二进制流</returns>
        public static byte[] DrawImage(string vcode, float fontSize = 14, Color backGround = default(Color), Color border = default(Color))
        {
            const int RandAngle = 45;
            var width = vcode.Length * (int)fontSize;
            using (var map = new Bitmap(width + 3, (int)fontSize + 10))
            {
                using (var graphics = Graphics.FromImage(map))
                {
                    graphics.Clear(backGround);
                    graphics.DrawRectangle(new Pen(border, 0), 0, 0, map.Width - 1, map.Height - 1);

                    //背景噪点生成
                    var random = new Random();
                    var blackPen = new Pen(Color.DarkGray, 0);
                    for (int i = 0; i < 50; i++)
                    {
                        int x = random.Next(0, map.Width);
                        int y = random.Next(0, map.Height);
                        graphics.DrawRectangle(blackPen, x, y, 1, 1);
                    }

                    var chars = vcode.ToCharArray();
                    //文字居中
                    var format = new StringFormat(StringFormatFlags.NoClip)
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };

                    //定义颜色
                    Color[] colors = { Color.Black, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple, Color.DarkGoldenrod };
                    FontStyle[] styles = { FontStyle.Bold, FontStyle.Italic, FontStyle.Regular, FontStyle.Underline };

                    //定义字体
                    string[] fonts = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };

                    foreach (var item in chars)
                    {
                        int cindex = random.Next(8);
                        int findex = random.Next(5);
                        int sindex = random.Next(4);

                        var font = new Font(fonts[findex], fontSize, styles[sindex]);
                        Brush b = new SolidBrush(colors[cindex]);
                        var dot = new Point(16, 16);
                        float angle = random.Next(-RandAngle, RandAngle);//转动的度数
                        graphics.TranslateTransform(dot.X, dot.Y);//移动光标到指定的位置
                        graphics.RotateTransform(angle);
                        graphics.DrawString(item.ToString(CultureInfo.InvariantCulture), font, b, 1, 1, format);

                        graphics.RotateTransform(-angle);//转回去
                        graphics.TranslateTransform(2, -dot.Y);//移动光标到指定的位置
                    }
                }
                //生成图片
                var stream = new MemoryStream();
                map.Save(stream, ImageFormat.Gif);
                //输出图片流
                return stream.ToArray();
            }
        } 
        #endregion
    }
}
