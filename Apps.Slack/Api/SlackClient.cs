using Apps.Slack.Constants;
using Apps.Slack.Models.Responses;
using Blackbird.Applications.Sdk.Common.Exceptions;
using HtmlAgilityPack;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.Slack.Api;

public class SlackClient() : RestClient(new RestClientOptions()
{
    BaseUrl = new(Urls.Api),
    MaxTimeout = 50000
})
{
    private readonly Dictionary<string, string> _errorMessages = new()
    {
        { "no_reaction", "The specified reaction does not exist, or the requestor is not the original reaction author." },
        { "thread_not_found", "The value entered at 'Timestamp' is incorrect." },
        { "time_in_past", "The scheduled time is in the past. Please update the scheduled time for this message." },
        { "not_in_channel", "Check the integrations, ensure that your integrations are added to the channel" }
    };  
    
    public async Task<RestResponse> ExecuteWithErrorHandling(RestRequest request, CancellationToken token = default)
    {
        var response = await ExecuteAsync(request, token);

        if (!string.IsNullOrEmpty(response.ErrorMessage))
        {
            throw new PluginApplicationException(response.ErrorMessage);
        }

        try
        {
            var genericResponse = JsonConvert.DeserializeObject<GenericResponse>(response.Content!);
            HandleGenericResponseErrors(genericResponse);
            return response;
        }
        catch (JsonException)
        {
            throw HandleHtmlResponseError(response);
        }
    }
    
    public async Task<T> ExecuteWithErrorHandling<T>(RestRequest request, CancellationToken token = default)
    {
        var response = await ExecuteWithErrorHandling(request, token);
        return JsonConvert.DeserializeObject<T>(response.Content!, JsonConfig.Settings)!;
    }

    public async Task<List<T>> Paginate<TV, T>(RestRequest request, CancellationToken token) where TV : PaginationResponse<T>
    {
        var result = new List<T>();

        string? cursor = null;

        do
        {
            request.AddQueryParameter("limit", 999);   
            if (cursor is not null)
            {
                request.AddQueryParameter("cursor", cursor);
                await Task.Delay(3000, token);
            }                          
            var response = await ExecuteWithErrorHandling<TV>(request, token);
            result.AddRange(response.Items);
            cursor = response.ResponseMetadata?.NextCursor;
            
        } while (!string.IsNullOrWhiteSpace(cursor));

        return result;
    }
    
    private void HandleGenericResponseErrors(GenericResponse? genericResponse)
    {
        if (genericResponse == null || string.IsNullOrEmpty(genericResponse.Error))
        {
            return;
        }

        if (_errorMessages.TryGetValue(genericResponse.Error, out var message))
        {
            throw new PluginMisconfigurationException (message);
        }

        throw new PluginApplicationException($"Error: {genericResponse.Error}");
    }

    private Exception HandleHtmlResponseError(RestResponse response)
    {
        try
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(response.Content);

            var issue = ExtractIssueFromHtml(htmlDoc) ?? "Unknown issue";
            return new PluginApplicationException ($"{issue}. Status Code: {response.StatusCode}");
        }
        catch
        {
            return new Exception($"Failed to parse response. Status Code: {response.StatusCode}, Content: {response.Content}");
        }
    }

    private string? ExtractIssueFromHtml(HtmlDocument htmlDoc)
    {
        var titleNode = htmlDoc.DocumentNode.SelectSingleNode("//title");
        var h1Node = htmlDoc.DocumentNode.SelectSingleNode("//h1");
        var pNode = htmlDoc.DocumentNode.SelectSingleNode("//p");

        return titleNode?.InnerText ?? h1Node?.InnerText ?? pNode?.InnerText;
    }
}