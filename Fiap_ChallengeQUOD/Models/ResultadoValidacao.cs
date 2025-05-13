namespace Fiap_ChallengeQUOD.Models
{
    public class ResultadoValidacao
    {
        public bool Sucesso { get; set; }
        public bool FraudeDetectada { get; set; }
        public string MotivoFraude { get; set; }
        public string Referencia { get; set; }
    }
}
