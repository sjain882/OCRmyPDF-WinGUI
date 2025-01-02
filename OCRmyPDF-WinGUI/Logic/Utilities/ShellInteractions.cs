using System.Diagnostics;
using System.Windows;

namespace OcrMyPdf.Logic.Utilities
{
    public class ShellInteractions
    {
        public static bool OpenInDefaultViewer(string pathOrURL, string failMsg)
        {
            var process = new Process();

            process.StartInfo = new ProcessStartInfo(pathOrURL)
            {
                UseShellExecute = true
            };

            try
            {
                process.Start();
            }
            catch (Exception)
            {
                MessageBox.Show(failMsg,
                                "OCRmyPDF",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);

                return false;
            }

            return true;
        }
    }
}
