using Apps.AmazonBedrock.Dtos;
using Blackbird.Applications.Sdk.Common;

namespace Apps.AmazonBedrock.Models.BaseModels.Responses;

public class ListFoundationModelsResponse
{
    [Display("Foundation models")]
    public IEnumerable<FoundationModelDto> FoundationModels { get; set; }
}