namespace AirQualityApp.Server.Infrastructure.Model;

public abstract record Response<T>(Metadata Meta, IEnumerable<T> Results);