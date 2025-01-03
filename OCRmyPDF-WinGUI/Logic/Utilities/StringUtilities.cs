﻿using System.Text;

namespace OcrMyPdf.Logic.Utilities
{
    public static class StringUtilities
    {
        public static StringBuilder AppendWithSeparator(this StringBuilder sb,
                                                        char separator,
                                                        string valueToAppend)
        {
            // If this is the first string appended, don't add the separator
            // If the value to append is empty (i.e, no arg / default OCRmyPDF behaviour), don't add the separator.
            if ((sb.Length > 0) && (valueToAppend.Length > 0))
                sb.Append(separator);

            sb.Append(valueToAppend);
            return sb;
        }

        public static string GetCurrentDateTime()
        {
            return DateTime.Now.ToString("yyyyMMdd-HHmmss");
        }
    }
}
