using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class ConverterHelper
    {
        #region 将string转换成对应的枚举类型 +ToEnum<T>(this string str) where T : struct
        /// <summary>
        /// 将string转换成对应的枚举类型
        /// </summary>
        /// <typeparam name="T">枚举的类型</typeparam>
        /// <param name="str">需要转换的字符串</param>
        /// <returns>所需枚举类型</returns>
        public static T ToEnum<T>(this string str, T def = default(T)) where T : struct
        {
            try
            {
                T rst;
                if (Enum.TryParse<T>(str, out rst))
                {
                    return rst;
                }
                else
                {
                    return def;
                }
            }
            catch
            {
                return def;
            }
        }
        #endregion

        #region 将string类型转换成int类型 +ToInt32(this string str, int def = default(int))
        /// <summary>
        /// 将string类型转换成int类型
        /// </summary>
        /// <param name="str">需要转换的字符串</param>
        /// <param name="def">转换失败的默认值，不提供默认为0</param>
        /// <returns>转换成int类型之后的结果</returns>
        public static int ToInt32(this string str, int def = default(int))
        {
            try
            {
                int rst;
                if (int.TryParse(str, out rst))
                {
                    return rst;
                }
                else
                {
                    return def;
                }
            }
            catch
            {

                return def;
            }
        }
        #endregion

        public static float ToFloat(this string str, float def = default(float))
        {
            try
            {
                float rst;
                if (float.TryParse(str, out rst))
                {
                    return rst;
                }
                else
                {
                    return def;
                }
            }
            catch
            {

                return def;
            }
        }
    }
}
