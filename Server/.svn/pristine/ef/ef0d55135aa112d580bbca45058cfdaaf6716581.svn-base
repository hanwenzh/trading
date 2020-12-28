using Model.DB;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Model.Return
{
    [DataContract]
    public class ResultUser : Base
    {
        [DataMember]
        public List<User> Data { get; set; }

        public ResultUser(List<User> data)
        {
            Data = data;
        }
    }
}