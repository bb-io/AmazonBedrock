using Apps.AmazonBedrock.DataSourceHandlers.FloatParameterHandlers;
using Apps.AmazonBedrock.DataSourceHandlers.ModelHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.AmazonBedrock.Models.Inference.Requests;

public class RunInferenceWithStabilityAIDiffusionRequest
{
    [Display("Model")]
    [DataSource(typeof(StabilityAIDiffusionModelDataSourceHandler))]
    public string ModelArn { get; set; }
    
    public string Prompt { get; set; }
    
    [Display("Prompt strength")]
    [DataSource(typeof(PromptStrengthDataSourceHandler))]
    public float? PromptStrength { get; set; } 
    
    [Display("Generation steps (from 0 to 150)")]
    public int? GenerationSteps { get; set; }
    
    [Display("Generated image filename without extension")]
    public string? GeneratedImageFilename { get; set; }
}