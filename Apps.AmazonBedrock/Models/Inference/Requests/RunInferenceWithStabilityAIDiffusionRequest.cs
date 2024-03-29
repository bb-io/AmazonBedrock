﻿using Apps.AmazonBedrock.DataSourceHandlers.FloatParameterHandlers;
using Apps.AmazonBedrock.DataSourceHandlers.ModelHandlers;
using Apps.AmazonBedrock.Models.Inference.Requests.Base;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.AmazonBedrock.Models.Inference.Requests;

public class RunInferenceWithStabilityAIDiffusionRequest : RunInferenceBase
{
    [Display("Model")]
    [DataSource(typeof(StabilityAIDiffusionModelDataSourceHandler))]
    public string ModelArn { get; set; }
    
    [Display("Prompt strength")]
    [DataSource(typeof(PromptStrengthDataSourceHandler))]
    public float? PromptStrength { get; set; } 
    
    [Display("Generation steps (from 0 to 150)")]
    public int? GenerationSteps { get; set; }
    
    [Display("Generated image file name", Description = "Generated image file name without an extension.")]
    public string? GeneratedImageFilename { get; set; }
}