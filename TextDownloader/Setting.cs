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

        private void SetButtonVisible(bool isEnable)
        {
            Invoke(new MethodInvoker(delegate { btnNew.Visible = isEnable; }));
            Invoke(new MethodInvoker(delegate { btnDelete.Visible = isEnable; }));
            Invoke(new MethodInvoker(delegate { btnTestRule.Visible = isEnable; }));
        }

        private bool LoadDeletePhraseNames()
        {
            string websiteKeyValue = Config.KeyValue("Website");
            if(websiteKeyValue != null)
            {
                List<string> deletePhraseNames = websiteKeyValue.Split('|').ToList();
                deletePhraseNames.Insert(0, "Chung");
                cbDeletePhraseName.DataSource = deletePhraseNames;
                return true;
            }

            return false;
        }

        private void tabSetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabSetting.SelectedTab == tabSetting.TabPages["tpGeneral"])
            {
                SetButtonVisible(false);
            }
            else if (tabSetting.SelectedTab == tabSetting.TabPages["tpDeletePhrase"])
            {
                Invoke(new MethodInvoker(delegate { btnNew.Visible = false; }));
                Invoke(new MethodInvoker(delegate { btnDelete.Visible = false; }));
                Invoke(new MethodInvoker(delegate { btnTestRule.Visible = true; }));

                LoadDeletePhraseNames();
            }
            else if (tabSetting.SelectedTab == tabSetting.TabPages["tpRuleWeb"])
            {
                SetButtonVisible(true);
            }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tabSetting.SelectedTab == tabSetting.TabPages["tpDeletePhrase"])
            {
                try
                {
                    List<string> lines = File.ReadLines(deletePhraseFile).ToList();
                    lines.RemoveAll(item => item.StartsWith(selectedItem));
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
                        else
                        {
                            MessageBox.Show("Test");
                        }
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
                
            }
        }

        private void btnTestRule_Click(object sender, EventArgs e)
        {
            if (tabSetting.SelectedTab == tabSetting.TabPages["tpDeletePhrase"])
            {
                TestDeletePhrase t = new TestDeletePhrase();
                t.ShowDialog();
            }
            else if (tabSetting.SelectedTab == tabSetting.TabPages["tpRuleWeb"])
            {
                SetButtonVisible(true);
            }
        }
    }
}
