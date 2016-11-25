﻿using System;
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
        public const string ConfigFile = "Config.dat";
        public const string DeletePhraseFile = "DeletePhrase.dat";
        public const string Forum = "http://www.tangthuvien.vn/forum/showthread.php?t=135248";
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
