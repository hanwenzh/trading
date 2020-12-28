using Model.Common;
using Model.Enum;
using Model.DB;
using MySQLSrv.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace MySQLSrv
{
    public class UnitDA
    {
        public static List<T> List<T>(int user_id = 0) where T : new()
        {
            string sql = "SELECT * FROM v_unit";
            if (user_id > 0)
                sql += " WHERE FIND_IN_SET(created_by, f_get_user_children(" + user_id + "))";
            DataTable dt = MySQLHelper.GetDataTable(sql, null);
            List<T> units = DAHelper.GetListByDataTable<T>(dt);
            return units;
        }

        public static List<Base> List4Undirected(int user_id = 0)
        {
            string sql = "SELECT id, `code`,`name` FROM unit WHERE user_id IS NULL";
            if (user_id > 0)
                sql += " AND FIND_IN_SET(created_by, f_get_user_children(" + user_id + "))";
            DataTable dt = MySQLHelper.GetDataTable(sql, null);
            List<Base> units = DAHelper.GetListByDataTable<Base>(dt);
            return units;
        }

        public static List<Base> List4User(int user_id)
        {
            string sql = "SELECT id, `code`,`name` FROM unit WHERE user_id=" + user_id;
            DataTable dt = MySQLHelper.GetDataTable(sql, null);
            List<Base> units = DAHelper.GetListByDataTable<Base>(dt);
            return units;
        }

        public static List<Base> List4Account(int account_id)
        {
            string sql = @"SELECT unit.id, unit.`code`,unit.`name` FROM unit
                LEFT JOIN account_group_item ON unit.account_group_id = account_group_item.account_group_id
                LEFT JOIN account ON account.id = account_group_item.account_id
                WHERE account.id=" + account_id;
            DataTable dt = MySQLHelper.GetDataTable(sql, null);
            List<Base> units = DAHelper.GetListByDataTable<Base>(dt);
            return units;
        }

        public static List<Base> List4AccountGroup(int account_group_id)
        {
            string sql = "SELECT id,code,name FROM unit where account_group_id=" + account_group_id;
            DataTable dt = MySQLHelper.GetDataTable(sql, null);
            List<Base> units = DAHelper.GetListByDataTable<Base>(dt);
            return units;
        }

        public static ApiResultEnum Add(Unit model, ref int id)
        {
            string sql = "SELECT `code` FROM unit WHERE `code` = @code";
            object obj = MySQLHelper.ExecuteScalar(sql, DAHelper.CreateParams(sql, model));
            if (obj != null)
            {
                return ApiResultEnum.Code_Exist;
            }

            sql = "INSERT INTO unit(code,name,area,broker,risk_controller,account_group_id,lever,ratio_management_fee,ratio_commission,ratio_software_fee,limit_stock_count,limit_ratio_mbm_single,limit_ratio_gem_single,limit_ratio_gem_total,limit_ratio_sme_single,limit_ratio_sme_total,limit_ratio_smg_total,limit_ratio_star_single,limit_ratio_star_total,ratio_warning,ratio_close_position,limit_no_buying,limit_order_price,created_by) VALUES(@code,@name,@area,@broker,@risk_controller,@account_group_id,@lever,@ratio_management_fee,@ratio_commission,@ratio_software_fee,@limit_stock_count,@limit_ratio_mbm_single,@limit_ratio_gem_single,@limit_ratio_gem_total,@limit_ratio_sme_single,@limit_ratio_sme_total,@limit_ratio_smg_total,@limit_ratio_star_single,@limit_ratio_star_total,@ratio_warning,@ratio_close_position,@limit_no_buying,@limit_order_price,@created_by); SELECT LAST_INSERT_ID()";
            obj = MySQLHelper.ExecuteScalar(sql, DAHelper.CreateParams(sql, model));
            if (obj != null)
            {
                id = int.Parse(obj.ToString());
                LogActionDA.Add(model.created_by, string.Format("创建单元{0}({1})", id, model.code));
                return ApiResultEnum.Success;
            }
            else
                return ApiResultEnum.Failed;
        }

        public static ApiResultEnum Update(Unit model)
        {
            string sql = "SELECT `code` FROM unit WHERE id <> @id AND `code` = @code";
            object obj = MySQLHelper.ExecuteScalar(sql, DAHelper.CreateParams(sql, model));
            if (obj != null)
            {
                return ApiResultEnum.Code_Exist;
            }

            sql = "UPDATE unit SET code=@code,name=@name,area=@area,broker=@broker,risk_controller=@risk_controller,account_group_id=@account_group_id,lever=@lever,ratio_management_fee=@ratio_management_fee,ratio_commission=@ratio_commission,ratio_software_fee=@ratio_software_fee,limit_stock_count=@limit_stock_count,limit_ratio_mbm_single=@limit_ratio_mbm_single,limit_ratio_gem_single=@limit_ratio_gem_single,limit_ratio_gem_total=@limit_ratio_gem_total,limit_ratio_sme_single=@limit_ratio_sme_single,limit_ratio_sme_total=@limit_ratio_sme_total,limit_ratio_smg_total=@limit_ratio_smg_total,limit_ratio_star_single=@limit_ratio_star_single,limit_ratio_star_total=@limit_ratio_star_total,ratio_warning=@ratio_warning,ratio_close_position=@ratio_close_position,limit_no_buying=@limit_no_buying,limit_order_price=@limit_order_price WHERE id =@id";
            if (MySQLHelper.ExecuteNonQuery(sql, DAHelper.CreateParams(sql, model)) > 0)
                return ApiResultEnum.Success;
            return ApiResultEnum.Failed;
        }

        public static ApiResultEnum UpdateStatus(Status model)
        {
            string sql = "UPDATE unit SET `status`=@status WHERE id=@id";
            if (MySQLHelper.ExecuteNonQuery(sql, DAHelper.CreateParams(sql, model)) > 0)
                return ApiResultEnum.Success;
            return ApiResultEnum.Failed;
        }

        public static ApiResultEnum UpdateStatusOrder(StatusOrder model)
        {
            string sql = "UPDATE unit SET status_order=@status WHERE id=@id";
            if (MySQLHelper.ExecuteNonQuery(sql, DAHelper.CreateParams(sql, model)) > 0)
                return ApiResultEnum.Success;
            return ApiResultEnum.Failed;
        }

        public static ApiResultEnum UpdateUserID(UserUnits model)
        {
            List<string> sqls = new List<string>();
            sqls.Add(string.Format("UPDATE unit SET user_id = NULL WHERE user_id = {0}", model.id));
            if (model.unit_ids.Count > 0)
                sqls.Add(string.Format("UPDATE unit SET user_id = {0} WHERE id in ({1})", model.id, string.Join(",", model.unit_ids)));
            if (MySQLHelper.ExecuteNonQuery(sqls))
                return ApiResultEnum.Success;
            return ApiResultEnum.Failed;
        }

        public static ApiResultEnum UpdateRatioFreezing(Unit model)
        {
            string sql = "UPDATE unit SET ratio_freezing=@ratio_freezing WHERE id=@id";
            if (MySQLHelper.ExecuteNonQuery(sql, DAHelper.CreateParams(sql, model)) > 0)
                return ApiResultEnum.Success;
            return ApiResultEnum.Failed;
        }

        public static ApiResultEnum UpdateCapital(Unit model)
        {
            string sql = "UPDATE unit SET capital_balance=@capital_balance,capital_stock_value=@capital_stock_value WHERE id=@id";
            if (MySQLHelper.ExecuteNonQuery(sql, DAHelper.CreateParams(sql, model)) > 0)
                return ApiResultEnum.Success;
            return ApiResultEnum.Failed;
        }

        public static ApiResultEnum Delete(Unit model, int _operator)
        {
            string sql = "DELETE FROM unit WHERE id=@id";
            if (MySQLHelper.ExecuteNonQuery(sql, DAHelper.CreateParams(sql, model)) > 0)
            {
                LogActionDA.Add(_operator, string.Format("删除单元{0}({1})", model.id, model.code));
                return ApiResultEnum.Success;
            }
            return ApiResultEnum.Failed;
        }
    }
}