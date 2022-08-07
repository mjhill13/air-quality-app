namespace AirQualityApp.Server.Infrastructure.OpenAQ.Model;

public record MeasurementResponse(int LocationId, string Location, string Parameter, double Value, string Unit, Coordinates Coordinates, string Country, string City, bool IsMobile, bool IsAnalysis, string Entity, string SensorType);