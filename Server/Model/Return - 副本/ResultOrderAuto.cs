using Model.API;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Model.Return
{
    [DataContract]
    public class ResultOrderAuto : Base
    {
        [DataMember]
        public List<OrderAuto> Data { get; set; }

        public ResultOrderAuto(List<OrderAuto> data)
        {
            Data = data;
        }
    }
}