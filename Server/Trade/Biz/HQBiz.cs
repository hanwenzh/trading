using HQ;
using MySQLSrv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trade.Biz
{
    public class HQBiz
    {
        public static void Save()
        {
            lock (HQService.HQs)
            {
                var hqs = HQService.HQs.Where(h => h.Value.Last > 0);
                foreach (var kvp in hqs)
                {
                    HQDA.Add(kvp.Value);
                }
            }
        }
    }
}