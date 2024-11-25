using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.Logic
{
    public static class OCRRunner
    {

        public static void RunOCR(string[] filePaths, OCRConfig config)
        {

            StringBuilder argsBuilder = new StringBuilder();

            argsBuilder.AppendWithSeparator(OCRParams.argsSprtr, OCRParams.ProcessingPolicy[(int) config.processingPolicy]);

            argsBuilder.AppendWithSeparator(OCRParams.argsSprtr, OCRParams.PDFType[(int) config.pdfType]);

            argsBuilder.AppendWithSeparator(OCRParams.argsSprtr, OCRParams.OptimisationLevel[(int) config.optimisationLevel]);

            if (config.rotate) argsBuilder.AppendWithSeparator(OCRParams.argsSprtr, OCRParams.rotate);

            if (config.deskew) argsBuilder.AppendWithSeparator(OCRParams.argsSprtr, OCRParams.deskew);

            string args = argsBuilder.ToString();

            // Process each file
            foreach (string path in filePaths)
            {

                StringBuilder cmdBuilder = new StringBuilder();

                cmdBuilder.AppendWithSeparator(OCRParams.argsSprtr, "/C ocrmypdf");

                cmdBuilder.AppendWithSeparator(OCRParams.argsSprtr, args);

                cmdBuilder.AppendWithSeparator(OCRParams.argsSprtr, path);

                cmdBuilder.AppendWithSeparator(OCRParams.argsSprtr, Utilities.AddSuffix(path, config.outputSuffix));

                System.Diagnostics.Process process = System.Diagnostics.Process.Start(@"cmd.exe", cmdBuilder.ToString());

                process.WaitForExit();
                int result = process.ExitCode;

            }        
        }
    }
}
