using Model.DB;
using Model.Enum;
using System;
using System.Runtime.Serialization;

namespace Model.Return
{
    [DataContract]
    public class ResultLogin : Result<User>
    {
        [DataMember]
        public string Token { get; set; }

        public ResultLogin(ApiResultEnum code, User data, string token) : base(code, data)
        {
            Token = token;
        }
    }
}