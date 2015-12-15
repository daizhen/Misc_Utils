using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SWS_IP_Location
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
		{
			Aspose.Cells.License license = new Aspose.Cells.License();
			license.SetLicense("Aspose.Words.lic");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
