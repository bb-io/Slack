namespace Blackbird.Applications.SDK.Blueprints
{    
    public enum BlueprintEvent
    {
        // Example of usage
        // [BlueprintItemDefinition("pathToIcon", "example description")]
        // Example
        [BlueprintItemDefinition("pathToWebhookIcon", "test webhook event", DefaultCategory = "test webhook event default category")]
        TestWebhookEvent,
        [BlueprintItemDefinition("pathToPollingIcon", "test polling event", DefaultCategory = "test polling event default category")]
        TestPollingEvent
    }
}
