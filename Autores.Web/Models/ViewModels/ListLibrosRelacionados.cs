using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autores.Web.Models.ViewModels
{
    public class ListLibrosRelacionados
    {
        public int IdRelacion { get; set; }
        public int IdLibro { get; set; }
        public int IdCategoria { get; set; }
        public int IdAutor { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }

        public virtual Categorias Categorias { get; set; }
        public virtual Libros Libros { get; set; }
        public virtual Autor Autor { get; set; }
    }
}