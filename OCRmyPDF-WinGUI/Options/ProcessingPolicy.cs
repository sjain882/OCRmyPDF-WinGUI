using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.Options
{
    public static class ProcessingPolicy
    {
        public static readonly MultiOptionTemplate Default = new MultiOptionTemplate(
            "",
            "Default: Stop if text already present",
            "");

        public static readonly MultiOptionTemplate RedoOCR = new MultiOptionTemplate(
            "--redo-ocr",
            "Redo: Analyse &amp; redo text where applicable",
            "");

        public static readonly MultiOptionTemplate ForceOCR = new MultiOptionTemplate(
            "--force-ocr",
            "Force: Wipe &amp; redo all text from scratch",
            "");
    }
}
