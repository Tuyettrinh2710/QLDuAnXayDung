using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using QLDAXayDung.Models;

[assembly: OwinStartupAttribute(typeof(QLDAXayDung.Startup))]
namespace QLDAXayDung
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //CreateRoleUser();
        }

        private void CreateRoleUser()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if (!roleManager.RoleExists("Admin"))
            {
                //Tạo role Admin
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
                //Tạo role Quản lý
                role = new IdentityRole();
                role.Name = "QuanLy";
                roleManager.Create(role);
                //Tạo user
                //Admin
                var user = new ApplicationUser();
                user.UserName = "admin@qlxd.com";
                user.Email = "admin@qlxd.com";
                var check = userManager.Create(user, "123456");
                if (check.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
                //Quản lý 1
                user = new ApplicationUser();
                user.UserName = "ql1@qlxd.com";
                user.Email = "ql1@qlxd.com";
                check = userManager.Create(user, "123456");
                if (check.Succeeded)
                {
                    userManager.AddToRole(user.Id, "QuanLy");
                }

            }
        }
    }
}
