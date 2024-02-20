using Apps.AmazonBedrock.DataSourceHandlers.EnumHandlers;
using Apps.AmazonBedrock.DataSourceHandlers.FloatParameterHandlers;
using Apps.AmazonBedrock.DataSourceHandlers.ModelHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.AmazonBedrock.Models.Inference.Requests;

public class RunInferenceWithAmazonTitanImageRequest
{
    [Display("Model")]
    [DataSource(typeof(AmazonTitanImageModelDataSourceHandler))]
    public string ModelArn { get; set; }
    
    [Display("Prompt", Description = "A text prompt to generate the image.")]
    public string Prompt { get; set; }
    
    [Display("Negative prompt", Description = "A text prompt to define what not to include in the image. Avoid " +
                                              "using negative words. For instance, if you prefer not to " +
                                              "include mirrors in an image, simply enter 'mirrors' instead " +
                                              "of using 'no mirrors'.")]
    public string? NegativePrompt { get; set; }
    
    [Display("Image", Description = "Image for which to generate variation.")]
    public FileReference? Image { get; set; }
    
    [DataSource(typeof(ImageSizeDataSourceHandler))]
    public string? Size { get; set; } 
    
    [Display("Configuration scale", Description = "Specifies how strongly the generated image should adhere to " +
                                                  "the prompt. Use a lower value to introduce more randomness " +
                                                  "in the generation.")]
    [DataSource(typeof(CfgScaleDataSourceHandler))]
    public float? CfgScale { get; set; }
    
    [Display("Generated image file name", Description = "Generated image file name without an extension.")]
    public string? GeneratedImageFileName { get; set; }
}