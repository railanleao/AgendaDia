using AgendaDia.Areas.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgendaDia.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendaController : Controller
    {
        private readonly IContatoService _contatoService;

        public AgendaController(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> ApagarContato([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await _contatoService.ApagarContato(id, cancellationToken).ConfigureAwait(false);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
