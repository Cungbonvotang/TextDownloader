using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextDownloader
{
    public partial class ChapList : Form
    {
        #region Khai báo
        Main main;
        List<Info> info;
        public static List<Info> chapList;
        BackgroundWorker background;
        int startChap = 0, endChap = 0, fileTypeIndex = 0;

        public int StartChap
        {
            get { return startChap; }
            set
            {
                if (value >= 0)
                    startChap = value;
                else
                {
                    MessageBox.Show("Chương bắt đầu không thể bằng 0", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    startChap = -1;
                }
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
                {
                    MessageBox.Show("Chương kết thúc phải lớn hơn chương bắt đầu", "Thông báo",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    endChap = -1;
                }
                else
                {
                    MessageBox.Show("Chương kết thúc không thể nhỏ hơn 0", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    endChap = -1;
                }
            }
        }
        #endregion

        public ChapList(Main main, List<Info> info)
        {
            InitializeComponent();
            this.main = main;
            this.info = info;
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

        public void SetControlEnable(bool b)
        {
            main.ChapList.Enabled = b;
            main.Setting.Enabled = b;
            main.Address.Enabled = b;
        }

        private void ChapList_Load(object sender, EventArgs e)
        {
            string content = "Nếu bạn muốn tải từ chương 50 đến 100 thì điền: 50-100";
            Util.SetTooltip(tipInfo, txtChapList, content);
            content = "Tên file truyện của bạn";
            Util.SetTooltip(tipInfo, txtFileName, content);
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
            if (lvChapList.SelectedItems.Count > 0)
            {
                int selecttedItemIndex = lvChapList.FocusedItem.Index;
                if (lvChapList.Items[selecttedItemIndex].Checked)
                {
                    lvChapList.Items[selecttedItemIndex].Checked = false;
                }
                else
                {
                    lvChapList.Items[selecttedItemIndex].Checked = true;
                }
            }
        }

        private void cbFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFileType.SelectedIndex == 0)
            {
                txtFileName.Enabled = true;
                fileTypeIndex = 0;
            }
            else
            {
                txtFileName.Enabled = false;
                fileTypeIndex = 1;
            }
        }

        private void ChapList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                SetControlEnable(true);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            chapList = new List<Info>();
            for (int i = 0; i < lvChapList.Items.Count; i++)
            {
                if (lvChapList.Items[i].Checked)
                {
                    chapList.Add(info[i]);
                }
            }
            Dispose();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string pattern = @"^(\d{1,4})-(\d{1,4})$";
            string clearChapListText = Regex.Replace(txtChapList.Text, @"\s+", "");
            
            if (Regex.IsMatch(clearChapListText, pattern))
            {
                txtChapList.Text = clearChapListText;
                string[] tmp = clearChapListText.Split('-');
                StartChap = int.Parse(tmp[0]) - 1;
                EndChap = int.Parse(tmp[1]) - 1;
                if (startChap != -1 || endChap != -1)
                {
                    for (int i = 0; i < lvChapList.Items.Count; i++)
                    {
                        if (i >= StartChap && i <= EndChap)
                            lvChapList.Items[i].Checked = true;
                        else
                            lvChapList.Items[i].Checked = false;
                    }
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
