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

        public static bool OpenURL(string url)
        {
            return ShellInteractions.OpenInDefaultViewer(url, 
                                                        "Failed to open URL. There is no default browser on this system.");
        }

        public static bool SearchOCRError(string errorName)
        {
            return OpenURL(@"https://www.google.com/search?q=ocrmypdf+error+" + errorName);
        }

    }
}
