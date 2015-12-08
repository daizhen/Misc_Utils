using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;

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
            string url = "http://opendata.baidu.com/api.php?query={0}&co=&resource_id=6006&t=1449537589352&ie=utf8&oe=gbk&format=json&tn=baidu&_=1449537514110";
            HttpWebRequest request =WebRequest.Create(string.Format(url,ip)) as HttpWebRequest;
            request.Method = "GET";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(response.GetResponseStream(),System.Text.Encoding.GetEncoding("GBK"));
            string responseContent = reader.ReadToEnd();
            reader.Close();

            SearchMessage resultMessage = JsonToObject<SearchMessage>(responseContent);
            if (resultMessage.data != null && resultMessage.data.Count >= 1)
            {
                return resultMessage.data[0].location;
            }

            return string.Empty;
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
