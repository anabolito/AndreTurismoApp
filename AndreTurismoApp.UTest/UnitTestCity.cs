using AndreTurismoApp.CityService.Controllers;
using AndreTurismoApp.CityService.Data;
using AndreTurismoApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AndreTurismoApp.UTest
{
    public class UnitTestCity
    {
        private DbContextOptions<AndreTurismoAppCityServiceContext> options;
        private void InitializeDataBase()
        {
            // Create a Temporary Database
            options = new DbContextOptionsBuilder<AndreTurismoAppCityServiceContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            // Insert data into the database using one instance of the context
            using (var context = new AndreTurismoAppCityServiceContext(options))
            {
                context.City.Add(new City { Id = 1, CityName = "city 1" });
                context.City.Add(new City { Id = 2, CityName = "city 2" });
                context.City.Add(new City { Id = 3, CityName = "city 3" });
                context.SaveChanges();
            }
        }
        [Fact]
        public void GetAll()
        {
            InitializeDataBase();
            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAppCityServiceContext(options))
            {
                CitiesController clientController = new CitiesController(context);
                IEnumerable<City> cities = clientController.GetCity().Result.Value;
                Assert.Equal(3, cities.Count());
            }
        }
        [Fact]
        public void GetbyId()
        {
            InitializeDataBase();
            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAppCityServiceContext(options))
            {
                int clientId = 2;
                CitiesController cityController = new CitiesController(context);
                City city = cityController.GetCity(clientId).Result.Value;
                Assert.Equal(2, city.Id);
            }
        }
        [Fact]
        public void Create()
        {
            InitializeDataBase();
            City city = new City()
            {
                Id = 4,
                CityName = "Bauru"
            };
            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAppCityServiceContext(options))
            {
                CitiesController cityController = new CitiesController(context);
                City c = cityController.PostCity(city).Result.Value;
                Assert.Equal(4, c.Id);
            }
        }
        [Fact]
        public void Update()
        {
            InitializeDataBase();
            City city = new City()
            {
                Id = 3,
                CityName = "Bauru"
            };
            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAppCityServiceContext(options))
            {
                CitiesController cityController = new CitiesController(context);
                City c = cityController.PutCity(3, city).Result.Value;
                Assert.Equal(3, c.Id);
            }
        }
        [Fact]
        public void Delete()
        {
            InitializeDataBase();
            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAppCityServiceContext(options))
            {
                CitiesController cityController = new CitiesController(context);
                City city = cityController.DeleteCity(2).Result.Value;
                Assert.Null(city);
            }
        }
    }
}


