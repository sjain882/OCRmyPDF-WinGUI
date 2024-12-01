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