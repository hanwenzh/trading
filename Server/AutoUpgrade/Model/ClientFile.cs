using System;

namespace AutoUpgrade.Model
{
    public class ClientFile
    {
        public string name { get; set; }

        public string size { get; set; }

        public string version { get; set; }

        public string time { get; set; }
    }

    public class ClientFileCompare : ClientFile
    {
        public string size_new { get; set; }

        public string time_new { get; set; }

        public string need_upgrade { get; set; }
    }
}