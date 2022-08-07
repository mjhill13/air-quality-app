using System.Web;
using AirQualityApp.Server.Domain;
using AirQualityApp.Server.Infrastructure.Model;
using AirQualityApp.Shared;
using AirQualityApp.Shared.Abstractions;
using AirQualityApp.Shared.Models;
using Flurl;
using Flurl.Http;
using Flurl.Util;

namespace AirQualityApp.Server.Infrastructure;

public class OpenAQClient : HttpClientBase, IOpenAQClient
{
    private readonly IDateProvider _dateProvider;
    private const string BaseUrl = "https://api.openaq.org";

    public OpenAQClient(IDateProvider dateProvider)
    {
        _dateProvider = dateProvider;
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

    public async Task<IEnumerable<Measurement>> FetchMeasurements(string city)
    {
        var response = await Run(() => BaseUrl
            .AppendPathSegment("/v2/measurements")
            .SetQueryParams(new PagingParams("datetime", 100, 1, 0, SortOrder.Desc))
            .SetQueryParam("date_from", _dateProvider.Today.AddDays(-30).ToInvariantString())
            .SetQueryParam("city", HttpUtility.UrlEncode(city))
            .SetQueryParam("radius", 1000)
            .GetAsync()
            .ReceiveJson<Response<Measurement>>());

        return response.Results.Select(x => new Measurement(x.Id, x.Location));
    }
}