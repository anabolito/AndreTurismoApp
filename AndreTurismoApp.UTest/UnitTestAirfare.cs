using AndreTurismoApp.AirfareService.Controllers;
using AndreTurismoApp.AirfareService.Data;
using AndreTurismoApp.HotelService.Controllers;
using AndreTurismoApp.HotelService.Data;
using AndreTurismoApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AndreTurismoApp.UTest
{
    public class UnitTestAirfare
    {
        private DbContextOptions<AndreTurismoAppAirfareServiceContext> options;
        private void InitializeDataBase()
        {
            // Create a Temporary Database
            options = new DbContextOptionsBuilder<AndreTurismoAppAirfareServiceContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            // Insert data into the database using one instance of the context
            using (var context = new AndreTurismoAppAirfareServiceContext(options))
            {
                context.Airfare.Add(new Airfare
                {
                    Id = 1,
                    Price = 1200,
                    Client = new Client() { Id = 1, Name = "nana", Phone = "999", Address = new Address() { Id = 1, Street = "rua1", Number = 1, Neighborhood = "bairro1", PostalCode = "14820428", City = new City() { Id = 1, CityName = "City1" } } },
                    Origin = new Address() { Id = 1, Street = "Street 1", PostalCode = "123456789", City = new City() { Id = 1, CityName = "City1" } },
                    Destiny = new Address() { Id = 2, Street = "Street 1", PostalCode = "123456789", City = new City() { Id = 1, CityName = "City1" }, }
                });
                context.Airfare.Add(new Airfare
                {
                    Id = 2,
                    Price = 1300,
                    Client = new Client() { Id = 2, Name = "nana", Phone = "999", Address = new Address() { Id = 2, Street = "rua2", Number = 2, Neighborhood = "bairro2", PostalCode = "14820428", City = new City() { Id = 2, CityName = "City2" } } },
                    Origin = new Address() { Id = 2, Street = "Street 2", PostalCode = "123456789", City = new City() { Id = 2, CityName = "City2" } },
                    Destiny = new Address() { Id = 2, Street = "Street 2", PostalCode = "123456789", City = new City() { Id = 2, CityName = "City2" } }
                });
                context.Airfare.Add(new Airfare
                {
                    Id = 3,
                    Price = 1400,
                    Client = new Client() { Id = 3, Name = "nana", Phone = "999", Address = new Address() { Id = 3, Street = "rua1", Number = 3, Neighborhood = "bairro3", PostalCode = "14820428", City = new City() { Id = 3, CityName = "City3" } } },
                    Origin = new Address() { Id = 3, Street = "Street 3", PostalCode = "123456789", City = new City() { Id = 3, CityName = "City3" } },
                    Destiny = new Address() { Id = 3, Street = "Street 3", PostalCode = "123456789", City = new City() { Id = 3, CityName = "City3" } }
                });
                context.SaveChanges();
            }
        }
        [Fact]
        public void GetAll()
        {
            InitializeDataBase();
            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAppAirfareServiceContext(options))
            {
                AirfaresController airfareController = new AirfaresController(context);
                IEnumerable<Airfare> airfares = airfareController.GetAirfare().Result.Value;
                Assert.Equal(3, airfares.Count());
            }
        }
        [Fact]
        public void GetbyId()
        {
            InitializeDataBase();
            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAppAirfareServiceContext(options))
            {
                int airfareId = 2;
                AirfaresController airfareController = new AirfaresController(context);
                Airfare airfare = airfareController.GetAirfare(airfareId).Result.Value;
                Assert.Equal(2, airfare.Id);
            }
        }
        [Fact]
        public void Create()
        {
            InitializeDataBase();
            Airfare airfare = new Airfare()
            {
                Id = 4,
                Price = 1400,
                Client = new Client() { Id = 4, Name = "nana", Phone = "999", Address = new Address() { Id = 4, Street = "rua1", Number = 4, Neighborhood = "bairro1", PostalCode = "14820428", City = new City() { Id = 4, CityName = "City4" } } },
                Origin = new() { Id = 4, Street = "Street 4", PostalCode = "123456789", City = new City() { Id = 4, CityName = "City4" } },
                Destiny = new() { Id = 4, Street = "Street 4", PostalCode = "123456789", City = new City() { Id = 4, CityName = "City4" }, }

            };
            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAppAirfareServiceContext(options))
            {
                AirfaresController airfareController = new AirfaresController(context);
                Airfare a = airfareController.PostAirfare(airfare).Result.Value;
                Assert.Equal(4, a.Id);
            }
        }
        [Fact]
        public void Update()
        {
            InitializeDataBase();
            Airfare airfare = new Airfare()
            {
                Id = 3,
                Price = 2000,
                Client = new Client() { Id = 3, Name = "nana", Phone = "999", Address = new Address() { Id = 1, Street = "rua1", Number = 1, Neighborhood = "bairro1", PostalCode = "14820428", City = new City() { Id = 3, CityName = "City3" } } },
                Origin = new() { Id = 3, Street = "Street 3", PostalCode = "123456789", City = new City() { Id = 3, CityName = "City3" } },
                Destiny = new() { Id = 3, Street = "Street 3", PostalCode = "123456789", City = new City() { Id = 3, CityName = "City3" }, }

            };

            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAppAirfareServiceContext(options))
            {
                AirfaresController airfareController = new AirfaresController(context);
                Airfare a = airfareController.PutAirfare(3, airfare).Result.Value;
                Assert.Equal(3, a.Id);
            }
        }
        [Fact]
        public void Delete()
        {
            InitializeDataBase();
            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAppAirfareServiceContext(options))
            {
                AirfaresController airfareController = new AirfaresController(context);
                Airfare airfare = airfareController.DeleteAirfare(2).Result.Value;
                Assert.Null(airfare);
            }
        }
    }
}

