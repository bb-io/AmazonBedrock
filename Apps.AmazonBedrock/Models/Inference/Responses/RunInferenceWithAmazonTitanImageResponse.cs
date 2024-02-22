using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.AmazonBedrock.Models.Inference.Responses;

public class RunInferenceWithAmazonTitanImageResponse
{
    [Display("Generated image")]
    public FileReference GeneratedImage { get; set; }
}

public class GeneratedImageWrapper
{
    public IEnumerable<string> Images { get; set; }
}