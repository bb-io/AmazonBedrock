using Apps.AmazonBedrock.DataSourceHandlers.FloatParameterHandlers;
using Apps.AmazonBedrock.DataSourceHandlers.ModelHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.AmazonBedrock.Models.Inference.Requests;

public class RunInferenceWithAnthropicClaudeRequest
{
    [Display("Model")]
    [DataSource(typeof(AnthropicClaudeModelDataSourceHandler))]
    public string ModelArn { get; set; }
    
    public string Prompt { get; set; }
    
    [DataSource(typeof(TemperatureDataSourceHandler))]
    public float? Temperature { get; set; }
    
    [Display("Top P")]
    [DataSource(typeof(TopPDataSourceHandler))]
    public float? TopP { get; set; }
    
    [Display("Top K (from 0 to 500)")]
    public int? TopK { get; set; }
    
    [Display("Maximum tokens number (from 0 to 8000)")]
    public int? MaximumTokensNumber { get; set; }
    
    [Display("Stop sequences")]
    public IEnumerable<string>? StopSequences { get; set; }
}