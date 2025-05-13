namespace Fiap_ChallengeQUOD.Utils
{
    public class NotificacaoClient
    {
        private readonly HttpClient _http = new();

        public async Task EnviarNotificacaoAsync(string tipo, string idUsuario, string motivo, string referencia)
        {
            var payload = new
            {
                tipo,
                idUsuario,
                motivo,
                referencia
            };

            await _http.PostAsJsonAsync("https://sistema.quod/notificacoes", payload);
        }
    }
}
