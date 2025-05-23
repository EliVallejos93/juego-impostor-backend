using juego_impostor_backend.Features.IniciarPartida.Application.DTOs;

namespace juego_impostor_backend.Features.IniciarPartida.Application.Interfaces
{
    public interface IConfiguracionService
    {
        string[] ElegirImpostores(configuracion configuracion);
        string ElegirPalabraSecreta(configuracion configuracion);
        List<string> TraerTodasPalabrasSecretas();
    }
}
