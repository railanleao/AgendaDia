using AgendaDia.Areas.Contatos.Models;
using AgendaDia.Areas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgendaDia.Areas.Contatos.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IContatoService _contatoService;

        public IEnumerable<Contato> Contatos { get; set; } = new List<Contato>();
        public IndexModel(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }
        public async Task OnGetAsync(CancellationToken cancellationToken)
        {
            Contatos = await _contatoService.ObterTodosContatos(cancellationToken);
        }
    }
}
