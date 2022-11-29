using Contatos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
    

namespace Contatos.Data
{
    public class ContatoDbContext : DbContext
    {
        public ContatoDbContext(DbContextOptions<ContatoDbContext> opts) : base(opts)
        {

        }
        public DbSet<Contato> Contatos { get; set; }
    }
}
