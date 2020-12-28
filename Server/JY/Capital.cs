using System;

namespace JY
{
    public class Capital
    {
        public Capital(string data)
        {
            string[] items = data.Split(',');
            available = items[0];
            value = items[1];
            profit = items[2];
            assets = items[3];
        }

        /// <summary>
        /// 可用
        /// </summary>
        public string available { get; set; }

        /// <summary>
        /// 市值
        /// </summary>
        public string value { get; set; }

        /// <summary>
        /// 盈亏
        /// </summary>
        public string profit { get; set; }

        /// <summary>
        /// 总资产
        /// </summary>
        public string assets { get; set; }
    }
}