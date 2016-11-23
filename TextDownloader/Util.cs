using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextDownloader
{
    static class Util
    {
        public static void SetTooltip(ToolTip tipInfo, Control control, string content)
        {
            tipInfo.AutoPopDelay = 10000;
            tipInfo.ToolTipIcon = ToolTipIcon.Info;
            tipInfo.ToolTipTitle = "Hướng dẫn";
            tipInfo.SetToolTip(control, content);
            tipInfo.IsBalloon = true;
        }
    }
}
