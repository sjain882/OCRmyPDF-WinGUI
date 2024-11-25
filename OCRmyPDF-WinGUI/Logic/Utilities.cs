﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OcrMyPdf.Logic
{
    public static class Utilities
    {
        public static StringBuilder AppendWithSeparator(this StringBuilder sb,
                                                        char separator,
                                                        string valueToAppend)
        {
            // If this is the first string appended, don't add the separator
            if (sb.Length > 0)
                sb.Append(separator);

            sb.Append(valueToAppend);
            return sb;
        }

        public static string AddSuffix(string filename, string suffix)
        {
            string fDir = Path.GetDirectoryName(filename);
            string fName = Path.GetFileNameWithoutExtension(filename);
            string fExt = Path.GetExtension(filename);
            return Path.Combine(fDir, String.Concat(fName, suffix, fExt));
        }
    }
}
