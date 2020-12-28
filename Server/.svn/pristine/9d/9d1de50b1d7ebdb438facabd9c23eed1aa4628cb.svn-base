using Model.DB;
using Model.Enum;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Model.Return
{
    [DataContract]
    public class ResultDeal : Base
    {
        [DataMember]
        public List<Deal> Data { get; set; }

        public ResultDeal(List<Deal> data)
        {
            Data = data;
        }

        public ResultDeal(ApiResultEnum code) : base(code)
        {
        }
    }
}