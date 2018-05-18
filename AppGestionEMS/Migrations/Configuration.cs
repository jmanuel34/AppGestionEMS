namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<AppGestionEMS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppGestionEMS.Models.ApplicationDbContext context)
        {
            string roleTipoUsuario1 = "administrador";
            string roleTipoUsuario2 = "profesor";
            string roleTipoUsuario3 = "alumno";
            AddRole(context, roleTipoUsuario1);
            AddRole(context, roleTipoUsuario2);
            AddRole(context, roleTipoUsuario3);
            AddUser(context, "admin", "admin", "admin@upm.es", roleTipoUsuario1);
            AddUser(context, "Jessica", "apellidos", "yesica.diaz@upm.es", roleTipoUsuario2);
            AddUser(context, "Carolina", "apellidos", "carolina.gallardop@upm.es", roleTipoUsuario2);
            AddUser(context, "pablo", " Rubio", "pablo@alumnos.upm.es", roleTipoUsuario3);
            AddUser(context, "pablich", "gomez", "pablich@alumnos.upm.es", roleTipoUsuario3);
            AddUser(context, "javier", "garcia", "javier@alumnos.upm.es", roleTipoUsuario3);
            AddUser(context, "jose", "mendez", "jose@alumnos.upm.es", roleTipoUsuario3);

        }

        public void AddRole(ApplicationDbContext context, String role)
    {
        IdentityResult IdRoleResult;
        var roleStore = new RoleStore<IdentityRole>(context);
        var roleMgr = new RoleManager<IdentityRole>(roleStore);
        if (!roleMgr.RoleExists(role))
            IdRoleResult = roleMgr.Create(new IdentityRole { Name = role });
    }
    public void AddUser(ApplicationDbContext context, String name, String surname, String email, String role)
    {
        IdentityResult IdUserResult;
        var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        var appUser = new ApplicationUser
        {
            Name = name,
            Surname = surname,
            UserName = email,
            Email = email,
        };
        IdUserResult = userMgr.Create(appUser, "123456Aa!");
        //asociar usuario con role
        if (!userMgr.IsInRole(userMgr.FindByEmail(email).Id, role))
        {
            IdUserResult = userMgr.AddToRole(userMgr.FindByEmail(email).Id, role);
        }
    }
}
}
