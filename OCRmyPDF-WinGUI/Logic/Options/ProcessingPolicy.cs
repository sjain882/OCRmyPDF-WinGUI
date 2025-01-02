using System.Collections.ObjectModel;

namespace OcrMyPdf.Logic.Options
{
    public static class ProcessingPolicy
    {
        public static readonly ObservableCollection<MultiOptionTemplate> OptionList = new ObservableCollection<MultiOptionTemplate>
        {
            new MultiOptionTemplate(
                "Default",
                "",
                "Default: Stop if text already present",
                ""),

            new MultiOptionTemplate(
                "RedoOCR",
                "--redo-ocr",
                "Redo: Analyse & redo text where applicable",
                ""),

            new MultiOptionTemplate(
                "ForceOCR",
                "--force-ocr",
                "Force: Wipe & redo all text from scratch",
                "")
        };
    }
}
