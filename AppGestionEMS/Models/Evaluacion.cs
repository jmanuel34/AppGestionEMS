using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppGestionEMS.Models
{
    public class Evaluacion
    {
        public int Id { get; set; }

        [Display(Name = "Alumno")]
        public string UsuarioId { get; set; }
        public virtual ApplicationUser Usuario { get; set; }

        [Display(Name = "Curso")]
        public string CursoId { get; set; }
        public virtual ApplicationUser Curso { get; set; }

        public float nota_Pr { get; set; }
        public float nota_Ev { get; set; }
        public float nota_P1 { get; set; }
        public float nota_P2 { get; set; }
        public float nota_P3 { get; set; }
        public float nota_P4 { get; set; }
        public float nota_Final { get; set; }

    }
}