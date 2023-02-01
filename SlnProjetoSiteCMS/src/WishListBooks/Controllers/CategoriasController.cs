using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HollywoodNoticias.ProjetoMVC.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WishListBooks.Models;
using WishListBooks.Models.Entities;
using WishListBooks.Service.Interfaces;

namespace WishListBooks.Controllers
{
    [PaginaRestrita]
    public class CategoriasController : Controller
    {
        private readonly ICategoriaService _service;

        public CategoriasController(ICategoriaService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var catg = await _service.GetAll();
            return View(catg);
        }

        public async Task<IActionResult> Details(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var catg = await _service.FindById(id);
            return View(catg);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Categoria ctg)
        {
            if (ModelState.IsValid)
            {
                await _service.Save(ctg);
                TempData["MensagemSucesso"] = "Categoria adicionada com sucesso";
                return RedirectToAction(nameof(Index));
                
            }
            TempData["MensagemErro"] = "Erro ao adicionar categoria";
            return View("Index");
            
        }

        public async Task<IActionResult> Edit(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var ctg = await _service.FindById(id);
            return View(ctg);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Categoria ctg)
        {
            if(id == null || ctg == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _service.Update(ctg);
                TempData["MensagemSucesso"] = "Categoria editada com sucesso";
                return RedirectToAction(nameof(Index));
            }
            TempData["MensagemErro"] = "Erro ao editar categoria";
            return View("Index");
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
