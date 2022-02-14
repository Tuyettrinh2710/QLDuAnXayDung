using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using QLDAXayDung.Models;

namespace QLDAXayDung.Controllers
{
    public class RoleAdminController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        [Authorize(Roles = "Admin")]
        // GET: RoleAdmin
        public ActionResult Index()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            return View(roleManager.Roles);
        }

        // GET: RoleAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoleAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleAdmin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RoleAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RoleAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RoleAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoleAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
