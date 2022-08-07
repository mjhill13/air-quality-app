namespace AirQualityApp.Server.Infrastructure.OpenAQ.Model;

public record Response<T>(Metadata Meta, IEnumerable<T> Results);