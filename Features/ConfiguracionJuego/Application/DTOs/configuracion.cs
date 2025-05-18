using System.Text.Json.Serialization;

namespace juego_impostor_backend.Features.ConfiguracionJuego.Application.DTOs
{
    public class configuracion
    {
        [JsonPropertyName("cant_impostores")]
        public int CantImpostores { get; set; }

        [JsonPropertyName("jugadores")]
        public string[] Jugadores { get; set; } = null!;

        [JsonPropertyName("palabra_secreta_nueva")]
        public string? PalabraSecretaNueva { get; set; }
    }
}
