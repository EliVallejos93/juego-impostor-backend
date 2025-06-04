using System.Numerics;

namespace juego_impostor_backend.Features.IniciarPartida.Domain.Entities
{
    public class PalabraSecretaEntity
    {
        public Guid Id { get; set; }
        public BigInteger IdCategoria { get; set; }
        public BigInteger IdSubCategoria { get; set; }
        public string Palabra { get; set; } = null!;
    }
}
