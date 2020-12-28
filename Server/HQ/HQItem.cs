using System;

namespace HQ
{
    public class HQItem
    {
        public HQItem()
        { }


        public HQItem(string data)
        {
            string[] items = data.Split(',');
            Code = items[0];
            Name = items[1];
            High = decimal.Parse(items[2]);
            Open = decimal.Parse(items[3]);
            Low = decimal.Parse(items[4]);
            Close = decimal.Parse(items[5]);
            Close_Prev = decimal.Parse(items[6]);
            Last = decimal.Parse(items[7]);
            Volume = int.Parse(items[8]);
            Amount = decimal.Parse(items[9]);
            Buy_1 = decimal.Parse(items[10]);
            Buy_2 = decimal.Parse(items[11]);
            Buy_3 = decimal.Parse(items[12]);
            Buy_4 = decimal.Parse(items[13]);
            Buy_5 = decimal.Parse(items[14]);
            Buy_Volume_1 = int.Parse(items[15]);
            Buy_Volume_2 = int.Parse(items[16]);
            Buy_Volume_3 = int.Parse(items[17]);
            Buy_Volume_4 = int.Parse(items[18]);
            Buy_Volume_5 = int.Parse(items[19]);
            Sell_1 = decimal.Parse(items[20]);
            Sell_2 = decimal.Parse(items[21]);
            Sell_3 = decimal.Parse(items[22]);
            Sell_4 = decimal.Parse(items[23]);
            Sell_5 = decimal.Parse(items[24]);
            Sell_Volume_1 = int.Parse(items[25]);
            Sell_Volume_2 = int.Parse(items[26]);
            Sell_Volume_3 = int.Parse(items[27]);
            Sell_Volume_4 = int.Parse(items[28]);
            Sell_Volume_5 = int.Parse(items[29]);
            Time = items[30];
            Date = items[31];
            Limit_High = decimal.Parse(items[32]);
            Limit_Low = decimal.Parse(items[33]);
        }

        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 最高价
        /// </summary>
        public decimal High { get; set; }

        /// <summary>
        /// 开盘价
        /// </summary>
        public decimal Open { get; set; }

        /// <summary>
        /// 最低价
        /// </summary>
        public decimal Low { get; set; }

        /// <summary>
        /// 收盘价
        /// </summary>
        public decimal Close { get; set; }

        /// <summary>
        /// 昨收盘价
        /// </summary>
        public decimal Close_Prev { get; set; }

        /// <summary>
        /// 最新价
        /// </summary>
        public decimal Last { get; set; }

        /// <summary>
        /// 成交量
        /// </summary>
        public int Volume { get; set; }

        /// <summary>
        /// 成交金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 买1价
        /// </summary>
        public decimal Buy_1 { get; set; }

        /// <summary>
        /// 买2价
        /// </summary>
        public decimal Buy_2 { get; set; }

        /// <summary>
        /// 买3价
        /// </summary>
        public decimal Buy_3 { get; set; }

        /// <summary>
        /// 买4价
        /// </summary>
        public decimal Buy_4 { get; set; }

        /// <summary>
        /// 买5价
        /// </summary>
        public decimal Buy_5 { get; set; }

        /// <summary>
        /// 买1量
        /// </summary>
        public int Buy_Volume_1 { get; set; }

        /// <summary>
        /// 买2量
        /// </summary>
        public int Buy_Volume_2 { get; set; }

        /// <summary>
        /// 买3量
        /// </summary>
        public int Buy_Volume_3 { get; set; }

        /// <summary>
        /// 买4量
        /// </summary>
        public int Buy_Volume_4 { get; set; }

        /// <summary>
        /// 买5量
        /// </summary>
        public int Buy_Volume_5 { get; set; }

        /// <summary>
        /// 卖1价
        /// </summary>
        public decimal Sell_1 { get; set; }

        /// <summary>
        /// 卖2价
        /// </summary>
        public decimal Sell_2 { get; set; }

        /// <summary>
        /// 卖3价
        /// </summary>
        public decimal Sell_3 { get; set; }

        /// <summary>
        /// 卖4价
        /// </summary>
        public decimal Sell_4 { get; set; }

        /// <summary>
        /// 卖5价
        /// </summary>
        public decimal Sell_5 { get; set; }

        /// <summary>
        /// 卖1量
        /// </summary>
        public int Sell_Volume_1 { get; set; }

        /// <summary>
        /// 卖2量
        /// </summary>
        public int Sell_Volume_2 { get; set; }

        /// <summary>
        /// 卖3量
        /// </summary>
        public int Sell_Volume_3 { get; set; }

        /// <summary>
        /// 卖4量
        /// </summary>
        public int Sell_Volume_4 { get; set; }

        /// <summary>
        /// 卖5量
        /// </summary>
        public int Sell_Volume_5 { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// 涨停价
        /// </summary>
        public decimal Limit_High { get; set; }

        /// <summary>
        /// 跌停价
        /// </summary>
        public decimal Limit_Low { get; set; }
    }
}