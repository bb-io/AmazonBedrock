using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.AmazonBedrock.DataSourceHandlers.ModelHandlers;

public class CohereModelDataSourceHandler : ModelBaseDataSourceHandler
{
    protected override string Provider => "cohere";
    protected override string Modality => "TEXT";
    
    public CohereModelDataSourceHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}