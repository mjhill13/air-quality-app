using AirQualityApp.Server.Infrastructure.Model;
using Flurl.Http;

namespace AirQualityApp.Server.Infrastructure;

public abstract class HttpClientBase
{
    protected async Task<Response<T>> Run<T>(Func<Task<Response<T>>> func)
    {
        try
        {
            return await func();
        }
        catch (FlurlHttpException ex)
        {
            var msg = await ex.GetResponseStringAsync();

            if (string.IsNullOrWhiteSpace(msg))
                msg = ex.Message;
            
            Console.WriteLine(msg);
            
            throw;
        }
    }
}