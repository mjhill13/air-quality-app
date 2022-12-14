using AirQualityApp.Server.Domain.Shared;
using AirQualityApp.Shared.Models;

namespace AirQualityApp.Server.Infrastructure.OpenAQ;

public interface IOpenAQClient
{
    Task<IEnumerable<City>> FetchCities(string? countryCode = null);
    Task<IEnumerable<Country>> FetchAllCountries();
    Task<IEnumerable<Measurement>> FetchMeasurements(string city, PagingParams paging);
}