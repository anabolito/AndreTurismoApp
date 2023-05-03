using AndreTurismoApp.Models;
using System.Text.Json;

namespace AndreTurismoApp.PackageService.Services
{
    public class PackageHotelService
    {
        static readonly HttpClient client = new HttpClient();
        public static async Task<Hotel> GetHotel(int id)
        {
            try
            {
                HttpResponseMessage response = await PackageHotelService.client.GetAsync("https://localhost:7031/api/Hotels" + id);
                response.EnsureSuccessStatusCode();
                string ender = await response.Content.ReadAsStringAsync();
                var end = JsonSerializer.Deserialize<Hotel>(ender);
                return end;
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

    }
}
