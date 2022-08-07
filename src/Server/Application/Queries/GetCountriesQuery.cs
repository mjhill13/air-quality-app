using AirQualityApp.Server.Domain;
using AirQualityApp.Server.Infrastructure.OpenAQ;
using AirQualityApp.Shared.Models;

namespace AirQualityApp.Server.Application.Queries;

public class GetCountriesQuery
{
    private readonly IOpenAQClient _client;

    public GetCountriesQuery(IOpenAQClientFactory clientFactory)
    {
        _client = clientFactory.Create();
    }

    public Task<IEnumerable<Country>> RunAsync() => 
        _client.FetchAllCountries();
}