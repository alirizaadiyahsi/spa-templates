using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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

        public async Task<List<WeatherForecastDto>> GetAllAsync()
        {
            return Mapper.Map<List<WeatherForecastDto>>(await _weatherForecastRepository.GetAllAsync());
        }
    }
}