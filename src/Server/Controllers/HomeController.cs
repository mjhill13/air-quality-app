using System.ComponentModel.DataAnnotations;
using AirQualityApp.Server.Application.Queries;
using AirQualityApp.Server.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AirQualityApp.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController  : ControllerBase
{
    private readonly IOpenAQClient _openAqClient;

    public HomeController(IOpenAQClient openAqClient)
    {
        _openAqClient = openAqClient;
    }
    
    [HttpGet("Countries")]
    public async Task<IActionResult> GetCountries()
    {
        var countries = await new GetCountriesQuery(_openAqClient).RunAsync();
        return new OkObjectResult(countries);
    }
    
    [HttpGet("Cities")]
    public async Task<IActionResult> GetCities()
    {
        var cities = await new GetCitiesQuery(_openAqClient).RunAsync();
        return new OkObjectResult(cities);
    }
    
    [HttpGet("Measurements")]
    public async Task<IActionResult> GetMeasurements([FromQuery, MinLength(1)]string cityName)
    {
        var measurements = await new GetMeasurementsQuery(_openAqClient, cityName).RunAsync();
        return new OkObjectResult(measurements);
    }
}