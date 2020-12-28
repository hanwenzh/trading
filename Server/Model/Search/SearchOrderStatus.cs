using Model.Enum;
using System;
using System.Runtime.Serialization;

namespace Model.Search
{
    [DataContract]
    public class SearchOrderStatus : Search, ISearch
    {
        [DataMember]
        public OrderStatusEnum status { get; set; }

        public new string Where()
        {
            string where = base.Where();
            if (status == OrderStatusEnum.Success)
                where += " AND state = 1";
            else if (status == OrderStatusEnum.Failed)
                where += " AND state = 2";
            else if (status == OrderStatusEnum.Abnormal)
                where += " AND state = 3";
            return where;
        }
    }
}