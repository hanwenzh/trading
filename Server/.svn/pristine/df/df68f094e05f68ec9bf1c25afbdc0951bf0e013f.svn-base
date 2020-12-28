using Model.Enum;
using System;
using System.Runtime.Serialization;

namespace Model.Common
{
    [DataContract]
    public class StatusOrder
    {
        public StatusOrder(int _id, StatusOrderEnum _status)
        {
            id = _id;
            status = _status;
        }

        [DataMember]
        public int id { get; set; }

        [DataMember]
        public StatusOrderEnum status { get; set; }
    }
}
