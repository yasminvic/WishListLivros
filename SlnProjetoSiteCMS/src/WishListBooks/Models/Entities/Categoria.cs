using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WishListBooks.Models.Entities
{
    [Table("categoria")]
    public class Categoria
    {
        [Column("id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("categoriaNome")]
        [Display(Name = "Categoria")]
        public string Nome { get; set; }

    }
}
