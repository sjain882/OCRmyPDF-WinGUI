using OcrMyPdf.Logic.ExitCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.Logic
{
    public class OCRError
    {
        public string filePath { get; set; }

        public ExitCodeTemplate exitCode { get; set; }

        public OCRError(string filePath, ExitCodeTemplate exitCode)
        {
            this.filePath = filePath;
            this.exitCode = exitCode;
        }   
    }
}
