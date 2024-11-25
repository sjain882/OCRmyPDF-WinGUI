using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.Logic
{
    enum ProcessingPolicy
    {
        Default     = 0,        // Default in CLI + GUI
        SkipText    = 1,
        RedoOCR     = 2,
        ForceOCR    = 3
    }

    enum PDFType
    {
        PDF         = 0,        // Make this default in GUI
        PDFA        = 1         // Defualt in CLI
    }

    enum OptimisationLevel
    {
        Default     = 0,
        Lossless    = 1,        // Default in CLI + GUI
        Lossy       = 2,
        AggrLossy   = 3,
        Disabled    = 4
    }

    internal class OCRConfig
    {
        public ProcessingPolicy processingPolicy { get; set; }

        public PDFType pdfType { get; set; }

        public OptimisationLevel optimisationLevel { get; set; }

        public bool rotate { get; set; }               // Make default T in GUI

        public bool deskew { get; set; }               // Make default T in GUI

        public string outputSuffix { get; set; } = "_Searchable";

    }
}
