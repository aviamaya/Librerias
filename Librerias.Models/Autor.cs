using System;
using System.Collections.Generic;
using System.Text;

namespace Librerias.Models
{
    public class Autor : Base
    {
        public int IdAutor { get; set; }
        public string Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }

    }
}
