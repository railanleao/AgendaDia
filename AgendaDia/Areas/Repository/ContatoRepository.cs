using AgendaDia.Areas.Contatos.Models;
using AgendaDia.Shared.Data;
using Microsoft.EntityFrameworkCore;

namespace AgendaDia.Areas.Repository
{
    public class ContatoRepository : GenericRepository<Contato>, IContatoRepository
    {
        private readonly DbContext _dbContext;

        public ContatoRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void AtualizarContatoSemFoto(Contato contato)
        {
            Update(contato);
            _dbContext.Entry(contato).Property(x => x.FotoUrl).IsModified = false;
        }
    }
}
