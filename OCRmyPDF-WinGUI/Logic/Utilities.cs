using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.Logic
{
    public static class Utilities
    {
        public static StringBuilder AppendWithSeparator(StringBuilder sb,
                                                        char separator,
                                                        string valueToAppend)
        {
            // If this is the first string appended, don't add the separator
            if (sb.Length > 0)
                sb.Append(separator);

            sb.Append(valueToAppend);
            return sb;
        }
    }
}
