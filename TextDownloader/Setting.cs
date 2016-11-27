using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextDownloader
{
    public partial class Setting : Form
    {
        string deletePhraseFile = Info.DeletePhraseFile;
        string selectedItem;

        public Setting()
        {
            InitializeComponent();
        }

        #region RuleWeb
        public void EnableControl(bool b)
        {
            txtRuleName.Enabled = b;
            txtChapList.Enabled = b;
            txtChapAddress.Enabled = b;
            txtStart.Enabled = b;
            txtEnd.Enabled = b;
            txtTitle.Enabled = b;
            txtContent.Enabled = b;
            chkIsEncodeGB2312.Enabled = b;
            chkIsReverse.Enabled = b;
            chkIsRightToLeft.Enabled = b;
        }

        public void ClearControl()
        {
            txtRuleName.Text = "";
            txtChapList.Text = "";
            txtChapAddress.Text = "";
            txtStart.Text = "";
            txtEnd.Text = "";
            txtTitle.Text = "";
            txtContent.Text = "";
            chkIsEncodeGB2312.Checked = false;
            chkIsReverse.Checked = false;
            chkIsRightToLeft.Checked = false;
            if (lvRuleWebList.SelectedItems.Count > 0)
                lvRuleWebList.SelectedItems[0].Selected = false;
        }

        public void ShowRuleList()
        {
            string[] str = Config.KeyValue("Website").Split('|');
            for (int i = 0; i < str.Length; i++)
            {
                ListViewItem item = new ListViewItem(i + 1 + "");
                item.SubItems.Add(str[i]);
                lvRuleWebList.Items.Add(item);
            }
        }

        public void LoadDataFromListviewToTextbox()
        {
            //Kiểm tra xem người dùng có nhấp vào đối tượng trên listview không
            if (lvRuleWebList.SelectedItems.Count > 0)
            {
                string web = lvRuleWebList.SelectedItems[0].SubItems[1].Text;
                string[] arr = Config.KeyValue(web).Split('|');
                txtRuleName.Text = web;
                txtChapList.Text = arr[0];
                txtChapAddress.Text = arr[1];
                txtStart.Text = arr[2];
                txtEnd.Text = arr[3];
                txtTitle.Text = arr[4];
                txtContent.Text = arr[5];
                if (arr[6] == "true") chkIsEncodeGB2312.Checked = true;
                else chkIsEncodeGB2312.Checked = false;
                if (arr[7] == "true") chkIsReverse.Checked = true;
                else chkIsReverse.Checked = false;
                if (arr[8] == "true") chkIsRightToLeft.Checked = true;
                else chkIsRightToLeft.Checked = false;
                txtRuleName.Enabled = false;
            }
        }

        private void lvRuleWebList_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableControl(true);
            LoadDataFromListviewToTextbox();
        }
        #endregion

        #region DeletePhrase
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

        private void cbDeletePhraseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblInfo.Text = "";
                selectedItem = cbDeletePhraseName.SelectedItem.ToString();
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

        private void txtDeletePhrasePattern_Enter(object sender, EventArgs e)
        {
            Invoke(new MethodInvoker(delegate { lblInfo.Text = ""; }));
        }
        #endregion

        #region Chung
        private void tabSetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabSetting.SelectedTab == tabSetting.TabPages["tpGeneral"])
            {
                Invoke(new MethodInvoker(delegate { btnNew.Visible = false; }));
                Invoke(new MethodInvoker(delegate { btnDelete.Visible = false; }));
                Invoke(new MethodInvoker(delegate { btnTestRule.Visible = false; }));
                Invoke(new MethodInvoker(delegate { btnSave.Visible = false; }));

                Invoke(new MethodInvoker(delegate { txtSaveFilePath.Text = Config.KeyValue("SavePath"); }));
            }
            else if (tabSetting.SelectedTab == tabSetting.TabPages["tpDeletePhrase"])
            {
                Invoke(new MethodInvoker(delegate { btnNew.Visible = false; }));
                Invoke(new MethodInvoker(delegate { btnDelete.Visible = false; }));
                Invoke(new MethodInvoker(delegate { btnTestRule.Visible = true; }));
                Invoke(new MethodInvoker(delegate { btnSave.Visible = true; }));

                LoadDeletePhraseNames();
            }
            else if (tabSetting.SelectedTab == tabSetting.TabPages["tpRuleWeb"])
            {
                Invoke(new MethodInvoker(delegate { btnNew.Visible = true; }));
                Invoke(new MethodInvoker(delegate { btnDelete.Visible = true; }));
                Invoke(new MethodInvoker(delegate { btnTestRule.Visible = false; }));
                Invoke(new MethodInvoker(delegate { btnSave.Visible = true; }));
                lvRuleWebList.Items.Clear();
                EnableControl(false);
                ShowRuleList();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tabSetting.SelectedTab == tabSetting.TabPages["tpDeletePhrase"])
            {
                try
                {
                    List<string> lines = File.ReadLines(deletePhraseFile).ToList();
                    lines.RemoveAll(item => item.StartsWith(selectedItem));
                    if (txtDeletePhrasePattern.Lines.Length != 0)
                    {
                        for (int i = 0; i < txtDeletePhrasePattern.Lines.Length; i++)
                        {
                            string deletePhrasePattern = txtDeletePhrasePattern.Lines[i];
                            if (Regex.IsMatch(deletePhrasePattern, @"^(.+)==(.*)$"))
                            {
                                lines.Add(selectedItem + "==" + deletePhrasePattern);
                                lines.Sort();
                                Config.WriteFile(deletePhraseFile, lines);
                                Invoke(new MethodInvoker(delegate { lblInfo.Text = "Đã lưu"; }));
                            }
                        }
                    }
                    else
                    {
                        Config.WriteFile(deletePhraseFile, lines);
                        Invoke(new MethodInvoker(delegate { lblInfo.Text = "Đã lưu"; }));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else if (tabSetting.SelectedTab == tabSetting.TabPages["tpRuleWeb"])
            {
                try
                {
                    if (string.IsNullOrEmpty(txtRuleName.Text.Trim())
                        || string.IsNullOrEmpty(txtChapList.Text.Trim())
                        || string.IsNullOrEmpty(txtTitle.Text.Trim())
                        || string.IsNullOrEmpty(txtContent.Text.Trim())
                        || string.IsNullOrEmpty(txtStart.Text.Trim())
                        || string.IsNullOrEmpty(txtEnd.Text.Trim()))
                    {
                        MessageBox.Show("Các ô không được để trống", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        LoadDataFromListviewToTextbox();
                    }
                    else
                    {
                        string value = txtChapList.Text.Trim() + "|" + txtChapAddress.Text.Trim() + "|"
                                       + txtStart.Text.Trim() + "|" + txtEnd.Text.Trim() + "|"
                                       + txtTitle.Text.Trim() + "|" + txtContent.Text.Trim() + "|"
                                       + ((chkIsEncodeGB2312.Checked) ? "true" : "false") + "|"
                                       + ((chkIsReverse.Checked) ? "true" : "false") + "|"
                                       + ((chkIsRightToLeft.Checked) ? "true" : "false");
                        if (lvRuleWebList.SelectedItems.Count > 0)
                            Config.EditKey(lvRuleWebList.SelectedItems[0].SubItems[1].Text, value);
                        else
                        {
                            string webString = Config.KeyValue("Website");
                            //Kiểm tra rule mới có trùng hay không
                            if (!Regex.IsMatch(txtRuleName.Text.Trim(), @"^(www\.).+(\.\w{2,3})"))
                            {
                                MessageBox.Show("Rule " + "\"" + txtRuleName.Text.Trim() + "\"" + " của bạn không đúng định dạng",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (webString.Contains(txtRuleName.Text.Trim()))
                            {
                                MessageBox.Show("Rule " + "\"" + txtRuleName.Text.Trim() + "\"" + " của bạn đã có trong dữ liệu",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                Config.AddKey(txtRuleName.Text.Trim(), value);
                                Config.EditKey("Website", webString + "|" + txtRuleName.Text.Trim());
                                lvRuleWebList.Items.Clear();
                                ClearControl();
                                ShowRuleList();
                                ActiveControl = txtRuleName;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTestRule_Click(object sender, EventArgs e)
        {
            TestDeletePhrase t = new TestDeletePhrase();
            t.ShowDialog();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            EnableControl(true);
            ClearControl();
            ActiveControl = txtRuleName;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvRuleWebList.SelectedItems.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa rules này không?",
                                              "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    string web = lvRuleWebList.SelectedItems[0].SubItems[1].Text;
                    string webString = Config.KeyValue("Website");

                    //Xóa key web khỏi app.config
                    Config.RemoveKey(web);

                    //Xóa chuỗi web khỏi key Website trong app.config
                    if (webString.Contains("|" + web))
                        webString = webString.Replace("|" + web, "");
                    else if (webString.Contains(web + "|"))
                        webString = webString.Replace(web + "|", "");
                    else
                        webString = webString.Replace(web, "");
                    Config.EditKey("Website", webString);
                    lvRuleWebList.Items.Clear();
                    ClearControl();
                    EnableControl(false);
                    ShowRuleList();
                }
            }
            else
            {
                MessageBox.Show("Bạn phải chọn một rule trong danh sách để xóa", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            try
            {
                CommonOpenFileDialog cofd = new CommonOpenFileDialog();
                cofd.Title = "Chọn nơi lưu truyện";
                cofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                cofd.IsFolderPicker = true;
                if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    txtSaveFilePath.Text = cofd.FileName;
                    Config.EditKey("SavePath", cofd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            Invoke(new MethodInvoker(delegate { txtSaveFilePath.Text = Config.KeyValue("SavePath"); }));
        }
        #endregion

    }
}
