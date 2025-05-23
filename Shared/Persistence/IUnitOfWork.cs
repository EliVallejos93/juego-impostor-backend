using juego_impostor_backend.Features.IniciarPartida.Application.Interfaces;
using juego_impostor_backend.Features.Categorias.Application.Interfaces;

namespace juego_impostor_backend.Shared.Persistence
{
    public interface IUnitOfWork
    {
        IPalabraSecretaRepository PalabrasSecretas { get; }
        ICategoriasRepository Categorias { get; }
        ISubCategoriasRepository SubCategorias { get; }
        Task<int> SaveChangesAsync();
    }

}
