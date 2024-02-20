using Blackbird.Applications.Sdk.Common;

namespace Apps.AmazonBedrock.Models.Inference.Responses;

public class RunInferenceWithAmazonTitanResponse
{
    [Display("Generated text")]
    public string OutputText { get; set; }
}

public class RunInferenceWithAmazonTitanResponseWrapper
{
    public IEnumerable<RunInferenceWithAmazonTitanResponse> Results { get; set; }
}