using Microsoft.AspNetCore.Mvc;
using ProjetoLead.API.Models;
using Refit;

namespace ProjetoLead.API.Interfaces
{
    public interface ICepApi
    {
        [Get("/ws/{cep}/json")]
        Task<CepResponse> GetResponseAsync(string cep);
    }
}
