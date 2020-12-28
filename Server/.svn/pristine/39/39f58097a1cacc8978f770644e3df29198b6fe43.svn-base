using Model.DB;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Model.Return
{
    [DataContract]
    public class ResultPosition : Base
    {
        [DataMember]
        public List<Position> Data { get; set; }

        public ResultPosition(List<Position> data)
        {
            Data = data;
        }
    }
}