using System.Text.Json.Serialization;

namespace AndreTurismoApp.Models
{
    public class AddressDTO
    {
        #region Propriedades
        public int Id { get; set; }


        [JsonPropertyName("pais")]
        public string? Country { get; set; }


        [JsonPropertyName("cep")]
        public string PostalCode { get; set; }


        [JsonPropertyName("bairro")]
        public string Neighborhood { get; set; }


        [JsonPropertyName("localidade")]
        public string City { get; set; }


        [JsonPropertyName("uf")]
        public string State { get; set; }


        [JsonPropertyName("logradouro")]
        public string Street { get; set; }


        [JsonPropertyName("gia")]
        public int Number { get; set; }


        [JsonPropertyName("complemento")]
        public string Complety { get; set; }
        #endregion
    }
}
