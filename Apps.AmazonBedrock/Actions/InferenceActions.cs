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
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using Blackbird.Applications.Sdk.Utils.Extensions.Files;
using Newtonsoft.Json;

namespace Apps.AmazonBedrock.Actions;

[ActionList]
public class InferenceActions : BaseInvocable
{
    private readonly AmazonBedrockRuntimeClient _client;

    private readonly IFileManagementClient _fileManagementClient;

    public InferenceActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient) : base(
        invocationContext)
    {
        _fileManagementClient = fileManagementClient;
        _client = BedrockClientFactory.CreateBedrockRuntimeClient(invocationContext.AuthenticationCredentialsProviders);
    }

    #region Text generation

    [Action("Generate text with Cohere Command", Description = "Generate text with Cohere Command model " +
                                                               "or any custom model that is based on Cohere " +
                                                               "Command model.")]
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

    [Action("Generate text with Anthropic Claude", Description = "Generate text with Anthropic Claude model or any " +
                                                                 "custom model that is based on Anthropic Claude model.")]
    public async Task<RunInferenceWithAnthropicClaudeResponse> RunInferenceWithAnthropicClaude(
        [ActionParameter] RunInferenceWithAnthropicClaudeRequest input)
    {
        var requestBody = new
        {
            prompt = (input.SystemPrompt == null ? "" : input.SystemPrompt) + $"\n\nHuman:{input.Prompt}\n\nAssistant:",
            temperature = input.Temperature ?? 0.5,
            top_p = input.TopP ?? 1,
            top_k = input.TopK ?? 250,
            max_tokens_to_sample = input.MaximumTokensNumber ?? 512,
            stop_sequences = input.StopSequences ?? new string[] { }
        };

        var response = await ExecuteRequestAsync<RunInferenceWithAnthropicClaudeResponse>(input.ModelArn, requestBody);
        return response;
    }
    
    [Action("Generate text with AI21 Labs Jurassic-2", Description = "Generate text with AI21 Labs Jurassic-2 model or " +
                                                                     "any custom model that is based on AI21 Labs " +
                                                                     "Jurassic-2 model.")]
    public async Task<RunInferenceWithAI21Response> RunInferenceWithAI21(
        [ActionParameter] RunInferenceWithAI21Request input)
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

    [Action("Generate text with Meta Llama 2", Description = "Generate text with Meta Llama 2 model or any custom " +
                                                             "model that is based on Meta Llama 2 model.")]
    public async Task<RunInferenceWithMetaLlamaResponse> RunInferenceWithMetaLlama(
        [ActionParameter] RunInferenceWithMetaLlamaRequest input)
    {
        var requestBody = new
        {
            prompt = input.Prompt,
            temperature = input.Temperature ?? 0.5,
            top_p = input.TopP ?? 0.9,
            max_gen_len = input.MaximumTokensNumber ?? 512
        };

        var response = await ExecuteRequestAsync<RunInferenceWithMetaLlamaResponse>(input.ModelArn, requestBody);
        return response;
    }
    
    [Action("Generate text with Amazon Titan", Description = "Generate text with Amazon Titan model or any " +
                                                             "custom model that is based on Amazon Titan model.")]
    public async Task<RunInferenceWithAmazonTitanResponse> RunInferenceWithAmazonTitan(
        [ActionParameter] RunInferenceWithAmazonTitanRequest input)
    {
        var requestBody = new
        {
            inputText = input.Prompt,
            textGenerationConfig = new
            {
                temperature = input.Temperature ?? 0,
                topP = input.TopP ?? 1,
                maxTokenCount = input.MaximumTokensNumber ?? 512,
                stopSequences = input.StopSequences ?? new string[] { }
            }
        };

        var response =
            await ExecuteRequestAsync<RunInferenceWithAmazonTitanResponseWrapper>(input.ModelArn, requestBody);
        return response.Results.First();
    }
    
    #endregion

    #region Image generation

    [Action("Generate image with Stability.ai Diffusion", Description = "Generate image with Stability.ai Diffusion model " +
                                                                        "or any custom model that is based on Stability.ai " +
                                                                        "Diffusion model.")]
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
        var fileName = (input.GeneratedImageFilename ?? "image") + ".png";

        var file = await _fileManagementClient.UploadAsync(new MemoryStream(bytes), MediaTypeNames.Image.Png, fileName);

        return new()
        {
            GeneratedImage = file
        };
    }

    [Action("Generate or edit image with Amazon Titan Image", 
        Description = "Generate or edit an image with the Amazon Titan Image model or any custom model based on " +
                      "it. If generating, leave 'Image' unspecified; for editing, specify the 'Image' parameter " +
                      "with the appropriate file.")]
    public async Task<RunInferenceWithAmazonTitanImageResponse> RunInferenceWithAmazonTitanImage(
        [ActionParameter] RunInferenceWithAmazonTitanImageRequest input)
    {
        async Task<string> GetBase64StringForImage()
        {
            await using var imageStream = await _fileManagementClient.DownloadAsync(input.Image);
            var imageBytes = await imageStream.GetByteData();
            return Convert.ToBase64String(imageBytes);
        }
        
        var height = 1024;
        var width = 1024;

        if (input.Size != null)
        {
            var parts = input.Size.Split('x');
            height = int.Parse(parts[0]);
            width = int.Parse(parts[1]);
        }

        var requestBody = new
        {
            taskType = input.Image == null ? "TEXT_IMAGE" : "IMAGE_VARIATION",
            textToImageParams = input.Image == null
                ? new 
                {
                    text = input.Prompt,
                    negativeText = input.NegativePrompt
                }
                : null,
            imageVariationParams = input.Image != null
                ? new
                {
                    text = input.Prompt,
                    negativeText = input.NegativePrompt,
                    images = new[] { await GetBase64StringForImage() }
                }
                : null,
            imageGenerationConfig = new
            {
                height,
                width,
                numberOfImages = 1,
                cfgScale = input.CfgScale ?? 8
            }
        };
        
        var response = await ExecuteRequestAsync<GeneratedImageWrapper>(input.ModelArn, requestBody);
        var generatedImageBytes = Convert.FromBase64String(response.Images.First());
        var fileName = (input.GeneratedImageFileName ?? "image") + ".png";

        await using var generatedImageStream = new MemoryStream(generatedImageBytes);
        var generatedImageFileReference =
            await _fileManagementClient.UploadAsync(generatedImageStream, MediaTypeNames.Image.Png, fileName);
        
        return new() { GeneratedImage = generatedImageFileReference };
    }

    #endregion
    
    #region Translation-related

    [Action("Perform an LQA analysis with Anthropic Claude", Description =
        "Perform an LQA analysis with Anthropic Claude " +
        "model.")]
    public async Task<PerformLQAAnalysisWithAnthropicClaudeResponse> PerformLQAAnalysisWithAnthropicClaude(
        [ActionParameter] PerformLQAAnalysisWithAnthropicClaudeRequest input)
    {
        var lqaPrompt =
            "You are an expert linguist and your task is to perform a Language Quality Assessment on input " +
            "sentences. Provide a quality rating for the original translation from 0 (completely bad) to 10 " +
            "(perfect). Perform an LQA analysis and use the MQM 2.0 format. For each issue found, specify the " +
            "category, description of the issue, and severity. \n\n" +
            $"{(input.SourceLanguage != null ? $"The {input.SourceLanguage} " : "")}\"{input.SourceText}\" " +
            $"was translated as \"{input.TargetText}\"{(input.TargetLanguage != null ? $" into {input.TargetLanguage}" : "")}." +
            $"\n\n{input.AdditionalPrompt}";

        var translationPrompt =
            "You are an expert linguist. You are provided with source (original) text" +
            $"{(input.SourceLanguage != null ? $" in {input.SourceLanguage}" : "")} and target (translated) text" +
            $"{(input.TargetLanguage != null ? $" in {input.TargetLanguage}" : "")}. Perform a Language Quality " +
            "Assessment on input texts and respond with a corrected target text that would have no Language Quality " +
            "Assessment errors (if there are any). Do not include any other information in the response. " +
            $"\n\nSource (original) text: \"{input.SourceText}\"\n\nTarget (translated) text: \"{input.TargetText}\"";

        var lqaRequestBody = new
        {
            prompt = $"\n\nHuman:{lqaPrompt}\n\nAssistant:",
            temperature = input.Temperature ?? 0.5,
            top_p = input.TopP ?? 1,
            top_k = input.TopK ?? 250,
            max_tokens_to_sample = input.MaximumTokensNumber ?? 4000,
            stop_sequences = input.StopSequences ?? new string[] { }
        };

        var lqaResponse = await ExecuteRequestAsync<RunInferenceWithAnthropicClaudeResponse>(input.ModelArn,
            lqaRequestBody);

        var translationRequestBody = new
        {
            prompt = $"\n\nHuman:{translationPrompt}\n\nAssistant:",
            temperature = input.Temperature ?? 0.5,
            top_p = input.TopP ?? 1,
            top_k = input.TopK ?? 250,
            max_tokens_to_sample = input.MaximumTokensNumber ?? 8000,
            stop_sequences = input.StopSequences ?? new string[] { }
        };

        var translationResponse = await ExecuteRequestAsync<RunInferenceWithAnthropicClaudeResponse>(input.ModelArn,
            translationRequestBody);

        return new()
        {
            LQAAnalysis = lqaResponse.Completion.Trim('"'),
            CorrectedTranslation = translationResponse.Completion.Trim('"')
        };
    }
    
    #endregion

    #region Embeddings

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

    #endregion

    private async Task<TResponse> ExecuteRequestAsync<TResponse>(string modelArn, object requestBody)
    {
        var jsonRequestBody = JsonConvert.SerializeObject(requestBody, new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        });

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