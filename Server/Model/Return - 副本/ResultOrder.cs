using Model.DB;
using Model.Enum;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Model.Return
{
    [DataContract]
    public class ResultOrder : Base
    {
        [DataMember]
        public List<Order> Data { get; set; }

        public ResultOrder(List<Order> data)
        {
            Data = data;
        }

        public ResultOrder(ApiResultEnum code) : base(code)
        {
        }
    }
}