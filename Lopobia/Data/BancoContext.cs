using Lopobia.Models;
using Microsoft.EntityFrameworkCore;

namespace Lopobia.Data
{
    public class BancoContext:DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<ContatoModel> Contatos { get; set; }
    }
}
