using Microsoft.EntityFrameworkCore;
using juego_impostor_backend.Features.Categorias.Domain.Entities;
using juego_impostor_backend.Features.IniciarPartida.Domain.Entities;

namespace juego_impostor_backend.Shared.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options) { }
        private IConfiguration _config { get; set; }
        public DbSet<CategoriaEntity> Categorias => Set<CategoriaEntity>();
        public DbSet<SubCategoriaEntity> SubCategorias => Set<SubCategoriaEntity>();
        public DbSet<PalabraSecretaEntity> PalabrasSecretas => Set<PalabraSecretaEntity>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de entidades si usás Fluent API
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_config.GetConnectionString("DefaultConnection"));
        }
    }
}
