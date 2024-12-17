using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.Logic.Utilities.SuffixGenerators
{
    public interface ISuffixGenerator
    {
        public string AddSuffix(string filePath);
    }
}
