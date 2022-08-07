using AirQualityApp.Server.Domain;
using AirQualityApp.Server.Domain.Shared;
using AirQualityApp.Server.Infrastructure.OpenAQ;
using AirQualityApp.Shared.Models;

namespace AirQualityApp.Server.Application.Queries;

public class GetMeasurementsQuery
{
    private readonly IOpenAQClient _client;
    private readonly string _cityName;
    private readonly PagingParams _paging;

    public GetMeasurementsQuery(IOpenAQClientFactory clientFactory, string cityName, PagingParams paging)
    {
        _client = clientFactory.Create();
        _cityName = cityName;
        _paging = paging;
    }

    public Task<IEnumerable<Measurement>> RunAsync() => 
        _client.FetchMeasurements(_cityName, _paging);
}