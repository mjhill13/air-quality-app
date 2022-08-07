using AirQualityApp.Server.Domain;
using AirQualityApp.Server.Infrastructure.OpenAQ;
using AirQualityApp.Shared.Models;

namespace AirQualityApp.Server.Application.Queries;

public class GetCitiesQuery
{
    private readonly IOpenAQClient _client;
    private readonly string _countryCode;

    public GetCitiesQuery(IOpenAQClientFactory clientFactory, string countryCode)
    {
        _client = clientFactory.Create();
        _countryCode = countryCode;
    }

    public Task<IEnumerable<City>> RunAsync() => 
        _client.FetchCities(_countryCode);
}