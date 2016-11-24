using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextDownloader
{
    class GetText
    {
        #region Khai báo
        Main main;
        string chapListNode, chapAddressNode, titleNode, contentNode, address;
        int startNode, endNode;
        bool reverse, encodeGB2312, rightToLeft;
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

        public bool GetNode(string address)
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
                        encodeGB2312 = true;
                    if (a[7] == "true")
                        reverse = true;
                    if (a[8] == "true")
                        rightToLeft = true;

                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        public HtmlNodeCollection RemoveSurplusChap(HtmlNodeCollection chapList, int startNode, int endNode)
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

        public HtmlWeb WebConfig(bool encodeGB2312)
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
                HtmlWeb web = WebConfig(encodeGB2312);
                var doc = web.Load(address);
                HtmlNodeCollection chapList = doc.DocumentNode.SelectNodes(chapListNode);

                if (startNode > 0 || endNode > 0)
                    chapList = RemoveSurplusChap(chapList, startNode, endNode);

                //Xử lý text bị đặt sai thứ tự (3, 2, 1, 6, 5, 4,...) thành (1, 2, 3, 4, 5, 6,...)
                List<Info> listInfo = new List<Info>();
                if (rightToLeft)
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
                    if (rightToLeft)
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

                if (reverse)
                    listInfo.Reverse();

                return listInfo;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
