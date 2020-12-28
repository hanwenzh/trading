using System;
using System.Runtime.Serialization;

namespace Model.Search
{
    [DataContract]
    public class SearchUnit : Search, ISearch
    {
        [DataMember]
        public int unit_id { get; set; }

        public new string Where()
        {
            string where = base.Where();
            where += " AND unit_id = " + unit_id;
            return where;
        }
    }
}