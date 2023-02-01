using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollywoodNoticias.ProjetoMVC.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WishListBooks.Helper;
using WishListBooks.Models;
using WishListBooks.Models.Entities;
using WishListBooks.Service.Implements;
using WishListBooks.Service.Interfaces;

namespace WishListBooks.Controllers
{
    [PaginaParaUsuarioLogado]
    public class LivrosLidosController : Controller
    {
        private readonly ILivrosLidosService _service;
        private readonly ILivroService _livroService;
        private readonly IUserService _userService;
        private readonly ISessao _sessao;
        public LivrosLidosController(ILivrosLidosService service, ILivroService livroService, IUserService userService, ISessao sessao)
        {
            _service = service;
            _livroService = livroService;
            _userService = userService;
            _sessao = sessao;
        }

        public async Task<IActionResult> Index()
        {
            var livrosLidos = await _service.GetAll();
            return View(livrosLidos);
        }

        public async Task<IActionResult> Details(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var lvrLido = await _service.FindById(id);
            return View(lvrLido);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["LivroId"] = new SelectList (await _livroService.GetAll(), "Id", "Nome", "Selecione...");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LivrosLidos lvrLidos)
        {
            User usuario = _sessao.BuscarSessao();
            if(usuario != null)
            {
                lvrLidos.UserId = usuario.Id;
            }
            if (ModelState.IsValid)
            {
                await _service.Save(lvrLidos);
                TempData["MensagemSucesso"] = "Avaliação adicionada com sucesso";
                return RedirectToAction("Index");
            }
            ViewData["LivroId"] = new SelectList(await _livroService.GetAll(), "Id", "Nome", "Selecione...");
            TempData["MensagemErro"] = "Erro ao adicionar Avaliação";
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var lvrLidos = await _service.FindById(id);

            User usuario = _sessao.BuscarSessao();

            if(lvrLidos.UserId == usuario.Id)
            {
                ViewData["LivroId"] = new SelectList(await _livroService.GetAll(), "Id", "Nome", "Selecione...");
                return View(lvrLidos);
            }

            TempData["MensagemErro"] = "Você apenas pode alterar as suas próprias avaliações!";
            return RedirectToAction(nameof(Index));
            
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, LivrosLidos lvrLidos)
        {
            if(id == null || lvrLidos == null)
            {
                return NotFound();
            }

            User usuario = _sessao.BuscarSessao();
            if (usuario != null)
            {
                lvrLidos.UserId = usuario.Id;
            }

            if (ModelState.IsValid)
            {
                await _service.Update(lvrLidos);
                TempData["MensagemSucesso"] = "Avaliação alterada com sucesso";
                return RedirectToAction("Index");
            }

            ViewData["LivroId"] = new SelectList(await _livroService.GetAll(), "Id", "Nome", "Selecione...");
            TempData["MensagemErro"] = "Erro ao alterar Avaliação";
            return View(lvrLidos);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            var retDel = new ReturnJsonDel
            {
                status = "Error",
                code = "400"
            };
            try
            {
                User usuario = _sessao.BuscarSessao();
                var lvr = await _service.FindById(id);
                if(usuario.Id == lvr.User.Id)
                {
                    var deletado = await _service.Delete(id);

                    if (deletado <= 0)
                    {
                        retDel = new ReturnJsonDel
                        {
                            status = "Error",
                            code = "400"
                        };
                    }
                    retDel = new ReturnJsonDel
                    {
                        status = "Success",
                        code = "200"
                    };
                    return Json(retDel);
                }

                TempData["MensagemErro"] = "Você apenas pode excluir as suas próprias avaliações!";
                

            }
            catch (Exception ex)
            {
                retDel = new ReturnJsonDel
                {
                    status = ex.Message,
                    code = "500"
                };
            }
            return Json(retDel);
        }
    }
}
