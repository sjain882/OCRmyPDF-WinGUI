using OcrMyPdf.Logic.ExitCodes;

namespace OcrMyPdf.Logic
{
    public class OCRError
    {
        public string FilePath { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public OCRError(string filePath, ExitCodeTemplate exitCode)
        {
            this.FilePath    = filePath;
            this.Name        = ExitCodeCollection.ExitCodeList.Single(o => o.code == exitCode.code).nameAndCode;
            this.Description = ExitCodeCollection.ExitCodeList.Single(o => o.code == exitCode.code).description;
        }
    }
}
