using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTI.Microservices.Library.AzureTextAnalytics.Models.DetectLanguage
{

    public class DetectLanguageRequest
    {
        public DetectLanguageRequestDocument[] documents { get; set; }
    }

    public class DetectLanguageRequestDocument
    {
        public string countryHint { get; set; }
        public string id { get; set; }
        public string text { get; set; }
    }

}
