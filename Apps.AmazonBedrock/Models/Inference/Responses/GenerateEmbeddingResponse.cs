namespace Apps.AmazonBedrock.Models.Inference.Responses;

public class GenerateEmbeddingResponse
{
    public IEnumerable<float> Embedding { get; set; }
}