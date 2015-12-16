using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SWS_IP_Location
{
	public class TradeIpHandler
	{
		public static void ExtractIp(Worksheet sheet)
		{
            Regex ipReg = new Regex(@"((?:(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d))))");

			int rowIndex = 1;
			while (sheet.Cells[rowIndex, 2].Value != null)
			{
				string rawIpStr = sheet.Cells[rowIndex, 8].StringValue;
				var matchResult = ipReg.Match(rawIpStr);
				if (matchResult.Success)
				{
					sheet.Cells[rowIndex, 1].PutValue(matchResult.Groups[0].Value);
				}
				rowIndex++;
			}
		}

        public static void ExtractMobilePhone(Worksheet sheet)
        {
            Regex ipReg = new Regex(@"(\[\d{11}\])");

            int rowIndex = 1;
            while (sheet.Cells[rowIndex, 2].Value != null)
            {
                string rawIpStr = sheet.Cells[rowIndex, 8].StringValue;
                var matchResult = ipReg.Match(rawIpStr);
                if (matchResult.Success)
                {
                    sheet.Cells[rowIndex, 1].PutValue(matchResult.Groups[0].Value);
                }
                rowIndex++;
            }

        }

		public static List<string> GetAllIp(Worksheet sheet)
		{
			List<string> ipList = new List<string>();
			int rowIndex = 1;
			while (sheet.Cells[rowIndex, 2].Value != null)
			{
				ipList.Add(sheet.Cells[rowIndex, 1].StringValue);
				rowIndex++;
			}

			return ipList;
		}

		public static List<string> GetIpLocationList(List<string> ipAddresses)
		{
			List<string> locationList = new List<string>();
			int index = 0;
			foreach (var address in ipAddresses)
			{
				if (!string.IsNullOrEmpty(address))
				{
					string result = IPLocationUtil.GetIPLocation(address);
					locationList.Add(result);
				}
				else
				{
					locationList.Add(string.Empty);
				}
				index++;
				if (index % 500 == 0)
				{
					Console.WriteLine(index);
				}
				Thread.Sleep(30);
			}
			return locationList;
		}
        public static void GetIpLocationList(Workbook workbook,string filePath )
        {
            Worksheet sheet = workbook.Worksheets[0];

            List<string> locationList = new List<string>();

            int rowIndex = 1;
            while (sheet.Cells[rowIndex, 2].Value != null)
            {
                string ipaddress = sheet.Cells[rowIndex, 1].StringValue;
                string result = IPLocationUtil.GetIPLocation(ipaddress);
                sheet.Cells[rowIndex, 0].PutValue(result);
                if (rowIndex % 10 == 0)
                {
                    workbook.Save(filePath);
                }
                Console.WriteLine(rowIndex);
                rowIndex++;
                Thread.Sleep(50);
            }

        }

	}
}
