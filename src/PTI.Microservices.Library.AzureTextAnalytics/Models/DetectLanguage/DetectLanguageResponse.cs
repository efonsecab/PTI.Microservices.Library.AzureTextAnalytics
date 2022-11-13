using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTI.Microservices.Library.AzureTextAnalytics.Models.DetectLanguage
{

    public class DetectLanguageResponse
    {
        public DetectLanguageResponseDocument[] documents { get; set; }
        public DetectLanguageResponseError[] errors { get; set; }
        public string modelVersion { get; set; }
    }

    public class DetectLanguageResponseDocument
    {
        public string id { get; set; }
        public Detectedlanguage detectedLanguage { get; set; }
        public object[] warnings { get; set; }
    }

    public class Detectedlanguage
    {
        public string name { get; set; }
        public string iso6391Name { get; set; }
        public float confidenceScore { get; set; }
    }

    public class DetectLanguageResponseError
    {
        public string id { get; set; }
        public DetectLanguageResponseErrorDetail error { get; set; }
    }

    public class DetectLanguageResponseErrorDetail
    {
        public string code { get; set; }
        public string message { get; set; }
        public DetectLanguageResponseErrorDetailInnerError innererror { get; set; }
    }

    public class DetectLanguageResponseErrorDetailInnerError
    {
        public string code { get; set; }
        public string message { get; set; }
    }

}
