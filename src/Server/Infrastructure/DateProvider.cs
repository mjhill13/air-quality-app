using AirQualityApp.Shared;
using AirQualityApp.Shared.Abstractions;

namespace AirQualityApp.Server.Infrastructure;

public class DateProvider : IDateProvider
{
    public DateTime Today { get; } = DateTime.Today;
}