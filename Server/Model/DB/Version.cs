using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Model.DB
{
    [DataContract]
    public class Version
    {
        [DataMember]
        public string version_no { get; set; }

        [DataMember]
        public int version { get; set; }
    }

    public class VersionFiles : Version
    {
        [DataMember]
        public int total_file_count { get; set; }

        [DataMember]
        public int total_size { get; set; }

        [DataMember]
        public List<ClientFile> files { get; set; }
    }
}