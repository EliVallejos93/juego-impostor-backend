namespace juego_impostor_backend.Features.Categorias.Domain.Entities
{
    public class SubCategoriaEntity
    {
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public string SubCategoria { get; set; } = null!;
    }
}
