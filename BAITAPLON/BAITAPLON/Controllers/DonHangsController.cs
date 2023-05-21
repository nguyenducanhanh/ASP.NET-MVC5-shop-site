using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BAITAPLON.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace BAITAPLON.Controllers
{
    public class DonHangsController : Controller
    {
        private QuanLySanPhamEntities db = new QuanLySanPhamEntities();

        // GET: DonHangs
        public ActionResult Index()
        {
            return View(db.DonHangs.ToList());
        }

        // GET: DonHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        // GET: DonHangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenKH,SDT,GT,CachNhan")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                db.DonHangs.Add(donHang);
                db.SaveChanges();
                CTDonHang dh = new CTDonHang();
                dh.IDDonHang = donHang.ID;
                foreach (var item in Models.Cart.items)
                {
                    dh.IDsanpham = item._shopping_product.ID;
                    dh.SoLuong = item._shopping_quantity;
                    dh.DonGia = item._shopping_product.GiaBanMoi * dh.SoLuong;
                    db.CTDonHangs.Add(dh);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            return View(donHang);
        }

        // GET: DonHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        // POST: DonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenKH,SDT,GT,CachNhan")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donHang);
        }

        // GET: DonHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        // POST: DonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonHang donHang = db.DonHangs.Find(id);
            db.DonHangs.Remove(donHang);
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
        public ActionResult DatHang()
        {
            return View();
        }

        // POST: DonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DatHang([Bind(Include = "ID,TenKH,SDT,GT,CachNhan")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                db.DonHangs.Add(donHang);
                db.SaveChanges();
                CTDonHang dh=new CTDonHang();
                dh.IDDonHang = donHang.ID;
                DH.iddh = donHang.ID;
                DH.tt = 1;
                foreach(var item in Models.Cart.items)
                {
                    dh.IDsanpham = item._shopping_product.ID;
                    dh.SoLuong = item._shopping_quantity;
                    dh.DonGia = item._shopping_product.GiaBanMoi * dh.SoLuong;
                    ct(dh);
                }
                return RedirectToAction("ShowToCart", "GioHang");
            }

            return View(donHang);
        }
        public void ct(CTDonHang ctdon)
        {
            string connectionString = @"Data Source=MACBOOK\SQLEXPRESS;Initial Catalog=QuanLySanPham;User ID=sa;Password=12345;";
            string query = "INSERT INTO CTDonHang (IDDonHang, IDsanpham, SoLuong,DonGia) VALUES (@Value1, @Value2, @Value3, @Value4)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Value1", ctdon.IDDonHang);
                    command.Parameters.AddWithValue("@Value2", ctdon.IDsanpham);
                    command.Parameters.AddWithValue("@Value3", ctdon.SoLuong);
                    command.Parameters.AddWithValue("@Value4", ctdon.DonGia);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    
                }
            }
        }
    }
}
