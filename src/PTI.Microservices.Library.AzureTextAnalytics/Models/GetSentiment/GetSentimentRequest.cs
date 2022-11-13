using System;
using System.Collections.Generic;
using System.Text;

namespace PTI.Microservices.Library.Models.AzureTextAnalyticsService.GetSentiment
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class GetSentimentRequest
    {
        public GetSentimentRequestDocument[] documents { get; set; }
    }

    public class GetSentimentRequestDocument
    {
        public string language { get; set; }
        public string id { get; set; }
        public string text { get; set; }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
