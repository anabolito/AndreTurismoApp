using AndreTurismoApp.AddressService.Controllers;
using AndreTurismoApp.AddressService.Data;
using AndreTurismoApp.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;
namespace AndreTurismoApp.UTest
{
    public class UnitTestAddress
    {
        private DbContextOptions<AndreTurismoAppAddressServiceContext> options;
        private void InitializeDataBase()
        {
            // Create a Temporary Database
            options = new DbContextOptionsBuilder<AndreTurismoAppAddressServiceContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            // Insert data into the database using one instance of the context
            using (var context = new AndreTurismoAppAddressServiceContext(options))
            {
                context.Address.Add(new Address { Id = 1, Street = "Street 1", PostalCode = "123456789", City = new City() { Id = 1, CityName = "City1" } });
                context.Address.Add(new Address { Id = 2, Street = "Street 2", PostalCode = "987654321", City = new City() { Id = 2, CityName = "City2" } });
                context.Address.Add(new Address { Id = 3, Street = "Street 3", PostalCode = "159647841", City = new City() { Id = 3, CityName = "City3" } });
                context.SaveChanges();
            }
        }
        [Fact]
        public void GetAll()
        {
            InitializeDataBase();
            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAppAddressServiceContext(options))
            {
                AddressesController addressController = new AddressesController(context);
                IEnumerable<Address> clients = addressController.GetAddress().Result.Value;
                Assert.Equal(3, clients.Count());
            }
        }
        [Fact]
        public void GetbyId()
        {
            InitializeDataBase();
            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAppAddressServiceContext(options))
            {
                int addressId = 2;
                AddressesController addressController = new AddressesController(context);
                Address address = addressController.GetAddress(addressId).Result.Value;
                Assert.Equal(2, address.Id);
            }
        }
        [Fact]
        public void Create()
        {
            InitializeDataBase();
            Address address = new Address()
            {
                Id = 4,
                Street = "Rua 10",
                PostalCode = "14804300",
                City = new() 
                { 
                    Id = 10, 
                    CityName = "City 10" 
                    
                }
            };
            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAppAddressServiceContext(options))
            {
                AddressesController clientController = new AddressesController(context);
                Address ad = clientController.PostAddress(address.PostalCode).Result.Value;
                Assert.Equal("Avenida Alberto Benassi", ad.Street);
            }
        }
        [Fact]
        public void Update()
        {
            InitializeDataBase();
            Address address = new Address()
            {
                Id = 3,
                Street = "Rua 10 Alterada",
                City = new() { Id = 10, CityName = "City 10 alterada" }
            };
            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAppAddressServiceContext(options))
            {
                AddressesController clientController = new AddressesController(context);
                Address ad = clientController.PutAddress(3, address).Result.Value;
                Assert.Equal("Rua 10 Alterada", ad.Street);
            }
        }
        [Fact]
        public void Delete()
        {
            InitializeDataBase();
            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAppAddressServiceContext(options))
            {
                AddressesController addressController = new AddressesController(context);
                Address address = addressController.DeleteAddress(2).Result.Value;
                Assert.Null(address);
            }
        }
    }
}