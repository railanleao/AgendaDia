using AgendaDia.Api;
using AgendaDia.Areas.Contatos.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaDia.Shared.Data
{
    public class AgendaDbContext : DbContext
    {
        public AgendaDbContext(DbContextOptions<AgendaDbContext> options) : base(options)
        {
        }
        public DbSet<Contato> Contatos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyUtcDateTimeConverter();//Coloque antes dos dados de sementes e após a criação do modelo
        }
    }
}
