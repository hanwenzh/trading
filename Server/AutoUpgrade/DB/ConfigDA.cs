using System;
using System.Collections.Generic;
using System.Data;

namespace AutoUpgrade.DB
{
    public class ConfigDA
    {
        public static Dictionary<string, string> List()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string sql = "SELECT `key`, `value` FROM config WHERE `key` in ('client_version', 'client_version_no')";
            DataTable dt = Helper.MySQLHelper.GetDataTable(sql, null);
            foreach(DataRow dr in dt.Rows)
            {
                dic.Add(dr["key"].ToString(), dr["value"].ToString());
            }
            return dic;
        }

        public static void Update(string version, string version_no)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string sql = "UPDATE config SET value='" + version + "' WHERE `key` = 'client_version'; UPDATE config SET value='" + version_no + "' WHERE `key` = 'client_version_no';";
            Helper.MySQLHelper.ExecuteNonQuery(sql, null);
        }
    }
}