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
using WishListBooks.Service.Interfaces;

namespace WishListBooks.Controllers
{
    
    public class UsersController : Controller
    {
        private readonly IUserService _service;
        private readonly ISessao _sessao;

        public UsersController(IUserService service, ISessao sessao)
        {
            _service = service;
            _sessao = sessao;
        }

        [PaginaRestrita]
        public async Task<IActionResult> Index()
        {
            var user = await _service.GetAll();
            return View(user);
        }

        [PaginaRestrita]
        public async Task<IActionResult> Details(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var user = await _service.FindById(id);
            TempData["MensagemSucesso"] = null;
            TempData["MensagemErro"] = null;
            return View(user);
        }

        public IActionResult CreateLogin()
        {
            return View();
        }

        [PaginaRestrita]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.CreatedDate = DateTime.Now;
                await _service.Save(user);
                TempData["MensagemSucesso"] = "Usuário adicionado com sucesso";
                if (_sessao.BuscarSessao() == null)
                {
                    _sessao.CriarSessao(user);
                    TempData["MensagemSucesso"] = null;
                }
                
                return RedirectToAction("Index");
            }
            TempData["MensagemErro"] = "Erro ao adicionar Categoria";
            return View();
        }

        [PaginaRestrita]
        public async Task<IActionResult> Edit(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var user = await _service.FindById(id);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, User usuario)
        {
            if(id == null || usuario == null)
            {
                return NotFound();
            }
            var user_antesUpdate = await _service.FindById(usuario.Id);
            if (ModelState.IsValid)
            {
                usuario.CreatedDate = user_antesUpdate.CreatedDate;
                usuario.Perfil = user_antesUpdate.Perfil;
                await _service.Update(usuario);
                TempData["MensagemSucesso"] = "Usuário alterado com sucesso";
                return RedirectToAction("Index");
            }

            TempData["MensagemSucesso"] = "Usuário alterado com sucesso";
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
