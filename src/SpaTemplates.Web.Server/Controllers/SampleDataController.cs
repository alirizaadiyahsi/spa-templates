using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaTemplates.Application.WeatherForecasts;
using SpaTemplates.Domain;

namespace SpaTemplates.Web.Server.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly IWeatherForecastApplicationService _weatherForecastApplicationService;

        public SampleDataController(IWeatherForecastApplicationService weatherForecastApplicationService)
        {
            _weatherForecastApplicationService = weatherForecastApplicationService;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<WeatherForecast>> WeatherForecasts()
        {
            return await _weatherForecastApplicationService.GetAllAsync();
        }
    }
}