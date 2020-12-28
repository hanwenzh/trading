using MySQLSrv.Helper;
using System;
using HQ;
using System.Collections.Generic;
using System.Data;

namespace MySQLSrv
{
    public class HQDA
    {
        public static void Add(HQItem model)
        {
            string sql = "INSERT INTO hq(Code,Name,High,Open,Low,Close,Close_Prev,Last,Volume,Amount,Buy_1,Buy_2,Buy_3,Buy_4,Buy_5,Buy_Volume_1,Buy_Volume_2,Buy_Volume_3,Buy_Volume_4,Buy_Volume_5,Sell_1,Sell_2,Sell_3,Sell_4,Sell_5,Sell_Volume_1,Sell_Volume_2,Sell_Volume_3,Sell_Volume_4,Sell_Volume_5,Time,Date) VALUES(@Code,@Name,@High,@Open,@Low,@Close,@Close_Prev,@Last,@Volume,@Amount,@Buy_1,@Buy_2,@Buy_3,@Buy_4,@Buy_5,@Buy_Volume_1,@Buy_Volume_2,@Buy_Volume_3,@Buy_Volume_4,@Buy_Volume_5,@Sell_1,@Sell_2,@Sell_3,@Sell_4,@Sell_5,@Sell_Volume_1,@Sell_Volume_2,@Sell_Volume_3,@Sell_Volume_4,@Sell_Volume_5,@Time,@Date)";
            MySQLHelper.ExecuteNonQuery(sql, DAHelper.CreateParams(sql, model));
        }

        public static List<HQItem> GetYesterday()
        {
            string sql = "SELECT * FROM hq WHERE Date = (SELECT MAX(Date) from hq)";
            DataTable dt = MySQLHelper.GetDataTable(sql, null);
            List<HQItem> list = DAHelper.GetListByDataTable<HQItem>(dt);
            return list;
        }

        public static HQItem GetLast(string code)
        {
            string sql = "SELECT * FROM hq WHERE `Code` = '" + code + "' ORDER BY Date DESC LIMIT 1";
            DataTable dt = MySQLHelper.GetDataTable(sql, null);
            if (dt.Rows.Count > 0)
                return DAHelper.GetModelByDataRow<HQItem>(dt.Rows[0]);
            return null;
        }
    }
}