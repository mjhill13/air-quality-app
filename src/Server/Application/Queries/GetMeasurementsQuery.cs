using AirQualityApp.Server.Domain;
using AirQualityApp.Shared.Models;

namespace AirQualityApp.Server.Application.Queries;

public class GetMeasurementsQuery
{
    private readonly IOpenAQClient _openAqClient;
    private readonly string _cityName;

    public GetMeasurementsQuery(IOpenAQClient openAqClient, string cityName)
    {
        _openAqClient = openAqClient;
        _cityName = cityName;
    }

    public Task<IEnumerable<Measurement>> RunAsync() => 
        _openAqClient.FetchMeasurements(_cityName);
}