using Microsoft.EntityFrameworkCore;
using MonowProject.Models;

namespace MonowProject.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; } = default!;
        public DbSet<Comanda> Comandas { get; set; } = default!;
        public DbSet<Categoria> Categorias { get; set; } = default!;
        public DbSet<Produto> Produtos { get; set; } = default!;
        public DbSet<Caixa> Caixas { get; set; } = default!;
        public DbSet<Pedido> Pedidos { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Nome = "admin",
                    Senha = "admin"
                }

                );

          




        }
    }
}
