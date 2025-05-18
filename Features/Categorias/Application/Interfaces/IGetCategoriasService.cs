using juego_impostor_backend.Features.Categorias.Application.DTOs;

namespace juego_impostor_backend.Features.Categorias.Application.Interfaces
{
    public interface IGetCategoriasService
    {
        public GetCategoriasDTOResponse TraerTodas();
    }
}
