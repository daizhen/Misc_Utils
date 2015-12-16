using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SWS_IP_Location
{
	[DataContract]
	public class MobileResponseMessage
	{
		[DataMember]
		public string message
		{
			get;
			set;
		}
		[DataMember]
		public int error_code
		{
			get;
			set;
		}
		[DataMember]
		public MobileDataItem data
		{
			get;
			set;
		}
	}
}
