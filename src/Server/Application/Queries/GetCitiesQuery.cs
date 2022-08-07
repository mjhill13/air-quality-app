using AirQualityApp.Server.Domain;
using AirQualityApp.Shared.Models;

namespace AirQualityApp.Server.Application.Queries;

public class GetCitiesQuery
{
    private readonly IOpenAQClient _openAqClient;

    public GetCitiesQuery(IOpenAQClient openAqClient)
    {
        _openAqClient = openAqClient;
    }

    public Task<IEnumerable<City>> RunAsync() => 
        _openAqClient.FetchCities();
}