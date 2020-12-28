using Model.API;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Model.Return
{
    [DataContract]
    public class ResultAccountPosition : Base
    {
        [DataMember]
        public List<AccountPosition> Data { get; set; }

        public ResultAccountPosition(List<AccountPosition> data)
        {
            Data = data;
        }
    }
}