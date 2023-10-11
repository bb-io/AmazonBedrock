using Amazon;
using Amazon.Bedrock;
using Amazon.BedrockRuntime;
using Blackbird.Applications.Sdk.Common.Authentication;

namespace Apps.AmazonBedrock.Factories;

public static class BedrockClientFactory
{
    public static AmazonBedrockClient CreateBedrockClient(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
    {
        var key = authenticationCredentialsProviders.First(p => p.KeyName == "Access key");
        var secret = authenticationCredentialsProviders.First(p => p.KeyName == "Access secret");

        return new(key.Value, secret.Value, new AmazonBedrockConfig
        {
            RegionEndpoint = RegionEndpoint.USWest2
        });
    }
    
    public static AmazonBedrockRuntimeClient CreateBedrockRuntimeClient(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
    {
        var key = authenticationCredentialsProviders.First(p => p.KeyName == "Access key");
        var secret = authenticationCredentialsProviders.First(p => p.KeyName == "Access secret");
        
        return new(key.Value, secret.Value, new AmazonBedrockRuntimeConfig
        {
            RegionEndpoint = RegionEndpoint.USWest2
        });
    }
}