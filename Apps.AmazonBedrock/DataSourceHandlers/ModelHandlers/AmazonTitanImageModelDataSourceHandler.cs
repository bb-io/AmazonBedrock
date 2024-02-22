using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.AmazonBedrock.DataSourceHandlers.ModelHandlers;

public class AmazonTitanImageModelDataSourceHandler : ModelBaseDataSourceHandler
{
    protected override string Provider => "amazon";
    protected override string Modality => "IMAGE";
    
    public AmazonTitanImageModelDataSourceHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}