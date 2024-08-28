using Apps.Slack.Constants;
using Apps.Slack.Models.Responses;
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
        { "no_reaction", "The specified reaction does not exist, or the requestor is not the original reaction author." }
    };

    public async Task<RestResponse> ExecuteWithErrorHandling(RestRequest request, CancellationToken token = default)
    {
        var response = await ExecuteAsync(request, token);
        if (!string.IsNullOrEmpty(response.ErrorMessage))
        {
            throw new Exception(response.ErrorMessage);
        }
            
        try
        {
            var genericResponse = JsonConvert.DeserializeObject<GenericResponse>(response.Content!);
            if (!string.IsNullOrEmpty(genericResponse?.Error))
            {
                if (_errorMessages.TryGetValue(genericResponse.Error, out var message))
                {
                    throw new Exception(message);
                }

                throw new Exception($"Error: {genericResponse.Error}");
            }

            return response;
        }
        catch (Exception e)
        {
            throw new Exception($"Error: {response.Content}, Message: {e.Message}");
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
}