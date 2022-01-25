using System;
using System.Collections.Generic;
using System.Text;

namespace Librerias.DTO
{
    public class CreateLibroDTO
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaPublicacion { get; set; }
    }
}
