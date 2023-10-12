using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.AmazonBedrock.DataSourceHandlers.FloatParameterHandlers;

public class TemperatureDataSourceHandler : FloatParameterBaseDataSourceHandler
{
    protected override float LowerBoundary => 0.0f;
    protected override float UpperBoundary => 1.0f;

    public TemperatureDataSourceHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}

public class CohereTemperatureDataSourceHandler : FloatParameterBaseDataSourceHandler
{
    protected override float LowerBoundary => 0.0f;
    protected override float UpperBoundary => 5.0f;

    public CohereTemperatureDataSourceHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}