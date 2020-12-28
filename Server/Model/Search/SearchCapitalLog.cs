using System;
using System.Runtime.Serialization;

namespace Model.Search
{
    [DataContract]
    public class SearchCapitalLog : SearchUnit, ISearch
    {
        [DataMember]
        public int type { get; set; }

        public new string Where()
        {
            string where = base.Where();
            where += " AND type = " + type;
            return where;
        }
    }
}