using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.Logic.Utilities.SuffixGenerators
{
    public class RandomSuffix : ISuffixGenerator
    {
        public string AddSuffix(string filePath)
        {
            // string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            char[] stringChars = new char[4];
            Random random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return StringUtilities.AddPathSuffix(filePath, "_" + new string(stringChars));
        }
    }
}
