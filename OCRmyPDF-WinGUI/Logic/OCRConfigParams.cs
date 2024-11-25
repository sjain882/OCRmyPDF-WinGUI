using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.Logic
{
    static class OcrParams
    {
        public static string[] ProcessingPolicy =
        {
        "",
        "--skip-text",
        "--redo-ocr",
        "--force-ocr"
        };

        public static string[] PDFType =
        {
        "--output-type pdf",
        "--output-type pdfa"
        };

        public static string[] OptimisationLevel =
{
        "--optimize 0",
        "--optimize 1",
        "--optimize 2",
        "--optimize 3"
        };

        public static string rotate = "--rotate";

        public static string deskew = "--deskew";

    }
}
