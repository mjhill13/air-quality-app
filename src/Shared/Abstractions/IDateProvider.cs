namespace AirQualityApp.Shared.Abstractions;

public interface IDateProvider
{
    DateTime Today { get; }
}