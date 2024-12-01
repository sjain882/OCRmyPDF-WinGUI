using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.Logic
{
    public static class OCRRunner
    {

        public static char argsSprtr = ' ';

        public static void RunOCR(string[] filePaths, OCROptionSet optionSet)
        {

            StringBuilder argsBuilder = new StringBuilder();

            argsBuilder.AppendWithSeparator(argsSprtr, optionSet.processingPolicy.argument);

            argsBuilder.AppendWithSeparator(argsSprtr, optionSet.pdfType.argument);

            argsBuilder.AppendWithSeparator(argsSprtr, optionSet.optimisationLevel.argument);

            if (optionSet.rotate) argsBuilder.AppendWithSeparator(argsSprtr, OCRSimpleOptionParams.rotate);

            if (optionSet.deskew) argsBuilder.AppendWithSeparator(argsSprtr, OCRSimpleOptionParams.deskew);

            string args = argsBuilder.ToString();

            // Process each file
            foreach (string path in filePaths)
            {

                StringBuilder cmdBuilder = new StringBuilder();

                cmdBuilder.AppendWithSeparator(argsSprtr, "/C ocrmypdf");

                cmdBuilder.AppendWithSeparator(argsSprtr, args);

                cmdBuilder.AppendWithSeparator(argsSprtr, "\"" + path + "\"");

                cmdBuilder.AppendWithSeparator(argsSprtr, "\"" + Utilities.AddSuffix(path, optionSet.outputSuffix) + "\"");

                System.Diagnostics.Process process = System.Diagnostics.Process.Start(@"cmd.exe", cmdBuilder.ToString());

                process.WaitForExit();
                int result = process.ExitCode;

            }        
        }
    }
}
