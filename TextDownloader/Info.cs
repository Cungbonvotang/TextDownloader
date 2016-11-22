using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextDownloader
{
    public class Info
    {
        public const string DOWNLOADING = "DOWNLOADING";
        public const string FAILED = "FAILED";
        public const string COMPLETED = "COMPLETED";
        public static string[] FileType = { "Tải một file gộp", "Tải nhiều file lẻ" };
        string address, title;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
    }
}
