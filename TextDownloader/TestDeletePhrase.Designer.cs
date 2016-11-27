namespace TextDownloader
{
    partial class TestDeletePhrase
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
            this.txtDeletePhrasePattern = new System.Windows.Forms.TextBox();
            this.cbDeletePhraseName = new System.Windows.Forms.ComboBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnReplace = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDeletePhrasePattern
            // 
            this.txtDeletePhrasePattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDeletePhrasePattern.Location = new System.Drawing.Point(13, 59);
            this.txtDeletePhrasePattern.Multiline = true;
            this.txtDeletePhrasePattern.Name = "txtDeletePhrasePattern";
            this.txtDeletePhrasePattern.Size = new System.Drawing.Size(400, 370);
            this.txtDeletePhrasePattern.TabIndex = 2;
            // 
            // cbDeletePhraseName
            // 
            this.cbDeletePhraseName.FormattingEnabled = true;
            this.cbDeletePhraseName.Location = new System.Drawing.Point(13, 13);
            this.cbDeletePhraseName.Name = "cbDeletePhraseName";
            this.cbDeletePhraseName.Size = new System.Drawing.Size(400, 27);
            this.cbDeletePhraseName.TabIndex = 1;
            this.cbDeletePhraseName.SelectedIndexChanged += new System.EventHandler(this.cbDeletePhraseName_SelectedIndexChanged);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(428, 59);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(246, 370);
            this.txtResult.TabIndex = 3;
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(428, 13);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(74, 26);
            this.txtAddress.TabIndex = 1;
            // 
            // btnReplace
            // 
            this.btnReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReplace.Location = new System.Drawing.Point(599, 11);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(75, 28);
            this.btnReplace.TabIndex = 5;
            this.btnReplace.Text = "Xóa";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload.Location = new System.Drawing.Point(518, 11);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 28);
            this.btnDownload.TabIndex = 6;
            this.btnDownload.Text = "Tải";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // TestDeletePhrase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 441);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.cbDeletePhraseName);
            this.Controls.Add(this.txtDeletePhrasePattern);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(700, 480);
            this.Name = "TestDeletePhrase";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thử nghiệm rule lọc rác";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDeletePhrasePattern;
        private System.Windows.Forms.ComboBox cbDeletePhraseName;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Button btnDownload;
    }
}