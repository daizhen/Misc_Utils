namespace ExcelGather
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDir = new System.Windows.Forms.Button();
            this.textBoxDir = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBoxResult = new System.Windows.Forms.RichTextBox();
            this.textBoxDestDir = new System.Windows.Forms.TextBox();
            this.buttonDestDir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "原始文件夹：";
            // 
            // buttonDir
            // 
            this.buttonDir.Location = new System.Drawing.Point(791, 29);
            this.buttonDir.Name = "buttonDir";
            this.buttonDir.Size = new System.Drawing.Size(75, 20);
            this.buttonDir.TabIndex = 1;
            this.buttonDir.Text = "选择...";
            this.buttonDir.UseVisualStyleBackColor = true;
            this.buttonDir.Click += new System.EventHandler(this.buttonDir_Click);
            // 
            // textBoxDir
            // 
            this.textBoxDir.Location = new System.Drawing.Point(94, 29);
            this.textBoxDir.Name = "textBoxDir";
            this.textBoxDir.Size = new System.Drawing.Size(691, 20);
            this.textBoxDir.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(911, 392);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 55);
            this.button1.TabIndex = 3;
            this.button1.Text = "统计";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBoxResult
            // 
            this.richTextBoxResult.Location = new System.Drawing.Point(12, 86);
            this.richTextBoxResult.Name = "richTextBoxResult";
            this.richTextBoxResult.ReadOnly = true;
            this.richTextBoxResult.Size = new System.Drawing.Size(1063, 300);
            this.richTextBoxResult.TabIndex = 4;
            this.richTextBoxResult.Text = "";
            // 
            // textBoxDestDir
            // 
            this.textBoxDestDir.Location = new System.Drawing.Point(94, 55);
            this.textBoxDestDir.Name = "textBoxDestDir";
            this.textBoxDestDir.Size = new System.Drawing.Size(691, 20);
            this.textBoxDestDir.TabIndex = 7;
            // 
            // buttonDestDir
            // 
            this.buttonDestDir.Location = new System.Drawing.Point(791, 55);
            this.buttonDestDir.Name = "buttonDestDir";
            this.buttonDestDir.Size = new System.Drawing.Size(75, 20);
            this.buttonDestDir.TabIndex = 6;
            this.buttonDestDir.Text = "选择...";
            this.buttonDestDir.UseVisualStyleBackColor = true;
            this.buttonDestDir.Click += new System.EventHandler(this.buttonDestDir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "结果文件夹：";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 529);
            this.Controls.Add(this.textBoxDestDir);
            this.Controls.Add(this.buttonDestDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBoxResult);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxDir);
            this.Controls.Add(this.buttonDir);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDir;
        private System.Windows.Forms.TextBox textBoxDir;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBoxResult;
        private System.Windows.Forms.TextBox textBoxDestDir;
        private System.Windows.Forms.Button buttonDestDir;
        private System.Windows.Forms.Label label2;
    }
}

