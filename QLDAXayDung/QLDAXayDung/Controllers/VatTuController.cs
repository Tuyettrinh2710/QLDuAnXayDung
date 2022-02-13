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
    public class VatTuController : Controller
    {
        private QLDAXayDungEntities db = new QLDAXayDungEntities();

        // GET: VatTu
        public ActionResult Index()
        {
            var vatTus = db.VatTus.Include(v => v.NhaCungCap);
            return View(vatTus.ToList());
        }

        // GET: VatTu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VatTu vatTu = db.VatTus.Find(id);
            if (vatTu == null)
            {
                return HttpNotFound();
            }
            return View(vatTu);
        }

        // GET: VatTu/Create
        public ActionResult Create()
        {
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC");
            return View();
        }

        // POST: VatTu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaVT,TenVT,SoLuong,ĐonViTinh,MaNCC")] VatTu vatTu)
        {
            if (ModelState.IsValid)
            {
                db.VatTus.Add(vatTu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", vatTu.MaNCC);
            return View(vatTu);
        }

        // GET: VatTu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VatTu vatTu = db.VatTus.Find(id);
            if (vatTu == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", vatTu.MaNCC);
            return View(vatTu);
        }

        // POST: VatTu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaVT,TenVT,SoLuong,ĐonViTinh,MaNCC")] VatTu vatTu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vatTu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", vatTu.MaNCC);
            return View(vatTu);
        }

        // GET: VatTu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VatTu vatTu = db.VatTus.Find(id);
            if (vatTu == null)
            {
                return HttpNotFound();
            }
            return View(vatTu);
        }

        // POST: VatTu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VatTu vatTu = db.VatTus.Find(id);
            db.VatTus.Remove(vatTu);
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
