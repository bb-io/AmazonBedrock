using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.AmazonBedrock.DataSourceHandlers.FloatParameterHandlers;

public class PromptStrengthDataSourceHandler : FloatParameterBaseDataSourceHandler
{
    protected override float LowerBoundary => 0.0f;
    protected override float UpperBoundary => 30.0f;

    public PromptStrengthDataSourceHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}