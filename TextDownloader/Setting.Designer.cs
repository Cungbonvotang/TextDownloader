namespace TextDownloader
{
    partial class Setting
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
            this.tabSetting = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tpDeletePhrase = new System.Windows.Forms.TabPage();
            this.cbDeletePhraseName = new System.Windows.Forms.ComboBox();
            this.txtDeletePhrasePattern = new System.Windows.Forms.TextBox();
            this.tpRuleweb = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnTestRule = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.tabSetting.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.tpDeletePhrase.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSetting
            // 
            this.tabSetting.Controls.Add(this.tpGeneral);
            this.tabSetting.Controls.Add(this.tpDeletePhrase);
            this.tabSetting.Controls.Add(this.tpRuleweb);
            this.tabSetting.Location = new System.Drawing.Point(13, 13);
            this.tabSetting.Name = "tabSetting";
            this.tabSetting.SelectedIndex = 0;
            this.tabSetting.Size = new System.Drawing.Size(479, 405);
            this.tabSetting.TabIndex = 0;
            this.tabSetting.SelectedIndexChanged += new System.EventHandler(this.tabSetting_SelectedIndexChanged);
            // 
            // tpGeneral
            // 
            this.tpGeneral.Controls.Add(this.button1);
            this.tpGeneral.Controls.Add(this.comboBox1);
            this.tpGeneral.Controls.Add(this.textBox1);
            this.tpGeneral.Location = new System.Drawing.Point(4, 28);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeneral.Size = new System.Drawing.Size(471, 373);
            this.tpGeneral.TabIndex = 0;
            this.tpGeneral.Text = "Chung";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(401, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 36);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(7, 84);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(335, 27);
            this.comboBox1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(388, 26);
            this.textBox1.TabIndex = 0;
            // 
            // tpDeletePhrase
            // 
            this.tpDeletePhrase.Controls.Add(this.lblInfo);
            this.tpDeletePhrase.Controls.Add(this.cbDeletePhraseName);
            this.tpDeletePhrase.Controls.Add(this.txtDeletePhrasePattern);
            this.tpDeletePhrase.Location = new System.Drawing.Point(4, 28);
            this.tpDeletePhrase.Name = "tpDeletePhrase";
            this.tpDeletePhrase.Padding = new System.Windows.Forms.Padding(3);
            this.tpDeletePhrase.Size = new System.Drawing.Size(471, 373);
            this.tpDeletePhrase.TabIndex = 1;
            this.tpDeletePhrase.Text = "Lọc text rác";
            this.tpDeletePhrase.UseVisualStyleBackColor = true;
            // 
            // cbDeletePhraseName
            // 
            this.cbDeletePhraseName.FormattingEnabled = true;
            this.cbDeletePhraseName.Location = new System.Drawing.Point(0, 6);
            this.cbDeletePhraseName.Name = "cbDeletePhraseName";
            this.cbDeletePhraseName.Size = new System.Drawing.Size(343, 27);
            this.cbDeletePhraseName.TabIndex = 1;
            this.cbDeletePhraseName.SelectedIndexChanged += new System.EventHandler(this.cbDeletePhraseName_SelectedIndexChanged);
            // 
            // txtDeletePhrasePattern
            // 
            this.txtDeletePhrasePattern.Location = new System.Drawing.Point(-5, 49);
            this.txtDeletePhrasePattern.Multiline = true;
            this.txtDeletePhrasePattern.Name = "txtDeletePhrasePattern";
            this.txtDeletePhrasePattern.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDeletePhrasePattern.Size = new System.Drawing.Size(480, 328);
            this.txtDeletePhrasePattern.TabIndex = 0;
            this.txtDeletePhrasePattern.Enter += new System.EventHandler(this.txtDeletePhrasePattern_Enter);
            // 
            // tpRuleweb
            // 
            this.tpRuleweb.Location = new System.Drawing.Point(4, 28);
            this.tpRuleweb.Name = "tpRuleweb";
            this.tpRuleweb.Padding = new System.Windows.Forms.Padding(3);
            this.tpRuleweb.Size = new System.Drawing.Size(471, 373);
            this.tpRuleweb.TabIndex = 2;
            this.tpRuleweb.Text = "Rule web";
            this.tpRuleweb.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(413, 435);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(332, 435);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 28);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(251, 435);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 28);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "Mới";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Visible = false;
            // 
            // btnTestRule
            // 
            this.btnTestRule.Location = new System.Drawing.Point(17, 435);
            this.btnTestRule.Name = "btnTestRule";
            this.btnTestRule.Size = new System.Drawing.Size(75, 28);
            this.btnTestRule.TabIndex = 4;
            this.btnTestRule.Text = "Test";
            this.btnTestRule.UseVisualStyleBackColor = true;
            this.btnTestRule.Visible = false;
            this.btnTestRule.Click += new System.EventHandler(this.btnTestRule_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.ForeColor = System.Drawing.Color.Red;
            this.lblInfo.Location = new System.Drawing.Point(367, 9);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 19);
            this.lblInfo.TabIndex = 2;
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 475);
            this.Controls.Add(this.btnTestRule);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabSetting);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Setting";
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cài đặt";
            this.tabSetting.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.tpGeneral.PerformLayout();
            this.tpDeletePhrase.ResumeLayout(false);
            this.tpDeletePhrase.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSetting;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.TabPage tpDeletePhrase;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TabPage tpRuleweb;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox cbDeletePhraseName;
        private System.Windows.Forms.TextBox txtDeletePhrasePattern;
        private System.Windows.Forms.Button btnTestRule;
        private System.Windows.Forms.Label lblInfo;
    }
}