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
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.txtSaveFilePath = new System.Windows.Forms.TextBox();
            this.tpDeletePhrase = new System.Windows.Forms.TabPage();
            this.lblInfo = new System.Windows.Forms.Label();
            this.cbDeletePhraseName = new System.Windows.Forms.ComboBox();
            this.txtDeletePhrasePattern = new System.Windows.Forms.TextBox();
            this.tpRuleweb = new System.Windows.Forms.TabPage();
            this.chkIsRightToLeft = new System.Windows.Forms.CheckBox();
            this.chkIsReverse = new System.Windows.Forms.CheckBox();
            this.chkIsEncodeGB2312 = new System.Windows.Forms.CheckBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.txtChapAddress = new System.Windows.Forms.TextBox();
            this.txtChapList = new System.Windows.Forms.TextBox();
            this.txtRuleName = new System.Windows.Forms.TextBox();
            this.lvRuleWebList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnTestRule = new System.Windows.Forms.Button();
            this.tabSetting.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.tpDeletePhrase.SuspendLayout();
            this.tpRuleweb.SuspendLayout();
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
            this.tpGeneral.Controls.Add(this.btnSelectPath);
            this.tpGeneral.Controls.Add(this.txtSaveFilePath);
            this.tpGeneral.Location = new System.Drawing.Point(4, 28);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeneral.Size = new System.Drawing.Size(471, 373);
            this.tpGeneral.TabIndex = 0;
            this.tpGeneral.Text = "Chung";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Location = new System.Drawing.Point(390, 12);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(75, 28);
            this.btnSelectPath.TabIndex = 1;
            this.btnSelectPath.Text = "Chọn";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // txtSaveFilePath
            // 
            this.txtSaveFilePath.Enabled = false;
            this.txtSaveFilePath.Location = new System.Drawing.Point(6, 14);
            this.txtSaveFilePath.Name = "txtSaveFilePath";
            this.txtSaveFilePath.Size = new System.Drawing.Size(378, 26);
            this.txtSaveFilePath.TabIndex = 0;
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
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.ForeColor = System.Drawing.Color.Red;
            this.lblInfo.Location = new System.Drawing.Point(367, 9);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 19);
            this.lblInfo.TabIndex = 2;
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
            this.tpRuleweb.Controls.Add(this.chkIsRightToLeft);
            this.tpRuleweb.Controls.Add(this.chkIsReverse);
            this.tpRuleweb.Controls.Add(this.chkIsEncodeGB2312);
            this.tpRuleweb.Controls.Add(this.txtContent);
            this.tpRuleweb.Controls.Add(this.txtTitle);
            this.tpRuleweb.Controls.Add(this.txtStart);
            this.tpRuleweb.Controls.Add(this.txtEnd);
            this.tpRuleweb.Controls.Add(this.txtChapAddress);
            this.tpRuleweb.Controls.Add(this.txtChapList);
            this.tpRuleweb.Controls.Add(this.txtRuleName);
            this.tpRuleweb.Controls.Add(this.lvRuleWebList);
            this.tpRuleweb.Location = new System.Drawing.Point(4, 28);
            this.tpRuleweb.Name = "tpRuleweb";
            this.tpRuleweb.Padding = new System.Windows.Forms.Padding(3);
            this.tpRuleweb.Size = new System.Drawing.Size(471, 373);
            this.tpRuleweb.TabIndex = 2;
            this.tpRuleweb.Text = "Rule web";
            this.tpRuleweb.UseVisualStyleBackColor = true;
            // 
            // chkIsRightToLeft
            // 
            this.chkIsRightToLeft.AutoSize = true;
            this.chkIsRightToLeft.Location = new System.Drawing.Point(265, 320);
            this.chkIsRightToLeft.Name = "chkIsRightToLeft";
            this.chkIsRightToLeft.Size = new System.Drawing.Size(148, 23);
            this.chkIsRightToLeft.TabIndex = 10;
            this.chkIsRightToLeft.Text = "Lưu từ trái qua phải";
            this.chkIsRightToLeft.UseVisualStyleBackColor = true;
            // 
            // chkIsReverse
            // 
            this.chkIsReverse.AutoSize = true;
            this.chkIsReverse.Location = new System.Drawing.Point(265, 290);
            this.chkIsReverse.Name = "chkIsReverse";
            this.chkIsReverse.Size = new System.Drawing.Size(147, 23);
            this.chkIsReverse.TabIndex = 9;
            this.chkIsReverse.Text = "Đảo ngược văn bản";
            this.chkIsReverse.UseVisualStyleBackColor = true;
            // 
            // chkIsEncodeGB2312
            // 
            this.chkIsEncodeGB2312.AutoSize = true;
            this.chkIsEncodeGB2312.Location = new System.Drawing.Point(265, 260);
            this.chkIsEncodeGB2312.Name = "chkIsEncodeGB2312";
            this.chkIsEncodeGB2312.Size = new System.Drawing.Size(139, 23);
            this.chkIsEncodeGB2312.TabIndex = 8;
            this.chkIsEncodeGB2312.Text = "Dùng mã GB2312";
            this.chkIsEncodeGB2312.UseVisualStyleBackColor = true;
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(265, 218);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(200, 26);
            this.txtContent.TabIndex = 7;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(265, 177);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(200, 26);
            this.txtTitle.TabIndex = 6;
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(265, 133);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(95, 26);
            this.txtStart.TabIndex = 5;
            // 
            // txtEnd
            // 
            this.txtEnd.Location = new System.Drawing.Point(370, 133);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Size = new System.Drawing.Size(95, 26);
            this.txtEnd.TabIndex = 4;
            // 
            // txtChapAddress
            // 
            this.txtChapAddress.Location = new System.Drawing.Point(265, 89);
            this.txtChapAddress.Name = "txtChapAddress";
            this.txtChapAddress.Size = new System.Drawing.Size(200, 26);
            this.txtChapAddress.TabIndex = 3;
            // 
            // txtChapList
            // 
            this.txtChapList.Location = new System.Drawing.Point(265, 47);
            this.txtChapList.Name = "txtChapList";
            this.txtChapList.Size = new System.Drawing.Size(200, 26);
            this.txtChapList.TabIndex = 2;
            // 
            // txtRuleName
            // 
            this.txtRuleName.Location = new System.Drawing.Point(265, 6);
            this.txtRuleName.Name = "txtRuleName";
            this.txtRuleName.Size = new System.Drawing.Size(200, 26);
            this.txtRuleName.TabIndex = 1;
            // 
            // lvRuleWebList
            // 
            this.lvRuleWebList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvRuleWebList.FullRowSelect = true;
            this.lvRuleWebList.Location = new System.Drawing.Point(-5, 7);
            this.lvRuleWebList.MultiSelect = false;
            this.lvRuleWebList.Name = "lvRuleWebList";
            this.lvRuleWebList.Size = new System.Drawing.Size(255, 370);
            this.lvRuleWebList.TabIndex = 0;
            this.lvRuleWebList.UseCompatibleStateImageBehavior = false;
            this.lvRuleWebList.View = System.Windows.Forms.View.Details;
            this.lvRuleWebList.SelectedIndexChanged += new System.EventHandler(this.lvRuleWebList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "STT";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên rule";
            this.columnHeader2.Width = 200;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(413, 435);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
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
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
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
            this.Load += new System.EventHandler(this.Setting_Load);
            this.tabSetting.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.tpGeneral.PerformLayout();
            this.tpDeletePhrase.ResumeLayout(false);
            this.tpDeletePhrase.PerformLayout();
            this.tpRuleweb.ResumeLayout(false);
            this.tpRuleweb.PerformLayout();
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
        private System.Windows.Forms.TextBox txtSaveFilePath;
        private System.Windows.Forms.ComboBox cbDeletePhraseName;
        private System.Windows.Forms.TextBox txtDeletePhrasePattern;
        private System.Windows.Forms.Button btnTestRule;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ListView lvRuleWebList;
        private System.Windows.Forms.CheckBox chkIsRightToLeft;
        private System.Windows.Forms.CheckBox chkIsReverse;
        private System.Windows.Forms.CheckBox chkIsEncodeGB2312;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.TextBox txtChapAddress;
        private System.Windows.Forms.TextBox txtChapList;
        private System.Windows.Forms.TextBox txtRuleName;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnSelectPath;
    }
}