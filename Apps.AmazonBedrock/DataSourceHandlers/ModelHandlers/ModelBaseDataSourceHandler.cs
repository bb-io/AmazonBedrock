using Amazon.Bedrock.Model;
using Apps.AmazonBedrock.Factories;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.AmazonBedrock.DataSourceHandlers.ModelHandlers;

public abstract class ModelBaseDataSourceHandler : BaseInvocable, IAsyncDataSourceHandler
{
    protected abstract string Provider { get; }
    protected abstract string Modality { get; }
    
    public ModelBaseDataSourceHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context, 
        CancellationToken cancellationToken)
    {
        var client = BedrockClientFactory.CreateBedrockClient(InvocationContext.AuthenticationCredentialsProviders);
        var models = await client.ListFoundationModelsAsync(new ListFoundationModelsRequest
        {
            ByProvider = Provider,
            ByOutputModality = Modality
        }, cancellationToken);
        return models.ModelSummaries
            .Where(model => context.SearchString == null 
                            || model.ModelName.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(model => model.ModelId, model => model.ModelName);
    }
}