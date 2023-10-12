using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.AmazonBedrock.DataSourceHandlers.ModelHandlers;

public class EmbeddingModelDataSourceHandler : ModelBaseDataSourceHandler
{
    protected override string? Provider => null;
    protected override string Modality => "EMBEDDING";
    
    public EmbeddingModelDataSourceHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}