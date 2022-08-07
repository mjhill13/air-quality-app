namespace AirQualityApp.Server.Infrastructure.Model;

public record Response<T>(Metadata Meta, IEnumerable<T> Results);