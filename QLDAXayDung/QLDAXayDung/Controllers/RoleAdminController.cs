using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using QLDAXayDung.Models;
using System.Net;
using System.Threading.Tasks;

namespace QLDAXayDung.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleAdminController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        
        // GET: RoleAdmin
        public ActionResult Index()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            return View(roleManager.Roles);
        }

        // GET: RoleAdmin/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if(id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var role = await roleManager.FindByIdAsync(id);
            var listUser = new List<ApplicationUser>();
            foreach (var user in userManager.Users.ToList())
                if (await userManager.IsInRoleAsync(user.Id, role.Name))
                    listUser.Add(user);
            ViewBag.Users = listUser;
            ViewBag.UserCount = listUser.Count();
            return View(role);
        }

        // GET: RoleAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleAdmin/Create
        [HttpPost]
        public async Task<ActionResult> Create(Role roleView)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole(roleView.Name);
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var roleResult = await roleManager.CreateAsync(role);
                if (!roleResult.Succeeded)
                {
                    ModelState.AddModelError("", roleResult.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: RoleAdmin/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
                return HttpNotFound();
            Role roleModel = new Role
            {
                Id = role.Id,
                Name = role.Name
            };
            return View(roleModel);
        }

        // POST: RoleAdmin/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Role roleModel)
        {
            if (ModelState.IsValid)
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var role = await roleManager.FindByIdAsync(roleModel.Id);
                if(role != null)
                {
                    role.Name = roleModel.Name;
                    await roleManager.UpdateAsync(role);
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: RoleAdmin/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
                return HttpNotFound();
            return View(role);
        }

        // POST: RoleAdmin/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(string id, string tpm ="")
        {
            if (ModelState.IsValid)
            {
                if(id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var role = await roleManager.FindByIdAsync(id);
                if (role == null)
                    return HttpNotFound();
                IdentityResult result = await roleManager.DeleteAsync(role);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View(0);
                }
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
