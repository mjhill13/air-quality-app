using AirQualityApp.Shared.Models;

namespace AirQualityApp.Server.Domain;

public interface IOpenAQClient
{
    Task<IEnumerable<City>> FetchCities(string? countryCode = null);
    Task<IEnumerable<Country>> FetchAllCountries();
    Task<IEnumerable<Measurement>> FetchMeasurements(string city);
}