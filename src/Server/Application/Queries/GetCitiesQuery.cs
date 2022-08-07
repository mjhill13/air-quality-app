using AirQualityApp.Server.Domain;
using AirQualityApp.Shared.Models;

namespace AirQualityApp.Server.Application.Queries;

public class GetCitiesQuery
{
    private readonly IOpenAQClient _openAqClient;
    private readonly string _countryCode;

    public GetCitiesQuery(IOpenAQClient openAqClient, string countryCode)
    {
        _openAqClient = openAqClient;
        _countryCode = countryCode;
    }

    public Task<IEnumerable<City>> RunAsync() => 
        _openAqClient.FetchCities(_countryCode);
}