using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ExcelGather
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBoxDir.Text = dialog.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
			string folder = @"C:\Users\dz\Downloads\凭证购买2015\{0}月凭证领用";
			string resultFileName = "2015.xls";

			int[] monthList = new int[] { 1, 2, 3, 4, 5, 6, 7, 8,9,10,11,12 };
			foreach (int month in monthList)
			{
				var items = GroupHandler.LoadItems(month, string.Format(folder, month));
				GroupHandler.Export(items, resultFileName, month);
			}
			//if (GetherData(textBoxDir.Text, textBoxDestDir.Text))
			//{
			//	MessageBox.Show("操作成功");
			//}
		}

        private bool GetherData(string dirPath,string destDirPath)
        {
            int[] columnValues_1 = new int[34];
            int[] columnValues_2 = new int[34];

            //工商银行
            // 中信银行
            // 兴业银行
            // 招商银行
             
            int gsyh = 0;
            int zxyh = 0;
            int xyyh = 0;
            int zsyh = 0; 

            DirectoryInfo dir = new DirectoryInfo(dirPath);

            var files = dir.GetFiles();
            foreach (var file in files)
            {
                if (file.Extension != ".xls")
                {
                    continue;
                }

                try
                {
					Workbook currentWorkbook = new Workbook();
					currentWorkbook.Open(file.FullName);
                    Worksheet sheet = currentWorkbook.Worksheets[0];

                    for (var i = 0; i < 34; i++)
                    {
                        if (sheet.Cells[i + 3, 2].Value != null)
                        {
                            columnValues_1[i] += sheet.Cells[i + 3, 2].IntValue;
                        }
                        if (sheet.Cells[i + 3, 9].Value != null)
                        {
                            columnValues_2[i] += sheet.Cells[i + 3, 9].IntValue;
                        }
                    }

                    int current_gsyh = ConvertNumber(sheet.Cells[2, 16].StringValue);
                    int current_zxyh = ConvertNumber(sheet.Cells[3, 16].StringValue);
                    int current_xyyh = ConvertNumber(sheet.Cells[4, 16].StringValue);
                    int current_zsyh = ConvertNumber(sheet.Cells[5, 16].StringValue);
                    gsyh += current_gsyh;
                    zxyh += current_zxyh;
                    xyyh += current_xyyh;
                    zsyh += current_zsyh;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(file.Name + "数据不合法");
                    return false;
                }
            }

            //Load the template and fill it will the result data. Then save it to the specified folder with name "Result.xls"
            Workbook resultWorkbook = new Workbook();
			resultWorkbook.Open("Template.xls");

            Worksheet resultSheet = resultWorkbook.Worksheets[0];

            for (var i = 0; i < 34; i++)
            {
                resultSheet.Cells[i + 3, 2].PutValue( columnValues_1[i]);
                resultSheet.Cells[i + 3, 9].PutValue( columnValues_2[i]);
            }
            resultSheet.Cells[2, 16].PutValue(gsyh + "本");
            resultSheet.Cells[3, 16].PutValue(zxyh + "本");
            resultSheet.Cells[4, 16].PutValue(xyyh + "本");
            resultSheet.Cells[5, 16].PutValue(zsyh + "本");
            resultWorkbook.Save(destDirPath + "\\Result.xls");
            return true;
        }
        private int ConvertNumber(string rawText)
        {
            if (string.IsNullOrEmpty(rawText) || rawText.Equals("本"))
            {
                return 0;
            }
            if (rawText.EndsWith("本"))
            {

                return Convert.ToInt32(rawText.Substring(0, rawText.Length - 1));
            }
            return Convert.ToInt32(rawText);
        }

        private void buttonDestDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBoxDestDir.Text = dialog.SelectedPath;
            }
        }
       
    }
}
