using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.AmazonBedrock.DataSourceHandlers.EnumHandlers;

public class ImageSizeDataSourceHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        { "1024x1024", "1024 x 1024" },
        { "768x768", "768 x 768" },
        { "512x512", "512 x 512" },
        { "768x1152", "768 x 1152" },
        { "384x576", "384 x 576" },
        { "1152x768", "1152 x 768" },
        { "576x384", "576 x 384" },
        { "768x1280", "768 x 1280" },
        { "384x640", "384 x 640" },
        { "1280x768", "1280 x 768" },
        { "640x384", "640 x 384" },
        { "896x1152", "896 x 1152" },
        { "448x576", "448 x 576" },
        { "1152x896", "1152 x 896" },
        { "576x448", "576 x 448" },
        { "768x1408", "768 x 1408" },
        { "384x704", "384 x 704" },
        { "1408x768", "1408 x 768" },
        { "704x384", "704 x 384" },
        { "640x1408", "640 x 1408" },
        { "320x704", "320 x 704" },
        { "1408x640", "1408 x 640" },
        { "704x320", "704 x 320" },
        { "1152x640", "1152 x 640" },
        { "1173x640", "1173 x 640" }
    };
}