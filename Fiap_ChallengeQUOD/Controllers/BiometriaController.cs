using Fiap_ChallengeQUOD.Models;
using Fiap_ChallengeQUOD.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fiap_ChallengeQUOD.Controllers
{
    [ApiController]
    [Route("biometria")]
    public class BiometriaController : ControllerBase
    {
        private readonly BiometriaService _service;

        public BiometriaController(BiometriaService service)
        {
            _service = service;
        }

        [HttpPost("facial")]
        [HttpPost("digital")]
        public async Task<IActionResult> Processar([FromBody] BiometriaRequest req)
        {
            var resultado = await _service.ProcessarAsync(req);
            return Ok(resultado);
        }
    }
}
