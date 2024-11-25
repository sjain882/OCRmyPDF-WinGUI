using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.Logic
{
    enum ProcessingPolicy
    {
        Default = 0,
        SkipText = 1,
        RedoOCR = 2,
        ForceOCR = 3
    }

    internal class OCRConfig
    {
        public ProcessingPolicy processingPolicy { get; set; }

    }
}
