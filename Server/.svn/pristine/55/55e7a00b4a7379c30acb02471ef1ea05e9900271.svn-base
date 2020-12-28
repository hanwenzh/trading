using Model.DB;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Model.Return
{
    [DataContract]
    public class ResultUnit : Base
    {
        [DataMember]
        public List<Unit> Data { get; set; }

        public ResultUnit(List<Unit> data)
        {
            Data = data;
        }
    }
}