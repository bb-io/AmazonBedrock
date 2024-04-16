using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Metadata;

namespace Apps.AmazonBedrock;

public class AmazonBedrockApplication : IApplication, ICategoryProvider
{
    public IEnumerable<ApplicationCategory> Categories
    {
        get =>
        [
            ApplicationCategory.ArtificialIntelligence, ApplicationCategory.AmazonApps, ApplicationCategory.Multimedia
        ];
        set { }
    }

    public string Name
    {
        get => "Amazon Bedrock";
        set { }
    }

    public T GetInstance<T>()
    {
        throw new NotImplementedException();
    }
}