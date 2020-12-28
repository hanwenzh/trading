using System;
using System.Runtime.Serialization;

namespace Model.DB
{
    [DataContract]
    public class ClientFile
    {
        [DataMember]
        public string name { get; set; }

        [DataMember]
        public int size { get; set; }

        [DataMember]
        public int version { get; set; }

        [DataMember]
        public string time { get; set; }
    }
}
