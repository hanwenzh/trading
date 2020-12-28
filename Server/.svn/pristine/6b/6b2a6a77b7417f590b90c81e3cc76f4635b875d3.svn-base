using RedisSrv.Helper;
using StackExchange.Redis;
using System;

namespace RedisSrv
{
    public class MonitorRA
    {
        public static bool SetStatusTrade(int value)
        {
            return RedisBiz.Monitor.StringSet("status_trade", value.ToString(), Expiry);
        }

        public static int GetStatusTrade()
        {
            RedisValue rv = RedisBiz.Monitor.StringGet("status_trade");
            if (rv.HasValue)
                return int.Parse(rv.ToString());
            return 0;
        }

        public static bool Set(string key, string field, string value)
        {
            bool flag = RedisBiz.Monitor.HashSet(key, field, value);
            SetExpire(key);
            return flag;
        }

        public static double Increment(string key, string field, float delta = 1)
        {
            return RedisBiz.Monitor.HashIncrement(key, field, delta);
        }

        public static bool SetExpire(string key)
        {
            return RedisBiz.Monitor.KeyExpire(key, DateTime.Now.Date.AddDays(5).AddHours(22));
        }

        public static bool KeyExists(string key)
        {
            return RedisBiz.Monitor.KeyExists(key);
        }

        public static bool HashExists(string key, string field)
        {
            return RedisBiz.Monitor.HashExists(key, field);
        }

        public static TimeSpan Expiry
        {
            get
            {
                return DateTime.Now.Date.AddHours(23) - DateTime.Now;
            }
        }
    }
}