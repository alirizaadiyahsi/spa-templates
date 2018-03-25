using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpaTemplates.Application.WeatherForecasts;
using SpaTemplates.Web.Server.AppConsts;

namespace SpaTemplates.Web.Server.Controllers
{
    //[Authorize(Policy = SpaTemplatesPolicies.ApiUser)]
    [Authorize]
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly IWeatherForecastApplicationService _weatherForecastApplicationService;

        public SampleDataController(IWeatherForecastApplicationService weatherForecastApplicationService)
        {
            _weatherForecastApplicationService = weatherForecastApplicationService;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<WeatherForecastDto>> WeatherForecasts()
        {
            return await _weatherForecastApplicationService.GetAllAsync();
        }
    }
}