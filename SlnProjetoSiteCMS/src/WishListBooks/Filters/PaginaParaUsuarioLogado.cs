using WishListBooks.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace HollywoodNoticias.ProjetoMVC.Filters
{
    public class PaginaParaUsuarioLogado : ActionFilterAttribute 
    {
        public override void OnActionExecuting(ActionExecutingContext context) //esse metodo ele é acessado antes de qualquer coisa no projeto
        {
            //resgata a sessao do usuario
            string sessao = context.HttpContext.Session.GetString("sessaoUsuario");

            if (sessao.IsNullOrEmpty())
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            }
            else
            {
                //convertendo json em objeto
                User usuario = JsonConvert.DeserializeObject<User>(sessao);

                if(usuario == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index"} });
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
