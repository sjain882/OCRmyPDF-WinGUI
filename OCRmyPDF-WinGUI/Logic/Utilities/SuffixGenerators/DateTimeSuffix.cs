using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.Logic.Utilities.SuffixGenerators
{
    public class DateTimeSuffix : ISuffixGenerator
    {
        public string AddSuffix(string filePath)
        {
            return StringUtilities.AddPathSuffix(filePath, "_" + DateTime.Now.ToString("yyyyMMdd-HHmmss"));
        }
    }
}
