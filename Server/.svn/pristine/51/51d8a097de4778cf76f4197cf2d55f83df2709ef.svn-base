using Common;
using Model.Enum;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Model.Return
{
    [DataContract]
    public class Return
    {
        private static Dictionary<string, string> Messages;

        static Return()
        {
            Messages = EnumHelper.GetDescription(typeof(ApiResultEnum));
        }

        [DataMember]
        public ApiResultEnum Code { get; set; }

        [DataMember]
        public string Message { get; set; }

        public Return(ApiResultEnum code = ApiResultEnum.Success)
        {
            Code = code;
            Message = Messages[code.ToString()];
        }
    }
}