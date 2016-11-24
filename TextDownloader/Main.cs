using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextDownloader
{
    public partial class Main : Form
    {
        #region Khai báo
        string address;
        List<Info> info;

        public TextBox Address
        {
            get { return txtAddress; }
            set { txtAddress = value; }
        }

        public Button Setting
        {
            get { return btnSetting; }
            set { btnSetting = value; }
        }

        public Button ChapList
        {
            get { return btnChapList; }
            set { btnChapList = value; }
        }

        public Label Status
        {
            get { return lblStatus; }
            set { lblStatus = value; }
        }
        #endregion

        public Main()
        {
            InitializeComponent();
            string content = "Bấm vào đây để đến diễn đàn";
            Util.SetTooltip(tipInfo, lblInfo, content);
            content = "Nhập địa chỉ truyện bạn muốn tải vào đây";
            Util.SetTooltip(tipInfo, txtAddress, content);
        }

        public void GetChapList()
        {
            address = txtAddress.Text.Trim();
            info = new List<Info>();
            GetText g = new GetText();
            if (g.CheckAddress(address))
            {
                info = g.GetChapList(address);
            }
        }

        private void btnChapList_Click(object sender, EventArgs e)
        {
            if (InternetConnection.IsConnectedToInternet())
            {
                Invoke(new MethodInvoker(delegate { lblStatus.Text = "Tiến trình: Đang xử lý danh sách truyện..."; }));
                Thread t = new Thread(GetChapList);
                t.IsBackground = true;
                t.Start();
                t.Join();
                ChapList c = new ChapList(this, info);
                c.ShowDialog();
            }
            else
            {
                MessageBox.Show("Không thể kết nối internet", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            Setting s = new Setting();
            s.ShowDialog();
        }

        private void lblInfo_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.tangthuvien.vn/forum/showthread.php?t=135248");
        }
    }
}
