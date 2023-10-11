using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.AmazonBedrock.DataSourceHandlers.EnumHandlers;

public class OutputModalityTypeDataSourceHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        { "TEXT", "Text" },
        { "IMAGE", "Image" },
        { "EMBEDDING", "Embedding" }
    };
}