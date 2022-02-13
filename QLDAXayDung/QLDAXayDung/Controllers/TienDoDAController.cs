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
    public class TienDoDAController : Controller
    {
        private QLDAXayDungEntities db = new QLDAXayDungEntities();

        // GET: TienDoDA
        public ActionResult Index()
        {
            var tienDoDAs = db.TienDoDAs.Include(t => t.DuAn);
            return View(tienDoDAs.ToList());
        }

        // GET: TienDoDA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TienDoDA tienDoDA = db.TienDoDAs.Find(id);
            if (tienDoDA == null)
            {
                return HttpNotFound();
            }
            return View(tienDoDA);
        }

        // GET: TienDoDA/Create
        public ActionResult Create()
        {
            ViewBag.MaDA = new SelectList(db.DuAns, "MaDA", "TenDA");
            return View();
        }

        // POST: TienDoDA/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTD,MaDA,CongViec,NgayBatDau,NgayKetThuc")] TienDoDA tienDoDA)
        {
            if (ModelState.IsValid)
            {
                db.TienDoDAs.Add(tienDoDA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDA = new SelectList(db.DuAns, "MaDA", "TenDA", tienDoDA.MaDA);
            return View(tienDoDA);
        }

        // GET: TienDoDA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TienDoDA tienDoDA = db.TienDoDAs.Find(id);
            if (tienDoDA == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDA = new SelectList(db.DuAns, "MaDA", "TenDA", tienDoDA.MaDA);
            return View(tienDoDA);
        }

        // POST: TienDoDA/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTD,MaDA,CongViec,NgayBatDau,NgayKetThuc")] TienDoDA tienDoDA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tienDoDA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDA = new SelectList(db.DuAns, "MaDA", "TenDA", tienDoDA.MaDA);
            return View(tienDoDA);
        }

        // GET: TienDoDA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TienDoDA tienDoDA = db.TienDoDAs.Find(id);
            if (tienDoDA == null)
            {
                return HttpNotFound();
            }
            return View(tienDoDA);
        }

        // POST: TienDoDA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TienDoDA tienDoDA = db.TienDoDAs.Find(id);
            db.TienDoDAs.Remove(tienDoDA);
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
