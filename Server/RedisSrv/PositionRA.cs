﻿using System;
using System.Collections.Generic;
using Model.DB;

namespace RedisSrv
{
    public class PositionRA
    {
        public static List<Position> List()
        {
            List<Position> list = new List<Position>();
            string[] keys = TradeRA.KeySearch("P_*");
            foreach (string key in keys)
            {
                list.Add(Get(key));
            }
            return list;
        }

        public static List<Position> List4Unit(int unit_id)
        {
            List<Position> list = new List<Position>();
            string[] keys = TradeRA.KeySearch("P_*_U_" + unit_id);
            foreach (string key in keys)
            {
                list.Add(Get(key));
            }
            return list;
        }

        public static List<Position> List4Account(int account_id)
        {
            List<Position> list = new List<Position>();
            string[] keys = TradeRA.KeySearch("P_*_A_" + account_id + "_U_*");
            foreach (string key in keys)
            {
                list.Add(Get(key));
            }
            return list;
        }

        public static List<Position> List4UnitCode(Position model)
        {
            List<Position> list = new List<Position>();
            string[] keys = TradeRA.KeySearch("P_"+model.code+"_A_*_U_" + model.unit_id);
            foreach (string key in keys)
            {
                list.Add(Get(key));
            }
            return list;
        }

        /// <summary>
        /// 获取单元下持有的股票只数
        /// </summary>
        /// <param name="unit_id"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static int GetCodeCount(int unit_id, string code = null)
        {
            List<string> lst = new List<string>();
            string[] keys = TradeRA.KeySearch("P_*_U_" + unit_id);
            foreach (string key in keys)
            {
                Position position = Get(key);
                if (position.count > 0)
                {
                    if (!lst.Contains(position.code))
                        lst.Add(position.code);
                }
            }
            return string.IsNullOrEmpty(code) || lst.Contains(code) ? lst.Count : lst.Count + 1;
        }

        public static Position Get(string key)
        {
            Dictionary<string, string> dic = TradeRA.GetFields(key);
            if (dic.Count == 0)
                return null;
            else
                return new Position()
                {
                    id = int.Parse(dic["id"]),
                    code = dic["code"],
                    name = dic["name"],
                    price_cost = decimal.Parse(dic["price_cost"]),
                    count = int.Parse(dic["count"]),
                    count_sellable = int.Parse(dic["count_sellable"]),
                    price_cost_today_buy = decimal.Parse(dic["price_cost_today_buy"]),
                    price_cost_today_sell = decimal.Parse(dic["price_cost_today_sell"]),
                    count_today_buy = int.Parse(dic["count_today_buy"]),
                    count_today_sell = int.Parse(dic["count_today_sell"]),
                    unit_id = int.Parse(dic["unit_id"]),
                    unit_name = dic["unit_name"],
                    account_id = int.Parse(dic["account_id"]),
                    account_name = dic["account_name"],
                    price_latest = decimal.Parse(dic["price_latest"]),
                    block = int.Parse(dic["block"])
                };
        }

        public static void Add(Position position, string key)
        {
            Dictionary<string, string> items = new Dictionary<string, string>();
            items.Add("id", position.id.ToString());
            items.Add("code", position.code);
            items.Add("name", position.name);
            items.Add("price_cost", position.price_cost.ToString());
            items.Add("count", position.count.ToString());
            items.Add("count_sellable", position.count_sellable.ToString());
            items.Add("price_cost_today_buy", position.price_cost_today_buy.ToString());
            items.Add("price_cost_today_sell", position.price_cost_today_sell.ToString());
            items.Add("count_today_buy", position.count_today_buy.ToString());
            items.Add("count_today_sell", position.count_today_sell.ToString());
            items.Add("unit_id", position.unit_id.ToString());
            items.Add("unit_name", position.unit_name ?? UnitRA.GetName(position.unit_id));
            items.Add("account_id", position.account_id.ToString());
            items.Add("account_name", position.account_name ?? AccountRA.GetName(position.account_id));
            items.Add("price_latest", position.price_latest.ToString());
            items.Add("block", position.block.ToString());
            TradeRA.SetFields(key, items);
            TradeRA.SetExpire(key);
        }

        public static void UpdateBuy(Position position, string key)
        {
            Dictionary<string, string> items = new Dictionary<string, string>();
            items.Add("price_cost", position.price_cost.ToString());
            items.Add("count", position.count.ToString());
            items.Add("price_cost_today_buy", position.price_cost_today_buy.ToString());
            items.Add("count_today_buy", position.count_today_buy.ToString());
            TradeRA.SetFields(key, items);
        }

        public static void UpdateSell(Position position, string key)
        {
            Dictionary<string, string> items = new Dictionary<string, string>();
            items.Add("price_cost", position.price_cost.ToString());
            items.Add("count", position.count.ToString());
            items.Add("count_sellable", position.count_sellable.ToString());
            items.Add("price_cost_today_sell", position.price_cost_today_sell.ToString());
            items.Add("count_today_sell", position.count_today_sell.ToString());
            TradeRA.SetFields(key, items);
        }

        public static void UpdateTransfer(int from_unit, int to_unit, int from_account, int to_account, string code, int count, decimal price_latest)
        {
            string key_from = "P_" + code + "_A_" + from_account + "_U_" + from_unit;
            TradeRA.Increment(key_from, "count", -count);
            TradeRA.Increment(key_from, "count_sellable", -count);
            string key_to = "P_" + code + "_A_" + to_account + "_U_" + to_unit;
            if (TradeRA.KeyExists(key_to))
            {
                TradeRA.Increment(key_to, "count", count);
                TradeRA.Increment(key_to, "count_sellable", count);
            }
            else
            {
                Position position = Get(key_from);
                position.unit_id = to_unit;
                position.account_id = to_account;
                position.count = position.count_sellable = count;
                position.price_cost_today_buy = position.price_cost_today_sell = 0;
                position.count_today_buy = position.count_today_sell = 0;
                position.price_latest = price_latest;
                Add(position, key_to);
            }
        }

        public static void UpdateSellableOrderSell(decimal delta, string key)
        {
            TradeRA.Increment(key, "count_sellable", (float)delta);
        }

        public static int GetSellable(int unit_id, string code)
        {
            int count_sellable = 0;
            string[] keys = TradeRA.KeySearch("P_" + code + "_A_*_U_" + unit_id);
            foreach (string key in keys)
            {
                count_sellable += TradeRA.GetInt(key, "count_sellable");
            }
            return count_sellable;
        }

        public static int GetSellable(int unit_id, string code, int account_id)
        {
            string key = "P_" + code + "_A_" + account_id + "_U_" + unit_id;
            return TradeRA.GetInt(key, "count_sellable");
        }
    }
}