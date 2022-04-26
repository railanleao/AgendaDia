using AgendaDia.Areas.Contatos.Models;

namespace AgendaDia.Areas.Repository
{
    public interface IContatoRepository
    {
        void AtualizarContatoSemFoto(Contato contato);
    }
}
