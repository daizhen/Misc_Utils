namespace SWS_IP_Location
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.buttonGetIP = new System.Windows.Forms.Button();
			this.buttonProcess = new System.Windows.Forms.Button();
			this.buttonPhone = new System.Windows.Forms.Button();
			this.buttonPhoneLocation = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buttonGetIP
			// 
			this.buttonGetIP.Location = new System.Drawing.Point(28, 37);
			this.buttonGetIP.Name = "buttonGetIP";
			this.buttonGetIP.Size = new System.Drawing.Size(122, 23);
			this.buttonGetIP.TabIndex = 0;
			this.buttonGetIP.Text = "Extract IP";
			this.buttonGetIP.UseVisualStyleBackColor = true;
			this.buttonGetIP.Click += new System.EventHandler(this.buttonGetIP_Click);
			// 
			// buttonProcess
			// 
			this.buttonProcess.Location = new System.Drawing.Point(28, 101);
			this.buttonProcess.Name = "buttonProcess";
			this.buttonProcess.Size = new System.Drawing.Size(122, 23);
			this.buttonProcess.TabIndex = 1;
			this.buttonProcess.Text = "Process";
			this.buttonProcess.UseVisualStyleBackColor = true;
			this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
			// 
			// buttonPhone
			// 
			this.buttonPhone.Location = new System.Drawing.Point(28, 163);
			this.buttonPhone.Name = "buttonPhone";
			this.buttonPhone.Size = new System.Drawing.Size(122, 23);
			this.buttonPhone.TabIndex = 2;
			this.buttonPhone.Text = "Extract Phone";
			this.buttonPhone.UseVisualStyleBackColor = true;
			this.buttonPhone.Click += new System.EventHandler(this.buttonPhone_Click);
			// 
			// buttonPhoneLocation
			// 
			this.buttonPhoneLocation.Location = new System.Drawing.Point(28, 224);
			this.buttonPhoneLocation.Name = "buttonPhoneLocation";
			this.buttonPhoneLocation.Size = new System.Drawing.Size(122, 23);
			this.buttonPhoneLocation.TabIndex = 3;
			this.buttonPhoneLocation.Text = "Phone Location";
			this.buttonPhoneLocation.UseVisualStyleBackColor = true;
			this.buttonPhoneLocation.Click += new System.EventHandler(this.buttonPhoneLocation_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 482);
			this.Controls.Add(this.buttonPhoneLocation);
			this.Controls.Add(this.buttonPhone);
			this.Controls.Add(this.buttonProcess);
			this.Controls.Add(this.buttonGetIP);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.Button buttonGetIP;
		private System.Windows.Forms.Button buttonProcess;
        private System.Windows.Forms.Button buttonPhone;
		private System.Windows.Forms.Button buttonPhoneLocation;
    }
}

