using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librerias.Entities
{
    public class Libro : Base
    {
        [Key]
        public int IdLibro { get; set; }
        public string NombreLibro { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaPublicacion { get; set; }
    }

}
