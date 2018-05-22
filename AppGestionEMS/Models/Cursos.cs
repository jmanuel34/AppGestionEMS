using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppGestionEMS.Models
{
    public class Cursos
    {
        [Key]

        public int cod_Curso { get; set; }

        public Boolean actual { get; set; }

        public string denominacion { get; set; }
    }
}