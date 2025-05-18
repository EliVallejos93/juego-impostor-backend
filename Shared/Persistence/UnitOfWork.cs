using juego_impostor_backend.Features.ConfiguracionJuego.Application.Interfaces;
using juego_impostor_backend.Features.ConfiguracionJuego.Infrastructure;
using juego_impostor_backend.Features.Categorias.Application.Interfaces;
using juego_impostor_backend.Features.Categorias.Infrastructure;
using System;

namespace juego_impostor_backend.Shared.Persistence
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        private readonly AppDbContext _context = context;
        public IPalabraSecretaRepository PalabrasSecretas { get; private set; } = new PalabraSecretaRepository(context);

        public ICategoriasRepository Categorias { get; private set; } = new CategoriasRepository(context);
        public ISubCategoriasRepository SubCategorias { get; private set; } = new SubCategoriasRepository(context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
