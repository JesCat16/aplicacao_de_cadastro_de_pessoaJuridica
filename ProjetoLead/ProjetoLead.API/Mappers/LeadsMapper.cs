using ProjetoLead.API.DTOs;
using ProjetoLead.API.Models;
using System.Runtime.CompilerServices;

namespace ProjetoLead.API.Mappers
{
    public static class LeadsMapper
    {
        public static GetAllLeadsDTO ToGetAllLeadsDTO(this CadastroLead cadastroModel)
        {
            return new GetAllLeadsDTO
            {
                id = cadastroModel.Id,
                cnpj = cadastroModel.cnpj,
                razao_social = cadastroModel.razao_social,
                cep = cadastroModel.cep,
                estado = cadastroModel.estado
            };
        }
        public static UpdateLeadDTO ToUpdateDTO(this CadastroLead cadastroModel)
        {
            return new UpdateLeadDTO
            {
                razao_social = cadastroModel.razao_social,
                cep = cadastroModel.cep,
                cidade = cadastroModel.cidade,
                numero = cadastroModel.numero,
                complemento = cadastroModel.complemento,
                bairro = cadastroModel.bairro,
                estado = cadastroModel.estado
            };
        }
    }
}
