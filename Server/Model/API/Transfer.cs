using System;
using System.Runtime.Serialization;

namespace Model.API
{
    [DataContract]
    public class Transfer
    {
        [DataMember]
        public int unit_id { get; set; }

        [DataMember]
        public string deal_no { get; set; }
    }
}