using juego_impostor_backend.Features.ConfiguracionJuego.Application.Interfaces;
using juego_impostor_backend.Shared.Persistence;

namespace juego_impostor_backend.Features.ConfiguracionJuego.Infrastructure
{
    public class PalabraSecretaRepository(AppDbContext context) : IPalabraSecretaRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<List<string>> ObtenerTodasAsync()
        {
            return Todas.ToList();
        }

        public async Task AgregarAsync(string nuevaPalabra)
        {
            // Guardar la palabra en donde corresponda
        }

        public readonly List<string> Todas = new List<string>
    {
        "Avión",
        "Barco",
        "Camión",
        "Coche",
        "Computadora",
        "Cuaderno",
        "Dado",
        "Escoba",
        "Gato",
        "Juguete",
        "Lápiz",
        "Mesa",
        "Mochila",
        "Perro",
        "Pelota",
        "Piano",
        "Reloj",
        "Silla",
        "Teléfono",
        "Ventana",
        "Ir a al mercado",
        "Ir a pescar",
        "comer comida china",
        "comer comida mexicana",
        "comer comida arabe",
        "comer comida española",
        "viajar",
        "reirse mucho",
        "fisuras",
        "tralalero tralala",
        "saracatunga",
        "corcho",
        "vamos a jugar al truco",
        "esta relampijiando",
        "vinito",
        "fernacho",
        "luz mala",
        "lobizon",
        "messi",
        "maradona",
        "el papa",
        "peluca",
        "salir a correr",
        "tomar agua",
        "jugar al ludo",
    };
    }
}
