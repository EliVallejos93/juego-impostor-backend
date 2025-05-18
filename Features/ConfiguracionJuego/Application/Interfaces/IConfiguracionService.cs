using juego_impostor_backend.Features.ConfiguracionJuego.Application.DTOs;

namespace juego_impostor_backend.Features.ConfiguracionJuego.Application.Interfaces
{
    public interface IConfiguracionService
    {
        string[] ElegirImpostores(configuracion configuracion);
        string ElegirPalabraSecreta(configuracion configuracion);
        List<string> TraerTodasPalabrasSecretas();
    }
}
