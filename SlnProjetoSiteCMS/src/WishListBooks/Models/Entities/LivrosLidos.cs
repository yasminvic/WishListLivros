using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WishListBooks.Models.Entities
{
    [Table("livrosLidos")]
    public class LivrosLidos
    {
        [Column("id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("LivroId")]
        [Display(Name = "Código do Livro")]
        public int LivroId { get; set; }

        [Column("UserId")]
        [Display(Name = "Usuário")]
        public int UserId { get; set; }

        [Column("dataIni")]
        [Display(Name = "Início da Leitura")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataIni { get; set; }

        [Column("dataFim")]
        [Display(Name = "Fim da Leitura")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataFim { get; set; }

        [Column("critica")]
        [Display(Name = "Crítica")]
        public string Critica { get; set; }

        [Column("avaliacao")]
        [Display(Name = "Nota/Avaliação")]
        [Range(0,5)]
        public int Avaliacao { get; set; }

        public virtual Livro? Livro { get; set; }
        public virtual User? User { get; set; }
    }
}
