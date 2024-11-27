using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.Logic
{

    public class OCRConfig
    {
        public enum ProcessingPolicy
        {
            Default     = 0,        // Default in CLI + GUI
            RedoOCR     = 1,
            ForceOCR    = 2
        }

        public enum PDFType
        {
            PDF         = 0,        // Make this default in GUI
            PDFA        = 1         // Defualt in CLI
        }

        public enum OptimisationLevel
        {
            Default     = 0,        // Default in CLI + GUI
            Lossless    = 1,        
            Lossy       = 2,
            AggrLossy   = 3,
            Disabled    = 4
        }

        public ProcessingPolicy processingPolicy { get; set; } = ProcessingPolicy.Default;

        public PDFType pdfType { get; set; } = PDFType.PDF;

        public OptimisationLevel optimisationLevel { get; set; } = OptimisationLevel.Default;

        public bool rotate { get; set; } = true;      

        public bool deskew { get; set; } = true;      

        public string outputSuffix { get; set; } = "_Searchable";

    }
}
