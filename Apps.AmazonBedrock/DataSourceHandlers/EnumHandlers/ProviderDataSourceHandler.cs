using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.AmazonBedrock.DataSourceHandlers.EnumHandlers;

public class ProviderDataSourceHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        { "ai21", "AI21 Labs" },
        { "amazon", "Amazon" },
        { "anthropic", "Anthropic" },
        { "cohere", "Cohere" },
        { "stability", "Stability AI" }
    };
}