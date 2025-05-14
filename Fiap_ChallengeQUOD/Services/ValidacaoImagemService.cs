using Fiap_ChallengeQUOD.Models;

namespace Fiap_ChallengeQUOD.Services
{
    public class ValidacaoImagemService
    {
        public class ValidacaoImagemsService
        {
            public ResultadoValidacao ValidarImagem(string base64, Dictionary<string, string> metadados)
            {
                // Simulação da validação (em produção, aplicar IA ou integrações)
                var rnd = new Random();
                bool fraude = rnd.Next(0, 4) == 0; // 25% chance

                return new ResultadoValidacao
                {
                    Sucesso = !fraude,
                    FraudeDetectada = fraude,
                    MotivoFraude = fraude ? "Deepfake detectado" : null,
                    Referencia = Guid.NewGuid().ToString()
                };
            }
        }
    }
}
