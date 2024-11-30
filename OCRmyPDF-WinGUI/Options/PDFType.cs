using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.Options
{
    public static class PDFType
    {
        public static readonly MultiOptionTemplate PDF = new MultiOptionTemplate(
            "--output-type pdf",
            "PDF",
            "");

        public static readonly MultiOptionTemplate PDFA = new MultiOptionTemplate(
            "--output-type pdfa",
            "PDFA",
            "");
    }
}
