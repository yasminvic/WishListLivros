using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WishListBooks.Models.Entities
{
    [Table("configuracaoSistema")]
    public class ConfiguracaoSistema
    {
        [Column("id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Nome do Site")]
        [Column("nomeSite")]
        public string NomeSite { get; set; }

        [Column("contato")]
        [Display(Name = "Contato")]
        public string Contato { get; set; }

        [Column("endereco")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
    }
}
