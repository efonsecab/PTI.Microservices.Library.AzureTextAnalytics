using System;
using System.Collections.Generic;
using System.Text;

namespace PTI.Microservices.Library.Models.AzureTextAnalyticsService.GetSentiment
{

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    public class GetSentimentResponse
    {
        public GetSentimentResponseStatistics statistics { get; set; }
        public GetSentimentResponseDocument[] documents { get; set; }
        public GetSentimentResponseError[] errors { get; set; }
        public string modelVersion { get; set; }
    }

    public class GetSentimentResponseStatistics
    {
        public int documentsCount { get; set; }
        public int validDocumentsCount { get; set; }
        public int erroneousDocumentsCount { get; set; }
        public int transactionsCount { get; set; }
    }

    public class GetSentimentResponseDocument
    {
        public string id { get; set; }
        public string sentiment { get; set; }
        public GetSentimentResponseStatistics1 statistics { get; set; }
        public GetSentimentResponseConfidencescores confidenceScores { get; set; }
        public GetSentimentResponseSentence[] sentences { get; set; }
        public object[] warnings { get; set; }
    }

    public class GetSentimentResponseStatistics1
    {
        public int charactersCount { get; set; }
        public int transactionsCount { get; set; }
    }

    public class GetSentimentResponseConfidencescores
    {
        public float positive { get; set; }
        public float neutral { get; set; }
        public float negative { get; set; }
    }

    public class GetSentimentResponseSentence
    {
        public string sentiment { get; set; }
        public GetSentimentResponseConfidencescores1 confidenceScores { get; set; }
        public int offset { get; set; }
        public int length { get; set; }
        public string text { get; set; }
        public object[] targets { get; set; }
        public object[] assessments { get; set; }
    }

    public class GetSentimentResponseConfidencescores1
    {
        public float positive { get; set; }
        public float neutral { get; set; }
        public float negative { get; set; }
    }

    public class GetSentimentResponseError
    {
        public string id { get; set; }
        public GetSentimentResponseError1 error { get; set; }
    }

    public class GetSentimentResponseError1
    {
        public string code { get; set; }
        public string message { get; set; }
        public GetSentimentResponseInnererror innererror { get; set; }
    }

    public class GetSentimentResponseInnererror
    {
        public string code { get; set; }
        public string message { get; set; }
    }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
