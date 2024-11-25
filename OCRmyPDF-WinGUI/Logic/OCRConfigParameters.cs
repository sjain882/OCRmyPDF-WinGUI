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
    }
}
