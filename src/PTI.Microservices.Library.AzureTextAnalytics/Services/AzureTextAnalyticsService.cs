using Microsoft.Extensions.Logging;
using PTI.Microservices.Library.AzureTextAnalytics.Models.DetectLanguage;
using PTI.Microservices.Library.Configuration;
using PTI.Microservices.Library.Interceptors;
using PTI.Microservices.Library.Models.AzureTextAnalyticsService.GetKeyPhrases;
using PTI.Microservices.Library.Models.AzureTextAnalyticsService.GetSentiment;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PTI.Microservices.Library.Services
{
    /// <summary>
    /// Service in cahrge of exposing access to Azure Text Analytics
    /// </summary>
    public sealed class AzureTextAnalyticsService
    {
        public const string VERSION = "v3.1";
        private ILogger<AzureTextAnalyticsService> Logger { get; }
        private AzureTextAnalyticsConfiguration AzureTextAnalyticsConfiguration { get; }
        private CustomHttpClient CustomHttpClient { get; }

        /// <summary>
        /// Creates a new instance of <see cref="AzureTextAnalyticsService"/>
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="azureTextAnalyticsConfiguration"></param>
        /// <param name="customHttpClient"></param>
        public AzureTextAnalyticsService(ILogger<AzureTextAnalyticsService> logger, 
            AzureTextAnalyticsConfiguration azureTextAnalyticsConfiguration,
            CustomHttpClient customHttpClient)
        {
            this.Logger = logger;
            this.AzureTextAnalyticsConfiguration = azureTextAnalyticsConfiguration;
            this.CustomHttpClient = customHttpClient;
            this.CustomHttpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.AzureTextAnalyticsConfiguration.Key);
        }

        /// <summary>
        /// Gets the sentiment
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetSentimentResponse> GetSentimentAsync(GetSentimentRequest model, CancellationToken cancellationToken =default)
        {
            try
            {
                string requestUrl = $"{this.AzureTextAnalyticsConfiguration.Endpoint}/text/analytics/{VERSION}/sentiment" +
                    $"?showStats={true}" +
                    $"&opinionMining={true}";
                var response = await this.CustomHttpClient.PostAsJsonAsync<GetSentimentRequest>(requestUrl, model, cancellationToken);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<GetSentimentResponse>(cancellationToken: cancellationToken);
                    return result;
                }
                else
                {
                    string reason = response.ReasonPhrase;
                    string detailedError = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Reason: {reason}. Details: {detailedError}");
                }
            }
            catch (Exception ex)
            {
                this.Logger?.LogError(ex, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Gets the key phrases
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetKeyPhrasesResponse> GetKeyPhrasesAsync(GetKeyPhrasesRequest model, CancellationToken cancellationToken=default)
        {
            try
            {
                string requestUrl = $"{this.AzureTextAnalyticsConfiguration.Endpoint}/text/analytics/{VERSION}/keyPhrases" +
                    $"?showStats={true}";
                var response = await this.CustomHttpClient.PostAsJsonAsync<GetKeyPhrasesRequest>(requestUrl, model, cancellationToken);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<GetKeyPhrasesResponse>(cancellationToken:cancellationToken);
                    return result;
                }
                else
                {
                    string reason = response.ReasonPhrase;
                    string detailedError = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Reason: {reason}. Details: {detailedError}");
                }
            }
            catch (Exception ex)
            {
                this.Logger?.LogError(ex, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Detects language from the given documents.
        /// Check https://westus.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-0/operations/Languages
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DetectLanguageResponse> DetectLanguageAsync(DetectLanguageRequest model, CancellationToken cancellationToken=default)
        {
            try
            {
                string requestUrl = $"{this.AzureTextAnalyticsConfiguration.Endpoint}/text/analytics" +
                    $"/{VERSION}/languages";
                var response = await this.CustomHttpClient.PostAsJsonAsync<DetectLanguageRequest>(requestUrl, model, cancellationToken: cancellationToken);
                //$"[?model-version][&showStats]";
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<DetectLanguageResponse>(cancellationToken: cancellationToken);
                    return result;
                }
                else
                {
                    string reason = response.ReasonPhrase;
                    string detailedError = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Reason: {reason}. Details: {detailedError}");
                }
            }
            catch(Exception ex)
            {
                this.Logger?.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}
