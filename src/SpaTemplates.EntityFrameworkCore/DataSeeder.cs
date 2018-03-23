using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpaTemplates.Domain;

namespace SpaTemplates.EntityFrameworkCore
{
    public class DataSeeder
    {
        private static readonly string[] Summaries = {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public static async Task SeedData(SpaTemplatesContext context)
        {
            SeedUsers(context);
            SeedWeatherForecasts(context);

            await context.SaveChangesAsync();
        }

        private static void SeedWeatherForecasts(SpaTemplatesContext context)
        {
            if (context.WeatherForecasts.Any())
            {
                return;
            }

            var rng = new Random();
            var weatherForecasts = Enumerable.Range(1, 10).Select(index => new WeatherForecast
            {
                Id = Guid.NewGuid(),
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });

            context.AddRange(weatherForecasts);
        }

        private static void SeedUsers(SpaTemplatesContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = Guid.NewGuid(),
                    AccessFailedCount= 0,
                    Email = "testuser1@mail.com",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    NormalizedEmail = "TESTUSER1@MAIL.COM",
                    NormalizedUserName = "TESTUSER1",
                    TwoFactorEnabled = false,
                    UserName = "testuser1"
                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid(),
                    AccessFailedCount= 0,
                    Email = "testuser2@mail.com",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    NormalizedEmail = "TESTUSER2@MAIL.COM",
                    NormalizedUserName = "TESTUSER2",
                    TwoFactorEnabled = false,
                    UserName = "testuser2"
                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid(),
                    AccessFailedCount= 0,
                    Email = "testuser3@mail.com",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    NormalizedEmail = "TESTUSER3@MAIL.COM",
                    NormalizedUserName = "TESTUSER3",
                    TwoFactorEnabled = false,
                    UserName = "testuser3"
                },
            };

            context.AddRange(users);
        }
    }
}