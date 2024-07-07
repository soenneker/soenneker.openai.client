using OpenAI.Managers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.OpenAI.Client.Abstract;

/// <summary>
/// An async thread-safe singleton for the OpenAI client by Betalgo
/// </summary>
public interface IOpenAIClientUtil : IDisposable, IAsyncDisposable
{
    ValueTask<OpenAIService> Get(CancellationToken cancellationToken = default);
}
