//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Autores.Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class v_Lista_LibrosRelacion
    {
        public int IdRelacion { get; set; }
        public int IdLibro { get; set; }
        public int IdAutor { get; set; }
        public int IdCategoria { get; set; }
        public string NombreLibro { get; set; }
        public string Detalle { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime FechaPublicacion { get; set; }
        public string Documento { get; set; }
        public string NombreAutor { get; set; }
    }
}
