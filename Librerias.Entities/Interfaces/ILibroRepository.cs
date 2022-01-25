using System;
using System.Collections.Generic;
using System.Text;

namespace Librerias.Entities.Interfaces
{
    public interface ILibroRepository
    {
        void CreateLibro(Libro libro);
        IEnumerable<Libro> GetAll();
    }
}
