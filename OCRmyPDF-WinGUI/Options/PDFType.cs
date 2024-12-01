using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.Options
{
    public static class PDFType
    {
        public static readonly List<MultiOptionTemplate> OptionList = new List<MultiOptionTemplate>
        {
            new MultiOptionTemplate(
                "PDF",
                "--output-type pdf",
                "PDF",
                ""),

            new MultiOptionTemplate(
                "PDFA",
                "--output-type pdfa",
                "PDF/A",
                "")
        };
    }
}
