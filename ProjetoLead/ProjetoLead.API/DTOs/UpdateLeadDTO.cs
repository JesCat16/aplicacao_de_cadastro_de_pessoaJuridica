namespace ProjetoLead.API.DTOs
{
    public class UpdateLeadDTO
    {
        public string razao_social { get; set; }
        public string cep { get; set; }
        public string endereco { get; set; }
        public int numero { get; set; }
        public string? complemento { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
    }
}
