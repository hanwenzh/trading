using Model.Common;
using System;
using System.Runtime.Serialization;

namespace Model.DB
{
    [DataContract]
    public class AccountGroupItem
    {
        public int account_group_id { get; set; }

        [DataMember]
        public int account_id { get; set; }

        [DataMember]
        public string account_code { get; set; }

        [DataMember]
        public string account_name { get; set; }

        /// <summary>
        /// 允许最大额度
        /// </summary>
        [DataMember]
        public decimal capital_allow { get; set; }

        /// <summary>
        /// 剩余可用额度
        /// </summary>
        public decimal capital_available { get { return (capital_allow == 0) ? decimal.MaxValue : Math.Max(capital_allow - capital_stock_value, 0);  } set { } }

        [DataMember]
        public int sort_buy { get; set; }

        [DataMember]
        public int sort_sell { get; set; }

        public int unit_id { get; set; }

        [UnValue]
        public decimal capital_stock_value { get; set; }
    }
}