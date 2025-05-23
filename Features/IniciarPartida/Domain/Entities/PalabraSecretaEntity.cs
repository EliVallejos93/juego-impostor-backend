namespace juego_impostor_backend.Features.IniciarPartida.Domain.Entities
{
    public class PalabraSecretaEntity
    {
        public int Id { get; set; }
        public string IdCategoria { get; set; } = null!;
        public string IdSubCategoria { get; set; } = null!;
        public string Palabra { get; set; } = null!;
    }
}
