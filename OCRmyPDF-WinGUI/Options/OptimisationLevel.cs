using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.Options
{
    public static class OptimisationLevel
    {
        public static readonly MultiOptionTemplate Default = new MultiOptionTemplate(
            "",
            "Default (recommended)",
            "");

        public static readonly MultiOptionTemplate Lossless = new MultiOptionTemplate(
            "--optimize 1",
            "Lossless",
            "");

        public static readonly MultiOptionTemplate Lossy = new MultiOptionTemplate(
            "--optimize 2",
            "Lossy",
            "");

        public static readonly MultiOptionTemplate AggrLossy = new MultiOptionTemplate(
            "--optimize 3",
            "Aggressive Lossy",
            "");

        public static readonly MultiOptionTemplate Disabled = new MultiOptionTemplate(
            "--optimize 0",
            "Disabled (not recommended)",
            "");
    }
}
