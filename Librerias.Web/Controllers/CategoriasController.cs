using Librerias.Models;
using Librerias.Models.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librerias.Web.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly DataBase _database;
        private readonly ILogger<CategoriasController> _logger;

        public CategoriasController(ILogger<CategoriasController> logger)
        {
            _logger = logger;
            _database = new DataBase();
        }

        public IActionResult Index()
        {
            if (TempData.ContainsKey("msj"))
            {
                ViewBag.msj = TempData["msj"].ToString();
            }
            return View(_database.Categorias.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria categoria)
        {

            var result = _database.Categorias.Create(categoria);
            if (!result.Success)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View(categoria);
            }

            TempData["msj"] = "Se realiza la creación del registro correctamente";
            ViewBag.msj = TempData["msj"];
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int id)
        {
            var categoria = _database.Categorias.GetById(id);
            if (categoria == null)
                return NotFound();

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categoria categoria)
        {

            var result = _database.Categorias.Update(categoria);
            if (!result.Success)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View(categoria);
            }
            TempData["msj"] = "Se realiza la modificación del registro correctamente";
            ViewBag.msj = TempData["msj"];
            return RedirectToAction(nameof(Index));
        }
    }
}
