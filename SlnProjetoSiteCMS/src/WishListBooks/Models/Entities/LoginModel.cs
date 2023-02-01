using System.ComponentModel.DataAnnotations;

namespace WishListBooks.Models.Entities
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite seu Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite sua Senha")]
        public string Senha { get; set; }
    }
}
