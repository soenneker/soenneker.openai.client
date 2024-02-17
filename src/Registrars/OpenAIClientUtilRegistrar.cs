using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.OpenAI.Client.Abstract;

namespace Soenneker.OpenAI.Client.Registrars;

/// <summary>
/// An async thread-safe singleton for the OpenAI client by Betalgo
/// </summary>
public static class OpenAIClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IOpenAIClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static void AddOpenAIClientUtilAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IOpenAIClientUtil, OpenAIClientUtil>();
    }
}
