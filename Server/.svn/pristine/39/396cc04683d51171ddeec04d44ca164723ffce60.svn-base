using Model.DB;
using Model.Enum;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Model.Return
{
    [DataContract]
    public class ResultVersion : Base
    {
        [DataMember]
        public Version Data { get; set; }

        public ResultVersion(ApiResultEnum code, Version data) : base(code)
        {
            Data = data;
        }
    }

    [DataContract]
    public class ResultVersionFiles : Base
    {
        [DataMember]
        public VersionFiles Data { get; set; }

        public ResultVersionFiles(ApiResultEnum code, VersionFiles data) : base(code)
        {
            Data = data;
        }
    }
}