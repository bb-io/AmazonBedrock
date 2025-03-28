using Apps.AmazonBedrock.Actions;
using Apps.AmazonBedrock.Models.Inference.Requests;
using Tests.AmazonBedrock.Base;

namespace Tests.AmazonBedrock
{
    [TestClass]
    public class InferenceTests : TestBase
    {
        [TestMethod]
        public async Task CreateProject_ReturnSucces()
        {
            var action = new InferenceActions(InvocationContext, FileManager);

            var input = new RunInferenceWithAnthropicClaudeRequest
            {
                ModelArn = "arn:aws:bedrock:us-east-1::foundation-model/anthropic.claude-3-haiku-20240307-v1:0:48k",
                Prompt= "Generate content in polish language"
            };

            var response = await action.RunInferenceWithAnthropicClaude(input);

            Console.WriteLine(response.Completion);
        }


    }
}
