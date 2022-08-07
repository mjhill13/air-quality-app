using AirQualityApp.Server.Domain;
using AirQualityApp.Shared.Abstractions;

namespace AirQualityApp.Server.Infrastructure.OpenAQ;

public class OpenAQClientFactory : IOpenAQClientFactory
{
    private readonly IServiceProvider _serviceProvider;

    public OpenAQClientFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public OpenAQClient Create()
    {
        var dateProvider = _serviceProvider.GetRequiredService<IDateProvider>();
        return new OpenAQClient(dateProvider);
    }
}