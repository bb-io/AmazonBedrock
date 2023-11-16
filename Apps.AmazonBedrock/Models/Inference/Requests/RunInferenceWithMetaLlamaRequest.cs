using Apps.AmazonBedrock.DataSourceHandlers.FloatParameterHandlers;
using Apps.AmazonBedrock.DataSourceHandlers.ModelHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.AmazonBedrock.Models.Inference.Requests;

public class RunInferenceWithMetaLlamaRequest
{
    [Display("Model")]
    [DataSource(typeof(MetaLlamaModelDataSourceHandler))]
    public string ModelArn { get; set; }
    
    public string Prompt { get; set; }

    [DataSource(typeof(TemperatureDataSourceHandler))]
    public float? Temperature { get; set; }
    
    [Display("Top P")]
    [DataSource(typeof(TopPDataSourceHandler))]
    public float? TopP { get; set; }
    
    [Display("Maximum tokens number (from 0 to 2048)")]
    public int? MaximumTokensNumber { get; set; }
}