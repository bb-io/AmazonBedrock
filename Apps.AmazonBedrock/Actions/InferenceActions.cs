using System.Text.Json;
using Amazon.BedrockRuntime;
using Amazon.BedrockRuntime.Model;
using Apps.AmazonBedrock.Factories;
using Apps.AmazonBedrock.Models.Inference.Requests;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.AmazonBedrock.Actions;

[ActionList]
public class InferenceActions: BaseInvocable
{
    private readonly AmazonBedrockRuntimeClient _client;

    public InferenceActions(InvocationContext invocationContext) : base(invocationContext)
    {
        _client = BedrockClientFactory.CreateBedrockRuntimeClient(invocationContext.AuthenticationCredentialsProviders);
    }

    [Action("Run inference with Amazon Titan model", Description = "Run inference with Amazon Titan model.")]
    public async Task RunInferenceWithAmazonTitan([ActionParameter] RunInferenceWithAmazonTitanRequest input)
    {
        var requestBody = new
        {
            inputText = input.Prompt,
            textGenerationConfig = new
            {
                temperature = input.Temperature ?? 0,
                topP = input.TopP ?? 1,
                maxTokenCount = input.MaxTokenCount ?? 512,
                stopSequences = input.StopSequences
            }
        };

        using var memoryStream = new MemoryStream();
        await JsonSerializer.SerializeAsync(memoryStream, requestBody);

        var response = await _client.InvokeModelAsync(new InvokeModelRequest
        {
            ModelId = input.ModelId,
            Body = memoryStream
        });
    }

    [Action("Run inference with Cohere model", Description = "Run inference with Cohere model.")]
    public async Task RunInferenceWithCohere([ActionParameter] RunInferenceWithCohereRequest input)
    {
        var requestBody = new
        {
            prompt = input.Prompt,
            temperature = input.Temperature ?? 0.9,
            p = input.TopP ?? 0.75,
            k = input.TopK ?? 0,
            max_tokens = input.MaxTokenCount ?? 200,
            stopSequences = input.StopSequences,
            stream = false
        };

        using var memoryStream = new MemoryStream();
        await JsonSerializer.SerializeAsync(memoryStream, requestBody);

        var response = await _client.InvokeModelAsync(new InvokeModelRequest
        {
            ModelId = input.ModelId,
            Body = memoryStream
        });
    }
}