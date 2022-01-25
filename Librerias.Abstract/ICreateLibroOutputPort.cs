using Librerias.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Librerias.Abstract
{
    interface ICreateLibroOutputPort
    {
        //es el libro ya creado
        Task Handle(LibroDTO libro);
    }
}
