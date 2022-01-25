using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Autores.Web.Models.ViewModels
{
    public class ListaLibrosPorAutor
    {
        public int IdRelacion { get; set; }
        public int IdLibro { get; set; }
        public int IdAutor { get; set; }
        public int IdCategoria { get; set; }
        public string NombreLibro { get; set; }

        [Display(Name = "Categoria Libro")]
        public string Detalle { get; set; }
        public string Descripcion { get; set; }
        public string Documento { get; set; }
        public string NombreAutor { get; set; }
        public DateTime FechaPublicacion { get; set; }
    }
}