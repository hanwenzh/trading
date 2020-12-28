using Model.API;
using System;
using System.Runtime.Serialization;

namespace Model.Return
{
    [DataContract]
    public class ResultUnitCapital : Base
    {
        [DataMember]
        public UnitCapital Data { get; set; }

        public ResultUnitCapital(UnitCapital data)
        {
            Data = data;
        }
    }
}