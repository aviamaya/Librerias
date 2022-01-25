using Librerias.Models;
using Librerias.Models.Queries;
using Librerias.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Librerias.Web.Controllers
{
    public class LibrosController : Controller
    {
        private readonly DataBase _database;
        private readonly ILogger<LibrosController> _logger;

        public LibrosController(ILogger<LibrosController> logger)
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
            return View(_database.Libros.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Libro libro)
        {
            TempData["msj"] = "";
            var result = _database.Libros.CreateLibro(libro);
            if (!result.Success)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                TempData["msj"] = result.Message;
                return View(libro);
            }
            TempData["msj"] = "Se realiza la creación del registro correctamente";
            ViewBag.msj = TempData["msj"];
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var libros = _database.Libros.GetById(id);
            if (libros == null)
                return NotFound();

            return View(libros);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Libro libro)
        {
            TempData["msj"] = "";
            var result = _database.Libros.UpdateLibro(libro);
            if (!result.Success)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                TempData["msj"] = result.Message;
                return View(libro);
            }
            TempData["msj"] = "Se realiza la modificación del registro correctamente";
            ViewBag.msj = TempData["msj"];
            return RedirectToAction(nameof(Index));
        }

    }
}
