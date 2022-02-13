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
    public class VatTuTrongDuAnController : Controller
    {
        private QLDAXayDungEntities db = new QLDAXayDungEntities();

        // GET: VatTuTrongDuAn
        public ActionResult Index()
        {
            var vatTuTrongDuAns = db.VatTuTrongDuAns.Include(v => v.DuAn).Include(v => v.VatTu);
            return View(vatTuTrongDuAns.ToList());
        }

        // GET: VatTuTrongDuAn/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VatTuTrongDuAn vatTuTrongDuAn = db.VatTuTrongDuAns.Find(id);
            if (vatTuTrongDuAn == null)
            {
                return HttpNotFound();
            }
            return View(vatTuTrongDuAn);
        }

        // GET: VatTuTrongDuAn/Create
        public ActionResult Create()
        {
            ViewBag.MaDA = new SelectList(db.DuAns, "MaDA", "TenDA");
            ViewBag.MaVT = new SelectList(db.VatTus, "MaVT", "TenVT");
            return View();
        }

        // POST: VatTuTrongDuAn/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaVT,MaDA,SoLuong")] VatTuTrongDuAn vatTuTrongDuAn)
        {
            if (ModelState.IsValid)
            {
                db.VatTuTrongDuAns.Add(vatTuTrongDuAn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDA = new SelectList(db.DuAns, "MaDA", "TenDA", vatTuTrongDuAn.MaDA);
            ViewBag.MaVT = new SelectList(db.VatTus, "MaVT", "TenVT", vatTuTrongDuAn.MaVT);
            return View(vatTuTrongDuAn);
        }

        // GET: VatTuTrongDuAn/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VatTuTrongDuAn vatTuTrongDuAn = db.VatTuTrongDuAns.Find(id);
            if (vatTuTrongDuAn == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDA = new SelectList(db.DuAns, "MaDA", "TenDA", vatTuTrongDuAn.MaDA);
            ViewBag.MaVT = new SelectList(db.VatTus, "MaVT", "TenVT", vatTuTrongDuAn.MaVT);
            return View(vatTuTrongDuAn);
        }

        // POST: VatTuTrongDuAn/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaVT,MaDA,SoLuong")] VatTuTrongDuAn vatTuTrongDuAn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vatTuTrongDuAn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDA = new SelectList(db.DuAns, "MaDA", "TenDA", vatTuTrongDuAn.MaDA);
            ViewBag.MaVT = new SelectList(db.VatTus, "MaVT", "TenVT", vatTuTrongDuAn.MaVT);
            return View(vatTuTrongDuAn);
        }

        // GET: VatTuTrongDuAn/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VatTuTrongDuAn vatTuTrongDuAn = db.VatTuTrongDuAns.Find(id);
            if (vatTuTrongDuAn == null)
            {
                return HttpNotFound();
            }
            return View(vatTuTrongDuAn);
        }

        // POST: VatTuTrongDuAn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VatTuTrongDuAn vatTuTrongDuAn = db.VatTuTrongDuAns.Find(id);
            db.VatTuTrongDuAns.Remove(vatTuTrongDuAn);
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
