using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Xml.Linq;

namespace WishListBooks.Models.Entities
{
    [Table("livro")]
    public class Livro
    {
        [Column("id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("titulo")]
        [Display(Name = "Título")]
        public string Nome { get; set; }

        [Column("CategoriaId")]
        [Display(Name = "Gênero")]
        public int CategoriaId { get; set; }

        [Column("autor")]
        [Display(Name = "Autor(a)")]
        public string Autor { get; set; }

        [Column("editora")]
        [Display(Name = "Editora")]
        public string Editora { get; set; }

        [Column("anolancamento")]
        [Display(Name = "Ano de Lançamento")]
        public string AnoLancamento { get; set; }

        public virtual Categoria? Categoria { get; set; }
        
    }
}
