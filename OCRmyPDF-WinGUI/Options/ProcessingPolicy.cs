using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.Options
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
