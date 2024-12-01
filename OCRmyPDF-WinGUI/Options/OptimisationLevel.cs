using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.Options
{
    public static class OptimisationLevel
    {
        public static readonly List<MultiOptionTemplate> OptionList = new List<MultiOptionTemplate>
        {
            new MultiOptionTemplate(
                "",
                "Default (recommended)",
                ""),

            new MultiOptionTemplate(
                "--optimize 1",
                "Lossless",
                ""),

            new MultiOptionTemplate(
                "--optimize 2",
                "Lossy",
                ""),

            new MultiOptionTemplate(
                "--optimize 3",
                "Aggressive Lossy",
                ""),

            new MultiOptionTemplate(
                "--optimize 0",
                "Disabled (not recommended)",
                "")
        };
    }
}