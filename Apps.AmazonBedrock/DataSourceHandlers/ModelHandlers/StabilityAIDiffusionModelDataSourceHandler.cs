using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.AmazonBedrock.DataSourceHandlers.ModelHandlers;

public class StabilityAIDiffusionModelDataSourceHandler : ModelBaseDataSourceHandler
{
    protected override string Provider => "stability";
    protected override string Modality => "IMAGE";
    
    public StabilityAIDiffusionModelDataSourceHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}