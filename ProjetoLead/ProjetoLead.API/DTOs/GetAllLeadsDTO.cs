namespace ProjetoLead.API.DTOs
{
    public class GetAllLeadsDTO
    {
        public int id {  get; set; }
        public string cnpj { get; set; }
        public string razao_social { get; set; }
        public string cep { get; set; }
        public string estado { get; set; }
    }
}
