using System.Collections.ObjectModel;

namespace OcrMyPdf.Logic.Options
{
    public static class PDFType
    {
        public static readonly ObservableCollection<MultiOptionTemplate> OptionList = new ObservableCollection<MultiOptionTemplate>
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
