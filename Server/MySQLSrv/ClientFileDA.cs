using Common;
using Model.DB;
using MySQLSrv.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MySQLSrv
{
    public class ClientFileDA
    {
        public static List<ClientFile> List(int current_version)
        {
            string sql = "SELECT * FROM client_file where version > " + current_version;
            DataTable dt = MySQLHelper.GetDataTable(sql, null);
            return DAHelper.GetListByDataTable<ClientFile>(dt);
        }
    }
}