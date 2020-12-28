using Model.DB;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Model.Return
{
    [DataContract]
    public class ResultStatement : Base
    {
        [DataMember]
        public List<Statement> Data { get; set; }

        public ResultStatement(List<Statement> data)
        {
            Data = data;
        }
    }
}