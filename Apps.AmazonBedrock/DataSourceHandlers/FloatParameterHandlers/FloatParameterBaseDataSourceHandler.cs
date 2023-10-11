using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.AmazonBedrock.DataSourceHandlers.FloatParameterHandlers;

public abstract class FloatParameterBaseDataSourceHandler : BaseInvocable, IDataSourceHandler
{
    protected abstract float LowerBoundary { get; }
    protected abstract float UpperBoundary { get; }
    
    public FloatParameterBaseDataSourceHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
    
    public Dictionary<string, string> GetData(DataSourceContext context)
    {
        var parameters = FloatArrayExtensions.GenerateFormattedFloatArray(LowerBoundary, UpperBoundary, 0.1f)
            .Where(parameter => context.SearchString == null || parameter.Contains(context.SearchString))
            .Take(50)
            .ToDictionary(parameter => parameter, parameter => parameter);

        return parameters;
    }
}