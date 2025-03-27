using ProjetoLead.API.DTOs;
using ProjetoLead.API.Models;

namespace ProjetoLead.API.Interfaces
{
    public interface ILeadsRepository
    {
        Task<List<CadastroLead>> GetAllAsync();
        Task<CadastroLead> CreateAsync(CadastroLead cadastro);
        Task<CadastroLead> UpdateAsync(int id, UpdateLeadDTO updateLead);
        Task<CadastroLead> DeleteAsync(int id);
    }
}
