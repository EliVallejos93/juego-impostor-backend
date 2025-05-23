using System.Text.Json.Serialization;

namespace juego_impostor_backend.Features.IniciarPartida.Application.DTOs
{
    public class ConfiguracionDTOResponse
    {
        [JsonPropertyName("impostores_seleccionados")]
        public string[] ImpostoresSeleccionados { get; set; } = null!;
        [JsonPropertyName("palabra_secreta")]
        public string PalabraSecreta { get; set; } = null!;
        [JsonPropertyName("palabras_secretas_todas")]
        public List<string> PalabrasSecretasTodas { get; set; }
    }
}
