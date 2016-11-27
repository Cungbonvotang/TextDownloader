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

        public TextBox AddressButton
        {
            get { return txtAddress; }
            set { txtAddress = value; }
        }

        public Button SettingButton
        {
            get { return btnSetting; }
            set { btnSetting = value; }
        }

        public Button ChapListButton
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
            Invoke(new MethodInvoker(delegate { lblStatus.Text = "Lấy danh sách chương truyện"; }));
            Invoke(new MethodInvoker(delegate { txtAddress.Enabled = false; }));
            Invoke(new MethodInvoker(delegate { btnChapList.Enabled = false; }));
            Invoke(new MethodInvoker(delegate { btnSetting.Enabled = false; }));
            address = txtAddress.Text.Trim();
            info = new List<Info>();
            GetText g = new GetText();
            if (g.CheckAddress(address))
            {
                info = g.GetChapList(address);
                ChapList c = new ChapList(this, info);
                //c.Owner = this;
                c.ShowDialog(this);
            }
        }

        public void Download()
        {
            Thread t = new Thread(() => 
            {
                GetText get = new GetText();
                get.Get(this, ChapList.chapAddresses);
            });
            t.IsBackground = true;
            t.Start();
            
            //main.Address.Enabled = true;
            //main.ChapList.Enabled = true;
            //main.Setting.Enabled = true;
        }

        private void btnChapList_Click(object sender, EventArgs e)
        {
            if (InternetConnection.IsConnectedToInternet())
            {
                Thread t = new Thread(GetChapList);
                t.IsBackground = true;
                t.Start();
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
            System.Diagnostics.Process.Start(Info.Forum);
        }
    }
}
