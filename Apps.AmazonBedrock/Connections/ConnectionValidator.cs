using Amazon.Bedrock.Model;
using Apps.AmazonBedrock.Factories;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;

namespace Apps.AmazonBedrock.Connections;

public class ConnectionValidator: IConnectionValidator
{
    public async ValueTask<ConnectionValidationResponse> ValidateConnection(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        CancellationToken cancellationToken)
    {
        var client = BedrockClientFactory.CreateBedrockClient(authenticationCredentialsProviders);

        try
        {
            await client.ListFoundationModelsAsync(new ListFoundationModelsRequest(), cancellationToken);
            return new ConnectionValidationResponse
            {
                IsValid = true,
                Message = "Success"
            };
        }
        catch (Exception)
        {
            return new ConnectionValidationResponse
            {
                IsValid = false,
                Message = "Invalid connection parameters"
            };
        }
    }
}