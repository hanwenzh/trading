using Model.Enum;
using System;
using System.Runtime.Serialization;

namespace Model.Return
{
    [DataContract]
    public class Result<T> : Return
    {
        [DataMember]
        public T Data { get; set; }

        public Result(ApiResultEnum code) : base(code)
        {
        }

        public Result(ApiResultEnum code, T data) : base(code)
        {
            Data = data;
        }
    }
}