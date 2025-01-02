using System.Collections.ObjectModel;

namespace OcrMyPdf.Logic.Options
{
    public static class OptimisationLevel
    {
        public static readonly ObservableCollection<MultiOptionTemplate> OptionList = new ObservableCollection<MultiOptionTemplate>
        {
            new MultiOptionTemplate(
                "Default",
                "",
                "Default (recommended)",
                ""),

            new MultiOptionTemplate(
                "Lossless",
                "--optimize 1",
                "Lossless",
                ""),

            new MultiOptionTemplate(
                "Lossy",
                "--optimize 2",
                "Lossy",
                ""),

            new MultiOptionTemplate(
                "AggrLossy",
                "--optimize 3",
                "Aggressive Lossy",
                ""),

            new MultiOptionTemplate(
                "Disabled",
                "--optimize 0",
                "Disabled (not recommended)",
                "")
        };
    }
}