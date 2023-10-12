using Apps.AmazonBedrock.DataSourceHandlers.ModelHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.AmazonBedrock.Models.Inference.Requests;

public class GenerateEmbeddingRequest
{
    [Display("Model")]
    [DataSource(typeof(EmbeddingModelDataSourceHandler))]
    public string ModelArn { get; set; }
    
    public string Text { get; set; }
}