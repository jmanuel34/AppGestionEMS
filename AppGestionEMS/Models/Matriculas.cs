using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppGestionEMS.Models
{
    public class Matriculas
    {
        public int Id { get; set; }

        [Display (Name="Alumno")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Display(Name = "Grupo Clase")]
        public string GrupoClaseId { get; set; }
        public virtual GrupoClases GrupoClase { get; set; }

        [Display(Name = "Curso")]
        public string CursoId { get; set; }
        public virtual Cursos Curso { get; set; }

    }
}