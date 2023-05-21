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
    public class DonHangsController : Controller
    {
        private QuanLySanPhamEntities db = new QuanLySanPhamEntities();

        // GET: Admin/DonHangs
        public ActionResult Index()
        {
            return View(db.DonHangs.ToList());
        }

        // GET: Admin/DonHangs/Details/5
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
        public ActionResult ChitietDH(int id)
        {
            //return RedirectToAction("Index", "CTDonHangs", new { id = getid });
            // var ct = db.CTDonHangs.Find(id);
            iddh.id = id;
            // return View("Index", RenderAction("Index", "CTDonHangs"));
            //  return RedirectToAction("Index", "CTDonHangs");
            return RedirectToAction("Index", "CTDonHangs");
        }
        // GET: Admin/DonHangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DonHangs/Create
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
                return RedirectToAction("Index");
            }

            return View(donHang);
        }

        // GET: Admin/DonHangs/Edit/5
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

        // POST: Admin/DonHangs/Edit/5
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

        // GET: Admin/DonHangs/Delete/5
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
        public ActionResult xoa(int? id)
        {
            string connectionString = @"Data Source=MACBOOK\SQLEXPRESS;Initial Catalog=QuanLySanPham;User ID=sa;Password=1234$;";
            string query = "delete from CTDonHang where IDDonHang=@iddh";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@iddh", id);
            command.ExecuteNonQuery();
            query = "delete from DonHang where ID=@iddh";
            SqlCommand command2 = new SqlCommand(query, connection);
            command2.Parameters.AddWithValue("@iddh", id);
            command2.ExecuteNonQuery();
            connection.Close();
            return RedirectToAction("Index");
        }
        // POST: Admin/DonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //xoa(id);
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
    }
}
