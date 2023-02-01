using WishListBooks.Models.Entities;
using WishListBooks.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace HollywoodNoticias.ProjetoMVC.Filters
{
    public class PaginaRestrita : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessao = context.HttpContext.Session.GetString("sessaoUsuario");

            if (sessao.IsNullOrEmpty())
            {
                context.Result = new RedirectToRouteResult( new RouteValueDictionary { { "controller", "Login"}, { "action", "Index"} });
            }
            else
            {
                User usuario = JsonConvert.DeserializeObject<User>(sessao);

                if(usuario == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }

                if(usuario.Perfil == PerfilEnum.Padrao)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "Index"} });
                }
            }
        }
    }
}
