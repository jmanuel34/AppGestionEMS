using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppGestionEMS.Models
{
    public class Matricula
    {
        public int Id { get; set; }
        [Display(Name = "Alumno")]
        public int UsuarioId { get; set; }
        public virtual ApplicationUser Usuario { get; set; }

        [Display(Name = "Grupo")]
        public int GrupoId { get; set; }
        public virtual GrupoClase Grupo { get; set; }

    }
}