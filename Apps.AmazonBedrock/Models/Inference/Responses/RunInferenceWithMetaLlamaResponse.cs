using Blackbird.Applications.Sdk.Common;

namespace Apps.AmazonBedrock.Models.Inference.Responses;

public class RunInferenceWithMetaLlamaResponse
{
    [Display("Generated text")]
    public string Generation { get; set; }
}