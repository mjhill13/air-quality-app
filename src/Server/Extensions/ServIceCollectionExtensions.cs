using AirQualityApp.Server.Domain;
using AirQualityApp.Server.Infrastructure.OpenAQ;

namespace AirQualityApp.Server.Extensions;

public static class ServIceCollectionExtensions
{
    public static void AddOpenAQ(this IServiceCollection services, ConfigurationManager configuration)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }
        
        services.AddScoped<IOpenAQClientFactory, OpenAQClientFactory>();

        var section = configuration.GetSection(nameof(OpenAQConfig));
        var config = section.Get<OpenAQConfig>();
        services.AddSingleton(config);
    }
}