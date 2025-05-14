using Fiap_ChallengeQUOD.Models;
using Fiap_ChallengeQUOD.Utils;
using MongoDB.Bson;
using static Fiap_ChallengeQUOD.Services.ValidacaoImagemService;

namespace Fiap_ChallengeQUOD.Services
{
    public class DocumentoService
    {
        private readonly MongoDbContext _db;
        private readonly ValidacaoImagemsService _validador;
        private readonly NotificacaoClient _notificador;

        public DocumentoService(MongoDbContext db, ValidacaoImagemsService validador, NotificacaoClient notificador)
        {
            _db = db;
            _validador = validador;
            _notificador = notificador;
        }

        public async Task<ResultadoValidacao> ProcessarAsync(DocumentoRequest req)
        {
            var resultado = _validador.ValidarImagem(req.ImagemBase64, req.Metadados);

            var registro = new BsonDocument
        {
            {"idUsuario", req.IdUsuario},
            {"tipo", "documento"},
            {"resultadoValidacao", resultado.FraudeDetectada ? "fraude" : "sucesso"},
            {"motivoFraude", resultado.MotivoFraude ?? ""},
            {"referencia", resultado.Referencia},
            {"dataProcessamento", DateTime.UtcNow}
        };

            await _db.Documentos.InsertOneAsync(registro);

            if (resultado.FraudeDetectada)
                await _notificador.EnviarNotificacaoAsync("fraude", req.IdUsuario, resultado.MotivoFraude, resultado.Referencia);

            return resultado;
        }
    }

}
