using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SWS_IP_Location
{
    [DataContract]
    public class IPDataItem
    {
        [DataMember]
        public string location
        {
            get;
            set;
        }

        [DataMember]
        public string origip
        {
            get;
            set;
        }
    }
}
