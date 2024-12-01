using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.Options
{
    public static class ProcessingPolicy
    {
        public static readonly List<MultiOptionTemplate> optionList = new List<MultiOptionTemplate>
        {
            new MultiOptionTemplate(
                "",
                "Default: Stop if text already present",
                ""),

            new MultiOptionTemplate(
                "--redo-ocr",
                "Redo: Analyse &amp; redo text where applicable",
                ""),

            new MultiOptionTemplate(
                "--force-ocr",
                "Force: Wipe &amp; redo all text from scratch",
                "")
        };
    }
}
