using Model.DB;
using MySql.Data.MySqlClient;
using MySQLSrv.Helper;
using System;
using System.Collections.Generic;
using System.Data;

namespace MySQLSrv
{
    public class LogTradeDA
    {
        public static List<LogTrade> List()
        {
            string sql = "SELECT * FROM log_trade ORDER BY date DESC LIMIT 10";
            DataTable dt = MySQLHelper.GetDataTable(sql, null);
            List<LogTrade> logTrades = DAHelper.GetListByDataTable<LogTrade>(dt);
            logTrades.Reverse();
            return logTrades;
        }

        public static bool Open(string _operator)
        {
            MySqlParameter[] msps = {
                new MySqlParameter("@operator_open", _operator)
            };
            string sql = "INSERT IGNORE INTO log_trade(date, operator_open) VALUES(CURRENT_DATE, @operator_open)";
            return MySQLHelper.ExecuteNonQuery(sql, msps) > 0;
        }

        public static bool Close(string _operator)
        {
            MySqlParameter[] msps = {
                new MySqlParameter("@operator_close", _operator)
            };
            string sql = "UPDATE log_trade SET operator_close=@operator_close, time_close = CURRENT_TIMESTAMP WHERE DATEDIFF(date, CURRENT_DATE) = 0";
            return MySQLHelper.ExecuteNonQuery(sql, msps) > 0;
        }
    }
}