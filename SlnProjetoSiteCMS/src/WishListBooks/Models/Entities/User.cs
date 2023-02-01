using WishListBooks.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WishListBooks.Models.Entities
{
    [Table("user")]
    public class User
    {
        [Column("id")]
        [Display(Name = "Código")]
        public int Id { get; set; }
        [Column("nome")]
        public string Nome { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("login")]
        public string Login { get; set; }

        [Column("senha")]
        public string Senha { get; set; }

        [Display(Name = "Data de Criação")]
        [Column("createdDate")]
        public DateTime CreatedDate { get; set; }

        [Column("perfil")]
        public PerfilEnum Perfil { get; set; }

        public ICollection<LivrosLidos>? Livros { get; set; }

        public bool ValidaSenha(string senha)
        {
            return Senha == senha;
        }
    }
}
