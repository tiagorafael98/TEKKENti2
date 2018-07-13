using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using TekkenTI2.Models;

[assembly: OwinStartupAttribute(typeof(TekkenTI2.Startup))]
namespace TekkenTI2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            iniciaAplicacao();
        }

        /// <summary>
        /// cria, caso não existam, as Roles de suporte à aplicação: Veterinario, Funcionario, Dono
        /// cria, nesse caso, também, um utilizador...
        /// </summary>
        private void iniciaAplicacao()
        {

            ApplicationDbContext db = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            // criar a Role 'Admin'
            if (!roleManager.RoleExists("Administrador"))
            {
                // não existe a 'role'
                // então, criar essa role
                var role = new IdentityRole();
                role.Name = "Administrador";
                roleManager.Create(role);
            }

            // criar a Role 'UtilizadorLogado'
            if (!roleManager.RoleExists("UtilizadorLogado"))
            {
                // não existe a 'role'
                // então, criar essa role
                var role = new IdentityRole();
                role.Name = "UtilizadorLogado";
                roleManager.Create(role);
            }

            // criar um utilizador 'Administrador'
            var user = new ApplicationUser();
            user.UserName = "a@a.com";
            user.Email = "a@a.com";
            // password
            string userPWD = "123_Asd";
            var chkUser = userManager.Create(user, userPWD);
            Utilizadores utilizador = new Utilizadores
            {
                UserName = user.Email,
                ID = 1,
                NomeCompleto = "Tiago Rafael Vasconcelos Caires Cândido",
                DataNascimento = new System.DateTime(1998, 08, 10),
                ContactoTelefonico = "963 969 917"
            };

            //Adicionar o Utilizador à respetiva Role-Administrador
            if (chkUser.Succeeded)
            {
                var result1 = userManager.AddToRole(user.Id, "Administrador");
                db.Utilizadores.Add(utilizador);
                db.SaveChanges();
            }
        }

            }

 }

        // https://code.msdn.microsoft.com/ASPNET-MVC-5-Security-And-44cbdb97
