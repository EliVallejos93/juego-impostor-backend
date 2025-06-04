using juego_impostor_backend.Features.Categorias.Application.Interfaces;
using juego_impostor_backend.Features.Categorias.Domain.Entities;
using juego_impostor_backend.Shared.Persistence;

namespace juego_impostor_backend.Features.Categorias.Infrastructure
{
    public class SubCategoriasRepository(AppDbContext context) : ISubCategoriasRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<List<SubCategoriaEntity>> TraerTodas()
        {
            List<SubCategoriaEntity> subCategoriasList = new();
            foreach (var subCategoria in Todas)
            {
                subCategoriasList.Add(subCategoria);
            }
            return subCategoriasList;
        }

        public readonly List<SubCategoriaEntity> Todas = new()
    {
            //new SubCategoriaEntity() { Id = 1, IdCategoria = 1, SubCategoria = "Acciones" },
            //new SubCategoriaEntity() { Id = 2, IdCategoria = 1, SubCategoria = "Animales" },

            //new SubCategoriaEntity() { Id = 3, IdCategoria = 2, SubCategoria = "Harry Potter" },
            //new SubCategoriaEntity() { Id = 4, IdCategoria = 2, SubCategoria = "Marvel" },

            //new SubCategoriaEntity() { Id = 5, IdCategoria = 3, SubCategoria = "Futbol" },
            //new SubCategoriaEntity() { Id = 6, IdCategoria = 3, SubCategoria = "Tenis" },
    };
    }
}
