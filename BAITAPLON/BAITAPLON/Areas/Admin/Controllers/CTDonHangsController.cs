using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BAITAPLON.Areas.Admin.Data;
using BAITAPLON.Models;

namespace BAITAPLON.Areas.Admin.Controllers
{
    public class CTDonHangsController : Controller
    {
        private QuanLySanPhamEntities db = new QuanLySanPhamEntities();

        // GET: Admin/CTDonHangs
        public ActionResult Index()
        {
            string connectionString = @"Data Source=MACBOOK\SQLEXPRESS;Initial Catalog=QuanLySanPham;User ID=sa;Password=1234$;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                iddh.ct.Clear();
                string sqlQuery = "SELECT * from CTDonHang where IDDonHang=@iddh ";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@iddh", iddh.id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Lấy giá trị từ các cột dữ liệu
                        int idsp = (int)reader["IDsanpham"];
                        int slsp = (int)reader["SoLuong"];
                        Decimal dongia = (Decimal)reader["DonGia"];
                        ctdh ct = new ctdh { id = idsp, sl = slsp, gia = dongia };
                        iddh.ct.Add(ct);
                    }
                }
            }

            //var cTDonHangs = db.CTDonHangs.Include(c => c.DonHang).Include(c => c.SanPham);
            return View();
        }

        // GET: Admin/CTDonHangs/Details/5
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

        // GET: Admin/CTDonHangs/Create
        public ActionResult Create()
        {
            ViewBag.IDDonHang = new SelectList(db.DonHangs, "ID", "TenKH");
            ViewBag.IDsanpham = new SelectList(db.SanPhams, "ID", "TenSanPham");
            return View();
        }

        // POST: Admin/CTDonHangs/Create
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

        // GET: Admin/CTDonHangs/Edit/5
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

        // POST: Admin/CTDonHangs/Edit/5
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
        public ActionResult xoa(int? id)
        {
            string connectionString = @"Data Source=MACBOOK\SQLEXPRESS;Initial Catalog=QuanLySanPham;User ID=sa;Password=12345;";
            string query = "delete from CTDonHang where IDDonHang=@iddh and IDSanPham=@idsp ";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@iddh", iddh.id);
            command.Parameters.AddWithValue("@idsp", id);
            command.ExecuteNonQuery();
            connection.Close();
            return RedirectToAction("Index");
        }
        // GET: Admin/CTDonHangs/Delete/5
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

        // POST: Admin/CTDonHangs/Delete/5
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
