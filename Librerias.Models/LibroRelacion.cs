using System;
using System.Collections.Generic;
using System.Text;

namespace Librerias.Models
{
    public class LibroRelacion : Base
    {
        public int IdRelacion { get; set; }
        public int IdLibro { get; set; }
        public int IdCategoria { get; set; }
        public int IdAutor { get; set; }

        public ICollection<Libro> Libros { get; set; }
        public ICollection<Categoria> Categorias { get; set; }
        public ICollection<Autor> Autores { get; set; }
    }

}
