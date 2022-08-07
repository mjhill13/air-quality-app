using System.Web;
using AirQualityApp.Server.Domain.Shared;
using AirQualityApp.Server.Infrastructure.OpenAQ.Model;
using AirQualityApp.Shared.Abstractions;
using AirQualityApp.Shared.Models;
using Flurl;
using Flurl.Http;
using Flurl.Util;

namespace AirQualityApp.Server.Infrastructure.OpenAQ;

public class OpenAQClient : HttpClientBase, IOpenAQClient
{
    private readonly IDateProvider _dateProvider;
    private readonly OpenAQConfig _config;
    private const string BaseUrl = "https://api.openaq.org";

    public OpenAQClient(IDateProvider dateProvider, OpenAQConfig config)
    {
        _dateProvider = dateProvider;
        _config = config;
    }
    
    public async Task<IEnumerable<Country>> FetchAllCountries()
    {
        var response = await Run(() => BaseUrl
            .AppendPathSegment("/v2/countries")
            .SetQueryParams(new PagingParams(Limit: Int32.MaxValue, OrderBy: "name"))
            .GetAsync()
            .ReceiveJson<Response<Country>>());

        return response.Results.Select(x => new Country(x.Name, x.Code));
    }

    public async Task<IEnumerable<City>> FetchCities(string? countryCode = null)
    {
        var response = await Run(() => BaseUrl
            .AppendPathSegment("/v2/cities")
            .SetQueryParams(new PagingParams(OrderBy: "city").AsQueryParams)
            .SetQueryParam("country_id", countryCode)
            .GetAsync()
            .ReceiveJson<Response<CityResponse>>());

        return response.Results.Select(x => new City(x.City));
    }

    public async Task<IEnumerable<Measurement>> FetchMeasurements(string city, PagingParams paging)
    {
        Console.WriteLine(_config.MeasurementRadius);
        Console.WriteLine(_config.MaxDays);
        var response = await Run(() => BaseUrl
            .AppendPathSegment("/v2/measurements")
            .SetQueryParams(paging.AsQueryParams)
            .SetQueryParam("date_from", _dateProvider.Today.AddDays(_config.MaxDays * -1).ToInvariantString())
            .SetQueryParam("city", HttpUtility.UrlEncode(city))
            .SetQueryParam("radius", _config.MeasurementRadius)
            .GetAsync()
            .ReceiveJson<Response<MeasurementResponse>>());

        return response.Results.Select(x => new Measurement(x.LocationId, x.Location, x.Value, x.Unit));
    }
}