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
    
    public partial class LibrosRelaciones
    {
        public int IdRelacion { get; set; }
        public int IdLibro { get; set; }
        public int IdCategoria { get; set; }
        public int IdAutor { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
    
        public virtual Categorias Categorias { get; set; }
        public virtual Libros Libros { get; set; }
        public virtual Autor Autor { get; set; }
    }
}
