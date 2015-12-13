﻿using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ExcelGather
{
	public class GroupHandler
	{
		public static Dictionary<string, int> LoadBrancheNameIds()
		{
			string[] noisyWords = new string[] { "营业部", "营业", "证券", "西南总部", "管理部", "投资部", "资产" };

			string fileName = "allbranch.xls";
			Dictionary<string, int> branches = new Dictionary<string, int>();

			Workbook currentWorkbook = new Workbook();
			currentWorkbook.Open(fileName);
			Worksheet sheet = currentWorkbook.Worksheets[0];

			for (var i = 1; i < 127; i++)
			{
				string netName = sheet.Cells[i, 1].StringValue;
				foreach (var word in noisyWords)
				{
					netName = netName.Replace(word, string.Empty);
				}
				if (!string.IsNullOrEmpty(netName))
				{
					branches.Add(netName, sheet.Cells[i, 0].IntValue);
				}
			}
			return branches;
		}

		public static Dictionary<int, string> LoadBrancheIdNames()
		{
			string fileName = "allbranch.xls";
			Dictionary<int, string> branches = new Dictionary<int, string>();

			Workbook currentWorkbook = new Workbook();
			currentWorkbook.Open(fileName);
			Worksheet sheet = currentWorkbook.Worksheets[0];

			for (var i = 1; i < 127; i++)
			{
				branches.Add(sheet.Cells[i, 0].IntValue, sheet.Cells[i, 1].StringValue);
			}
			return branches;
		}


		public static int GetLeastEditDistance(string source, string dest)
		{
			int[,] matrix = new int[source.Length + 1, dest.Length + 1];

			for (int i = 0; i < source.Length + 1; i++)
			{
				matrix[i, 0] = i;
			}
			for (int i = 0; i < dest.Length + 1; i++)
			{
				matrix[0, i] = i;
			}

			for (int i = 1; i < source.Length + 1; i++)
			{
				for (int j = 1; j < dest.Length + 1; j++)
				{
					int ed_add = matrix[i - 1, j] + 1;
					int ed_delete = matrix[i, j - 1] + 1;
					int ed_edit = matrix[i - 1, j - 1] + (source[i - 1] == dest[j - 1] ? 0 : 1);
					matrix[i, j] = Math.Min(ed_add, Math.Min(ed_delete, ed_edit));

				}
			}
			return matrix[source.Length, dest.Length];
		}


		public static List<RequestItem> LoadItems(int month, string folder)
		{
			List<RequestItem> items = new List<RequestItem>();
			string namePrefix = "营业部名称(签章)：";

			DirectoryInfo dir = new DirectoryInfo(folder);

			Regex reg = new Regex("^(\\d+)");
			var files = dir.GetFiles();
			Dictionary<int, string> branches = LoadBrancheIdNames();
			Dictionary<string, int> branches_1 = LoadBrancheNameIds();

			foreach (var file in files)
			{
				if (file.Extension == ".xls" || file.Extension == ".xlsx")
				{
					RequestItem requestItem = new RequestItem();
					requestItem.Month = month;
					string fileName = file.Name;
					requestItem.FileName = fileName;
					Match matchResult = reg.Match(fileName);
					if (matchResult.Success)
					{
						string id = matchResult.Groups[0].Value;
						if (branches.ContainsKey(Convert.ToInt32(id)))
						{
							requestItem.SerialNum = id;
							requestItem.FullName = branches[Convert.ToInt32(id)];
						}
						else
						{
							requestItem.SerialNum = "-" + id;
							Console.WriteLine("Id of :" + id + " not valid --" + fileName);
						}
					}

					Workbook currentWorkbook = new Workbook();
					currentWorkbook.Open(file.FullName);
					Worksheet sheet = currentWorkbook.Worksheets[0];


					//Set Name
					string rawName = sheet.Cells[1, 0].StringValue;
					if (rawName.StartsWith(namePrefix))
					{
						requestItem.RawName = rawName.Substring(namePrefix.Length);
					}
					else
					{
						Console.WriteLine("Name Error:" + fileName);
					}
					//Set Full Name
					if (string.IsNullOrEmpty(requestItem.SerialNum) || requestItem.SerialNum.StartsWith("-"))
					{
						double sim_FileName;
						double sim_RawName;

						string serial_FileName = GuessMostSimilarBranchId(requestItem.FileName, branches_1, out sim_FileName).ToString();
						string serial_RawName = GuessMostSimilarBranchId(requestItem.RawName, branches_1, out sim_RawName).ToString();

						if (sim_FileName > sim_RawName)
						{
							requestItem.SerialNum = serial_FileName;
						}
						else
						{
							requestItem.SerialNum = serial_RawName;
						}
						requestItem.FullName = branches[Convert.ToInt32(requestItem.SerialNum)];
					}

					//Set Money

					double money = 0.0;
					if (!IsValidMoneyValue(sheet.Cells[37, 2].StringValue, out money))
					{
						if (!IsValidMoneyValue(sheet.Cells[36, 12].StringValue, out money))
						{
							if (!IsValidMoneyValue(sheet.Cells[36, 11].StringValue, out money))
							{
								IsValidMoneyValue(sheet.Cells[36, 9].StringValue, out money);
							}
						}
					}
					if (money == 0.0)
					{
						Console.WriteLine("Money  Convert Error:" + fileName);
					}
					requestItem.Money = money;
					items.Add(requestItem);
				}
			}
			return items;
		}

		public static void Export(List<RequestItem> items, string fileName, int month)
		{
			string sheetName = month + "月";
			Workbook currentWorkbook = new Workbook();
			currentWorkbook.Open(fileName);
			Worksheet sheet = currentWorkbook.Worksheets[sheetName];
			if (sheet == null)
			{
				currentWorkbook.Worksheets.Add(sheetName);
				sheet = currentWorkbook.Worksheets[sheetName];
			}
			sheet.Cells[0, 0].PutValue("原名称");
			sheet.Cells[0, 1].PutValue("文件名");
			sheet.Cells[0, 2].PutValue("标准名称");
			sheet.Cells[0, 3].PutValue("编号");
			sheet.Cells[0, 4].PutValue("钱");

			for (int i = 0; i < items.Count; i++)
			{
				sheet.Cells[i + 1, 0].PutValue(items[i].RawName);
				sheet.Cells[i + 1, 1].PutValue(items[i].FileName);
				sheet.Cells[i + 1, 2].PutValue(items[i].FullName);
				sheet.Cells[i + 1, 3].PutValue(items[i].SerialNum);
				sheet.Cells[i + 1, 4].PutValue(items[i].Money);

			}

			//Add items to summary sheet

			Worksheet sheetSummary = currentWorkbook.Worksheets["Summary"];	
			for (int i = 1; i <= 127; i++)
			{
				var list = items.FindAll(p => p.SerialNum == sheetSummary.Cells[i, 0].StringValue);
				double resultValue =Sum(list);
				if(resultValue!=0)
				{
					sheetSummary.Cells[i, month + 1].PutValue(resultValue);
				}
			}
			currentWorkbook.Save(fileName);
		}

		public static double Sum(List<RequestItem> items)
		{
			double money = 0;
			foreach (var item in items)
			{
				money += item.Money;
			}
			return money;
		}

		public static double CalcSimilar(string source, string dest)
		{
			if (source.Length == 0)
			{
				return 0;
			}
			if (string.IsNullOrEmpty(dest))
			{
				return 0;
			}
			int count = 0;
			for (int i = 0; i < source.Length; i++)
			{
				if (dest.Contains(source[i] + ""))
				{
					count++;
				}
			}

			return count;
		}

		public static bool IsValidMoneyValue(string rawStr, out double value)
		{
			value = 0;
			if (string.IsNullOrEmpty(rawStr))
			{
				return false;
			}
			if (rawStr.EndsWith("元"))
			{
				if (Double.TryParse(rawStr.Substring(0, rawStr.Length - 1).Trim(), out value))
				{
					return true;
				}
			}
			return Double.TryParse(rawStr, out value);
		}

		public static int GuessMostSimilarBranchId(string rawName, Dictionary<string, int> brancheNameIds, out double value)
		{
			int branchId = -1;
			double simility = 0.0;
			string[] noisyWords = new string[] { "营业部", "营业", "证券", "西南", "总部", "管理部", "投资部", "资产", "股份有限公司", "业务凭证", "领取表" };
			if (string.IsNullOrEmpty(rawName))
			{
				rawName = "";
			}
			string netName = rawName;
			foreach (var word in noisyWords)
			{
				netName = netName.Replace(word, string.Empty);
			}
			foreach (var pair in brancheNameIds)
			{
				double currentSim = CalcSimilar(pair.Key, netName);
				if (branchId < 0)
				{
					branchId = pair.Value;
					simility = currentSim;
				}
				else
				{
					if (currentSim > simility)
					{
						simility = currentSim;
						branchId = pair.Value;
					}
				}
			}
			value = simility;
			return branchId;
		}
	
	}
}
