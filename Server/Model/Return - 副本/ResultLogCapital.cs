using Model.DB;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Model.Return
{
    [DataContract]
    public class ResultLogCapital : Base
    {
        [DataMember]
        public List<LogCapital> Data { get; set; }

        public ResultLogCapital(List<LogCapital> data)
        {
            Data = data;
        }
    }
}