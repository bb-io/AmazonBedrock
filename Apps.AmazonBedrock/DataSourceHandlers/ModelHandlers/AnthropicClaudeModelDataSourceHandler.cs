using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.AmazonBedrock.DataSourceHandlers.ModelHandlers;

public class AnthropicClaudeModelDataSourceHandler : ModelBaseDataSourceHandler
{
    protected override string Provider => "anthropic";
    protected override string Modality => "TEXT";
    
    public AnthropicClaudeModelDataSourceHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}