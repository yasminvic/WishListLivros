using HollywoodNoticias.ProjetoMVC.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WishListBooks.Models;
using WishListBooks.Models.Entities;
using WishListBooks.Service.Interfaces;

namespace WishListBooks.Controllers
{
    [PaginaParaUsuarioLogado]
    public class LivrosController : Controller
    {
        private readonly ILivroService _service;
        private readonly ICategoriaService _categoriaService;
        private readonly ILivrosLidosService _livrosLidosService;

        public LivrosController(ILivroService service, ICategoriaService categoriaService, ILivrosLidosService livrosLidosService)
        {
            _service = service;
            _categoriaService = categoriaService;
            _livrosLidosService = livrosLidosService;
        }

        public async Task<IActionResult> Index()
        {
            var livros = await _service.GetAll();
            return View(livros);
        }

        public async Task<IActionResult> Details(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var livro = await _service.FindById(id);

            

            return View(livro);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["CategoriaId"] = new SelectList ( await _categoriaService.GetAll(), "Id", "Nome", "Selecione...");
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(Livro lvr)
        {
            if (ModelState.IsValid)
            {
                
                await _service.Save(lvr);
                TempData["MensagemSucesso"] = "Livro adicionado com sucesso";
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoriaId"] = new SelectList(await _categoriaService.GetAll(), "Id", "Nome", "Selecione...");
            TempData["MensagemErro"] = "Falha ao adicionar Livro!";
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var lvr = await _service.FindById(id);
            ViewData["CategoriaId"] = new SelectList(await _categoriaService.GetAll(), "Id", "Nome", "Selecione...");
            return View(lvr);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Livro lvr)
        {
            if(id == null || lvr == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _service.Update(lvr);
                TempData["MensagemSucesso"] = "Livro alterado com sucesso";
                return RedirectToAction(nameof(Index));
            }

            TempData["MensagemSucesso"] = "Erro ao alterar Livro";
            ViewData["CategoriaId"] = new SelectList(await _categoriaService.GetAll(), "Id", "Nome", "Selecione...");
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int? id)
        {
            var retDel = new ReturnJsonDel
            {
                status = "Success",
                code = "200"
            };
            try
            {
                if (await _service.Delete(id ?? 0) <= 0)
                {
                    retDel = new ReturnJsonDel
                    {
                        status = "Error",
                        code = "400"
                    };
                }
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
