using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SWS_IP_Location
{
    [DataContract]
	public class MobileDataItem
    {
        [DataMember]
		public string province
        {
            get;
            set;
        }

		[DataMember]
		public string city
		{
			get;
			set;
		}
		[DataMember]
		public string telephone
		{
			get;
			set;
		}
		[DataMember(Name = "operator")]
		public string Operator
		{
			get;
			set;
		}
		public override string ToString()
		{
			return province + "/" + city + "/" + Operator;
		}
	}
}
