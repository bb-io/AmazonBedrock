using Apps.AmazonBedrock.DataSourceHandlers.EnumHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.AmazonBedrock.Models.BaseModels.Requests;

public class ListFoundationModelsRequest
{
    [Display("Inference type")]
    [DataSource(typeof(InferenceTypeDataSourceHandler))]
    public string? InferenceType { get; set; }
    
    [Display("Output modality type")]
    [DataSource(typeof(OutputModalityTypeDataSourceHandler))]
    public string? OutputModalityType { get; set; }
    
    [DataSource(typeof(ProviderDataSourceHandler))]
    public string? Provider { get; set; }
}