﻿using Model.Enum;
using Model.DB;
using MySQLSrv.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using Model.Search;

namespace MySQLSrv
{
    public class DealDA
    {
        public static List<Deal> List<T>(T model) where T : ISearch
        {
            string sql = "SELECT * FROM v_deal WHERE 1=1" + model.Where() + " ORDER BY id DESC";
            DataTable dt = MySQLHelper.GetDataTable(sql, null);
            List<Deal> deals = DAHelper.GetListByDataTable<Deal>(dt);
            return deals;
        }

        public static void Add(Deal model)
        {
            string sql = "INSERT INTO deal(`code`,`name`,type,price,count,money,commission,management_fee,deal_no,order_no,unit_id,account_id,time_dt,transferred,profit) VALUES(@code,@name,@type,@price,@count,@money,@commission,@management_fee,@deal_no,@order_no,@unit_id,@account_id,@time_dt,@transferred,@profit)";
            MySQLHelper.ExecuteNonQuery(sql, DAHelper.CreateParams(sql, model));
        }
    }
}