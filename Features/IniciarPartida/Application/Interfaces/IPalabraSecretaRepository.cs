namespace juego_impostor_backend.Features.IniciarPartida.Application.Interfaces
{
    public interface IPalabraSecretaRepository
    {
        Task<List<string>> ObtenerTodasAsync();
        Task AgregarAsync(string nuevaPalabra);
    }
}
