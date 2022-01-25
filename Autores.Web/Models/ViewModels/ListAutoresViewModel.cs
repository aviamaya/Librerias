using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autores.Web.Models.ViewModels
{
    public class ListAutoresViewModel
    {
        public int IdAutor { get; set; }
        public Nullable<int> TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
    }
}