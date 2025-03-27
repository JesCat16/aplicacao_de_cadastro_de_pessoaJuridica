using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CpfCnpjLibrary;
using Microsoft.EntityFrameworkCore;
using ProjetoLead.API.DB;
using ProjetoLead.API.DTOs;
using ProjetoLead.API.Interfaces;
using ProjetoLead.API.Mappers;
using ProjetoLead.API.Models;
using ProjetoLead.API.Repository;
using ProjetoLead.API.CepConsult;
using System.Data;

namespace ProjetoLead.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        private readonly ApplicationDBContext _dBContext;
        private readonly ILeadsRepository _leadsRepository;

        public LeadController(ApplicationDBContext dBContext, ILeadsRepository repository)
        {
            _dBContext = dBContext;
            _leadsRepository = repository;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var leads = await _leadsRepository.GetAllAsync();
            var leadsDto = leads.Select(s => s.ToGetAllLeadsDTO());

            return Ok(leadsDto);
        }

        [HttpPost]

        public async Task<IActionResult> Create(string cnpj, string razao_social, string cep, string? complemento, int numero, 
            string? endereco, string? bairro, string? cidade, string? estado)
        {

            var consult = CepConsult.CepConsult.FindAddress(cep);
            CepResponse address = consult.Result;
            var newLead = new CadastroLead();
            if (Cnpj.Validar(cnpj))
            {
                newLead.cnpj = cnpj;
            }
            else
            {
                throw new Exception("Cnpj inválido");                
            }
            newLead.cep = cep;
            if (address == null)
            {
                if(endereco == null || bairro == null || cidade == null || estado == null)
                {
                    throw new Exception("Endereço não encontrado pelo cep, coloque as informações manualmente");
                }
                newLead.endereço = endereco;
                newLead.bairro = bairro;
                newLead.cidade = cidade;
                newLead.estado = estado;
            }
            else
            {
                newLead.endereço = address.Logradouro;
                newLead.bairro = address.Bairro;
                newLead.cidade = address.Localidade;
                newLead.estado = address.Estado;
            }
            newLead.razao_social = razao_social;
            newLead.numero = numero;
            if(complemento == null)
            {
                newLead.complemento = null;
            }
            else
            {
                newLead.complemento = complemento;
            }

            await _leadsRepository.CreateAsync(newLead);
            return CreatedAtAction(nameof(GetAll), new { id = newLead.Id }, newLead);
        }

        [HttpPut]

        public async Task<IActionResult> Update(int id, UpdateLeadDTO update)
        {
            var leadModel = await _leadsRepository.UpdateAsync(id, update);

            if (leadModel != null)
            {
                return NotFound();
            }

            return Ok(leadModel.ToUpdateDTO());
        }

        [HttpDelete]

        public async Task<IActionResult> Delete(int id)
        {
            var lead = await _leadsRepository.DeleteAsync(id);

            if (lead == null) 
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
