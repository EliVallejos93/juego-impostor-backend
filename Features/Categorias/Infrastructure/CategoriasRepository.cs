using juego_impostor_backend.Features.Categorias.Application.Interfaces;
using juego_impostor_backend.Features.Categorias.Domain.Entities;
using juego_impostor_backend.Shared.Persistence;

namespace juego_impostor_backend.Features.Categorias.Infrastructure
{
    public class CategoriasRepository(AppDbContext context) : ICategoriasRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<List<CategoriaEntity>> TraerTodas()
        {
            List<CategoriaEntity> categoriasList = new();
            foreach (var categoria in Todas)
            {
                categoriasList.Add(categoria);
            }
            return categoriasList;
        }

        public readonly List<CategoriaEntity> Todas = new()
    {
            //new CategoriaEntity() { Id = 1, Categoria = "General" },
            //new CategoriaEntity() { Id = 2, Categoria = "Cine" },
            //new CategoriaEntity() { Id = 3, Categoria = "Deporte" },
    };
    }
}
