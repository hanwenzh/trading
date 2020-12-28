using Model.DB;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Model.Return
{
    [DataContract]
    public class ResultAccount : Base
    {
        [DataMember]
        public List<Account> Data { get; set; }

        public ResultAccount(List<Account> data)
        {
            Data = data;
        }
    }
}