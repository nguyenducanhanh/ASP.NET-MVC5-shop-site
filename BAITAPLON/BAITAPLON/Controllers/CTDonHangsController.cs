using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BAITAPLON.Models;

namespace BAITAPLON.Controllers
{
    public class CTDonHangsController : Controller
    {
        private QuanLySanPhamEntities db = new QuanLySanPhamEntities();

        // GET: CTDonHangs
        public ActionResult Index()
        {
            var cTDonHangs = db.CTDonHangs.Include(c => c.DonHang).Include(c => c.SanPham);
            return View(cTDonHangs.ToList());
        }

        // GET: CTDonHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTDonHang cTDonHang = db.CTDonHangs.Find(id);
            if (cTDonHang == null)
            {
                return HttpNotFound();
            }
            return View(cTDonHang);
        }

        // GET: CTDonHangs/Create
        public ActionResult Create()
        {
            ViewBag.IDDonHang = new SelectList(db.DonHangs, "ID", "TenKH");
            ViewBag.IDsanpham = new SelectList(db.SanPhams, "ID", "TenSanPham");
            return View();
        }

        // POST: CTDonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDDonHang,IDsanpham,SoLuong,DonGia")] CTDonHang cTDonHang)
        {
            if (ModelState.IsValid)
            {
                db.CTDonHangs.Add(cTDonHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDDonHang = new SelectList(db.DonHangs, "ID", "TenKH", cTDonHang.IDDonHang);
            ViewBag.IDsanpham = new SelectList(db.SanPhams, "ID", "TenSanPham", cTDonHang.IDsanpham);
            return View(cTDonHang);
        }

        // GET: CTDonHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTDonHang cTDonHang = db.CTDonHangs.Find(id);
            if (cTDonHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDDonHang = new SelectList(db.DonHangs, "ID", "TenKH", cTDonHang.IDDonHang);
            ViewBag.IDsanpham = new SelectList(db.SanPhams, "ID", "TenSanPham", cTDonHang.IDsanpham);
            return View(cTDonHang);
        }

        // POST: CTDonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDDonHang,IDsanpham,SoLuong,DonGia")] CTDonHang cTDonHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTDonHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDDonHang = new SelectList(db.DonHangs, "ID", "TenKH", cTDonHang.IDDonHang);
            ViewBag.IDsanpham = new SelectList(db.SanPhams, "ID", "TenSanPham", cTDonHang.IDsanpham);
            return View(cTDonHang);
        }

        // GET: CTDonHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTDonHang cTDonHang = db.CTDonHangs.Find(id);
            if (cTDonHang == null)
            {
                return HttpNotFound();
            }
            return View(cTDonHang);
        }

        // POST: CTDonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CTDonHang cTDonHang = db.CTDonHangs.Find(id);
            db.CTDonHangs.Remove(cTDonHang);
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
