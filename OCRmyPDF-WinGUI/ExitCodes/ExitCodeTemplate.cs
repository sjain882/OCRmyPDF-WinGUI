using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.ExitCodes
{
    public class ExitCodeTemplate
    {
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

        public ExitCodeTemplate(int code, string displayName, string description)
        {
            this.code = code;
            this.displayName = displayName;
            this.description = description;
        }

        public ExitCodeTemplate(ExitCodeTemplate errorCodeTemplate)
        {
            this.code = errorCodeTemplate.code;
            this.displayName = errorCodeTemplate.displayName;
            this.description = errorCodeTemplate.description;
        }
    }
}
