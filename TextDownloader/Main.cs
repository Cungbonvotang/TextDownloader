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
        public Main()
        {
            InitializeComponent();
        }

        private void btnChapList_Click(object sender, EventArgs e)
        {
            ChapList c = new ChapList();
            c.ShowDialog();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {

        }
    }
}
