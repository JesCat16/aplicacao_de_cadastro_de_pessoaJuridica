using Newtonsoft.Json;
namespace ProjetoLead.API.Models
{
    public class CepResponse
    {
        [JsonProperty("cep")]
        public string Cep {  get; set; }
        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }
        [JsonProperty("complemento")]
        public string Complemento { get; set; }
        [JsonProperty("bairro")]
        public string Bairro { get; set; }
        [JsonProperty("localidade")]
        public string Localidade { get; set; }
        [JsonProperty("estado")]
        public string Estado { get; set; }
        [JsonProperty("unidade")]
        public string Unidade { get; set; }
        [JsonProperty("ibge")]
        public string Ibge { get; set; }
        [JsonProperty("gia")]
        public string Gia { get; set; }
    }
}
