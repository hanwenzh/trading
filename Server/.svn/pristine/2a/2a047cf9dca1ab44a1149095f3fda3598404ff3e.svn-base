using Model.Common;
using System;
using System.Runtime.Serialization;

namespace Model.DB
{
    [DataContract]
    public class LogTrade
    {
        [DataMember]
        public string date { get; set; }

        [DataMember]
        public string time_open { get; set; }

        [DataMember]
        public string operator_open { get; set; }

        [DataMember]
        public string time_close { get; set; }

        [DataMember]
        public string operator_close { get; set; }

        private string _state;
        [DataMember]
        [UnValue]
        public string state
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(time_close))
                    return "已收盘";
                else
                    return _state;
            }
            set
            {
                _state = value;
            }
        }
    }
}