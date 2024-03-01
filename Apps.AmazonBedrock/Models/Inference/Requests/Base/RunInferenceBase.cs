using Blackbird.Applications.Sdk.Common;

namespace Apps.AmazonBedrock.Models.Inference.Requests.Base;

public class RunInferenceBase
{
    public string Prompt { get; set; }
    
    [Display("Is Blackbird prompt", Description = "Parameter indicating whether the input prompt is the output " +
                                                  "of one of the AI Utilities app's actions; defaults to 'False'.")]
    public bool? IsBlackbirdPrompt { get; set; }
}