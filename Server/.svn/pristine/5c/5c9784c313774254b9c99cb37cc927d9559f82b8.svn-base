using System;

namespace RedisSrv.Helper
{
    internal class RedisBiz
    {
        internal static RedisHelper Monitor;
        internal static RedisHelper User;
        internal static RedisHelper Trade;

        static RedisBiz()
        {
            Monitor = new RedisHelper(7);
            User = new RedisHelper(8);
            Trade = new RedisHelper((int)DateTime.Now.DayOfWeek);
        }
    }
}
