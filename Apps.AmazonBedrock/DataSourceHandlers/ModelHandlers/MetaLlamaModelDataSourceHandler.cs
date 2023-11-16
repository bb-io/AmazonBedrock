using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.AmazonBedrock.DataSourceHandlers.ModelHandlers;

public class MetaLlamaModelDataSourceHandler : ModelBaseDataSourceHandler
{
    protected override string Provider => "meta";
    protected override string Modality => "TEXT";
    
    public MetaLlamaModelDataSourceHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}