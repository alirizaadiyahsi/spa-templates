using System.Collections.Generic;
using System.Threading.Tasks;
using SpaTemplates.Domain;
using SpaTemplates.EntityFrameworkCore;

namespace SpaTemplates.Application.WeatherForecasts
{
    public class WeatherForecastApplicationService : IWeatherForecastApplicationService
    {
        private readonly IRepository<WeatherForecast> _weatherForecastRepository;

        public WeatherForecastApplicationService(IRepository<WeatherForecast> weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }
        //todo: return dto instead of entity
        public async Task<List<WeatherForecast>> GetAllAsync()
        {
            return await _weatherForecastRepository.GetAllAsync();
        }
    }
}