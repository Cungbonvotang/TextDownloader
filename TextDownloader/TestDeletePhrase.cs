using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextDownloader
{
    public partial class TestDeletePhrase : Form
    {
        bool isEncodeGB2312 =false;

        public TestDeletePhrase()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            LoadDeletePhraseNames();
        }

        private bool LoadDeletePhraseNames()
        {
            string websiteKeyValue = Config.KeyValue("Website");
            if (websiteKeyValue != null)
            {
                List<string> deletePhraseNames = websiteKeyValue.Split('|').ToList();
                deletePhraseNames.Insert(0, "Chung");
                cbDeletePhraseName.DataSource = deletePhraseNames;
                return true;
            }

            return false;
        }

        private bool GetNode(string address)
        {
            try
            {
                string addressPattern = @"^(https?)(:\/\/www)(\.\w+\.\w+\/)(\w+\/(\w+\/|\w+\.html|\w+\.shtml)*)$";
                if (string.IsNullOrEmpty(address))
                {
                    MessageBox.Show("Không được để trống địa chỉ", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (!Regex.IsMatch(address, addressPattern))
                {
                    MessageBox.Show("Địa chỉ không đúng định dạng", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    string[] str = address.Split('/');
                    string value = Config.KeyValue(str[2]);
                    if (value == null) return false;

                    if (string.IsNullOrEmpty(value))
                    {
                        MessageBox.Show("Phần mềm không hỗ trợ trang web này", "Thông báo",
                             MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else
                    {
                        string[] a = value.Split('|');
                        if (a[6] == "true")
                            isEncodeGB2312 = true;

                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void ReplaceRegex()
        {
            string patternString = txtDeletePhrasePattern.Text;
            string result = txtResult.Text;
            string[] multiPatternLines = patternString.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            Parallel.ForEach(multiPatternLines, singlePatternLine =>
            {
                if (Regex.IsMatch(singlePatternLine, @"^(.+)==(.*)$"))
                {
                    string[] temporaryString = singlePatternLine.Split(new string[] { "==" }, StringSplitOptions.None);
                    result = Regex.Replace(result, temporaryString[0], Regex.Unescape(temporaryString[1]));
                }
            });

            Invoke(new MethodInvoker(delegate { txtResult.Text = result; }));
        }

        public void DownloadHTMLString()
        {
            try
            {
                if (GetNode(txtAddress.Text.Trim()))
                {
                    using (WebClient client = new WebClient())
                    {
                        if (isEncodeGB2312)
                            client.Encoding = Encoding.GetEncoding("gb2312");
                        else
                            client.Encoding = Encoding.UTF8;
                        client.Headers.Add("user-agent",
                            "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:49.0) Gecko/20100101 Firefox/49.0");
                        Invoke(new MethodInvoker(delegate { txtResult.Text = client.DownloadString(txtAddress.Text.Trim()); }));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void SetControlEnable(bool b)
        {
            Invoke(new MethodInvoker(delegate { btnDownload.Enabled = b; }));
            Invoke(new MethodInvoker(delegate { btnReplace.Enabled = b; }));
        }

        private void cbDeletePhraseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedItem = cbDeletePhraseName.SelectedItem.ToString();
                List<string> list = new List<string>();
                var lines = File.ReadLines(Info.DeletePhraseFile);
                foreach (var line in lines)
                {
                    if (line.StartsWith(selectedItem))
                    {
                        string[] deletePhrasePattern = line.Split(new string[] { "==" }, StringSplitOptions.None);
                        list.Add(deletePhrasePattern[1] + "==" + deletePhrasePattern[2]);
                    }
                }
                txtDeletePhrasePattern.Text = string.Join("\r\n", list.ToArray());
            }
            catch
            {
                File.WriteAllText(Info.DeletePhraseFile, string.Empty);
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            //SetControlEnable(false);
            Thread t = new Thread(DownloadHTMLString);
            t.IsBackground = true;
            t.Start();
            //t.Join();
            //SetControlEnable(true);
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            //SetControlEnable(false);
            Thread t = new Thread(ReplaceRegex);
            t.IsBackground = true;
            t.Start();
            //t.Join();
            //SetControlEnable(true);
        }
    }
}
