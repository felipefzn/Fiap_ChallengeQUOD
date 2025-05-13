namespace Fiap_ChallengeQUOD.Models
{
    public class DocumentoRequest
    {
        public string IdUsuario { get; set; }
        public string ImagemBase64 { get; set; }
        public Dictionary<string, string> Metadados { get; set; }
    }
}
