using Blackbird.Applications.Sdk.Common;

namespace Apps.AmazonBedrock.Models.Inference.Responses;

public class RunInferenceWithAnthropicClaudeResponse
{
    [Display("Generated text")]
    public string Completion { get; set; }
}