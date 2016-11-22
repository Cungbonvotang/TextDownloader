namespace TextDownloader
{
    partial class ChapList
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
            this.lvChapList = new System.Windows.Forms.ListView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.txtChapList = new System.Windows.Forms.TextBox();
            this.cbFileType = new System.Windows.Forms.ComboBox();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvChapList
            // 
            this.lvChapList.CheckBoxes = true;
            this.lvChapList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvChapList.FullRowSelect = true;
            this.lvChapList.Location = new System.Drawing.Point(13, 13);
            this.lvChapList.MultiSelect = false;
            this.lvChapList.Name = "lvChapList";
            this.lvChapList.OwnerDraw = true;
            this.lvChapList.Size = new System.Drawing.Size(409, 342);
            this.lvChapList.TabIndex = 0;
            this.lvChapList.UseCompatibleStateImageBehavior = false;
            this.lvChapList.View = System.Windows.Forms.View.Details;
            this.lvChapList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvChapList_ColumnClick_1);
            this.lvChapList.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvChapList_DrawColumnHeader_1);
            this.lvChapList.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvChapList_DrawItem_1);
            this.lvChapList.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lvChapList_DrawSubItem_1);
            this.lvChapList.SelectedIndexChanged += new System.EventHandler(this.lvChapList_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(347, 416);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(266, 416);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 28);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "Chọn";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // txtChapList
            // 
            this.txtChapList.Location = new System.Drawing.Point(225, 375);
            this.txtChapList.Name = "txtChapList";
            this.txtChapList.Size = new System.Drawing.Size(197, 26);
            this.txtChapList.TabIndex = 3;
            // 
            // cbFileType
            // 
            this.cbFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFileType.FormattingEnabled = true;
            this.cbFileType.Location = new System.Drawing.Point(13, 375);
            this.cbFileType.Name = "cbFileType";
            this.cbFileType.Size = new System.Drawing.Size(197, 27);
            this.cbFileType.TabIndex = 4;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 30;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên chương";
            this.columnHeader2.Width = 375;
            // 
            // ChapList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 456);
            this.Controls.Add(this.cbFileType);
            this.Controls.Add(this.txtChapList);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lvChapList);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ChapList";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn chương tải";
            this.Load += new System.EventHandler(this.ChapList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvChapList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TextBox txtChapList;
        private System.Windows.Forms.ComboBox cbFileType;
    }
}