using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.AmazonBedrock.DataSourceHandlers.FloatParameterHandlers;

public class TopKDataSourceHandler : FloatParameterBaseDataSourceHandler
{
    protected override float LowerBoundary => 0.0f;
    protected override float UpperBoundary => 500.0f;
    
    public TopKDataSourceHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}