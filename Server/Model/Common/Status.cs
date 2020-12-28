using Model.Enum;
using System;
using System.Runtime.Serialization;

namespace Model.Common
{
    [DataContract]
    public class Status
    {
        [DataMember]
        public long id { get; set; }

        [DataMember]
        public StatusEnum status { get; set; }
    }
}
