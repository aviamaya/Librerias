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
    public class LibrosRelacionController : Controller
    {
        private readonly DataBase _database;
        private readonly ILogger<LibrosRelacionController> _logger;

        public LibrosRelacionController(ILogger<LibrosRelacionController> logger)
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
            return View(_database.LibrosRelaciones.GetAll());
        }

        public IActionResult Create()
        {
            ListasDesplegables();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LibroRelacion libroRelacion)
        {

            var result = _database.LibrosRelaciones.Create(libroRelacion);
            if (!result.Success)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                TempData["msj"] = result.Message;
                ListasDesplegables();
                return View(libroRelacion);
            }
            TempData["msj"] = "Se realiza la Creación del registro correctamente";
            ViewBag.msj = TempData["msj"];
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int id)
        {
            ListasDesplegables();
            var librosRel = _database.LibrosRelaciones.GetById(id);
            if (librosRel == null)
                return NotFound();

            return View(librosRel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(LibroRelacion librosRelaciones)
        {
            TempData["msj"] = "";
            var result = _database.LibrosRelaciones.Update(librosRelaciones);
            if (!result.Success)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                TempData["msj"] = result.Message;
                ListasDesplegables();
                return View(librosRelaciones);
            }

            TempData["msj"] = "Se realiza la Modificación del registro correctamente";
            ViewBag.msj = TempData["msj"];
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detail(int id)
        {
            var librosRel = _database.LibrosRelaciones.GetById(id);
            if (librosRel == null)
                return NotFound();

            return View(librosRel);
        }
        public IActionResult Delete(int id)
        {
            TempData["msj"] = "";
            var result = _database.LibrosRelaciones.Delete(id);
            if (!result.Success)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                TempData["msj"] = result.Message;
                return View(id);
            }
            TempData["msj"] = "Se Elimino el registro correctamente";
            ViewBag.msj = TempData["msj"];
            return RedirectToAction(nameof(Index));
        }

        private void ListasDesplegables()
        {
            ViewBag.Categorias = _database.Categorias.GetAll()
              .Select(x => new SelectListItem { Text = x.Detalle, Value = x.IdCategoria.ToString() });

            ViewBag.Libros = _database.Libros.GetAll()
                .Select(x => new SelectListItem { Text = x.NombreLibro, Value = x.IdLibro.ToString() });

            ViewBag.Autores = _database.Autores.GetAll()
                .Select(x => new SelectListItem { Text = (x.Nombres + " " + x.Apellidos), Value = x.IdAutor.ToString() });
        }

    }
}
