using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.Options
{
    public static class PDFType
    {
        public static readonly List<MultiOptionTemplate> optionList = new List<MultiOptionTemplate>
        {
            new MultiOptionTemplate(
                "--output-type pdf",
                "PDF",
                ""),

            new MultiOptionTemplate(
                "--output-type pdfa",
                "PDFA",
                "")
        }
    }
}
