using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.AmazonBedrock.DataSourceHandlers.FloatParameterHandlers;

public class CfgScaleDataSourceHandler : FloatParameterBaseDataSourceHandler
{
    protected override float LowerBoundary => 1.1f;
    protected override float UpperBoundary => 10.0f;

    public CfgScaleDataSourceHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}