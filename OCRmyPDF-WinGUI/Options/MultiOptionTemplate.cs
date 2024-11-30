using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.Options
{
    public class MultiOptionTemplate
    {
        public string argument { get; set; }

        public string displayName {  get; set; }

        public string description { get; set; }

        public MultiOptionTemplate(string argument, string displayName, string description)
        {
            this.argument = argument;
            this.displayName = displayName;
            this.description = displayName + ":" + Environment.NewLine + description;
        }
    }
}
