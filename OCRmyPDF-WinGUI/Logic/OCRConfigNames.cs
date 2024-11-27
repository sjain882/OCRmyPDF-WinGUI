using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.Logic
{
    public static class OCRConfigNames
    {

        public static string[] ProcessingPolicy =
        {
        "Default: Stop if text already present",
        "Redo: Analyse &amp; redo text where applicable",
        "Force: Wipe &amp; redo all text from scratch"
        };

        public static string[] PDFType =
        {
        "PDF",
        "PDF/A"
        };

        public static string[] OptimisationLevel =
        {
        "Default (recommended)",
        "Lossless",
        "Lossy",
        "Aggressive Lossy",
        "Disabled (not recommended)"
        };

        public static string rotate = "Rotate";

        public static string deskew = "Deskew";

    }
}
