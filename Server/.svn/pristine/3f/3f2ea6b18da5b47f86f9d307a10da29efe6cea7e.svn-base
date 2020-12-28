using RedisSrv.Helper;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RedisSrv
{
    public class TradeRA
    {
        public static void SetFields(string key, Dictionary<string, string> items)
        {
            HashEntry[] entries = items.Select(kvp => new HashEntry(kvp.Key, kvp.Value ?? "")).ToArray();
            RedisBiz.Trade.HashSet(key, entries);
        }

        public static Dictionary<string, string> GetFields(string key)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            HashEntry[] hes = RedisBiz.Trade.HashGetAll(key);
            foreach(HashEntry he in hes)
            {
                dic.Add(he.Name, he.Value.HasValue ? he.Value.ToString() : null);
            }
            return dic;
        }

        public static bool Set(string key, string field, string value)
        {
            return RedisBiz.Trade.HashSet(key, field, value);
        }

        public static string Get(string key, string field)
        {
            RedisValue rv = RedisBiz.Trade.HashGet(key, field);
            return rv.HasValue ? rv.ToString() : "";
        }

        public static int GetInt(string key, string field)
        {
            RedisValue rv = RedisBiz.Trade.HashGet(key, field);
            return rv.HasValue ? int.Parse(rv.ToString()) : 0;
        }

        public static double Increment(string key, string field, float delta)
        {
            return RedisBiz.Trade.HashIncrement(key, field, delta);
        }

        public static bool SetExpire(string key)
        {
            return RedisBiz.Trade.KeyExpire(key, DateTime.Now.Date.AddDays(5).AddHours(22));
        }

        public static bool KeyExists(string key)
        {
            return RedisBiz.Trade.KeyExists(key);
        }

        public static bool KeyRename(string key_old, string key_new)
        {
            return RedisBiz.Trade.KeyRename(key_old, key_new);
        }

        public static string[] KeySearch(string keyPattern)
        {
            return RedisBiz.Trade.KeySearch(keyPattern);
        }

        public static bool Delete(string key)
        {
            return RedisBiz.Trade.KeyDelete(key);
        }
    }
}