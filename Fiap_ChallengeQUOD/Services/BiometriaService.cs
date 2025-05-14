using Fiap_ChallengeQUOD.Models;
using Fiap_ChallengeQUOD.Utils;
using MongoDB.Bson;
using static Fiap_ChallengeQUOD.Services.ValidacaoImagemService;

namespace Fiap_ChallengeQUOD.Services
{
    public class BiometriaService
    {
        private readonly MongoDbContext _db;
        private readonly ValidacaoImagemsService _validador;
        private readonly NotificacaoClient _notificador;

        public BiometriaService(MongoDbContext db, ValidacaoImagemsService validador, NotificacaoClient notificador)
        {
            _db = db;
            _validador = validador;
            _notificador = notificador;
        }

        public async Task<ResultadoValidacao> ProcessarAsync(BiometriaRequest req)
        {
            var resultado = _validador.ValidarImagem(req.ImagemBase64, req.Metadados);

            var registro = new BsonDocument
        {
            {"idUsuario", req.IdUsuario},
            {"tipo", req.Tipo},
            {"resultadoValidacao", resultado.FraudeDetectada ? "fraude" : "sucesso"},
            {"motivoFraude", resultado.MotivoFraude ?? ""},
            {"referencia", resultado.Referencia},
            {"dataProcessamento", DateTime.UtcNow}
        };

            await _db.Biometrias.InsertOneAsync(registro);

            if (resultado.FraudeDetectada)
                await _notificador.EnviarNotificacaoAsync("fraude", req.IdUsuario, resultado.MotivoFraude, resultado.Referencia);

            return resultado;
        }
    }

}
