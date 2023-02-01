using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using WishListBooks.Models.Entities;

namespace WishListBooks.ViewComponents
{
    public class Menu : ViewComponent 
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //resgatando as info do user
            string sessaoUser = HttpContext.Session.GetString("sessaoUsuario");

            if (sessaoUser.IsNullOrEmpty())
            {
                return null;
            }

            User usuario = JsonConvert.DeserializeObject<User>(sessaoUser);
            return View(usuario);
        }
    }
}
