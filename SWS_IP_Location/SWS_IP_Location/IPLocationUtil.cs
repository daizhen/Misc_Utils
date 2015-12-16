using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;

namespace SWS_IP_Location
{
	public class IPLocationUtil
	{
		/// <summary>
		/// 根据ip获取归属地
		/// </summary>
		/// <param name="ip"></param>
		/// <returns></returns>
		public static string GetIPLocation(string ip)
		{
			bool success = false;
			string location = "";

			while (!success)
			{
				try
				{
                    DateTime s1 = DateTime.Now;
                    DateTime s = new DateTime(1970, 1, 1);
                    TimeSpan d = s1 - s;
                    int i = (int)d.TotalSeconds;

					string url = "http://opendata.baidu.com/api.php?query={0}&co=&resource_id=6006&t={1}&ie=utf8&oe=gbk&format=json&tn=baidu&_=1449537514110";
					HttpWebRequest request = WebRequest.Create(string.Format(url, ip,i)) as HttpWebRequest;
					request.Method = "GET";
					request.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
					request.Host = "sp0.baidu.com";
					request.Referer = "https://www.baidu.com/s?ie=utf-8&f=8&rsv_bp=1&rsv_idx=1&tn=baidu&wd=ip%E5%9C%B0%E5%9D%80&oq=ip%20%E6%AD%A3%E5%88%99&rsv_pq=ea0291bc00002d0d&rsv_t=1cc6%2BONOU6hj7P%2FWjJe73nS1kNYVPutVPpxna9WCMheyjZFlQHPGOff%2BaIo&rsv_enter=1&inputT=4852&rsv_sug3=24&rsv_sug1=23&bs=ip%20%E6%AD%A3%E5%88%99";
					request.UserAgent = "Mozilla/5.0 (Linux; U; Android 2.2; en-us; SCH-I800 Build/FROYO) AppleWebKit/533.1 (KHTML, like Gecko) Version/4.0 Mobile Safari/533.1";

					HttpWebResponse response = request.GetResponse() as HttpWebResponse;
					StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding("GBK"));
					string responseContent = reader.ReadToEnd();
					reader.Close();

					SearchMessage resultMessage = JsonToObject<SearchMessage>(responseContent);
					if (resultMessage.data != null && resultMessage.data.Count >= 1)
					{
						location = resultMessage.data[0].location;
					}
					success = true;
				}
				catch (Exception ex)
				{
					success = false;
					Thread.Sleep(500);
				}
			}
			return location;
		}

		public static string ObjectToJson(object obj)
		{
			string output = string.Empty;
			DataContractJsonSerializer dataSerializer = new DataContractJsonSerializer(obj.GetType());

			using (MemoryStream ms = new MemoryStream())
			{
				dataSerializer.WriteObject(ms, obj);
				output = Encoding.UTF8.GetString(ms.ToArray());
			}
			return output;
		}

		public static T JsonToObject<T>(string strJson) where T : class
		{
			DataContractJsonSerializer deSerializer = new DataContractJsonSerializer(typeof(T));
			T result = null;

			using (MemoryStream memoryStre = new MemoryStream(Encoding.UTF8.GetBytes(strJson)))
			{
				try
				{
					result = deSerializer.ReadObject(memoryStre) as T;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			return result;
		}
	}
}
