using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextDownloader
{
    class GetText
    {
        #region Khai báo
        string chapListNode, chapAddressNode, titleNode, contentNode;
        int startNode, endNode;
        bool isReverse, isEncodeGB2312, isRightToLeft;
        #endregion

        public bool CheckAddress(string address)
        {
            string pattern = @"^(https?)(:\/\/www)(\.\w+\.\w+\/)(\w+\/(\w+\/|\w+\.html)*)$";
            if (Regex.IsMatch(address, pattern))
                return true;
            else
            {
                MessageBox.Show("Địa chỉ bạn nhập không đúng định dạng", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private bool GetNode(string address)
        {
            try
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
                    chapListNode = a[0];
                    if (a[1] == "auto")
                    {
                        if (address.EndsWith(".html"))
                        {
                            int index = address.LastIndexOf('/');
                            address = address.Remove(index + 1);
                        }
                        chapAddressNode = address;
                    }
                    else
                        chapAddressNode = a[1];
                    startNode = int.Parse(a[2]);
                    endNode = int.Parse(a[3]);
                    titleNode = a[4];
                    contentNode = a[5];
                    if (a[6] == "true")
                        isEncodeGB2312 = true;
                    if (a[7] == "true")
                        isReverse = true;
                    if (a[8] == "true")
                        isRightToLeft = true;

                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private HtmlNodeCollection RemoveSurplusChap(HtmlNodeCollection chapList, int startNode, int endNode)
        {
            for (int i = 0; i < startNode; i++)
            {
                chapList.RemoveAt(0);
            }
            for (int i = 0; i < endNode; i++)
            {
                chapList.RemoveAt(chapList.Count - 1);
            }

            return chapList;
        }

        private HtmlWeb WebConfig(bool encodeGB2312)
        {
            HtmlWeb web;
            if (encodeGB2312)
                web = new HtmlWeb() { AutoDetectEncoding = false, OverrideEncoding = Encoding.GetEncoding("gb2312") };
            else
                web = new HtmlWeb();
            web.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:49.0) Gecko/20100101 Firefox/49.0";

            return web;
        }

        public List<Info> GetChapList(string address)
        {
            try
            {
                if (!GetNode(address)) return null;
                HtmlWeb web = WebConfig(isEncodeGB2312);
                var doc = web.Load(address);
                HtmlNodeCollection chapList = doc.DocumentNode.SelectNodes(chapListNode);

                if (startNode > 0 || endNode > 0)
                    chapList = RemoveSurplusChap(chapList, startNode, endNode);

                //Xử lý text bị đặt sai thứ tự (3, 2, 1, 6, 5, 4,...) thành (1, 2, 3, 4, 5, 6,...)
                List<Info> listInfo = new List<Info>();
                if (isRightToLeft)
                {
                    HtmlNode temp;
                    for (int i = 0; i < chapList.Count; i += 3)
                    {
                        temp = chapList[i];
                        chapList[i] = chapList[i + 2];
                        chapList[i + 2] = temp;
                    }

                    List<int> deleteChap = new List<int>();
                    Parallel.For(0, chapList.Count, i =>
                    {
                        if (chapList[i].InnerHtml == "&nbsp;")
                            deleteChap.Add(i);
                    });

                    deleteChap.Sort();
                    for (int i = deleteChap.Count - 1; i >= 0; i--)
                    {
                        chapList.RemoveAt(deleteChap[i]);
                    }
                }


                for (int i = 0; i < chapList.Count; i++)
                {
                    Info info = new Info();
                    HtmlNode data = chapList[i];
                    if (isRightToLeft)
                    {
                        info.Title = chapList[i].SelectSingleNode("a").InnerText;
                        info.Address = chapAddressNode + chapList[i].SelectSingleNode("a").Attributes["href"].Value;
                    }
                    else
                    {
                        info.Title = chapList[i].InnerText;
                        info.Address = chapAddressNode + chapList[i].Attributes["href"].Value;
                    }

                    listInfo.Add(info);
                }

                if (isReverse)
                    listInfo.Reverse();

                return listInfo;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private string GetHTMLString(string address)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    if (isEncodeGB2312)
                        client.Encoding = Encoding.GetEncoding("gb2312");
                    else
                        client.Encoding = Encoding.UTF8;
                    client.Headers.Add("user-agent",
                        "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:49.0) Gecko/20100101 Firefox/49.0");
                    return client.DownloadString(address);
                }
            }
            catch
            {
                return "";
            }
        }

        private string RemoveHTMLTag(string dataInput, string keyDeletePhrase)
        {
            dataInput = Regex.Replace(dataInput, @"<p>|<br>|<br \/>", "_newline1_");
            dataInput = Regex.Replace(dataInput, @"(&nbsp;)+", "");
            dataInput = Regex.Replace(dataInput, @"<script[^>]*>[\s\S]*?<\/script>", "");
            dataInput = Regex.Replace(dataInput, @"<div[^>]*>[\s\S]*?<\/div>", "");
            dataInput = Regex.Replace(dataInput, @"<center[^>]*>[\s\S]*?<\/center>", "");
            dataInput = Regex.Replace(dataInput, @"<a[^>]*>[\s\S]*?<\/a>", "");
            dataInput = Regex.Replace(dataInput, @"( |\t|\r?\n|\r\n|\n|<\/p>)+|<.*?>", "");
            dataInput = Regex.Replace(dataInput, @"_newline1_", "\r\n");
            dataInput = Regex.Replace(dataInput, @"(\r\n|\r?\n|\n){1,}", "\r\n    ");
            dataInput = Regex.Replace(dataInput, @"_newline2_", "\r\n\r\n    ");

            //var lines = File.ReadLines(Info.DeletePhraseFile);

            //Parallel.ForEach(lines, line =>
            //{
            //    if (line.StartsWith("Chung"))
            //    {
            //        string[] deletePhrasePattern = line.Split(new string[] { "==" }, StringSplitOptions.None);
            //        dataInput = Regex.Replace(dataInput, deletePhrasePattern[1], deletePhrasePattern[2]);
            //    }
            //});

            //Parallel.ForEach(lines, line =>
            //{
            //    if (line.StartsWith(keyDeletePhrase))
            //    {
            //        string[] deletePhrasePattern = line.Split(new string[] { "==" }, StringSplitOptions.None);
            //        dataInput = Regex.Replace(dataInput, deletePhrasePattern[1], deletePhrasePattern[2]);
            //    }
            //});

            return dataInput;
        }

        public bool Get(Main main, List<Info> chapAddresses)
        {
            if (!GetNode(main.AddressButton.Text.Trim())) return false;
            int chapNumber = chapAddresses.Count;
            string[] novel = new string[chapNumber];
            int count = 0;

            Parallel.For(0, chapNumber, i =>
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        if (isEncodeGB2312)
                            client.Encoding = Encoding.GetEncoding("gb2312");
                        else
                            client.Encoding = Encoding.UTF8;
                        client.Headers.Add("user-agent",
                            "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:49.0) Gecko/20100101 Firefox/49.0");
                        novel[i] = client.DownloadString(chapAddresses[i].Address);
                        count += 1;
                        main.Status.Text = "Tiến trình: " + ((float)(count * 100) / (chapNumber - 1)).ToString("0.00") + "%";
                    }
                }
                catch
                {

                }
            });

            main.Status.Text = "Tiến trình: Xử lý text rác...";
            string[] str = main.AddressButton.Text.Trim().Split('/');

            Parallel.For(0, chapNumber, i =>
            {
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(novel[i]);
                string content = null;
                if (contentNode != "auto")
                    content = doc.DocumentNode.SelectSingleNode(contentNode).InnerHtml;
                content = novel[i];
                novel[i] = chapAddresses[i].Title + "_newline2_" + content + "_newline2_";
                novel[i] = RemoveHTMLTag(novel[i], str[2]);
            });

            if (ChapList.fileTypeIndex == 0)
            {
                File.WriteAllLines(Config.KeyValue("SavePath") + "\\" + ChapList.novelName + ".txt", novel);
            }
            else
            {
                string folderPath = Config.KeyValue("SavePath");
                Directory.CreateDirectory(folderPath + "\\" + ChapList.novelName);
                Parallel.For(0, novel.Count(), i =>
                {
                    string saveFilePath = folderPath + "\\" + ChapList.novelName +
                                        "\\" + i + ".txt";
                    File.WriteAllText(saveFilePath, novel[i]);
                });
            }
            main.Status.Text = "Tải hoàn thành";
            return true;
        }
    }
}
