using BAITAPLON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BAITAPLON.Models.Map;


namespace BAITAPLON.Areas.Admin.Controllers
{

    public class HomeAdminController : Controller
    {

        // check db 
        QuanLySanPhamEntities db = new QuanLySanPhamEntities();
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("DangNhap");
            }
            else
            {

                var map = new mapSanPham();
                return View(map.DanhSach());


            }
        }


      























        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(string user, string password)
        {
           
            var nhanVien = db.NhanViens.SingleOrDefault(m => m.Username.ToLower() == user.ToLower() && m.Password == password);
            // check code
            if (nhanVien != null)
            {
                Session["user"] = nhanVien;

                return RedirectToAction("Index");

            }
            else
            {
                TempData["error"] = "ko dung ";
                return View();
            }

        }

    }
}
