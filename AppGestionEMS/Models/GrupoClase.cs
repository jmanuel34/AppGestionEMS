﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppGestionEMS.Models
{
    public class GrupoClase
    {
            public int Id { get; set; }
            public string denominacion { get; set; }

        [Display(Name = "Profesor")]
        public int UsuarioId { get; set; }
        public virtual ApplicationUser Usuario { get; set; }

    }
    
}