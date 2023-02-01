using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WishListBooks.Helper;
using WishListBooks.Models.Entities;
using WishListBooks.Service.Interfaces;

namespace WishListBooks.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _service;
        private readonly ISessao _sessao;

        public LoginController(IUserService service, ISessao sessao)
        {
            _service = service; 
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            //se o usuario estiver logado, ele não consegue voltar para essa página
            if (_sessao.BuscarSessao() != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public IActionResult Create()
        {
            //se o usuario estiver logado, ele não consegue voltar para essa página
            if (_sessao.BuscarSessao() != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Entrar(LoginModel loginModel)
        {
            try
            {
                //procurando no BD algum usuario com esse login
                User user = await _service.FindByLogin(loginModel.Login);

                if (ModelState.IsValid)
                {
                    if(user != null)
                    {
                        if (user.ValidaSenha(loginModel.Senha))
                        {
                            _sessao.CriarSessao(user);
                            return RedirectToAction("Index", "Home");
                        }

                    }
                }

                TempData["MensagemErro"] = "Ops, Login ou Senha estão errados. Tente novamente!";
                return View("Create");
            }
            catch(Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, algo deu errado. Tente novamente!";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessao();

            return RedirectToAction("Index", "Login");
        }
    }
}
