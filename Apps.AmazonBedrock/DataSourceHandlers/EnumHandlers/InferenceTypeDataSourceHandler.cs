using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.AmazonBedrock.DataSourceHandlers.EnumHandlers;

public class InferenceTypeDataSourceHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        { "ON_DEMAND", "On demand" },
        { "PROVISIONED", "Provisioned" }
    };
}