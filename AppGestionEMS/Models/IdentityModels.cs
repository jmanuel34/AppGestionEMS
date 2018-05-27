﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AppGestionEMS.Models
{
    // Puede agregar datos del perfil del usuario agregando más propiedades a la clase ApplicationUser. Para más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<AppGestionEMS.Models.Curso> Cursoes { get; set; }

        public System.Data.Entity.DbSet<AppGestionEMS.Models.GrupoClase> GrupoClases { get; set; }

        public System.Data.Entity.DbSet<AppGestionEMS.Models.AsignacionDocente> AsignacionDocentes { get; set; }

        public System.Data.Entity.DbSet<AppGestionEMS.Models.Matricula> Matriculas { get; set; }

        public System.Data.Entity.DbSet<AppGestionEMS.Models.Evaluacion> Evaluacions { get; set; }
    }
}