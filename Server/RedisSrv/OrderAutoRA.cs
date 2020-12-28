﻿using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Model.API;
using Model.Common;
using Model.DB;
using Model.Enum;

namespace RedisSrv
{
    public class OrderAutoRA
    {
        public static List<OrderAuto> List4Unit(int unit_id)
        {
            List<OrderAuto> list = new List<OrderAuto>();
            string[] keys = TradeRA.KeySearch("S_*_U_" + unit_id + "_D_*");
            foreach (string key in keys)
            {
                list.Add(Get(key));
            }
            return list;
        }

        public static List<OrderAuto> List4Undone()
        {
            List<OrderAuto> list = new List<OrderAuto>();
            string[] keys = TradeRA.KeySearch("S_*_D_0");
            foreach (string key in keys)
            {
                list.Add(Get(key));
            }
            return list;
        }

        public static OrderAuto Get(string key)
        {
            Dictionary<string, string> dic = TradeRA.GetFields(key);
            return new OrderAuto()
            {
                id = long.Parse(dic["id"]),
                unit_id = int.Parse(dic["unit_id"]),
                user_id = int.Parse(dic["user_id"]),
                platform = int.Parse(dic["platform"]),
                account_id = int.Parse(dic["account_id"]),
                account_name = dic["account_name"],
                code = dic["code"],
                name = dic["name"],
                status = int.Parse(dic["status"]),
                type = int.Parse(dic["type"]),
                price_min = decimal.Parse(dic["price_min"]),
                price_max = decimal.Parse(dic["price_max"]),
                price_type = int.Parse(dic["price_type"]),
                count_min = int.Parse(dic["count_min"]),
                count_max = int.Parse(dic["count_max"]),
                count_total = int.Parse(dic["count_total"]),
                time_min = int.Parse(dic["time_min"]),
                time_max = int.Parse(dic["time_max"]),
                time_next_dt = DateTime.Parse(dic["time_next_dt"]),
                time_prev_dt = DateTime.Parse(dic["time_prev_dt"]),
                order_times = int.Parse(dic["order_times"]),
                order_count = int.Parse(dic["order_count"]),
                result_prev = dic["result_prev"],
                operator_start = dic["operator_start"],
                operator_stop = dic["operator_stop"]
            };
        }

        public static void Add(OrderAutoAdd order, string key)
        {
            Dictionary<string, string> items = new Dictionary<string, string>();
            items.Add("id", order.id.ToString());
            items.Add("unit_id", order.unit_id.ToString());
            items.Add("user_id", order.user_id.ToString());
            items.Add("platform", order.platform.ToString());
            items.Add("account_id", order.account_id.ToString());
            items.Add("account_name", order.account_name);
            items.Add("code", order.code);
            items.Add("name", order.name);
            items.Add("status", "0");
            items.Add("type", order.type.ToString());
            items.Add("price_min", order.price_min.ToString());
            items.Add("price_max", order.price_max.ToString());
            items.Add("price_type", order.price_type.ToString());
            items.Add("count_min", order.count_min.ToString());
            items.Add("count_max", order.count_max.ToString());
            items.Add("count_total", order.count_total.ToString());
            items.Add("time_min", order.time_min.ToString());
            items.Add("time_max", order.time_max.ToString());
            items.Add("time_next_dt", DateTime.MinValue.Format());
            items.Add("time_prev_dt", DateTime.MinValue.Format());
            items.Add("order_times", "0");
            items.Add("order_count", "0");
            items.Add("result_prev", "");
            items.Add("operator_start", "");
            items.Add("operator_stop", "");
            TradeRA.SetFields(key, items);
            TradeRA.SetExpire(key);
        }

        public static bool Update(OrderAutoUpdate order)
        {
            string[] keys = TradeRA.KeySearch("S_" + order.id + "_*_D_0");
            if (keys.Length > 0)
            {
                Dictionary<string, string> items = new Dictionary<string, string>();
                items.Add("price_min", order.price_min.ToString());
                items.Add("price_max", order.price_max.ToString());
                items.Add("price_type", order.price_type.ToString());
                items.Add("count_min", order.count_min.ToString());
                items.Add("count_max", order.count_max.ToString());
                items.Add("time_min", order.time_min.ToString());
                items.Add("time_max", order.time_max.ToString());
                TradeRA.SetFields(keys[0], items);
                return true;
            }
            return false;
        }

        public static void UpdateExecuted(OrderAuto order_auto, Order order, string key)
        {
            Dictionary<string, string> items = new Dictionary<string, string>();
            items.Add("time_next_dt", order_auto.time_next_dt.Format());
            items.Add("time_prev_dt", order_auto.time_prev_dt.Format());
            items.Add("order_times", order_auto.order_times.ToString());
            items.Add("order_count", order_auto.order_count.ToString());
            items.Add("result_prev", order_auto.result_prev);
            TradeRA.SetFields(key, items);
            AddItems(order_auto, order);

            if (order_auto.order_count == order_auto.count_total)
                UpdateStatus(StatusAutoOrderEnum.Done, 1, key);
        }

        private static void AddItems(OrderAuto order_auto, Order order)
        {
            Dictionary<string, string> items = new Dictionary<string, string>();
            items.Add("id", order_auto.order_times.ToString());
            items.Add("time", order_auto.time_prev_dt.Format());
            items.Add("price", order.price.ToString());
            items.Add("count", order.count.ToString());
            items.Add("result", order_auto.result_prev);
            string key = "T_" + order_auto.id + "_" + order_auto.order_times.ToString().PadLeft(3, '0');
            TradeRA.SetFields(key, items);
            TradeRA.SetExpire(key);
        }

        public static void UpdateStatus(StatusAutoOrderEnum status, int user_id, string key)
        {
            Dictionary<string, string> items = new Dictionary<string, string>();
            items.Add("status", ((int)status).ToString());
            if (status == StatusAutoOrderEnum.Run)
                items.Add("operator_start", UserRA.Get(user_id.ToString(), "name"));
            else if (status == StatusAutoOrderEnum.Pause)
                items.Add("operator_stop", UserRA.Get(user_id.ToString(), "name"));
            TradeRA.SetFields(key, items);

            if (status == StatusAutoOrderEnum.Done || status == StatusAutoOrderEnum.Stop)
                TradeRA.KeyRename(key, (key.Substring(0, key.Length - 1) + "1"));
        }

        public static bool Delete(OrderAutoUpdate model)
        {
            string[] keys = TradeRA.KeySearch("S_" + model.id + "_U_" + model.unit_id + "_*");
            if (keys.Length > 0)
            {
                return TradeRA.Delete(keys[0]);
            }
            return false;
        }
    }
}