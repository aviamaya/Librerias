using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librerias.Entities
{
    public class LibrosRelacion : Base
    {
        [Key]
        public int IdRelacion { get; set; }

        public int IdLibro { get; set; }
        public int IdCategoria { get; set; }
        public int IdAutor { get; set; }

        public List<Libro> Libros { get; set; }
        public List<Categoria> Categorias { get; set; }
        public List<Autor> Autores { get; set; }
    }


}
