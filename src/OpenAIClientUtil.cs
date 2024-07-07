using System;
using System.Threading;
using Soenneker.Utils.AsyncSingleton;
using Soenneker.OpenAI.Client.Abstract;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OpenAI;
using OpenAI.Managers;
using Soenneker.Extensions.Configuration;

namespace Soenneker.OpenAI.Client;

/// <inheritdoc cref="IOpenAIClientUtil"/>
public class OpenAIClientUtil: IOpenAIClientUtil
{
    private readonly AsyncSingleton<OpenAIService> _client;

    public OpenAIClientUtil(ILogger<OpenAIClientUtil> logger, IConfiguration configuration)
    {
        _client = new AsyncSingleton<OpenAIService>(() =>
        {
            logger.LogDebug("Creating OpenAI client...");

            var apiKey = configuration.GetValueStrict<string>("OpenAI:ApiKey");

            var options = new OpenAiOptions
            {
                ApiKey = apiKey
            };

            var client = new OpenAIService(options);

            return client;
        });
    }

    public ValueTask<OpenAIService> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);

        return _client.DisposeAsync();
    }
}
