using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.AmazonBedrock.DataSourceHandlers.FloatParameterHandlers;

public class PresencePenaltyDataSourceHandler : FloatParameterBaseDataSourceHandler
{
    protected override float LowerBoundary => 0.0f;
    protected override float UpperBoundary => 5.0f;

    public PresencePenaltyDataSourceHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}