using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SpaTemplates.Application.Users;
using SpaTemplates.Domain;
using SpaTemplates.EntityFrameworkCore;

namespace SpaTemplates.Application.Tests
{
    public class TestBase
    {
        public ServiceCollection GetServiceCollection()
        {
            var services = new ServiceCollection();

            return services;
        }

        public SpaTemplatesContext GetEmptyDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SpaTemplatesContext>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            var inMemoryContext = new SpaTemplatesContext(optionsBuilder.Options);

            return inMemoryContext;
        }

        public SpaTemplatesContext GetInitializedDbContext()
        {
            var inMemoryContext = GetEmptyDbContext();

            var testUsers = new List<ApplicationUser>
            {
                new ApplicationUser {UserName = "A"},
                new ApplicationUser {UserName = "B"},
                new ApplicationUser {UserName = "C"},
                new ApplicationUser {UserName = "D"},
                new ApplicationUser {UserName = "E"},
                new ApplicationUser {UserName = "F"}
            };

            inMemoryContext.AddRange(testUsers);
            inMemoryContext.SaveChanges();

            return inMemoryContext;
        }
    }
}