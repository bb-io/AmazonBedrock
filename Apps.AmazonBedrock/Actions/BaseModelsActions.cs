using Amazon.Bedrock;
using Apps.AmazonBedrock.Dtos;
using Apps.AmazonBedrock.Factories;
using Apps.AmazonBedrock.Models.BaseModels.Requests;
using Apps.AmazonBedrock.Models.BaseModels.Responses;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.AmazonBedrock.Actions;

[ActionList]
public class BaseModelsActions : BaseInvocable
{
    private readonly AmazonBedrockClient _client;

    public BaseModelsActions(InvocationContext invocationContext) : base(invocationContext)
    {
        _client = BedrockClientFactory.CreateBedrockClient(invocationContext.AuthenticationCredentialsProviders);
    }

    [Action("List foundation models", Description = "List Bedrock foundation models available for use.")]
    public async Task<ListFoundationModelsResponse> ListFoundationModels(
        [ActionParameter] ListFoundationModelsRequest input)
    {
        var models = await _client.ListFoundationModelsAsync(new Amazon.Bedrock.Model.ListFoundationModelsRequest
        {
            ByInferenceType = input.InferenceType,
            ByOutputModality = input.OutputModalityType,
            ByProvider = input.Provider
        });
        
        return new()
        {
            FoundationModels = models.ModelSummaries.Select(model => new FoundationModelDto(model))
        };
    }
}