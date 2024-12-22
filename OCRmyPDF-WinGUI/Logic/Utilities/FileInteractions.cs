using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OcrMyPdf.Logic.Utilities
{
    public static class FileInteractions
    {
        public static bool ExploreFile(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
            {
                return false;
            }
            // Clean up file path so it can be navigated OK
            filePath = System.IO.Path.GetFullPath(filePath);

            // Start the process (new explorer window)
            System.Diagnostics.Process.Start("explorer.exe", string.Format("/select,\"{0}\"", filePath));

            // If we got to this point, it must be successful
            return true;
        }

        public static bool OpenFileInDefaultViewer(string filePath)
        {
            var process = new Process();

            process.StartInfo = new ProcessStartInfo(@filePath)
            {
                UseShellExecute = true
            };

            try
            {
                process.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to open PDF. There is no default PDF viewer on this system.",
                                "OCRmyPDF",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);

                return false;
            }

            return true;
        }
    }
}
