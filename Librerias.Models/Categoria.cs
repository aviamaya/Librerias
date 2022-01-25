using System;
using System.Collections.Generic;
using System.Text;

namespace Librerias.Models
{
    public class Categoria : Base
    {
        public int IdCategoria { get; set; }
        public string Detalle { get; set; }
        public bool Activo { get; set; }
    }
}
