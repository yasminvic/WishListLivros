using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using WishListBooks.Models.Entities;
using WishListBooks.Enum;

namespace WishListBooks.Models
{
    public class ContextoDatabase : DbContext
    {
        public ContextoDatabase(DbContextOptions<ContextoDatabase> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConfiguracaoSistema>()
                .HasData(
                    new { Id = 1, NomeSite = "Wish List Books", Contato = "3333-3333", Endereco = "wishlistbooks@gmail.com" }
                );

            modelBuilder.Entity<User>()
                .HasData(
                new {Id = 1, Nome = "Ana de Souza", Email = "ana@gmail.com", Login = "ana", Senha = "123", CreatedDate = DateTime.Now, Perfil = PerfilEnum.Admin},
                new { Id = 2, Nome = "Maria Clara da Silva", Email = "maria@gmail.com", Login = "maria", Senha = "123", CreatedDate = DateTime.Now, Perfil = PerfilEnum.Admin },
                new { Id = 3, Nome = "Laura Muller", Email = "laura@gmail.com", Login = "laura", Senha = "123", CreatedDate = DateTime.Now, Perfil = PerfilEnum.Padrao },
                new { Id = 4, Nome = "João Victor Machado", Email = "joao@gmail.com", Login = "joao", Senha = "123", CreatedDate = DateTime.Now, Perfil = PerfilEnum.Admin },
                new { Id = 5, Nome = "Pietro da Cruz", Email = "pietro@gmail.com", Login = "pietro", Senha = "123", CreatedDate = DateTime.Now, Perfil = PerfilEnum.Padrao },
                new { Id = 6, Nome = "Izabella Luiza de Souza", Email = "izabella@gmail.com", Login = "izabella", Senha = "123", CreatedDate = DateTime.Now, Perfil = PerfilEnum.Padrao },
                new { Id = 7, Nome = "Antonia Barborsa", Email = "antonia@gmail.com", Login = "antonia", Senha = "123", CreatedDate = DateTime.Now, Perfil = PerfilEnum.Padrao }
                );

            modelBuilder.Entity<Categoria>()
                .HasData(
                  new { Id = 1, Nome = "Suspense" },
                  new { Id = 2, Nome = "Fantasia" },
                  new { Id = 3, Nome = "Romance" },
                  new { Id = 4, Nome = "Autoajuda" },
                  new { Id = 5, Nome = "Religião" },
                  new { Id = 6, Nome = "Astronomia" }
                );

            modelBuilder.Entity<Livro>()
                .HasData(
                    new { Id = 1, Nome = "A Seleção", CategoriaId = 3, Autor = "Kiera Cass", Editora = "Seguinte", AnoLancamento = "2012" },
                    new { Id = 3, Nome = "Suicidas", CategoriaId = 1, Autor = "Raphael Montes", Editora = "Companhia das Letras", AnoLancamento = "2012"},
                    new { Id = 4, Nome = "Origens", CategoriaId = 6, Autor = "Neil deGrasse Tyson", Editora = "Planeta", AnoLancamento = "2004" },
                    new { Id = 5, Nome = "Jantar Secreto", CategoriaId = 1, Autor = "Raphael Montes", Editora = "Companhia das Letras", AnoLancamento = "2016" },
                    new { Id = 6, Nome = "Mentirosos", CategoriaId = 1, Autor = "E. Lockhart", Editora = "Seguinte", AnoLancamento = "2014" },
                    new { Id = 7, Nome = "A Escolha", CategoriaId = 3, Autor = "Kiera Cass", Editora = "Seguinte", AnoLancamento = "2014" },
                    new { Id = 8, Nome = "A Elite", CategoriaId = 3, Autor = "Kiera Cass", Editora = "Seguinte", AnoLancamento = "2013" },
                    new { Id = 9, Nome = "A Herdeira", CategoriaId = 3, Autor = "Kiera Cass", Editora = "Seguinte", AnoLancamento = "2015" },
                    new { Id = 10, Nome = "A Coroa", CategoriaId = 3, Autor = "Kiera Cass", Editora = "Seguinte", AnoLancamento = "2016" },
                    new { Id = 11, Nome = "A Rainha Vermelha", CategoriaId = 2, Autor = "Victoria Aveyard", Editora = "Seguinte", AnoLancamento = "2015" },
                    new { Id = 12, Nome = "Espada de Vidro", CategoriaId = 2, Autor = "Victoria Aveyard", Editora = "Seguinte", AnoLancamento = "2016" },
                    new { Id = 13, Nome = "A Prisão do Rei", CategoriaId = 2, Autor = "Victoria Aveyard", Editora = "Seguinte", AnoLancamento = "2017" },
                    new { Id = 14, Nome = "Tempestada de Guerra", CategoriaId = 2, Autor = "Victoria Aveyard", Editora = "Seguinte", AnoLancamento = "2018" },
                    new { Id = 15, Nome = "Trono Destruído", CategoriaId = 2, Autor = "Victoria Aveyard", Editora = "Seguinte", AnoLancamento = "2019" }
                    );

            base.OnModelCreating(modelBuilder);
        }

        #region DbSets

        public DbSet<ConfiguracaoSistema> ConfiguracaoSistema { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<LivrosLidos> LivrosLidos { get; set; }
        public DbSet<User> Users { get; set; }

        #endregion
    }
}
