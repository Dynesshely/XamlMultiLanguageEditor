using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XamlMultiLanguageEditor.Winform
{
    internal class Messages
    {
        internal static void ShowDumplicatedKeyTip(string tip = "")
        {
            MessageBox.Show($"This key already existed.\r\n{tip}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
