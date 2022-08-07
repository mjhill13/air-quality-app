using AirQualityApp.Server.Infrastructure.OpenAQ;

namespace AirQualityApp.Server.Domain;

public interface IOpenAQClientFactory
{
    OpenAQClient Create();
}