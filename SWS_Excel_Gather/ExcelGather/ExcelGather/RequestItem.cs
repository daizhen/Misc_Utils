using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelGather
{
	public class RequestItem
	{
        /// <summary>
        /// 原始签章名
        /// </summary>
		public string RawName
		{
			get;
			set;
		}

        /// <summary>
        /// 标准名称
        /// </summary>
		public string FullName
		{
			get;
			set;
		}
        
        /// <summary>
        /// 序列号
        /// </summary>
		public string SerialNum
		{
			get;
			set;
		}

        /// <summary>
        /// 月份
        /// </summary>
		public int Month
		{
			get;
			set;
		}

        /// <summary>
        /// 总金额
        /// </summary>
		public double Money
		{
			get;
			set;
		}
        /// <summary>
        /// excel文件名
        /// </summary>
		public string FileName
		{
			get;
			set;
		}
	}
}
