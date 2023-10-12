using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.AmazonBedrock.DataSourceHandlers.ModelHandlers;

public class AI21LabsJurassicModelDataSourceHandler : ModelBaseDataSourceHandler
{
    protected override string Provider => "ai21";
    protected override string Modality => "TEXT";
    
    public AI21LabsJurassicModelDataSourceHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}