using Model.Enum;
using System;
using System.Runtime.Serialization;

namespace Model.API
{
    [DataContract]
    public class PositionMoveIn
    {
        [DataMember]
        public int unit_id { get; set; }

        [DataMember]
        public int account_id { get; set; }

        [DataMember]
        public string code { get; set; }

        [DataMember]
        public int count { get; set; }

        [DataMember]
        public decimal price_cost { get; set; }
    }
}