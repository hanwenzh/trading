using Model.Enum;
using System;
using System.Runtime.Serialization;

namespace Model.Search
{
    [DataContract]
    public class SearchDealStatus : Search, ISearch
    {
        [DataMember]
        public DealStatusEnum status { get; set; }

        public new string Where()
        {
            string where = base.Where();
            if (status == DealStatusEnum.In)
                where += " AND unit_id > 0";
            else if (status == DealStatusEnum.Out)
                where += " AND unit_id = 0";
            return where;
        }
    }
}