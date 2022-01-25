using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Autores.Web.Models;
using Autores.Web.Models.ViewModels;
using static Autores.Web.Models.ViewModels.Enum;

namespace Autores.Web.Controllers
{
    public class AutoresController : Controller
    {
        public ActionResult Index()
        {

            if (TempData.ContainsKey("msj"))
            {
                ViewBag.msj = TempData["msj"].ToString();
            }

            if (TempData.ContainsKey("msjCorrecto"))
            {
                ViewBag.msjCorrecto = TempData["msjCorrecto"].ToString();
            }

            List<ListAutoresViewModel> lst;
            using (dbAppLibreriaEntities db = new dbAppLibreriaEntities())
            {
                lst = (from d in db.Autor
                       select new ListAutoresViewModel
                       {
                           IdAutor = d.IdAutor,
                           Documento = d.Documento,
                           Nombres = d.Nombres,
                           Apellidos = d.Apellidos,
                           Celular = d.Celular,
                           Correo = d.Correo
                       }).ToList();

                return View(lst);
            }
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AutoresViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dbAppLibreriaEntities db = new dbAppLibreriaEntities())
                    {
                        ViewBag.TipoDocumento = (int)TipoDocu.CC;
                        var oAutores = new Autor();
                        oAutores.Documento = model.Documento;
                        oAutores.Nombres = model.Nombres;
                        oAutores.Apellidos = model.Apellidos;
                        oAutores.Correo = model.Correo;
                        oAutores.Celular = model.Celular;
                        oAutores.FechaCreacion = DateTime.Now;

                        db.Autor.Add(oAutores);
                        db.SaveChanges();
                    }
                    TempData["msjCorrecto"] = "Se realiza Creación del registro correctamente";
                    ViewBag.msjCorrecto = TempData["msjCorrecto"];
                    return Redirect("~/Autores/");
                }
                return View(model);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


        public ActionResult Edit(int Id)
        {
            AutoresViewModel model = new AutoresViewModel();
            using (dbAppLibreriaEntities db = new dbAppLibreriaEntities())
            {
                var oAutores = db.Autor.Find(Id);
                model.IdAutor = oAutores.IdAutor;
                model.Documento = oAutores.Documento;
                model.Nombres = oAutores.Nombres;
                model.Apellidos = oAutores.Apellidos;
                model.Correo = oAutores.Correo;
                model.Celular = oAutores.Celular;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AutoresViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dbAppLibreriaEntities db = new dbAppLibreriaEntities())
                    {
                        var oAutores = db.Autor.Find(model.IdAutor);
                        oAutores.Documento = model.Documento;
                        oAutores.Nombres = model.Nombres;
                        oAutores.Apellidos = model.Apellidos;
                        oAutores.Correo = model.Correo;
                        oAutores.Celular = model.Celular;
                        oAutores.FechaModificacion = DateTime.Now;

                        db.Entry(oAutores).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    TempData["msjCorrecto"] = "Se realiza Modificación del registro correctamente";
                    ViewBag.msjCorrecto = TempData["msjCorrecto"];
                    return Redirect("~/Autores/");
                }
                return View(model);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            try
            {
                AutoresViewModel model = new AutoresViewModel();
                using (dbAppLibreriaEntities db = new dbAppLibreriaEntities())
                {
                    var oAutores = db.Autor.Find(Id);
                    db.Autor.Remove(oAutores);
                    db.SaveChanges();
                }
                TempData["msjCorrecto"] = "Se Eliminó el registro correctamente";
                ViewBag.msjCorrecto = TempData["msjCorrecto"];
                return Redirect("~/Autores/");
            }
            catch
            {
                TempData["msj"] = "El autor tiene libros relacionados, el registro no se puede eliminar";
                ViewBag.msj = TempData["msj"];
                return RedirectToAction("Index");
            }

        }


        public ActionResult ListaLibros(int Id)
        {
            List<ListaLibrosPorAutor> lst;
            using (dbAppLibreriaEntities db = new dbAppLibreriaEntities())
            {
                lst = (from d in db.v_Lista_LibrosRelacion
                       select new ListaLibrosPorAutor
                       {
                           IdRelacion = d.IdRelacion,
                           IdAutor = d.IdAutor,
                           Detalle = d.Detalle,
                           NombreLibro = d.NombreLibro,
                           Descripcion = d.Descripcion,
                           FechaPublicacion = d.FechaPublicacion,
                           NombreAutor = d.NombreAutor,
                       }).Where(d => d.IdAutor == Id).ToList();

                return View(lst);
            }
        }

    }
}