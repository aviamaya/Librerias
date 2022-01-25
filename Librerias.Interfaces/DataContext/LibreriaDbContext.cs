using Librerias.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librerias.Interfaces.DataContext
{
    public class LibreriaDbContext : DbContext
    {

        public LibreriaDbContext(DbContextOptions<LibreriaDbContext> options) : base(options) { }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<LibroRelacion> LibrosRelaciones { get; set; }
        public DbSet<Autor> Autores { get; set; }

    }
}
