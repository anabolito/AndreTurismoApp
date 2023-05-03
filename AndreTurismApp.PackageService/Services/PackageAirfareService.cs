using AndreTurismoApp.Models;
using System.Text.Json;

namespace AndreTurismoApp.PackageService.Services
{
    public class PackageAirfareService
    {
        static readonly HttpClient client = new HttpClient();
        public static async Task<Airfare> GetAirfare(int id)
        {
            try
            {
                HttpResponseMessage response = await PackageAirfareService.client.GetAsync("https://localhost:7038/api/Airfares" + id);
                response.EnsureSuccessStatusCode();
                string ender = await response.Content.ReadAsStringAsync();
                var end = JsonSerializer.Deserialize<Airfare>(ender);
                return end;
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
    }
}
