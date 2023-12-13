﻿using Apps.Slack.Constants;
using Apps.Slack.Models.Responses;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.Slack.Api;

public class SlackClient : RestClient
{
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
            throw new Exception($"Error: {genericResponse.Error}");

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
        var baseUrl = request.Resource;

        do
        {
            if (cursor is not null)
                request.Resource = baseUrl.SetQueryParameter("cursor", cursor);

            var response = await ExecuteWithErrorHandling<TV>(request);
            result.AddRange(response.Items);
            cursor = response.ResponseMetadata?.NextCursor;
        } while (!string.IsNullOrWhiteSpace(cursor));

        return result;
    }
}