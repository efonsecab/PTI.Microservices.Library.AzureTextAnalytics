# PTI.Microservices.Library.AzureTextAnalytics

This is part of PTI.Microservices.Library set of packages

The purpose of this package is to facilitate the calls to Azure Text Analytics APIs, while maintaining a consistent usage pattern among the different services in the group

**Examples:**

## Get Key Phrases
    AzureTextAnalyticsService azureTextAnalyticsService =
        new AzureTextAnalyticsService(null, this.AzureTextAnalyticsConfiguration,
        new Microservices.Library.Interceptors.CustomHttpClient(
            new Microservices.Library.Interceptors.CustomHttpClientHandler(this.Logger_CustomHttpClientHandler)));
    GetKeyPhrasesRequest model = new GetKeyPhrasesRequest()
    {
        documents = new GetKeyPhrasesRequestDocument[] {
            new GetKeyPhrasesRequestDocument(){ id=Guid.NewGuid().ToString(), language="en", text="This is a sample text" },
            new GetKeyPhrasesRequestDocument(){ id=Guid.NewGuid().ToString(), language="es", text="Lo mejor del libro El Poder del Amor, es que es un libro creado en Costa Rica" },
        }
    };
    var result = await azureTextAnalyticsService.GetKeyPhrasesAsync(model);

## Get Sentiment
    AzureTextAnalyticsService azureTextAnalyticsService =
        new AzureTextAnalyticsService(null, this.AzureTextAnalyticsConfiguration,
        new Microservices.Library.Interceptors.CustomHttpClient(
            new Microservices.Library.Interceptors.CustomHttpClientHandler(null)));
    GetSentimentRequest model = new GetSentimentRequest()
    {
        documents = new GetSentimentRequestDocument[]
        {
            new GetSentimentRequestDocument()
            {
                id=Guid.NewGuid().ToString(), language="en", 
                text="This is a sample text create in order to analyze the sentiment of this paragraph." +
                "This is a second paragraph in order to test multiple sentences opinion mining"
            },
            new GetSentimentRequestDocument()
            {
                id=Guid.NewGuid().ToString(), language="es",text="La vida es bella, tan bella que quisiera vivir para siempre"
            },
            new GetSentimentRequestDocument()
            {
                id=Guid.NewGuid().ToString(), language="en",text="This is a multi-sentence text in order to check how the API splits it." +
                " There are many items that would be too long"
            }
        }
    };
    var result = await azureTextAnalyticsService.GetSentimentAsync(model);

## Detect Language
    AzureTextAnalyticsService azureTextAnalyticsService =
                    new AzureTextAnalyticsService(null, this.AzureTextAnalyticsConfiguration,
                    new Microservices.Library.Interceptors.CustomHttpClient(
                        new Microservices.Library.Interceptors.CustomHttpClientHandler(null)));
    var result = 
        await azureTextAnalyticsService.DetectLanguageAsync(
        new Microservices.Library.AzureTextAnalytics.Models.DetectLanguage.DetectLanguageRequest()
        {
            documents = new Microservices.Library.AzureTextAnalytics.Models.DetectLanguage.DetectLanguageRequestDocument[]
            {
                new Microservices.Library.AzureTextAnalytics.Models.DetectLanguage.DetectLanguageRequestDocument()
                {
                    countryHint="CR",
                    id="1",
                    text="Esto es una prueba"
                }
            }
        });
    Assert.IsNotNull(result);
    var firstItem = result.documents[0];
    Assert.IsTrue(firstItem.detectedLanguage.iso6391Name == "es");