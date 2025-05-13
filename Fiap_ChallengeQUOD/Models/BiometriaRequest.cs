namespace Fiap_ChallengeQUOD.Models
{
    public class BiometriaRequest
    {
        public string IdUsuario { get; set; }
        public string ImagemBase64 { get; set; }
        public string Tipo { get; set; } // "facial" ou "digital"
        public Dictionary<string, string> Metadados { get; set; }
    }
}
