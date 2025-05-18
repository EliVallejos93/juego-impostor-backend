using juego_impostor_backend.Features.Categorias.Domain.Entities;

namespace juego_impostor_backend.Features.Categorias.Application.DTOs
{
    public class GetCategoriasDTOResponse
    {
        public List<CategoriaDTO> Categorias { get; set; } = new();
    }

    public class CategoriaDTO
    {
        //public CategoriaEntity Categoria { get; set; } = new CategoriaEntity();
        public int Id { get; set; }
        public string Categoria { get; set; } = null!;
        public List<SubCategoriaEntity> SubCategorias { get; set; } = new List<SubCategoriaEntity>();
    }
}

