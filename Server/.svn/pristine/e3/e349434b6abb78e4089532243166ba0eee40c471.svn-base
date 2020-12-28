using Model.DB;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Model.Return
{
    [DataContract]
    public class ResultAccountGroup : Base
    {
        [DataMember]
        public List<AccountGroup> Data { get; set; }

        public ResultAccountGroup(List<AccountGroup> data)
        {
            Data = data;
        }
    }
}