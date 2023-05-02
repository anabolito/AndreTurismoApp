using AndreTurismoApp.Models;
using AndreTurismoApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private AddressService addressService;

        private readonly PostOfficeService _postOffice;
        public AddressController()
        {
            addressService = new AddressService();
        }

        [HttpPost("cep")]
        public bool Insert(string cep)
        {
            var aux = PostOfficeService.GetAddress(cep).Result;
            Address address = new()
            {
                Street = aux.Street,
                Number = int.Parse(aux.Number),
                Neighborhood = aux.Neighborhood,
                PostalCode = aux.PostalCode,
                City = new City()
                {
                    CityName = aux.City
                }
            };
            return addressService.Insert(address);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            //Address address = new();
            //address.Id = id;
            return addressService.Delete(id);
        }

        [HttpPut]
        public bool Update(Address address)
        {
            return addressService.Update(address);
        }

        [HttpGet]
        public List<Address> GetAll()
        {
            return addressService.GetAll();
        }

    }
}
