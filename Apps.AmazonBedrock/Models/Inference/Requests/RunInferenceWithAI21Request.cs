using Apps.AmazonBedrock.DataSourceHandlers.FloatParameterHandlers;
using Apps.AmazonBedrock.DataSourceHandlers.ModelHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.AmazonBedrock.Models.Inference.Requests;

public class RunInferenceWithAI21Request
{
    [Display("Model")]
    [DataSource(typeof(AI21LabsJurassicModelDataSourceHandler))]
    public string ModelArn { get; set; }
    
    public string Prompt { get; set; }
    
    [DataSource(typeof(TemperatureDataSourceHandler))]
    public float? Temperature { get; set; }
    
    [Display("Top P")]
    [DataSource(typeof(TopPDataSourceHandler))]
    public float? TopP { get; set; }

    [Display("Maximum tokens number (from 0 to 8191)")]
    public int? MaximumTokensNumber { get; set; }
    
    [Display("Stop sequences")]
    public IEnumerable<string>? StopSequences { get; set; }
    
    [Display("Presence penalty")]
    [DataSource(typeof(PresencePenaltyDataSourceHandler))]
    public float? PresencePenalty { get; set; }
    
    [Display("Count penalty")]
    [DataSource(typeof(CountPenaltyDataSourceHandler))]
    public float? CountPenalty { get; set; }
    
    [Display("Frequency penalty (from 0 to 500)")]
    public int? FrequencyPenalty { get; set; }
}