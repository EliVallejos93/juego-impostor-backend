using Microsoft.EntityFrameworkCore;
using juego_impostor_backend.Features.Categorias.Domain.Entities;
using juego_impostor_backend.Features.IniciarPartida.Domain.Entities;

namespace juego_impostor_backend.Shared.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<CategoriaEntity> Categorias => Set<CategoriaEntity>();
        public DbSet<SubCategoriaEntity> SubCategorias => Set<SubCategoriaEntity>();
        public DbSet<PalabraSecretaEntity> PalabrasSecretas => Set<PalabraSecretaEntity>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de entidades si usás Fluent API
            base.OnModelCreating(modelBuilder);
        }
    }
}
