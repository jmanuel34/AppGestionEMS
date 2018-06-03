using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppGestionEMS.Models
{
    public class Evaluaciones
    {
        public enum ConvocatoriaType
        {
            Ordinaria,
            Extraordinaria
        }
        public int Id { get; set; }

        [Display(Name = "Curso")]
        public int CursoId { get; set; }
        public virtual Cursos Curso { get; set; }

        [Display(Name = "Alumno")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public ConvocatoriaType Convocatoria { get; set; }
        public float nota_Pr { get; set; }
        public float nota_Ev { get; set; }
        public float nota_P1 { get; set; }
        public float nota_P2 { get; set; }
        public float nota_P3 { get; set; }
        public float nota_P4 { get; set; }
        public float nota_Final { get; set; }
    }
}