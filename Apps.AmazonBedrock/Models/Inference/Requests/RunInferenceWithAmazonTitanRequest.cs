using Apps.AmazonBedrock.DataSourceHandlers.FloatParameterHandlers;
using Apps.AmazonBedrock.DataSourceHandlers.ModelHandlers;
using Apps.AmazonBedrock.Models.Inference.Requests.Base;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.AmazonBedrock.Models.Inference.Requests;

public class RunInferenceWithAmazonTitanRequest : RunInferenceBase
{
    [Display("Model")]
    [DataSource(typeof(AmazonTitanTextModelDataSourceHandler))]
    public string ModelArn { get; set; }
    
    [DataSource(typeof(TemperatureDataSourceHandler))]
    public float? Temperature { get; set; }
    
    [Display("Top P")]
    [DataSource(typeof(TopPDataSourceHandler))]
    public float? TopP { get; set; }
    
    [Display("Maximum tokens number (from 0 to 8000)")]
    public int? MaximumTokensNumber { get; set; }
    
    [Display("Stop sequences")]
    public IEnumerable<string>? StopSequences { get; set; }
}