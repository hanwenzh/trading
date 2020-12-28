﻿using MySQLSrv.Helper;
using System;
using HQ;
using System.Collections.Generic;
using System.Data;
using Model.DB;

namespace MySQLSrv
{
    public class PositionDA
    {
        public static List<Position> List()
        {
            string sql = "SELECT * FROM v_position";
            DataTable dt = MySQLHelper.GetDataTable(sql, null);
            List<Position> positions = DAHelper.GetListByDataTable<Position>(dt);
            return positions;
        }

        public static void Add(Position position)
        {
            string sql = "INSERT INTO `position`(`code`,`name`,count,price_cost,price_latest,unit_id,account_id,block) VALUES(@code,@name,@count,@price_cost,@price_latest,@unit_id,@account_id,@block)";
            MySQLHelper.ExecuteNonQuery(sql, DAHelper.CreateParams(sql, position));
        }

        public static void Update(Position position)
        {
            string sql = "UPDATE `position` SET count=@count,price_cost=@price_cost,price_latest=@price_latest WHERE id=@id";
            MySQLHelper.ExecuteNonQuery(sql, DAHelper.CreateParams(sql, position));
        }

        public static void Delete(int id)
        {
            string sql = "DELETE FROM `position` WHERE id=" + id;
            MySQLHelper.ExecuteNonQuery(sql, null);
        }
    }
}