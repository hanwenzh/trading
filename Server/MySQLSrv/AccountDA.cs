﻿using Model.Common;
using Model.Enum;
using Model.DB;
using MySQLSrv.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace MySQLSrv
{
    public class AccountDA
    {
        public static List<T> List<T>(int user_id = 0) where T : new()
        {
            string sql = "SELECT * FROM account";
            if(user_id > 0)
                sql += " WHERE FIND_IN_SET(created_by, f_get_user_children(" + user_id + "))";
            DataTable dt = MySQLHelper.GetDataTable(sql, null);
            List<T> accounts = DAHelper.GetListByDataTable<T>(dt);
            return accounts;
        }

        public static List<Base> List4Unit(int unit_id)
        {
            MySqlParameter[] msps = {
                new MySqlParameter("@unit_id", unit_id)
            };
            string sql = @"SELECT account.id, account.`code`,account.`name` FROM account
                            LEFT JOIN account_group_item ON account.id = account_group_item.account_id
                            LEFT JOIN unit ON unit.account_group_id = account_group_item.account_group_id
                            WHERE unit.id = @unit_id";
            DataTable dt = MySQLHelper.GetDataTable(sql, msps);
            List<Base> accounts = DAHelper.GetListByDataTable<Base>(dt);
            return accounts;
        }

        public static ApiResultEnum Add(Account model, ref int id)
        {
            string sql = "SELECT * FROM `account` WHERE `code` = @code OR `server_ip` = @server_ip";
            DataTable dt = MySQLHelper.GetDataTable(sql, DAHelper.CreateParams(sql, model));
            if (dt == null)
            {
                return ApiResultEnum.Failed;
            }
            else if (dt.Rows.Count > 0)
            {
                Account account = DAHelper.GetModelByDataRow<Account>(dt.Rows[0]);
                if (account.code == model.code)
                    return ApiResultEnum.Code_Exist;
                else if (account.server_ip == model.server_ip)
                    return ApiResultEnum.Account_IP_Exist;
            }

            sql = "INSERT INTO account(server_ip, server_port, `code`, `name`, full_name, remarks, limit_no_buying, ratio_commission, limit_ratio_single, limit_ratio_gem_single, limit_ratio_gem_total, ratio_capital_warning, capital_initial, capital_inferior, capital_priority, capital_raobiao, capital_raobiao_rate, created_by) VALUES(@server_ip, @server_port, @code, @name, @full_name, @remarks, @limit_no_buying, @ratio_commission, @limit_ratio_single, @limit_ratio_gem_single, @limit_ratio_gem_total, @ratio_capital_warning, @capital_initial, @capital_inferior, @capital_priority, @capital_raobiao, @capital_raobiao_rate, @created_by); SELECT LAST_INSERT_ID()";
            object obj = MySQLHelper.ExecuteScalar(sql, DAHelper.CreateParams(sql, model));
            if (obj != null)
            {
                id = int.Parse(obj.ToString());
                LogActionDA.Add(model.created_by, string.Format("创建主账户{0}({1})", id, model.code));
                return ApiResultEnum.Success;
            }
            else
                return ApiResultEnum.Failed;
        }

        public static ApiResultEnum Update(Account model)
        {
            string sql = "SELECT * FROM `account` WHERE id <> @id AND (`code` = @code OR server_ip = @server_ip)";
            DataTable dt = MySQLHelper.GetDataTable(sql, DAHelper.CreateParams(sql, model));
            if (dt == null)
            {
                return ApiResultEnum.Failed;
            }
            else if (dt.Rows.Count > 0)
            {
                Account account = DAHelper.GetModelByDataRow<Account>(dt.Rows[0]);
                if (account.code == model.code)
                    return ApiResultEnum.Code_Exist;
                else if (account.server_ip == model.server_ip)
                    return ApiResultEnum.Account_IP_Exist;
            }

            sql = "UPDATE account SET server_ip=@server_ip, server_port=@server_port, `code`=@code, `name`=@name, full_name=@full_name, remarks=@remarks, limit_no_buying=@limit_no_buying, ratio_commission=@ratio_commission, limit_ratio_single=@limit_ratio_single, limit_ratio_gem_single=@limit_ratio_gem_single, limit_ratio_gem_total=@limit_ratio_gem_total, ratio_capital_warning=@ratio_capital_warning, capital_initial=@capital_initial, capital_inferior=@capital_inferior, capital_priority=@capital_priority, capital_raobiao=@capital_raobiao, capital_raobiao_rate=@capital_raobiao_rate WHERE id =@id";
            if (MySQLHelper.ExecuteNonQuery(sql, DAHelper.CreateParams(sql, model)) > 0)
            {
                LogActionDA.Add(model.created_by, string.Format("修改主账户{0}({1})", model.id, model.code));
                return ApiResultEnum.Success;
            }
            return ApiResultEnum.Failed;
        }

        public static ApiResultEnum UpdateStatus(Status model)
        {
            string sql = "UPDATE account SET `status`=@status WHERE id=@id";
            if (MySQLHelper.ExecuteNonQuery(sql, DAHelper.CreateParams(sql, model)) > 0)
                return ApiResultEnum.Success;
            return ApiResultEnum.Failed;
        }

        public static ApiResultEnum UpdateStatusOrder(StatusOrder model)
        {
            string sql = "UPDATE account SET status_order=@status WHERE id=@id";
            if (MySQLHelper.ExecuteNonQuery(sql, DAHelper.CreateParams(sql, model)) > 0)
                return ApiResultEnum.Success;
            return ApiResultEnum.Failed;
        }

        public static ApiResultEnum UpdateCapital(Account model)
        {
            string sql="UPDATE account SET capital_available=@capital_available,capital_stock_value=@capital_stock_value,capital_total=@capital_total,capital_profit=@capital_profit,synchronized_time=@synchronized_time WHERE id=@id";
            if (MySQLHelper.ExecuteNonQuery(sql, DAHelper.CreateParams(sql, model)) > 0)
                return ApiResultEnum.Success;
            return ApiResultEnum.Failed;
        }
        
        public static ApiResultEnum Delete(Account model)
        {
            string sql = "DELETE FROM account WHERE id=@id";
            if (MySQLHelper.ExecuteNonQuery(sql, DAHelper.CreateParams(sql, model)) > 0)
            {
                LogActionDA.Add(model.created_by, string.Format("删除主账户{0}({1})", model.id, model.code));
                return ApiResultEnum.Success;
            }
            return ApiResultEnum.Failed;
        }
    }
}