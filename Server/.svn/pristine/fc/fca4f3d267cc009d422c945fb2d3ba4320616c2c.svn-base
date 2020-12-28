using Common;
using System;
using System.Runtime.Serialization;

namespace Model.Search
{
    [DataContract]
    public class Search : ISearch
    {
        [DataMember]
        public string from { get; set; }

        [DataMember]
        public string to { get; set; }

        public DateTime from_dt { get { return string.IsNullOrWhiteSpace(from) ? DateTime.Now.Date : DateTime.Parse(from); } set { } }

        public DateTime to_dt { get { return string.IsNullOrWhiteSpace(to) ? DateTime.Now.Date : DateTime.Parse(to); } set { } }

        public string Where()
        {
            string where = "";
            if (!string.IsNullOrWhiteSpace(from))
            {
                where += " AND time_dt >= '" + from + "'";
            }
            if (!string.IsNullOrWhiteSpace(to))
            {
                where += " AND time_dt <= '" + to + " 23:59:59'";
            }
            return where;
        }
    }
}