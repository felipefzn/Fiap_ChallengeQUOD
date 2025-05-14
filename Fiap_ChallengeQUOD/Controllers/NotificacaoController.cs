using Fiap_ChallengeQUOD.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Fiap_ChallengeQUOD.Controllers
{
    [ApiController]
    [Route("api/notificacoes")]
    public class NotificacaoController : ControllerBase
    {
        private readonly MongoDbContext _db;

        public NotificacaoController(MongoDbContext db)
        {
            _db = db;
        }

        [HttpPost("fraude")]
        public async Task<IActionResult> NotificarFraude([FromBody] NotificacaoFraudeRequest request)
        {
            var doc = new BsonDocument
        {
            {"transacaoId", request.TransacaoId},
            {"tipoBiometria", request.TipoBiometria},
            {"tipoFraude", request.TipoFraude},
            {"dataCaptura", request.DataCaptura},
            {"dispositivo", new BsonDocument
                {
                    {"fabricante", request.Dispositivo.Fabricante},
                    {"modelo", request.Dispositivo.Modelo},
                    {"sistemaOperacional", request.Dispositivo.SistemaOperacional}
                }
            },
            {"canalNotificacao", new BsonArray(request.CanalNotificacao)},
            {"notificadoPor", request.NotificadoPor},
            {"metadados", new BsonDocument
                {
                    {"latitude", request.Metadados.Latitude},
                    {"longitude", request.Metadados.Longitude},
                    {"ipOrigem", request.Metadados.IpOrigem}
                }
            },
            {"dataRegistro", DateTime.UtcNow}
            };

            await _db.Notificacoes.InsertOneAsync(doc);

            return Created(string.Empty, new { mensagem = "Notificação de fraude registrada." });
        }
    }
}
