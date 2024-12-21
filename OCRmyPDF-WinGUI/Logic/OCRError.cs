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
    }
}
