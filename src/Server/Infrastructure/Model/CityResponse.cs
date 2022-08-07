namespace AirQualityApp.Server.Infrastructure.Model;

// 'Model' suffix for ease because there is a property 'City' and records cannot share property names with record name
public record CityResponse(string Country, string City, int Count, int Locations, DateTimeOffset FirstUpdated, DateTimeOffset LastUpdated, string[] Parameters);