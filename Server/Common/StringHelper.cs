using Microsoft.International.Converters.PinYinConverter;
using System;
using System.Text;

namespace Common
{
    public class StringHelper
    {
        /// <summary>
        /// 汉字转拼音缩写
        /// MuseStudio@hotmail.com
        /// </summary>
        /// <param name="str">要转换的汉字字符串</param>
        /// <returns>拼音缩写</returns>
        public static string GetPYString(string str)
        {
            string tempStr = "";
            foreach (char c in str)
            {
                if (c == ' ')
                {
                    continue;
                }
                else if (c == 'Ａ')
                {
                    tempStr += 'A';
                }
                else if ((int)c >= 33 && (int)c <= 126)//字母和符号原样保留
                {
                    tempStr += c;
                }
                else//累加拼音声母
                {
                    tempStr += GetPYChar(c);
                }
            }
            return tempStr.ToUpper();
        }

        /// <param name="c">要转换的单个汉字</param>
        /// <returns>拼音声母</returns>
        private static string GetPYChar(char c)
        {
            ChineseChar chn = new ChineseChar(c);
            if(chn != null && chn.Pinyins.Length > 0)
                return chn.Pinyins[0].Substring(0, 1);
            return "";
        }
    }
}