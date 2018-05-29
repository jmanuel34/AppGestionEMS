using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppGestionEMS.Models
{
    public class GrupoClase
    {
        public int Id { get; set; }
        public string nombre { get; set; }

        [Display(Name = "Profesor")]
        public string UsuarioId { get; set; }
        public virtual ApplicationUser Usuario { get; set; }
    }
}