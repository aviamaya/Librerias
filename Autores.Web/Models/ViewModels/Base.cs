using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autores.Web.Models.ViewModels
{
    public class Base
    {
        public DateTimeOffset FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}