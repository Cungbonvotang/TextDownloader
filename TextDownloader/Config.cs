using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextDownloader
{
    class Config
    {
        const string configFile = Info.ConfigFile;
        const string deletePhraseFile = Info.DeletePhraseFile;

        public static List<string> ReadFile(string fileName)
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    using (StreamReader br = new StreamReader(fs))
                    {
                        string tmp = br.ReadToEnd();
                        return tmp.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static bool WriteFile(string fileName, List<string> list)
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    using (StreamWriter bw = new StreamWriter(fs))
                    {
                        string data = string.Join("\r\n", list.ToArray());
                        bw.Write(data);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static string KeyValue(string key)
        {
            List<string> list = new List<string>();
            string value = null;
            list = ReadFile(configFile);
            if (list == null) return null;

            Parallel.ForEach(list, str =>
            {
                if (str.StartsWith(key + "=="))
                {
                    string[] tmp = str.Split(new string[] { "==" }, StringSplitOptions.None);
                    value = tmp[1];
                    return;
                }
            });

            return value;
        }

        public static void AddKey(string key, string value)
        {
            try
            {
                List<string> list = new List<string>();
                list = ReadFile(configFile);
                list.Add(key + "==" + value);
                list.Sort();
                WriteFile(configFile, list);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void EditKey(string key, string value)
        {
            try
            {
                List<string> list = new List<string>();
                list = ReadFile(configFile);
                Parallel.ForEach(list, str =>
                {
                    if (str.StartsWith(key + "=="))
                    {
                        list.Remove(str);
                        list.Add(key + "==" + value);
                    }

                    return;
                });

                list.Sort();
                WriteFile(configFile, list);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void RemoveKey(string key)
        {
            try
            {
                List<string> list = new List<string>();
                list = ReadFile(configFile);
                Parallel.ForEach(list, str =>
                {
                    if (str.StartsWith(key + "=="))
                        list.Remove(str);
                    return;
                });

                list.Sort();
                WriteFile(configFile, list);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static List<string> FindKeys(string keyword)
        {
            try
            {
                List<string> list = new List<string>();
                list = ReadFile(configFile);
                Parallel.ForEach(list, str =>
                {
                    string[] tmp = str.Split(new string[] { "==" }, StringSplitOptions.None);
                    if (!tmp[0].StartsWith(keyword))
                    {
                        list.Remove(str);
                    }
                });

                list.Sort();
                return list;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
