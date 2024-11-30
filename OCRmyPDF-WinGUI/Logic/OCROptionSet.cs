using OcrMyPdf.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.Logic
{
    public class OCROptionSet
    {
        public MultiOptionTemplate processingPolicy { get; set; } = ProcessingPolicy.Default;

        public MultiOptionTemplate pdfType { get; set; } = PDFType.PDF;

        public MultiOptionTemplate optimisationLevel { get; set; } = OptimisationLevel.Default;

        public string outputSuffix { get; set; } = "_Searchable";

        public bool rotate { get; set; } = true;

        public bool deskew { get; set; } = true;

    }
}
