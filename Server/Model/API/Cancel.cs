using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Model.API
{
    [DataContract]
    public class Cancel
    {
        [DataMember]
        public int unit_id { get; set; }

        [DataMember]
        public List<string> trade_nos { get; set; }
    }
}