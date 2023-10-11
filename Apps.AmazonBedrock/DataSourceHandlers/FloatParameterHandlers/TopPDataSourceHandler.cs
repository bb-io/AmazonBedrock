using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.AmazonBedrock.DataSourceHandlers.FloatParameterHandlers;

public class TopPDataSourceHandler : FloatParameterBaseDataSourceHandler
{
    protected override float LowerBoundary => 0.0f;
    protected override float UpperBoundary => 1.0f;
    
    public TopPDataSourceHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}