using AndreTurismoApp.Models;
using System.Text.Json;

namespace AndreTurismoApp.AddressService.Services
{ // DENTRO DO MICROSSERVIÇO
    public class PostOfficeService
    {
        static readonly HttpClient endereco = new HttpClient();
        public static async Task<AddressDTO> GetAddress(string cep)
        {
            try
            {
                HttpResponseMessage response = await PostOfficeService.endereco.GetAsync("https://viacep.com.br/ws/" + cep + "/json/");
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
