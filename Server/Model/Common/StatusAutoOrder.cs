using Model.Enum;
using System;
using System.Runtime.Serialization;

namespace Model.Common
{
    [DataContract]
    public class StatusAutoOrder
    {
        [DataMember]
        public long id { get; set; }

        [DataMember]
        public StatusAutoOrderEnum status { get; set; }
    }
}
