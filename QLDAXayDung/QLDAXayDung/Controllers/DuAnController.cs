using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLDAXayDung.Models;

namespace QLDAXayDung.Controllers
{
    public class DuAnController : Controller
    {
        private QLDAXayDungEntities db = new QLDAXayDungEntities();

        // GET: DuAn
        public ActionResult Index()
        {
            return View(db.DuAns.ToList());
        }

        // GET: DuAn/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DuAn duAn = db.DuAns.Find(id);
            if (duAn == null)
            {
                return HttpNotFound();
            }
            return View(duAn);
        }

        // GET: DuAn/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DuAn/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDA,TenDA,DiaDiem,NgayBatDau,NgayKetThuc")] DuAn duAn)
        {
            if (ModelState.IsValid)
            {
                db.DuAns.Add(duAn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(duAn);
        }

        // GET: DuAn/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DuAn duAn = db.DuAns.Find(id);
            if (duAn == null)
            {
                return HttpNotFound();
            }
            return View(duAn);
        }

        // POST: DuAn/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDA,TenDA,DiaDiem,NgayBatDau,NgayKetThuc")] DuAn duAn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(duAn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(duAn);
        }

        // GET: DuAn/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DuAn duAn = db.DuAns.Find(id);
            if (duAn == null)
            {
                return HttpNotFound();
            }
            return View(duAn);
        }

        // POST: DuAn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DuAn duAn = db.DuAns.Find(id);
            db.DuAns.Remove(duAn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
