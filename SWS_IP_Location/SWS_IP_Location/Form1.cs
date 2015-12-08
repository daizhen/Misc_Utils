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
            string result = IPLocationUtil.GetIPLocation("15.203.233.86");
        }
    }
}
