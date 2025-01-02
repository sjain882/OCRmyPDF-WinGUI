namespace OcrMyPdf.Logic.ExitCodes
{
    public class ExitCodeTemplate
    {
        public string identifier {  get; set; }

        public int code {  get; set; }

        public string displayName { get; set; }

        public string description { get; set; }

        public string nameAndDesc
        {
            get
            {
                return this.displayName + " - " + this.description;
            }
        }

        public string nameAndCode
        {
            get
            {
                return this.displayName + " (" + this.code + ")";
            }
        }

        public ExitCodeTemplate(int code)
        {
            this.identifier = ExitCodeCollection.ExitCodeList.Single(o => o.code == code).identifier;
            this.code = code;
            this.displayName = ExitCodeCollection.ExitCodeList.Single(o => o.code == code).displayName;
            this.description = ExitCodeCollection.ExitCodeList.Single(o => o.code == code).description;
        }

        public ExitCodeTemplate(string identifier, int code, string displayName, string description)
        {
            this.identifier = identifier;
            this.code = code;
            this.displayName = displayName;
            this.description = description;
        }

        public ExitCodeTemplate(ExitCodeTemplate errorCodeTemplate)
        {
            this.identifier = errorCodeTemplate.identifier;
            this.code = errorCodeTemplate.code;
            this.displayName = errorCodeTemplate.displayName;
            this.description = errorCodeTemplate.description;
        }
    }
}
