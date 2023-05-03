using AndreTurismoApp.ClientService.Controllers;
using AndreTurismoApp.ClientService.Data;
using AndreTurismoApp.ClientService.Controllers;
using AndreTurismoApp.ClientService.Data;
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
    public class UnitTestClient
    {
        private DbContextOptions<AndreTurismoAppClientServiceContext> options;
        private void InitializeDataBase()
        {
            // Create a Temporary Database
            options = new DbContextOptionsBuilder<AndreTurismoAppClientServiceContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            // Insert data into the database using one instance of the context
            using (var context = new AndreTurismoAppClientServiceContext(options))
            {
                context.Client.Add(new Client { Id = 1, Name = "nana", Phone = "999", Address = new Address() { Id = 1, Street = "rua1" ,Number = 1 , Neighborhood = "bairro1", PostalCode = "14820428", City = new City() { Id = 1, CityName = "City1" } } });
                context.Client.Add(new Client { Id = 2, Name = "nene", Phone = "888", Address = new Address() { Id = 2, Street = "rua2", Number = 2, Neighborhood = "bairro2", PostalCode = "14820429", City = new City() { Id = 2, CityName = "City2" } } });
                context.Client.Add(new Client { Id = 3, Name = "nini", Phone = "777", Address = new Address() { Id = 3, Street = "rua3", Number = 3, Neighborhood = "bairro3", PostalCode = "14820430", City = new City() { Id = 3, CityName = "City3" } } });
                context.SaveChanges();
            }
        }
        [Fact]
        public void GetAll()
        {
            InitializeDataBase();
            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAppClientServiceContext(options))
            {
                ClientsController clientController = new ClientsController(context);
                IEnumerable<Client> clients = clientController.GetClient().Result.Value;
                Assert.Equal(3, clients.Count());
            }
        }
        [Fact]
        public void GetbyId()
        {
            InitializeDataBase();
            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAppClientServiceContext(options))
            {
                int clientId = 2;
                ClientsController clientController = new ClientsController(context);
                Client client = clientController.GetClient(clientId).Result.Value;
                Assert.Equal(2, client.Id);
            }
        }
        [Fact]
        public void Create()
        {
            InitializeDataBase();
            Client customer = new Client()
            {
                Id = 4,
                Name = "nono",
                Phone = "666",
                Address = new Address() 
                { 
                    Id = 4, 
                    Street = "rua4", 
                    Number = 4, 
                    Neighborhood = "bairro4", 
                    PostalCode = "14820431", 
                    City = new City() 
                    { 
                        Id = 4, 
                        CityName = "City4" 
                    } 
                }
            };
            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAppClientServiceContext(options))
            {
                ClientsController clientController = new ClientsController(context);
                Client cl = clientController.PostClient(customer).Result.Value;
                Assert.Equal("nono", cl.Name);
            }
        }
        [Fact]
        public void Update()
        {
            InitializeDataBase();
            Client customer = new Client()
            {
                Id = 4,
                Name = "nonono",
                Phone = "6666",
                Address = new Address()
                {
                    Id = 4,
                    Street = "rua4",
                    Number = 4,
                    Neighborhood = "bairro4",
                    PostalCode = "14820431",
                    City = new City()
                    {
                        Id = 4,
                        CityName = "City4"
                    }
                }
            };
            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAppClientServiceContext(options))
            {
                ClientsController clientController = new ClientsController(context);
                Client cl = clientController.PutClient(4,customer).Result.Value;
                Assert.Equal("nonono", cl.Name);
            }
        }
        [Fact]
        public void Delete()
        {
            InitializeDataBase();
            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAppClientServiceContext(options))
            {
                ClientsController ClientController = new ClientsController(context);
                Client client = ClientController.DeleteClient(2).Result.Value;
                Assert.Null(client);
            }
        }
    }
}

