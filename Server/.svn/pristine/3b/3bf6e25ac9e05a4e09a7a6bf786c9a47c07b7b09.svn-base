using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Model.Return
{
    [DataContract]
    public class ResultBase : Base
    {
        [DataMember]
        public List<Common.Base> Data { get; set; }

        public ResultBase(List<Common.Base> data)
        {
            Data = data;
        }
    }
}