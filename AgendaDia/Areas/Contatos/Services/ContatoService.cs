using AgendaDia.Areas.Contatos.Models;
using AgendaDia.Areas.Repository;
using AgendaDia.Shared.Data;

namespace AgendaDia.Areas.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IGenericRepository<Contato> _genericRepository;
        private readonly IContatoRepository _contatoRepository;
        private readonly IWebHostEnvironment _env;

        public ContatoService(IGenericRepository<Contato> genericRepository,
            IContatoRepository contatoRepository, IWebHostEnvironment env)
        {
            _genericRepository = genericRepository;
            _contatoRepository = contatoRepository;
            _env = env;
        }
        public async Task<bool> Adicionar(Contato contato, CancellationToken cancellationToken)
        {
            //Salvar a Image
            contato.Id = Guid.NewGuid();
            contato.DataModificacao = DateTime.Now;
            await UploadFoto(contato, cancellationToken).ConfigureAwait(false);

            await _genericRepository.AddAsync(contato, cancellationToken).ConfigureAwait(false);
            var result = await _genericRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
            return result;
        }

        public async Task<bool>Alterar(Contato contato, CancellationToken cancellationToken)
        {
           if(contato.Foto != null)
            {
                await UploadFoto(contato, cancellationToken).ConfigureAwait(false);
                _genericRepository.Update(contato);
            }
           else
            {
                _contatoRepository.AtualizarContatoSemFoto(contato);
            }
            contato.DataModificacao = DateTime.Now;
            return await _genericRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<bool> ApagarContato(Guid id, CancellationToken cancellationToken)
        {
            var contato = await _genericRepository.GetByKeysAsync(cancellationToken, id).ConfigureAwait(false);
            _genericRepository.Delete(contato);
            return await _genericRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Contato> ObterPorId(Guid id, CancellationToken cancellationToken)
        {
            return await _genericRepository.GetByKeysAsync(cancellationToken, id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Contato>> ObterTodosContatos(CancellationToken cancellationToken)
        {
            return await _genericRepository.GetAllAsync(cancellationToken: cancellationToken, noTracking: true);
        }
        // métodos privados
        private async Task UploadFoto(Contato contato, CancellationToken cancellationToken)
        {
            if (contato.Foto != null)
            {
                contato.FotoUrl = Path.Combine("Images", "Contatos", $"{contato.Id}-{contato.Foto.FileName}");
                var fulPath = Path.Combine(_env.WebRootPath, contato.FotoUrl);
                using (var fileStream = new FileStream(fulPath, FileMode.Create))
                {
                    await contato.Foto.CopyToAsync(fileStream, cancellationToken).ConfigureAwait(false);
                }
            }
        }
    }
}
