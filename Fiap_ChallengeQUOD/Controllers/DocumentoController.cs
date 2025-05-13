using Fiap_ChallengeQUOD.Models;
using Fiap_ChallengeQUOD.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fiap_ChallengeQUOD.Controllers
{
    [ApiController]
    [Route("documento")]
    public class DocumentoController : ControllerBase
    {
        private readonly DocumentoService _service;

        public DocumentoController(DocumentoService service)
        {
            _service = service;
        }

        [HttpPost("validar")]
        public async Task<IActionResult> Validar([FromBody] DocumentoRequest req)
        {
            var resultado = await _service.ProcessarAsync(req);
            return Ok(resultado);
        }
    }

}
