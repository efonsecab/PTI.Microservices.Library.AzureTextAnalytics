using System;
using System.Collections.Generic;
using System.Text;

namespace PTI.Microservices.Library.Models.AzureTextAnalyticsService.GetKeyPhrases
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class GetKeyPhrasesResponse
    {
        public GetKeyPhrasesResponseDocument[] documents { get; set; }
        public object[] errors { get; set; }
        public string modelVersion { get; set; }
    }

    public class GetKeyPhrasesResponseDocument
    {
        public string id { get; set; }
        public string[] keyPhrases { get; set; }
        public object[] warnings { get; set; }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
