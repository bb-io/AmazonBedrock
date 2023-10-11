using Apps.AmazonBedrock.DataSourceHandlers.FloatParameterHandlers;
using Apps.AmazonBedrock.DataSourceHandlers.ModelHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.AmazonBedrock.Models.Inference.Requests;

public class RunInferenceWithCohereRequest
{
    [Display("Model")]
    [DataSource(typeof(CohereModelDataSourceHandler))]
    public string ModelId { get; set; }
    
    public string Prompt { get; set; }
    
    [DataSource(typeof(CohereTemperatureDataSourceHandler))]
    public float? Temperature { get; set; }
    
    [Display("Top P")]
    [DataSource(typeof(TopPDataSourceHandler))]
    public float? TopP { get; set; }
    
    [Display("Top K")]
    [DataSource(typeof(TopKDataSourceHandler))]
    public float? TopK { get; set; }
    
    [Display("Max token count (from 0 to 4096)")]
    public int? MaxTokenCount { get; set; }
    
    [Display("Stop sequences")]
    public IEnumerable<string>? StopSequences { get; set; }
}