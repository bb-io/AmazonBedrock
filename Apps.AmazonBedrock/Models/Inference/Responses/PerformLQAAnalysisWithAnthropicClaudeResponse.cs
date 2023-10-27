using Blackbird.Applications.Sdk.Common;

namespace Apps.AmazonBedrock.Models.Inference.Responses;

public class PerformLQAAnalysisWithAnthropicClaudeResponse
{
    [Display("LQA analysis")]
    public string LQAAnalysis { get; set; }
    
    [Display("Corrected translation")]
    public string CorrectedTranslation { get; set; }
}