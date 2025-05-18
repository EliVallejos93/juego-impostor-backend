using juego_impostor_backend.Features.Categorias.Domain.Entities;

namespace juego_impostor_backend.Features.Categorias.Application.Interfaces
{
    public interface ISubCategoriasRepository
    {
        Task<List<SubCategoriaEntity>> TraerTodas();
    }
}
