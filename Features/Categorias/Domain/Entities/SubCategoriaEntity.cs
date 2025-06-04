using System.Numerics;

namespace juego_impostor_backend.Features.Categorias.Domain.Entities
{
    public class SubCategoriaEntity
    {
        public Guid Id { get; set; }
        public BigInteger IdCategoria { get; set; }
        public string SubCategoria { get; set; } = null!;
    }
}
