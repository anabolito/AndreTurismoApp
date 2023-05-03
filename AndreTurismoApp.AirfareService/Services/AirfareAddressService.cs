using AndreTurismoApp.AirfareService.Data;
using AndreTurismoApp.Models;
using System.Text.Json;

namespace AndreTurismoApp.AirfareService.Services
{
    public class AirfareAddressService
    {
        static readonly HttpClient client = new HttpClient();
        public static async Task<AddressDTO> GetAddress(string cep)
        {
            try
            {
                HttpResponseMessage response = await AirfareAddressService.client.GetAsync("https://localhost:7060/api/Addresses/" + cep);
                response.EnsureSuccessStatusCode();
                string ender = await response.Content.ReadAsStringAsync();
                var end = JsonSerializer.Deserialize<AddressDTO>(ender);
                return end;
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
    }
}
