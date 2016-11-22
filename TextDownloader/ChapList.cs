using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextDownloader
{
    public partial class ChapList : Form
    {
        #region Khai báo
        List<Info> info;
        int startChap = 0, endChap = 0;

        public int StartChap
        {
            get { return startChap; }
            set
            {
                if (value >= 0)
                    startChap = value;
                else
                    MessageBox.Show("Chương bắt đầu không thể nhỏ hơn 0");
            }
        }

        public int EndChap
        {
            get { return endChap; }
            set
            {
                if (value >= 0 && value > startChap)
                    endChap = value;
                else if (value <= startChap)
                    MessageBox.Show("Chương kết thúc phải lớn hơn chương bắt đầu", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Chương kết thúc không thể nhỏ hơn 0", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        public ChapList(List<Info> list)
        {
            InitializeComponent();
            this.info = list;
        }

        #region Vẽ checkbox trong listview
        private void lvChapList_DrawColumnHeader_1(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.DrawBackground();
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(e.Header.Tag);
                }
                catch (Exception)
                {
                }
                CheckBoxRenderer.DrawCheckBox(e.Graphics,
                    new Point(e.Bounds.Left + 4, e.Bounds.Top + 4),
                    value ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal :
                    System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void lvChapList_DrawItem_1(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lvChapList_DrawSubItem_1(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lvChapList_ColumnClick_1(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(lvChapList.Columns[e.Column].Tag);
                }
                catch (Exception)
                {
                }
                lvChapList.Columns[e.Column].Tag = !value;
                foreach (ListViewItem item in lvChapList.Items)
                    item.Checked = !value;

                lvChapList.Invalidate();
            }
        }
        #endregion

        private void ChapList_Load(object sender, EventArgs e)
        {
            cbFileType.DataSource = Info.FileType;

            foreach (Info i in info)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Add(i.Title);
                lvChapList.Items.Add(item);
            }

            txtChapList.Text = "1-" + info.Count;
        }

        private void lvChapList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = lvChapList.Items[0];
            MessageBox.Show("Test");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string pattern = @"^(\d+)-(\d+)$";
            if (Regex.IsMatch(txtChapList.Text.Trim(), pattern))
            {
                string[] tmp = txtChapList.Text.Trim().Split('-');
                StartChap = int.Parse(tmp[0]) - 1;
                EndChap = int.Parse(tmp[1]) - 1;
                for (int i = 0; i < lvChapList.Items.Count; i++)
                {
                    if (i >= StartChap && i <= EndChap)
                        lvChapList.Items[i].Checked = true;
                    else
                        lvChapList.Items[i].Checked = false;
                }
            }
            else
            {
                MessageBox.Show("Bạn nhập không đúng định dạng", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
