using OcrMyPdf.Logic.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.Logic
{
    public class OCROptionSet
    {
        public MultiOptionTemplate processingPolicy { get; set; } = ProcessingPolicy.OptionList.Single(o => o.identifier == "RedoOCR");

        public MultiOptionTemplate pdfType { get; set; } = PDFType.OptionList.Single(o => o.identifier == "PDF");

        public MultiOptionTemplate optimisationLevel { get; set; } = OptimisationLevel.OptionList.Single(o => o.identifier == "Default");

        public string outputSuffix { get; set; } = "_Searchable";

        public bool rotate { get; set; } = true;

        public bool deskew { get; set; } = false;

        public bool clearSuccesses { get; set; } = false;

    }
}
