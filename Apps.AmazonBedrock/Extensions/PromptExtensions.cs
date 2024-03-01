namespace Apps.AmazonBedrock.Extensions;

public static class PromptExtensions
{
    public static (string SystemPrompt, string UserPrompt) FromBlackbirdPrompt(this string inputPrompt)
    {
        var promptSegments = inputPrompt.Split(";;");

        if (promptSegments.Length == 1)
            return new(string.Empty, promptSegments[0]);

        if (promptSegments.Length == 2 || promptSegments.Length == 3)
            return new(promptSegments[0], promptSegments[1]);

        throw new("Wrong blackbird prompt format");
    }
}