using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OcrMyPdf.Logic.Utilities
{
    public class OutputPathCreator
    {
        private ISuffixGenerator _suffixGenerator;
        private string _outputSuffix;

        // in the constructor of of the two ISuffixGenerator classes will be passed in
        public OutputPathCreator(ISuffixGenerator suffixGenerator, string outputSuffix)
        {
            _suffixGenerator = suffixGenerator;
            _outputSuffix = outputSuffix;
        }

        public static string AddPathSuffix(string filePath, string suffix)
        {
            string fDir = Path.GetDirectoryName(filePath);
            string fName = Path.GetFileNameWithoutExtension(filePath);
            string fExt = Path.GetExtension(filePath);
            return Path.Combine(fDir, String.Concat(fName, suffix, fExt));
        }

        public string DetermineOutputPath(string inputFilePath)
        {
            // Append user-chosen suffix
            string outputFilePath = AddPathSuffix(inputFilePath, _outputSuffix);

            // Check if filename already exists
            if (File.Exists(outputFilePath))
            {
                // Generate a new one if so
                string outputFilePath2 = AddPathSuffix(outputFilePath, _suffixGenerator.GenerateSuffix());

                // Check if that has collided (very rare)
                while (File.Exists(outputFilePath2))
                {
                    // If so, generate a different one
                    outputFilePath2 = AddPathSuffix(outputFilePath, _suffixGenerator.GenerateSuffix());
                }

                outputFilePath = outputFilePath2;
            }
            return outputFilePath;
        }
    }
}
