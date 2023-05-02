using AndreTurismoApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoApp.Services
{  // DENTRO DA APLICAÇÃO, CONSULTA O MICROSSERVIÇO
    public class PostOfficeService
    {
        static readonly HttpClient endereco = new HttpClient();
        public static async Task<AddressDTO> GetAddress(string cep)
        {
            try
            {
                //HttpResponseMessage response = await PostOfficeService.endereco.GetAsync("https://localhost:7060/api/Addresses");
                HttpResponseMessage response = await PostOfficeService.endereco.GetAsync("https://localhost:7060/api/Addresses/" + cep);
                response.EnsureSuccessStatusCode();
                string ender = await response.Content.ReadAsStringAsync();
                var end = JsonConvert.DeserializeObject<AddressDTO>(ender);
                return end;
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
    }
}
