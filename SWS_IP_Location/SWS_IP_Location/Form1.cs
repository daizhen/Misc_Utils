using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SWS_IP_Location
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        
        }

		private void buttonGetIP_Click(object sender, EventArgs e)
		{
			//string result = IPLocationUtil.GetIPLocation("15.203.233.86");
			Workbook currentWorkbook = new Workbook();
			currentWorkbook.Open("Trades.xls");

			Worksheet sheet = currentWorkbook.Worksheets[0];
			TradeIpHandler.ExtractIp(sheet);
			currentWorkbook.Save("Trades.xls");
		}

		private void buttonProcess_Click(object sender, EventArgs e)
		{
			Workbook currentWorkbook = new Workbook();
			currentWorkbook.Open("Trades.xls");
            TradeIpHandler.GetIpLocationList(currentWorkbook, "Trades_result.xls");
			//Worksheet sheet = currentWorkbook.Worksheets[0];

            //List<string> ipAddressList = TradeIpHandler.GetAllIp(sheet);
            //List<string> ipLocationList = TradeIpHandler.GetIpLocationList(ipAddressList);
            //for(int i =0;i<ipLocationList.Count;i++)
            //{
            //    sheet.Cells[i + 1, 0].PutValue(ipLocationList[i]);
            //}

		}
    }
}
