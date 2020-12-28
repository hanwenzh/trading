﻿using Common;
using Model.DB;
using MySQLSrv.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MySQLSrv
{
    public class StockInfoDA
    {
        public static Dictionary<string, StockInfo> List()
        {
            string sql = "SELECT * FROM stock_info";
            DataTable dt = MySQLHelper.GetDataTable(sql, null);
            List<StockInfo> stocks = DAHelper.GetListByDataTable<StockInfo>(dt);
            stocks.ForEach(s => s.pyjc = StringHelper.GetPYString(s.name));
            return stocks.Select(s => new KeyValuePair<string, StockInfo>(s.code, s)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        public static void Add(List<StockInfo> list)
        {
            var sqls = list.Select(s => string.Format("INSERT INTO stock_info(`code`,`name`,date) VALUES('{0}', '{1}', '{2}')", s.code, s.name, s.date)).ToList();
            sqls.Insert(0, "TRUNCATE TABLE stock_info");
            MySQLHelper.ExecuteNonQuery(sqls);
        }
    }
}