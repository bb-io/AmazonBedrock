using Blackbird.Applications.Sdk.Common;

namespace Apps.AmazonBedrock.Models.Inference.Responses;

public class RunInferenceWithCohereResponse
{
    [Display("Generated text")]
    public string Text { get; set; }
}

public class RunInferenceWithCohereResponseWrapper
{
    public IEnumerable<RunInferenceWithCohereResponse> Generations { get; set; }
}