namespace OcrMyPdf.Logic.Utilities
{
    // Interface
    public interface ISuffixGenerator
    {
        public string GenerateSuffix();
    }


    // Generate random suffix
    public class RandomSuffixGenerator : ISuffixGenerator
    {
        public string GenerateSuffix()
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
    }

    // Generate timestamp suffix
    public class TimestampSuffixGenerator : ISuffixGenerator
    {
        public string GenerateSuffix()
        {
            return "_" + DateTime.Now.ToString("yyyyMMdd-HHmmss");
        }
    }
}
