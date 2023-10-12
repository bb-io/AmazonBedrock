using Blackbird.Applications.Sdk.Common;

namespace Apps.AmazonBedrock.Models.Inference.Responses;

public class RunInferenceWithAI21Response
{
    [Display("Generated text")]
    public string Text { get; set; }
}

public class RunInferenceWithAI21ResponseWrapper
{
    public class DataWrapper
    {
        public RunInferenceWithAI21Response Data { get; set; }
    }
    
    public IEnumerable<DataWrapper> Completions { get; set; }
}