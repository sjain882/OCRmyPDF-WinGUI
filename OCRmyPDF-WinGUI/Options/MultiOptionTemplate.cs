using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrMyPdf.Options
{
    public class MultiOptionTemplate
    {
        public string identifier {  get; set; }

        public string argument { get; set; }

        public string displayName { get; set; }

        public string description { get; set; }

        public MultiOptionTemplate(string identifier, string argument, string displayName, string description)
        {
            this.identifier = identifier;
            this.argument = argument;
            this.displayName = displayName;
            this.description = displayName + ":" + Environment.NewLine + description;
        }

        public MultiOptionTemplate(MultiOptionTemplate multiOptionTemplate)
        {
            this.identifier = multiOptionTemplate.identifier;
            this.argument = multiOptionTemplate.argument;
            this.displayName = multiOptionTemplate.displayName;
            this.description = multiOptionTemplate.description;
        }
    }
}
