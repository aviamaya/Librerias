using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Autores.Web.Models.ViewModels
{
    public class AutoresViewModel : Base
    {
        public int IdAutor { get; set; }

        public Nullable<int> TipoDocumento { get; set; }

        [Required]
        [Display(Name = "Documento")]
        public string Documento { get; set; }

        [Required]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string Correo { get; set; }

        [Required]
        [Display(Name = "Numero Celular")]
        public string Celular { get; set; }
    }
}