using Soenneker.OpenAI.Client.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;
using Xunit.Abstractions;

namespace Soenneker.OpenAI.Client.Tests;

[Collection("Collection")]
public class OpenAiClientUtilTests : FixturedUnitTest
{
    private readonly IOpenAIClientUtil _util;

    public OpenAiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IOpenAIClientUtil>(true);
    }
}
