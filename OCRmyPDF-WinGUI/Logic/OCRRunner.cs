using OcrMyPdf.Logic.Options;
using OcrMyPdf.Logic.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.Logic
{
    public class OCRRunner
    {
        public static readonly char argsSprtr = ' ';
        private OCROptionSet optionSet;
        public string ocrArguments;

        public OCRRunner(OCROptionSet optionsSet)
        {
            ocrArguments = GetOCRArguments(optionsSet);
            this.optionSet = optionsSet;
        }

        public int OCRSinglePDF(string inputFilePath)
        {

            StringBuilder cmdBuilder = new StringBuilder();

            // OCRmyPDF Arguments
            cmdBuilder.AppendWithSeparator(argsSprtr, this.ocrArguments);

            // Input PDF path
            cmdBuilder.AppendWithSeparator(argsSprtr, "\"" + inputFilePath + "\"");

            // Output PDF path
            cmdBuilder.AppendWithSeparator(argsSprtr, "\"" + StringUtilities.AddSuffix(inputFilePath, this.optionSet.outputSuffix) + "\"");

            // Prepare the process
            Process process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = @"ocrmypdf.exe",
                    Arguments = cmdBuilder.ToString(),
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();

            process.WaitForExit();

            return process.ExitCode;
        }

        public string GetOCRArguments(OCROptionSet optionSet)
        {

            StringBuilder argsBuilder = new StringBuilder();

            argsBuilder.AppendWithSeparator(argsSprtr, optionSet.processingPolicy.argument);

            argsBuilder.AppendWithSeparator(argsSprtr, optionSet.pdfType.argument);

            argsBuilder.AppendWithSeparator(argsSprtr, optionSet.optimisationLevel.argument);

            if (optionSet.rotate) argsBuilder.AppendWithSeparator(argsSprtr, SimpleOptionParams.rotate);

            if (optionSet.deskew) argsBuilder.AppendWithSeparator(argsSprtr, SimpleOptionParams.deskew);

            return argsBuilder.ToString();
        }
    }
}
