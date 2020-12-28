using Model.Enum;
using System;
using System.Runtime.Serialization;

namespace Model.Return
{
    [DataContract]
    public class Result : Return
    {
        [DataMember]
        public string Data { get; set; }

        public Result(ApiResultEnum code, string data) : base(code)
        {
            Data = data;
        }
    }
}