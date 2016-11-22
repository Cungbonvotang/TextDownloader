using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextDownloader
{
    public partial class Main : Form
    {
        string address;

        public Main()
        {
            InitializeComponent();
        }

        private void btnChapList_Click(object sender, EventArgs e)
        {
            if (InternetConnection.IsConnectedToInternet())
            {
                address = txtAddress.Text.Trim();
                List<Info> info = new List<Info>();
                GetText g = new GetText();
                if (g.CheckAddress(address))
                {
                    info = g.GetChapList(address);
                    if (info != null)
                    {
                        ChapList c = new ChapList(info);
                        c.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("Không thể kết nối internet", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {

        }
    }
}
