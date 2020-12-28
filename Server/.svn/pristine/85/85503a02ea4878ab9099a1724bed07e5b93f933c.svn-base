using Model.DB;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Model.Return
{
    [DataContract]
    public class ResultLogTrade : Base
    {
        [DataMember]
        public List<LogTrade> Data { get; set; }

        public ResultLogTrade(List<LogTrade> data)
        {
            Data = data;
        }
    }
}