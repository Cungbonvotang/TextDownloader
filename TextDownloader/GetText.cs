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

                List<Info> listInfo = new List<Info>();
                for (int i = 0; i < chapList.Count; i++)
                {
                    Info info = new Info();
                    info.Title = chapList[i].InnerText;
                    info.Address = chapAddressNode + chapList[i].Attributes["href"].Value;
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
