using AndreTurismoApp.Models;
using System.Text.Json;

namespace AndreTurismoApp.AirfareService.Services
{
    public class AirfareClientService
    {
        static readonly HttpClient client = new HttpClient();
        public static async Task<Client> GetClient(int id)
        {
            try
            {
                HttpResponseMessage response = await AirfareClientService.client.GetAsync("https://localhost:7262/api/Clients/" + id);
                response.EnsureSuccessStatusCode();
                string ender = await response.Content.ReadAsStringAsync();
                var end = JsonSerializer.Deserialize<Client>(ender);
                return end;
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
    }
}
