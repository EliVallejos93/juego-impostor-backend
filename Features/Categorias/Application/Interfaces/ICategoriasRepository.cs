using juego_impostor_backend.Features.Categorias.Domain.Entities;

namespace juego_impostor_backend.Features.Categorias.Application.Interfaces
{
    public interface ICategoriasRepository
    {
        Task<List<CategoriaEntity>> TraerTodas();
    }
}
