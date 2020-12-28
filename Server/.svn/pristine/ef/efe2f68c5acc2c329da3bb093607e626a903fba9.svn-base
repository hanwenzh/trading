using Model.Enum;
using Model.DB;
using MySQLSrv.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using Model.Search;

namespace MySQLSrv
{
    public class LogCapitalDA
    {
        public static List<LogCapital> List(SearchCapitalLog model)
        {
            string sql = "SELECT * FROM log_capital WHERE 1=1" + model.Where() + " ORDER BY time_dt DESC";
            DataTable dt = MySQLHelper.GetDataTable(sql, null);
            List<LogCapital> logCapitals = DAHelper.GetListByDataTable<LogCapital>(dt);
            return logCapitals;
        }

        public static ApiResultEnum Add(LogCapital model, out decimal delta)
        {
            List<string> sqls = new List<string>();
            string action = model.action_enum == ActionEnum.In ? "+" : "-";
            decimal capital;
            if (model.type_enum == CapitalLogTypeEnum.Capital)
            {
                capital = model.amount;
                sqls.Add(string.Format("UPDATE unit SET capital_scale = capital_scale {0} {1}, capital_balance = capital_balance {0} {1} WHERE id = {2}", action, model.amount, model.unit_id));
            }
            else
            {
                string sql = string.Format("SELECT lever FROM unit WHERE id={0}", model.unit_id);
                decimal level = decimal.Parse(MySQLHelper.ExecuteScalar(sql, null).ToString());
                capital = (model.amount + model.amount * level);
                sqls.Add(string.Format("UPDATE unit SET bond = bond {0} {1}, capital_scale = capital_scale {2} {3}, capital_balance = capital_balance {2} {3} WHERE id = {4}", action, model.amount, action, capital, model.unit_id));
            }
            delta = (model.action_enum == ActionEnum.In ? capital : -capital);
            sqls.Add(string.Format("INSERT INTO log_capital(type,action,amount,remark,unit_id,operator) VALUES({0},{1},{2},'{3}',{4},{5})", model.type, model.action, model.amount, model.remark, model.unit_id, model.@operator));
            if (MySQLHelper.ExecuteNonQuery(sqls))
                return ApiResultEnum.Success;
            return ApiResultEnum.Failed;
        }
    }
}