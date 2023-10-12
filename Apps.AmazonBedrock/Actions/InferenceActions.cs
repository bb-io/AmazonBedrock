using System.Net.Mime;
using System.Text;
using Amazon.BedrockRuntime;
using Amazon.BedrockRuntime.Model;
using Apps.AmazonBedrock.Factories;
using Apps.AmazonBedrock.Models.Inference.Requests;
using Apps.AmazonBedrock.Models.Inference.Responses;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Newtonsoft.Json;
using File = Blackbird.Applications.Sdk.Common.Files.File;

namespace Apps.AmazonBedrock.Actions;

[ActionList]
public class InferenceActions: BaseInvocable
{
    private readonly AmazonBedrockRuntimeClient _client;

    public InferenceActions(InvocationContext invocationContext) : base(invocationContext)
    {
        _client = BedrockClientFactory.CreateBedrockRuntimeClient(invocationContext.AuthenticationCredentialsProviders);
    }

    [Action("Generate text with Cohere Command model", Description = "Generate text with Cohere Command model or any " +
                                                                     "custom model that is based on Cohere Command model.")]
    public async Task<RunInferenceWithCohereResponse> RunInferenceWithCohere(
        [ActionParameter] RunInferenceWithCohereRequest input)
    {
        var requestBody = new
        {
            prompt = input.Prompt,
            temperature = input.Temperature ?? 0.9,
            p = input.TopP ?? 0.75,
            k = input.TopK ?? 0,
            max_tokens = input.MaximumTokensNumber ?? 512,
            stop_sequences = input.StopSequences ?? new string[] { },
            stream = false
        };

        var response = await ExecuteRequestAsync<RunInferenceWithCohereResponseWrapper>(input.ModelArn, requestBody);
        return response.Generations.First();
    }
    
    [Action("Generate text with Anthropic Claude model", Description = "Generate text with Anthropic Claude model or any " +
                                                                       "custom model that is based on Anthropic Claude model.")]
    public async Task<RunInferenceWithAnthropicClaudeResponse> RunInferenceWithAnthropicClaude(
        [ActionParameter] RunInferenceWithAnthropicClaudeRequest input)
    {
        var requestBody = new
        {
            prompt = $"\n\nHuman:{input.Prompt}\n\nAssistant:",
            temperature = input.Temperature ?? 0.5,
            top_p = input.TopP ?? 1,
            top_k = input.TopK ?? 250,
            max_tokens_to_sample = input.MaximumTokensNumber ?? 512,
            stop_sequences = input.StopSequences ?? new string[] { }
        };

        var response = await ExecuteRequestAsync<RunInferenceWithAnthropicClaudeResponse>(input.ModelArn, requestBody);
        return response;
    }

    [Action("Generate text with AI21 Labs Jurassic-2 model", Description = "Generate text with AI21 Labs Jurassic-2 model " +
                                                                           "or any custom model that is based on AI21 Labs " +
                                                                           "Jurassic-2 model.")]
    public async Task<RunInferenceWithAI21Response> RunInferenceWithAI21([ActionParameter] RunInferenceWithAI21Request input)
    {
        var requestBody = new
        {
            prompt = input.Prompt,
            temperature = input.Temperature ?? 0.5,
            topP = input.TopP ?? 0.5,
            maxTokens = input.MaximumTokensNumber ?? 512,
            stopSequences = input.StopSequences ?? new string[] { },
            countPenalty = new
            {
                scale = input.CountPenalty ?? 0
            },
            presencePenalty = new
            {
                scale = input.PresencePenalty ?? 0
            },
            frequencyPenalty = new
            {
                scale = input.FrequencyPenalty ?? 0
            }
        };

        var response = await ExecuteRequestAsync<RunInferenceWithAI21ResponseWrapper>(input.ModelArn, requestBody);
        return response.Completions.First().Data;
    }
    
    [Action("Generate image with Stability.ai Diffusion model", Description = "Generate image with Stability.ai Diffusion " +
                                                                              "model or any custom model that is based on " +
                                                                              "Stability.ai Diffusion model.")]
    public async Task<RunInferenceWithStabilityAIDiffusionResponse> RunInferenceWithStabilityAIDiffusion(
        [ActionParameter] RunInferenceWithStabilityAIDiffusionRequest input)
    {
        var requestBody = new
        {
            text_prompts = new[]
            {
                new { text = input.Prompt }
            },
            cfg_scale = input.PromptStrength ?? 10,
            steps = input.GenerationSteps ?? 50
        };

        var response = await ExecuteRequestAsync<ImageBytesWrapper>(input.ModelArn, requestBody);
        var bytes = response.Artifacts.First().Base64;
        var filename = (input.GeneratedImageFilename ?? input.Prompt) + ".png";
        
        return new()
        {
            GeneratedImage = new File(bytes)
            {
                ContentType = "image/png",
                Name = filename
            }
        };
    }

    [Action("Generate embedding", Description = "Generate embedding vector for a text provided.")]
    public async Task<GenerateEmbeddingResponse> GenerateEmbedding([ActionParameter] GenerateEmbeddingRequest input)
    {
        var requestBody = new
        {
            inputText = input.Text
        };
        
        var response = await ExecuteRequestAsync<GenerateEmbeddingResponse>(input.ModelArn, requestBody);
        return response;
    }
    
    // TODO: Uncomment this action when Amazon Titan text models are available. They are not available because they are in preview at the moment of writing.
    // [Action("Run inference with Amazon Titan model", Description = "Run inference with Amazon Titan model.")]
    // public async Task<> RunInferenceWithAmazonTitan([ActionParameter] RunInferenceWithAmazonTitanRequest input)
    // {
    //     var requestBody = new
    //     {
    //         inputText = input.Prompt,
    //         textGenerationConfig = new
    //         {
    //             temperature = input.Temperature ?? 0,
    //             topP = input.TopP ?? 1,
    //             maxTokenCount = input.MaximumTokensNumber ?? 512,
    //             stopSequences = input.StopSequences ?? new string[] { }
    //         }
    //     };
    //
    //     var response = await ExecuteRequestAsync<>(input.ModelArn, requestBody);
    //     return response;
    // }

    private async Task<TResponse> ExecuteRequestAsync<TResponse>(string modelArn, object requestBody)
    {
        var jsonRequestBody = JsonConvert.SerializeObject(requestBody);

        using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonRequestBody));
        
        var response = await _client.InvokeModelAsync(new InvokeModelRequest
        {
            ModelId = modelArn,
            ContentType = MediaTypeNames.Application.Json,
            Body = memoryStream
        });

        var jsonResponse = Encoding.UTF8.GetString(response.Body.ToArray());
        var responseObject = JsonConvert.DeserializeObject<TResponse>(jsonResponse, new JsonSerializerSettings
        {
            MissingMemberHandling = MissingMemberHandling.Ignore
        });
        return responseObject;
    }
}