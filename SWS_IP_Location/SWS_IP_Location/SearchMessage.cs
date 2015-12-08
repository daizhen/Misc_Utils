using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text;

namespace SWS_IP_Location
{
    [DataContract]
    public class SearchMessage
    {
        [DataMember]
        public string status
        {
            get;
            set;
        }
        [DataMember]
        public string t
        {
            get;
            set;
        }

        [DataMember]
        public Collection<IPDataItem> data
        {
            get;
            set;
        }
    }
}
