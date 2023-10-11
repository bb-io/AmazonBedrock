using Blackbird.Applications.Sdk.Common;

namespace Apps.AmazonBedrock;

public class AmazonBedrockApplication : IApplication
{
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