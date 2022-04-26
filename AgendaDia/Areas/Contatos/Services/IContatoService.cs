using AgendaDia.Areas.Contatos.Models;

namespace AgendaDia.Areas.Services
{
    public interface IContatoService
    {
        Task<bool> Adicionar(Contato contato, CancellationToken cancellationToken);
        Task<bool> Alterar(Contato contato, CancellationToken cancellationToken);
        Task<IEnumerable<Contato>> ObterTodosContatos(CancellationToken cancellationToken);
        Task<bool> ApagarContato(Guid id, CancellationToken cancellationToken);
        Task<Contato> ObterPorId (Guid id, CancellationToken cancellationToken);
    }
}
