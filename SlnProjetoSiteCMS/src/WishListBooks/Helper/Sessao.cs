using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using WishListBooks.Models.Entities;

namespace WishListBooks.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        //buscar por login
        public User BuscarSessao()
        {
            //trazendo o usuario em formato json
            string sessao = _httpContext.HttpContext.Session.GetString("sessaoUsuario");

            if (sessao.IsNullOrEmpty())
            {
                return null;
            }

            return JsonConvert.DeserializeObject<User>(sessao); //transformando de json para objeto
        }

        //armazena usuario
        public void CriarSessao(User user)
        {
            //transformar o objeto em json
            string value = JsonConvert.SerializeObject(user);
            _httpContext.HttpContext.Session.SetString("sessaoUsuario", value);
        }

        public void RemoverSessao()
        {
            //fazendo o logout
            _httpContext.HttpContext.Session.Remove("sessaoUsuario");
        }
    }
}
