using AndreTurismoApp.HotelService.Controllers;
using AndreTurismoApp.HotelService.Data;
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
    public class UnitTestHotel
    {
        private DbContextOptions<AndreTurismoAppHotelServiceContext> options;
        private void InitializeDataBase()
        {
            // Create a Temporary Database
            options = new DbContextOptionsBuilder<AndreTurismoAppHotelServiceContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            // Insert data into the database using one instance of the context
            using (var context = new AndreTurismoAppHotelServiceContext(options))
            {
                context.Hotel.Add(new Hotel { Id = 1, HotelName = "hotel 1", DailyPrice = 400, HotelAddress = new Address() { Id = 1, Street = "rua1", Number = 1, Neighborhood = "bairro1", PostalCode = "14820428", City = new City() { Id = 1, CityName = "City1" } } });
                context.Hotel.Add(new Hotel { Id = 2, HotelName = "hotel 2", DailyPrice = 500, HotelAddress = new Address() { Id = 2, Street = "rua2", Number = 2, Neighborhood = "bairro2", PostalCode = "14820428", City = new City() { Id = 2, CityName = "City2" } } });
                context.Hotel.Add(new Hotel { Id = 3, HotelName = "hotel 3", DailyPrice = 600, HotelAddress = new Address() { Id = 3, Street = "rua3", Number = 3, Neighborhood = "bairro3", PostalCode = "14820428", City = new City() { Id = 3, CityName = "City3" } } });
                context.SaveChanges();
            }
        }
        [Fact]
        public void GetAll()
        {
            InitializeDataBase();
            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAppHotelServiceContext(options))
            {
                HotelsController hotelController = new HotelsController(context);
                IEnumerable<Hotel> hotels = hotelController.GetHotel().Result.Value;
                Assert.Equal(3, hotels.Count());
            }
        }
        [Fact]
        public void GetbyId()
        {
            InitializeDataBase();
            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAppHotelServiceContext(options))
            {
                int clientId = 2;
                HotelsController hotelController = new HotelsController(context);
                Hotel hotel = hotelController.GetHotel(clientId).Result.Value;
                Assert.Equal(2, hotel.Id);
            }
        }
        [Fact]
        public void Create()
        {
            InitializeDataBase();
            Hotel hotel = new Hotel()
            {
                Id = 4,
                HotelName = "hotelNana",
                DailyPrice = 500,
                HotelAddress = new()
                {
                    Id = 3,
                    Street = "Rua 10",
                    Neighborhood = "centro",
                    PostalCode = "14820428",
                    City = new() { Id = 10, CityName = "City 10" }
                }

            };
            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAppHotelServiceContext(options))
            {
                HotelsController hotelController = new HotelsController(context);
                Hotel h = hotelController.PostHotel(hotel).Result.Value;
                Assert.Equal(4, h.Id);
            }
        }
        [Fact]
        public void Update()
        {
            InitializeDataBase();
            Hotel hotel = new Hotel()
            {
                Id = 1,
                HotelName = "hotel 1111",
                DailyPrice = 1000,
                HotelAddress = new()
                {
                    Id = 1,
                    Street = "rua1",
                    Number = 1,
                    Neighborhood = "bairro1",
                    PostalCode = "14820428",
                    City = new()
                    {
                        Id = 1,
                        CityName = "City1"
                    }
                }
            };
            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAppHotelServiceContext(options))
            {
                HotelsController hotelController = new HotelsController(context);
                Hotel h = hotelController.PutHotel(1, hotel).Result.Value;
                Assert.Equal(1, h.Id);
            }
        }
        [Fact]
        public void Delete()
        {
            InitializeDataBase();
            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAppHotelServiceContext(options))
            {
                HotelsController hotelController = new HotelsController(context);
                Hotel hotel = hotelController.DeleteHotel(2).Result.Value;
                Assert.Null(hotel);
            }
        }
    }
}

