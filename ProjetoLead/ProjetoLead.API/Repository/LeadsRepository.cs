using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ProjetoLead.API.DB;
using ProjetoLead.API.DTOs;
using ProjetoLead.API.Interfaces;
using ProjetoLead.API.Mappers;
using ProjetoLead.API.Models;
using System.Runtime.ConstrainedExecution;

namespace ProjetoLead.API.Repository
{
    public class LeadsRepository : ILeadsRepository
    {
        private readonly ApplicationDBContext _dBContext;

        public LeadsRepository(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<CadastroLead> CreateAsync(CadastroLead cadastro)
        {
            _dBContext.CadastroLead.Add(cadastro);
            _dBContext.SaveChanges();
            return cadastro;
        }

        public async Task<CadastroLead?> DeleteAsync(int id)
        {
            var leadModel = await _dBContext.CadastroLead.FirstOrDefaultAsync(x => x.Id == id);

            if (leadModel == null)
            {
                return null;
            }

            _dBContext.CadastroLead.Remove(leadModel);
            await _dBContext.SaveChangesAsync();
            return leadModel;
        }

        public Task<List<CadastroLead>> GetAllAsync()
        {
            return _dBContext.CadastroLead.ToListAsync();
        }

        public async Task<CadastroLead> UpdateAsync(int id, UpdateLeadDTO updateLead)
        {
            var existinglead = await _dBContext.CadastroLead.FirstOrDefaultAsync(x => x.Id == id);

            if (existinglead == null)
            {
                return null;
            }

            existinglead.cep = updateLead.cep;
            var consult = CepConsult.CepConsult.FindAddress(updateLead.cep);
            CepResponse address = consult.Result;
            if (address == null)
            {
                if (updateLead.endereco == null || updateLead.bairro == null || updateLead.cidade == null || updateLead.estado == null)
                {
                    throw new Exception("Endereço não encontrado pelo cep, coloque as informações manualmente");
                }
                existinglead.endereço = updateLead.endereco;
                existinglead.bairro = updateLead.bairro;
                existinglead.cidade = updateLead.cidade;
                existinglead.estado = updateLead.estado;

            }
            existinglead.razao_social = updateLead.razao_social;
            existinglead.endereço = address.Logradouro;
            existinglead.bairro = address.Bairro;
            existinglead.cidade = address.Localidade;
            existinglead.estado = address.Estado;
            existinglead.complemento = updateLead.complemento;
            existinglead.numero = updateLead.numero;

            await _dBContext.SaveChangesAsync();
            return existinglead;
        }
    }
}
