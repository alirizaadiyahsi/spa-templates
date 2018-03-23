using System.Collections.Generic;
using System.Threading.Tasks;
using SpaTemplates.Domain;

namespace SpaTemplates.Application.WeatherForecasts
{
    public interface IWeatherForecastApplicationService
    {
        Task<List<WeatherForecastDto>> GetAllAsync();
    }
}
