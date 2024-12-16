using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

        public static string AddPathSuffix(string filePath, string suffix)
        {
            string fDir = Path.GetDirectoryName(filePath);
            string fName = Path.GetFileNameWithoutExtension(filePath);
            string fExt = Path.GetExtension(filePath);
            return Path.Combine(fDir, String.Concat(fName, suffix, fExt));
        }

        public static string GetRandomSuffix(string filepath)
        {
            // string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            char[] stringChars = new char[4];
            Random random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return "_" + new string(stringChars);
        }

        public static string AddRandomPathSuffix(string filePath)
        {
            return AddPathSuffix(filePath, GetRandomSuffix(filePath));
        }
    }
}
