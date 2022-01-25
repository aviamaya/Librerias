using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librerias.Entities
{
    public class Categoria : Base
    {
        [Key]
        public int IdCategoria { get; set; }
        public string Detalle { get; set; }
        public bool Activo { get; set; }
    }
}
