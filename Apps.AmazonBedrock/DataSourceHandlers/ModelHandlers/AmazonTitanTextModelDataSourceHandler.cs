using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.AmazonBedrock.DataSourceHandlers.ModelHandlers;

public class AmazonTitanTextModelDataSourceHandler : ModelBaseDataSourceHandler
{
    protected override string Provider => "amazon";
    protected override string Modality => "TEXT";
    
    public AmazonTitanTextModelDataSourceHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}