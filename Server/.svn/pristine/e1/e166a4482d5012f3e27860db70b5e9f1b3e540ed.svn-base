using Model.Enum;
using Model.DB;
using MySQLSrv.Helper;
using System;
using System.Collections.Generic;
using System.Data;

namespace MySQLSrv
{
    public class StatementDA
    {
        public static List<Statement> Get4User(int user_id)
        {
            string sql = "SELECT statement.*, unit.`name` AS unit_name FROM statement LEFT JOIN unit ON unit.id = statement.unit_id WHERE unit.user_id = " + user_id + " AND date = (SELECT date FROM statement ORDER BY id DESC LIMIT 1)";
            DataTable dt = MySQLHelper.GetDataTable(sql, null);
            List<Statement> statements = DAHelper.GetListByDataTable<Statement>(dt);
            return statements;
        }

        public static ApiResultEnum Add(Statement model)
        {
            string sql = "INSERT INTO statement(unit_id,date,capital_total,capital_stock_value,profit,fee,capital_inout) VALUES(@unit_id,CURRENT_DATE,@capital_total,@capital_stock_value,@profit,@fee,@capital_inout)";
            int result = MySQLHelper.ExecuteNonQuery(sql, DAHelper.CreateParams(sql, model));
            if (result > 0)
                return ApiResultEnum.Success;
            return ApiResultEnum.Failed;
        }
    }
}