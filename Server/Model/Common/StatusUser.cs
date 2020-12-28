using Model.Enum;
using System;
using System.Runtime.Serialization;

namespace Model.Common
{
    [DataContract]
    public class StatusUser
    {
        [DataMember]
        public long id { get; set; }

        [DataMember]
        public StatusUserEnum status { get; set; }
    }
}
