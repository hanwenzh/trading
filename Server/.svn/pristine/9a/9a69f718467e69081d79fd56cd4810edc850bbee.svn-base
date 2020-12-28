using MySQLSrv;
using System;
using System.Collections.Generic;

namespace Trade.Biz
{
    public class Config
    {
        public static void Init()
        {
            Dictionary<string, string> dic = ConfigDA.List();
            client_version_no = dic["client_version_no"];
            client_version = int.Parse(dic["client_version"]);
        }

        public static string client_version_no { get; set; }
        public static int client_version { get; set; }
}
}