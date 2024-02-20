using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.AmazonBedrock.Models.Inference.Responses;

public class RunInferenceWithStabilityAIDiffusionResponse
{
    [Display("Generated image")]
    public FileReference GeneratedImage { get; set; }
}

public class ImageBytesWrapper 
{
    public IEnumerable<ImageArtifact> Artifacts { get; set; }
}

public class ImageArtifact
{
    public byte[] Base64 { get; set; }
}