using Microsoft.EntityFrameworkCore;
using ProjetoLead.API.Models;

namespace ProjetoLead.API.DB
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<CadastroLead> CadastroLead { get; set; }
        public ApplicationDBContext(DbContextOptions options) : base(options) 
        {
               
        }

    }
}
