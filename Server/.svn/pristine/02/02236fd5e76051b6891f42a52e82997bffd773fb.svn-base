using Model.DB;
using MySQLSrv.Helper;
using System;
using System.Collections.Generic;
using System.Data;

namespace MySQLSrv
{
    public class BlockInfoDA
    {
        public static List<BlockInfo> List()
        {
            string sql = "SELECT * FROM block_info";
            DataTable dt = MySQLHelper.GetDataTable(sql, null);
            List<BlockInfo> blocks = DAHelper.GetListByDataTable<BlockInfo>(dt);
            return blocks;
        }
    }
}