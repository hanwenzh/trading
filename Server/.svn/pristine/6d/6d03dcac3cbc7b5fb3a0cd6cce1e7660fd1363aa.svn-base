using AutoUpgrade.DB.Helper;
using AutoUpgrade.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AutoUpgrade.DB
{
    public class ClientFileDA
    {
        public static List<ClientFile> List()
        {
            string sql = "SELECT * FROM client_file";
            DataTable dt = MySQLHelper.GetDataTable(sql, null);
            return DAHelper.GetListByDataTable<ClientFile>(dt);
        }

        public static bool Add(List<ClientFileCompare> list, string version)
        {
            List<string> sqls = new List<string>();
            list.ForEach(f =>
            {
                if (string.IsNullOrEmpty(f.size))
                    sqls.Add(string.Format("INSERT INTO client_file(name, size, version, time) VALUES('{0}', {1}, {2}, '{3}')", f.name, f.size_new, version, f.time_new));
                else if (string.IsNullOrEmpty(f.time_new))
                    sqls.Add(string.Format("DELETE FROM client_file WHERE name='{0}'", f.name));
                else
                    sqls.Add(string.Format("UPDATE client_file SET size={0}, version={1}, time='{2}' WHERE name='{3}'", f.size_new, version, f.time_new, f.name));
            });
            return MySQLHelper.ExecuteNonQuery(sqls);
        }
    }
}