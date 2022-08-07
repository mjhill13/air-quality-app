using AirQualityApp.Server.Domain;
using AirQualityApp.Shared.Models;

namespace AirQualityApp.Server.Application.Queries;

public class GetCountriesQuery
{
    private readonly IOpenAQClient _openAqClient;

    public GetCountriesQuery(IOpenAQClient openAqClient)
    {
        _openAqClient = openAqClient;
    }

    public Task<IEnumerable<Country>> RunAsync() => 
        _openAqClient.FetchAllCountries();
}