namespace TextDownloader
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnChapList = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.tipInfo = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(12, 12);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(359, 26);
            this.txtAddress.TabIndex = 1;
            this.txtAddress.Text = "http://www.shumilou.co/suohun/";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 59);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(71, 19);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Tiến trình: ";
            // 
            // btnChapList
            // 
            this.btnChapList.Location = new System.Drawing.Point(298, 98);
            this.btnChapList.Name = "btnChapList";
            this.btnChapList.Size = new System.Drawing.Size(75, 28);
            this.btnChapList.TabIndex = 3;
            this.btnChapList.Text = "DSC";
            this.btnChapList.UseVisualStyleBackColor = true;
            this.btnChapList.Click += new System.EventHandler(this.btnChapList_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Location = new System.Drawing.Point(217, 98);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(75, 28);
            this.btnSetting.TabIndex = 5;
            this.btnSetting.Text = "Cài đặt";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(12, 103);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(140, 19);
            this.lblInfo.TabIndex = 6;
            this.lblInfo.Text = "Hỗ trợ, góp ý, báo lỗi";
            this.lblInfo.Click += new System.EventHandler(this.lblInfo_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 138);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.btnChapList);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtAddress);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Text Downloader 2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnChapList;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ToolTip tipInfo;
    }
}

