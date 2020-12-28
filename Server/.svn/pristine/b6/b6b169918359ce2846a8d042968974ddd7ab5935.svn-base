using HQ;
using Model.DB;
using Model.Enum;
using MySQLSrv;
using RedisSrv;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Trade.Biz
{
    public class OpenCloseBiz
    {
        public static void Open()
        {
            HQService.SubscribeStart();
            var accounts = AccountDA.List<Account>();
            foreach (Account account in accounts)
            {
                LoadAccount(account);
            }

            var units = UnitDA.List<Unit>();
            foreach (Unit unit in units)
            {
                LoadUnit(unit);
            }

            var positions = PositionDA.List();
            foreach (Position position in positions)
            {
                LoadPosition(position);
            }

            var items = AccountGroupDA.ListItems();
            foreach (AccountGroupItem item in items)
            {
                LoadAccountGroupItem(item);
            }

            HQService.Get(positions.Select(p => p.code));
            TradeBiz.Start();
        }

        public static void Close()
        {
            TradeBiz.Stop();
            HQBiz.Save();
            SaveOrder();

            Dictionary<int, decimal[]> dic = new Dictionary<int, decimal[]>();
            SaveDeal(ref dic);
            SavePosition();
            SaveAccountCapital();
            SaveUnitCapital(dic);

            StockInfoBiz.RefreshBlockList();
        }

        public static void LoadAccount(Account account, bool add = true)
        {
            TradeBiz.LoadAccount(account);

            string key = "A_" + account.id;
            if (add && TradeRA.KeyExists(key))
                return;

            if (add)
                AccountRA.Add(account, key);
            else
                AccountRA.Update(account, key);
        }

        public static void LoadUnit(Unit unit, bool add = true)
        {
            string key = "U_" + unit.id;
            if (add && TradeRA.KeyExists(key))
                return;

            if (add)
            {
                UnitRA.Add(unit, key);
            }
            else
            {
                UnitRA.Update(unit, key);
            }
        }

        public static void LoadPosition(Position position)
        {
            string key = "P_" + position.code + "_A_" + position.account_id + "_U_" + position.unit_id;
            if (TradeRA.KeyExists(key))
                return;

            position.count_sellable = position.count;
            PositionRA.Add(position, key);
        }

        public static void LoadAccountGroupItem(AccountGroupItem item)
        {
            string key = "G_" + item.account_group_id + "_U_" + item.unit_id + "_A_" + item.account_id;
            if (TradeRA.KeyExists(key))
                return;

            AccountGroupRA.Add(item, key);
        }

        public static void SaveOrder()
        {
            string[] keys = TradeRA.KeySearch("O_*");
            foreach (string key in keys)
            {
                Order order = OrderRA.Get(key);
                if (order.state_enum == OrderStatusEnum.Submitted)
                    order.state_enum = OrderStatusEnum.Abnormal;
                OrderDA.Add(order);
            }
        }

        public static void SaveDeal(ref Dictionary<int, decimal[]> dic)
        {
            string[] keys = TradeRA.KeySearch("D_*");
            foreach (string key in keys)
            {
                Deal deal = DealRA.Get(key);
                DealDA.Add(deal);
                if (deal.unit_id > 0)
                {
                    if (dic.ContainsKey(deal.unit_id))
                    {
                        dic[deal.unit_id][0] = dic[deal.unit_id][0] + deal.commission;
                        dic[deal.unit_id][1] = dic[deal.unit_id][1] + deal.profit;
                    }
                    else
                        dic.Add(deal.unit_id, new decimal[2] { deal.commission, deal.profit });
                }
            }
        }

        public static void SavePosition()
        {
            string[] keys = TradeRA.KeySearch("P_*");
            foreach (string key in keys)
            {
                Position position = PositionRA.Get(key);
                if (position.count == 0)
                {
                    if (position.id > 0)
                        PositionDA.Delete(position.id);
                }
                else
                {
                    position.price_latest = HQService.Get(position.code).Last;
                    if (position.id > 0)
                        PositionDA.Update(position);
                    else
                        PositionDA.Add(position);
                }
            }
        }

        public static void SaveAccountCapital()
        {
            string[] keys = TradeRA.KeySearch("A_*");
            foreach (string key in keys)
            {
                Account account = AccountRA.Get(key);
                AccountDA.UpdateCapital(account);
            }
        }

        public static void SaveUnitCapital(Dictionary<int, decimal[]> dic)
        {
            string[] keys = TradeRA.KeySearch("U_*");
            foreach (string key in keys)
            {
                Unit unit = UnitRA.Get(key);
                UnitDA.UpdateCapital(unit);
                Statement statement = new Statement()
                {
                    unit_id = unit.id,
                    capital_total = unit.capital_total,
                    capital_stock_value = unit.capital_stock_value,
                    capital_inout = unit.capital_inout,
                    fee = dic.ContainsKey(unit.id) ? dic[unit.id][0] : 0,
                    profit = dic.ContainsKey(unit.id) ? dic[unit.id][1] : 0,
                };
                StatementDA.Add(statement);
            }
        }
    }
}