using Librerias.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Librerias.Abstract
{
    public interface ICreateLibroInputPort
    {
        //es el libro que se quiere crear
        Task Handle(CreateLibroDTO libro);

    }
}
