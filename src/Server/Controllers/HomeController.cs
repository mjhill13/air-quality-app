using System.ComponentModel.DataAnnotations;
using AirQualityApp.Server.Application.Queries;
using AirQualityApp.Server.Domain;
using AirQualityApp.Server.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace AirQualityApp.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController  : ControllerBase
{
    private readonly IOpenAQClientFactory _clientFactory;

    public HomeController(IOpenAQClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    
    [HttpGet("Countries")]
    public async Task<IActionResult> GetCountries()
    {
        var countries = await new GetCountriesQuery(_clientFactory).RunAsync();
        return new OkObjectResult(countries);
    }
    
    [HttpGet("Cities")]
    public async Task<IActionResult> GetCities([FromQuery, MinLength(1)] string countryCode)
    {
        var cities = await new GetCitiesQuery(_clientFactory, countryCode).RunAsync();
        return new OkObjectResult(cities);
    }
    
    [HttpGet("Measurements")]
    public async Task<IActionResult> GetMeasurements([FromQuery, MinLength(1)] string cityName, [FromQuery] string order = "datetime", [FromQuery] SortOrder sort = SortOrder.Asc)
    {
        var measurements = await new GetMeasurementsQuery(_clientFactory, cityName, 
            new PagingParams(OrderBy: order, Sort: sort)).RunAsync();
        return new OkObjectResult(measurements);
    }
}