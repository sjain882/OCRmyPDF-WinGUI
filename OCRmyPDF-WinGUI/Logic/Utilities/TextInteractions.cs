using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.Logic.Utilities
{
    public class TextInteractions
    {

        public static bool CopyTextToClipboard(string text)
        {
            System.Windows.Clipboard.SetText(text);

            // If we got to this point, it must be successful
            return true;
        }

    }
}
