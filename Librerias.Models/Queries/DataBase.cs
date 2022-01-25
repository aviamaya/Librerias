using System;
using System.Collections.Generic;
using System.Text;

namespace Librerias.Models.Queries
{
    public class DataBase
    {
        public Libros Libros { get; set; }
        public Categorias Categorias { get; set; }
        public LibrosRelaciones LibrosRelaciones { get; set; }
        public Autores Autores { get; set; }

        public DataBase()
        {
            Libros = new Libros();
            Categorias = new Categorias();
            LibrosRelaciones = new LibrosRelaciones();
            Autores = new Autores();
        }

    }
}
