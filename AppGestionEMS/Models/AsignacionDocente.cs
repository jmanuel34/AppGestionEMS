using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppGestionEMS.Models
{
    public class AsignacionDocente
    {
        public int Id { get; set; }

        [Display(Name = "Curso")]
        public string CursoId { get; set; }
        public virtual Curso Curso { get; set; }

        [Display(Name = "Grupo")]
        public string GrupoId { get; set; }
        public virtual GrupoClase Grupo { get; set; }

        [Display(Name = "Profesor")]
        public string UsuarioId { get; set; }
        public virtual ApplicationUser Usuario { get; set; }

    }
}