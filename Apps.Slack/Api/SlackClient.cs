using Apps.Slack.Constants;
using Apps.Slack.Models.Responses;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.Slack.Api;

public class SlackClient : RestClient
{
    private readonly Dictionary<string, string> ErrorMessages = new()
    {
        { "no_reaction", "The specified reaction does not exist, or the requestor is not the original reaction author." }
    };
    
    public SlackClient() : base(new RestClientOptions()
    {
        BaseUrl = new(Urls.Api)
    })
    {
    }

    public async Task<RestResponse> ExecuteWithErrorHandling(RestRequest request)
    {
        var response = await ExecuteAsync(request);
        var genericResponse = JsonConvert.DeserializeObject<GenericResponse>(response.Content!);

        if (!string.IsNullOrEmpty(genericResponse?.Error))
        {
            if(ErrorMessages.TryGetValue(genericResponse.Error, out var message))
            {
                throw new Exception(message);
            }
            
            throw new Exception($"Error: {genericResponse.Error}");
        }

        return response;
    }

    public async Task<T> ExecuteWithErrorHandling<T>(RestRequest request)
    {
        var response = await ExecuteWithErrorHandling(request);
        return JsonConvert.DeserializeObject<T>(response.Content!, JsonConfig.Settings)!;
    }

    public async Task<List<T>> Paginate<TV, T>(RestRequest request) where TV : PaginationResponse<T>
    {
        var result = new List<T>();

        string? cursor = null;

        do
        {
            request.AddQueryParameter("limit", 999);   
            if (cursor is not null)
            {
                request.AddQueryParameter("cursor", cursor);
                Thread.Sleep(1000);
            }                          
            var response = await ExecuteWithErrorHandling<TV>(request);
            result.AddRange(response.Items);
            cursor = response.ResponseMetadata?.NextCursor;
            
        } while (!string.IsNullOrWhiteSpace(cursor));

        return result;
    }
}