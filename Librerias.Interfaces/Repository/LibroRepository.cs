using Librerias.Entities;
using Librerias.Entities.Interfaces;
using Librerias.Interfaces.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Librerias.Interfaces.Repository
{
    public class LibroRepository : ILibroRepository
    {
        readonly LibreriaDbContext dbContext;
        public LibroRepository(LibreriaDbContext context) => dbContext = context;

        public void CreateLibro(Libro libro)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Libro> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
