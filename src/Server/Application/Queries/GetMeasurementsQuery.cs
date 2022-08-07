using AirQualityApp.Server.Domain;
using AirQualityApp.Server.Domain.Shared;
using AirQualityApp.Shared.Models;

namespace AirQualityApp.Server.Application.Queries;

public class GetMeasurementsQuery
{
    private readonly IOpenAQClient _openAqClient;
    private readonly string _cityName;
    private readonly PagingParams _paging;

    public GetMeasurementsQuery(IOpenAQClient openAqClient, string cityName, PagingParams paging)
    {
        _openAqClient = openAqClient;
        _cityName = cityName;
        _paging = paging;
    }

    public Task<IEnumerable<Measurement>> RunAsync() => 
        _openAqClient.FetchMeasurements(_cityName, _paging);
}