using Model.Enum;
using System;
using System.Runtime.Serialization;

namespace Model.Return
{
    [DataContract]
    public class ResultLong : Base
    {
        [DataMember]
        public long Data { get; set; }

        public ResultLong(ApiResultEnum code, long data) : base(code)
        {
            Data = data;
        }
    }
}