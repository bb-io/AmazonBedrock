using Amazon.Bedrock.Model;
using Blackbird.Applications.Sdk.Common;

namespace Apps.AmazonBedrock.Dtos;

public class FoundationModelDto
{
    public FoundationModelDto(FoundationModelSummary model)
    {
        ModelId = model.ModelId;
        ModelName = model.ModelName;
        ProviderName = model.ProviderName;
        CustomizationsSupported = model.CustomizationsSupported;
        InferenceTypesSupported = model.InferenceTypesSupported;
        InputModalities = model.InputModalities;
        OutputModalities = model.OutputModalities;
        ModelArn = model.ModelArn;
        ResponseStreamingSupported = model.ResponseStreamingSupported;
    }
    
    [Display("Model ID")]
    public string ModelId { get; set; }
    
    [Display("Model name")]
    public string ModelName { get; set; }
    
    [Display("Provider name")]
    public string ProviderName { get; set; }
    
    [Display("Customizations supported")]
    public IEnumerable<string> CustomizationsSupported { get; set; }
    
    [Display("Inference types supported")]
    public IEnumerable<string> InferenceTypesSupported { get; set; }
    
    [Display("Input modalities")]
    public IEnumerable<string> InputModalities { get; set; }
    
    [Display("Output modalities")]
    public IEnumerable<string> OutputModalities { get; set; }
    
    [Display("Model ARN")]
    public string ModelArn { get; set; }
    
    [Display("Response streaming supported")]
    public bool ResponseStreamingSupported { get; set; }
}