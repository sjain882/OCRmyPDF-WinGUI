using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.Logic
{
    public enum ProcessingPolicy
    {
        Default     = 0,
        SkipText    = 1,
        RedoOCR     = 2,
        ForceOCR    = 3
    }

}
