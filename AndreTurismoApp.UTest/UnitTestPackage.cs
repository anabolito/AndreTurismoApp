using AndreTurismApp.PackageService.Controllers;
using AndreTurismApp.PackageService.Data;
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
    public class UnitTestPackage
    {
        private DbContextOptions<AndreTurismAppPackageServiceContext> options;
        private void InitializeDataBase()
        {
            // Create a Temporary Database
            options = new DbContextOptionsBuilder<AndreTurismAppPackageServiceContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            // Insert data into the database using one instance of the context
            using (var context = new AndreTurismAppPackageServiceContext(options))
            {
                context.Package.Add(new Package
                {
                    Id = 1,
                    PackagePrice = 10000,
                    Airfare = new Airfare
                    {
                        Id = 1,
                        Price = 1200,
                        Client = new Client()
                        {
                            Id = 1,
                            Name = "nana",
                            Phone = "999",
                            Address = new Address()
                            {
                                Id = 1,
                                Street = "rua1",
                                Number = 1,
                                Neighborhood = "bairro1",
                                PostalCode = "14820428",
                                City = new City()
                                {
                                    Id = 1,
                                    CityName = "City1"
                                }
                            }
                        },
                        Origin = new Address()
                        {
                            Id = 1,
                            Street = "Street 1",
                            PostalCode = "123456789",
                            City = new City()
                            {
                                Id = 1,
                                CityName = "City1"
                            }
                        },
                        Destiny = new Address()
                        {
                            Id = 2,
                            Street = "Street 1",
                            PostalCode = "123456789",
                            City = new City() { Id = 1, CityName = "City1" },
                        }
                    },
                    Client = new Client
                    {
                        Id = 1,
                        Name = "nana",
                        Phone = "999",
                        Address = new Address()
                        {
                            Id = 1,
                            Street = "rua1",
                            Number = 1,
                            Neighborhood = "bairro1",
                            PostalCode = "14820428",
                            City = new City()
                            {
                                Id = 1,
                                CityName = "City1"
                            }
                        }
                    },
                    Hotel = new Hotel
                    {
                        Id = 1,
                        HotelName = "hotel 1",
                        DailyPrice = 400,
                        HotelAddress = new Address()
                        {
                            Id = 1,
                            Street = "rua1",
                            Number = 1,
                            Neighborhood = "bairro1",
                            PostalCode = "14820428",
                            City = new City()
                            {
                                Id = 1,
                                CityName = "City1"
                            }
                        }
                    }
                });
                context.Package.Add(new Package
                {
                    Id = 2,
                    PackagePrice = 20000,
                    Airfare = new Airfare
                    {
                        Id = 2,
                        Price = 1200,
                        Client = new Client()
                        {
                            Id = 2,
                            Name = "nana",
                            Phone = "999",
                            Address = new Address()
                            {
                                Id = 2,
                                Street = "rua1",
                                Number = 1,
                                Neighborhood = "bairro1",
                                PostalCode = "14820428",
                                City = new City()
                                {
                                    Id = 2,
                                    CityName = "City1"
                                }
                            }
                        },
                        Origin = new Address()
                        {
                            Id = 2,
                            Street = "Street 1",
                            PostalCode = "123456789",
                            City = new City()
                            {
                                Id = 2,
                                CityName = "City1"
                            }
                        },
                        Destiny = new Address()
                        {
                            Id = 2,
                            Street = "Street 1",
                            PostalCode = "123456789",
                            City = new City() { Id = 2, CityName = "City1" },
                        }
                    },
                    Client = new Client
                    {
                        Id = 2,
                        Name = "nana",
                        Phone = "999",
                        Address = new Address()
                        {
                            Id = 2,
                            Street = "rua1",
                            Number = 1,
                            Neighborhood = "bairro1",
                            PostalCode = "14820428",
                            City = new City()
                            {
                                Id = 2,
                                CityName = "City1"
                            }
                        }
                    },
                    Hotel = new Hotel
                    {
                        Id = 2,
                        HotelName = "hotel 1",
                        DailyPrice = 400,
                        HotelAddress = new Address()
                        {
                            Id = 2,
                            Street = "rua1",
                            Number = 1,
                            Neighborhood = "bairro1",
                            PostalCode = "14820428",
                            City = new City()
                            {
                                Id = 2,
                                CityName = "City1"
                            }
                        }
                    }
                });
                context.Package.Add(new Package
                {
                    Id = 3,
                    PackagePrice = 30000,
                    Airfare = new Airfare
                    {
                        Id = 3,
                        Price = 1200,
                        Client = new Client()
                        {
                            Id = 3,
                            Name = "nana",
                            Phone = "999",
                            Address = new Address()
                            {
                                Id = 3,
                                Street = "rua1",
                                Number = 1,
                                Neighborhood = "bairro1",
                                PostalCode = "14820428",
                                City = new City()
                                {
                                    Id = 3,
                                    CityName = "City1"
                                }
                            }
                        },
                        Origin = new Address()
                        {
                            Id = 3,
                            Street = "Street 1",
                            PostalCode = "123456789",
                            City = new City()
                            {
                                Id = 3,
                                CityName = "City1"
                            }
                        },
                        Destiny = new Address()
                        {
                            Id = 3,
                            Street = "Street 1",
                            PostalCode = "123456789",
                            City = new City() { Id = 3, CityName = "City1" },
                        }
                    },
                    Client = new Client
                    {
                        Id = 3,
                        Name = "nana",
                        Phone = "999",
                        Address = new Address()
                        {
                            Id = 3,
                            Street = "rua1",
                            Number = 1,
                            Neighborhood = "bairro1",
                            PostalCode = "14820428",
                            City = new City()
                            {
                                Id = 3,
                                CityName = "City1"
                            }
                        }
                    },
                    Hotel = new Hotel
                    {
                        Id = 3,
                        HotelName = "hotel 1",
                        DailyPrice = 400,
                        HotelAddress = new Address()
                        {
                            Id = 3,
                            Street = "rua1",
                            Number = 1,
                            Neighborhood = "bairro1",
                            PostalCode = "14820428",
                            City = new City()
                            {
                                Id = 3,
                                CityName = "City1"
                            }
                        }
                    }
                }); 
                context.SaveChanges();
            }

        }
        [Fact]
        public void GetAll()
        {
            InitializeDataBase();
            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismAppPackageServiceContext(options))
            {
                PackagesController packageController = new PackagesController(context);
                IEnumerable<Package> packages = packageController.GetPackage().Result.Value;
                Assert.Equal(3, packages.Count());
            }
        }
        [Fact]
        public void GetbyId()
        {
            InitializeDataBase();
            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismAppPackageServiceContext(options))
            {
                int packageId = 2;
                PackagesController packageController = new PackagesController(context);
                Package package = packageController.GetPackage(packageId).Result.Value;
                Assert.Equal(2, package.Id);
            }
        }
        [Fact]
        public void Create()
        {
            InitializeDataBase();
            Package package = new Package()
            {
                Id = 4,
                PackagePrice = 40000,
                Airfare = new Airfare
                {
                    Id = 4,
                    Price = 1200,
                    Client = new Client()
                    {
                        Id = 4,
                        Name = "nana",
                        Phone = "999",
                        Address = new Address()
                        {
                            Id = 4,
                            Street = "rua1",
                            Number = 1,
                            Neighborhood = "bairro1",
                            PostalCode = "14820428",
                            City = new City()
                            {
                                Id = 4,
                                CityName = "City1"
                            }
                        }
                    },
                    Origin = new Address()
                    {
                        Id = 4,
                        Street = "Street 1",
                        PostalCode = "123456789",
                        City = new City()
                        {
                            Id = 4,
                            CityName = "City1"
                        }
                    },
                    Destiny = new Address()
                    {
                        Id = 4,
                        Street = "Street 1",
                        PostalCode = "123456789",
                        City = new City() { Id = 4, CityName = "City1" },
                    }
                },
                Client = new Client
                {
                    Id = 4,
                    Name = "nana",
                    Phone = "999",
                    Address = new Address()
                    {
                        Id = 4,
                        Street = "rua1",
                        Number = 1,
                        Neighborhood = "bairro1",
                        PostalCode = "14820428",
                        City = new City()
                        {
                            Id = 4,
                            CityName = "City1"
                        }
                    }
                },
                Hotel = new Hotel
                {
                    Id = 4,
                    HotelName = "hotel 1",
                    DailyPrice = 400,
                    HotelAddress = new Address()
                    {
                        Id = 4,
                        Street = "rua1",
                        Number = 1,
                        Neighborhood = "bairro1",
                        PostalCode = "14820428",
                        City = new City()
                        {
                            Id = 4,
                            CityName = "City1"
                        }
                    }
                }
            };
            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismAppPackageServiceContext(options))
            {
                PackagesController packageController = new PackagesController(context);
                Package p = packageController.PostPackage(package).Result.Value;
                Assert.Equal(4, p.Id);
            }
        }
        [Fact]
        public void Update()
        {
            InitializeDataBase();
            Package package = new Package()
            {
                Id = 1,
                PackagePrice = 11111,
                Airfare = new Airfare
                {
                    Id = 1,
                    Price = 1200,
                    Client = new Client()
                    {
                        Id = 1,
                        Name = "nana",
                        Phone = "999",
                        Address = new Address()
                        {
                            Id = 1,
                            Street = "rua1",
                            Number = 1,
                            Neighborhood = "bairro1",
                            PostalCode = "14820428",
                            City = new City()
                            {
                                Id = 1,
                                CityName = "City1"
                            }
                        }
                    },
                    Origin = new Address()
                    {
                        Id = 1,
                        Street = "Street 1",
                        PostalCode = "123456789",
                        City = new City()
                        {
                            Id = 1,
                            CityName = "City1"
                        }
                    },
                    Destiny = new Address()
                    {
                        Id = 2,
                        Street = "Street 1",
                        PostalCode = "123456789",
                        City = new City() { Id = 1, CityName = "City1" },
                    }
                },
                Client = new Client
                {
                    Id = 1,
                    Name = "nana",
                    Phone = "999",
                    Address = new Address()
                    {
                        Id = 1,
                        Street = "rua1",
                        Number = 1,
                        Neighborhood = "bairro1",
                        PostalCode = "14820428",
                        City = new City()
                        {
                            Id = 1,
                            CityName = "City1"
                        }
                    }
                },
                Hotel = new Hotel
                {
                    Id = 1,
                    HotelName = "hotel 1",
                    DailyPrice = 400,
                    HotelAddress = new Address()
                    {
                        Id = 1,
                        Street = "rua1",
                        Number = 1,
                        Neighborhood = "bairro1",
                        PostalCode = "14820428",
                        City = new City()
                        {
                            Id = 1,
                            CityName = "City1"
                        }
                    }
                }
            };
            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismAppPackageServiceContext(options))
            {
                PackagesController packageController = new PackagesController(context);
                Package p = packageController.PutPackage(1, package).Result.Value;
                Assert.Equal(1, p.Id);
            }
        }
        [Fact]
        public void Delete()
        {
            InitializeDataBase();
            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismAppPackageServiceContext(options))
            {
                PackagesController packageController = new PackagesController(context);
                Package package = packageController.DeletePackage(2).Result.Value;
                Assert.Null(package);
            }
        }
    }
}
