using MySQLSrv.Helper;
using System;
using System.Collections.Generic;
using System.Data;

namespace MySQLSrv
{
    public class ConfigDA
    {
        public static Dictionary<string, string> List()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string sql = "SELECT `key`, `value` FROM config";
            DataTable dt = MySQLHelper.GetDataTable(sql, null);
            foreach(DataRow dr in dt.Rows)
            {
                dic.Add(dr["key"].ToString(), dr["value"].ToString());
            }
            return dic;
        }
    }
}